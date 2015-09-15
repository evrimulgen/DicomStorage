using System.IO;
using System.Linq;
using System.Threading;
using Dicom;

namespace DicomStorage.WindowsService
{
    public class ImportService: BackgroundService
    {
        protected override void workAction()
        {
            var scanIndex = 0;
            while (!CancellationPending)
            {
                Thread.Sleep(100);
                if (scanIndex > 0 && scanIndex % 100 == 0)
                {
                    scanIndex = 0;

                    foreach (var serverOptions in Properties.Settings.Default.OptionsList.TakeWhile(x => !CancellationPending))
                    {
                        var importDir = Properties.Settings.Default.GetImportPath(serverOptions.ServerName);

                        if (string.IsNullOrEmpty(importDir)) continue;

                        try
                        {
                            Directory.CreateDirectory(importDir);
                        }
                        catch
                        {
                        }

                        if (Directory.Exists(importDir))
                        {
                            foreach (var fileName in Directory.GetFiles(importDir, "*.dcm").TakeWhile(x => !CancellationPending))
                            {
                                try
                                {
                                    using (var excluFile = File.Open(fileName, FileMode.Open, FileAccess.Read))
                                    {
                                        var dicomFile = DicomFile.Open(excluFile);
                                        CStoreScp.SaveDicomToFile(dicomFile.Dataset, Properties.Settings.Default.GetStoragePath(serverOptions.ServerName), dicomFile, serverOptions);
                                        excluFile.Close();
                                        File.Delete(fileName);
                                    }
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                }
                else
                    scanIndex++;
            }
        }

    }
}
