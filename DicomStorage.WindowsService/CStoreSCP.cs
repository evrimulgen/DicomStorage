using System;
using System.IO;
using System.Linq;
using System.Text;
using Dicom;
using Dicom.Log;
using Dicom.Network;
using DicomStorage.WindowsService.Properties;

namespace DicomStorage.WindowsService
{
    
    class CStoreScp : DicomService, IDicomServiceProvider, IDicomCStoreProvider, IDicomCEchoProvider
    {
        private static readonly DicomTransferSyntax[] AcceptedTransferSyntaxes = 
            new[]
                {
                    DicomTransferSyntax.ExplicitVRLittleEndian,
                    DicomTransferSyntax.ExplicitVRBigEndian,
                    DicomTransferSyntax.ImplicitVRLittleEndian
                };

        private static readonly DicomTransferSyntax[] AcceptedImageTransferSyntaxes = 
            new[] {
                // Lossless
                DicomTransferSyntax.JPEGLSLossless,
                DicomTransferSyntax.JPEG2000Lossless,
                DicomTransferSyntax.JPEGProcess14SV1,
                DicomTransferSyntax.JPEGProcess14,
                DicomTransferSyntax.RLELossless,
                // Lossy
                DicomTransferSyntax.JPEGLSNearLossless,
                DicomTransferSyntax.JPEG2000Lossy,
                DicomTransferSyntax.JPEGProcess1,
                DicomTransferSyntax.JPEGProcess2_4,
                // Uncompressed
                DicomTransferSyntax.ExplicitVRLittleEndian,
                DicomTransferSyntax.ExplicitVRBigEndian,
                DicomTransferSyntax.ImplicitVRLittleEndian
            };

        public CStoreScp(Stream stream, Logger log)
            : base(stream, log)
        {
        }

        public void OnReceiveAssociationRequest(DicomAssociation association)
        {
            if (Settings.Default.OptionsList.All(x => x.ServerName != association.CalledAE))
            {
                SendAssociationReject(DicomRejectResult.Permanent, DicomRejectSource.ServiceUser,
                    DicomRejectReason.CalledAENotRecognized);
                return;
            }

            foreach (var pc in association.PresentationContexts)
            {
                if (pc.AbstractSyntax == DicomUID.Verification)
                    pc.AcceptTransferSyntaxes(AcceptedTransferSyntaxes);
                else if (pc.AbstractSyntax.StorageCategory != DicomStorageCategory.None)
                    pc.AcceptTransferSyntaxes(AcceptedImageTransferSyntaxes);
            }

            SendAssociationAccept(association);
        }

        public void OnReceiveAssociationReleaseRequest()
        {
            SendAssociationReleaseResponse();
        }

        public void OnReceiveAbort(DicomAbortSource source, DicomAbortReason reason)
        {
        }

        public void OnConnectionClosed(int errorCode)
        {
        }

        public DicomCStoreResponse OnCStoreRequest(DicomCStoreRequest request)
        {
            var path = Settings.Default.GetStoragePath(Association.CalledAE);
            SaveDicomToFile(request.Dataset, path, request.File, Settings.Default.GetServerOptions(Association.CalledAE));
            return new DicomCStoreResponse(request, DicomStatus.Success);
        }

        public static void SaveDicomToFile(DicomDataset dataset, string storagePath, 
            DicomFile dicomFile, ServerOptions serverOptions)
        {
            var pacientName = dataset.GetPacientName(serverOptions);
            var pacientDate = dataset.Get<DateTime>(DicomTag.PatientBirthDate);
            var imageDateTime = dataset.GetImageDateTime();

            var path = Path.GetFullPath(storagePath);
            path = Path.Combine(path, imageDateTime.Year.ToString("D4"));
            path = Path.Combine(path, imageDateTime.Month.ToString("D2"));
            path = Path.Combine(path, imageDateTime.ToShortDateString());

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileName = pacientName + " " + pacientDate.ToShortDateString() + " " + imageDateTime.ToLongTimeString() + ".dcm";
            fileName = Path.GetInvalidFileNameChars().Aggregate(fileName, (current, invalidChar) => current.Replace(invalidChar, '_'));
            fileName = Path.Combine(path, fileName);

            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                dicomFile.Save(fileStream);
                fileStream.Flush();
            }

            var item = new QueueItem { FileName = fileName, Options = serverOptions };


            lock (BackgroundService.Services)
            {
                foreach (var queueService in BackgroundService.Services.OfType<QueueService>())
                    queueService.Enqueue(item);
            }

            try
            {
                if(Settings.Default.QueueNameList.Count > 0)
                {
                    foreach (var queueName in Settings.Default.QueueNameList)
                    {
                        if (!string.IsNullOrEmpty(queueName))
                        {
                            var name = queueName;
                            if (!name.Contains(@"\"))
                                name = @".\Private$\" + name;

                            System.Messaging.MessageQueue messageQueue;
                            if (System.Messaging.MessageQueue.Exists(name))
                                messageQueue = new System.Messaging.MessageQueue(name);
                            else
                                messageQueue = System.Messaging.MessageQueue.Create(name);

                            try
                            {
                                messageQueue.Send(item);
                            }
                            finally
                            {
                                messageQueue.Dispose();
                            }
                        }
                    }
                }
            }
            catch
            {
            }

        }

        public void OnCStoreRequestException(string tempFileName, Exception e)
        {
            // let library handle logging and error response
        }

        public DicomCEchoResponse OnCEchoRequest(DicomCEchoRequest request)
        {
            return new DicomCEchoResponse(request, DicomStatus.Success);
        }
    }
}