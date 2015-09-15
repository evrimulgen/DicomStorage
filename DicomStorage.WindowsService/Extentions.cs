using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dicom;

namespace DicomStorage.WindowsService
{
    public static class Extentions
    {
        public static DateTime GetImageDateTime(this DicomDataset dataset)
        {
            var imageDate = DateTime.MinValue;
            var imageTime = DateTime.MinValue;

            var extracted = tryGetImageDateTime(DicomTag.ContentDate, DicomTag.ContentTime, dataset, ref imageDate, ref imageTime)
             || tryGetImageDateTime(DicomTag.SeriesDate, DicomTag.SeriesTime, dataset, ref imageDate, ref imageTime)
             || tryGetImageDateTime(DicomTag.StudyDate, DicomTag.StudyTime, dataset, ref imageDate, ref imageTime)
             || tryGetImageDateTime(DicomTag.Date, DicomTag.Time, dataset, ref imageDate, ref imageTime);


            return imageDate.Add(imageTime.TimeOfDay);
        }

        private static bool tryGetImageDateTime(DicomTag dateTag, DicomTag timeTag, DicomDataset dataset, 
                ref DateTime imageDate, ref DateTime imageTime)
        {
            var dateValue = dataset.Get<DateTime>(dateTag);
            var result = dateValue > DateTime.MinValue;
            if (result)
            {
                imageDate = dateValue;
                imageTime = dataset.Get<DateTime>(timeTag);
            }
            return result;
        }

        public static  string GetPacientName(this DicomDataset dataset, ServerOptions serverOptions)
        {
            return dataset.GetCorrectedString(serverOptions, DicomTag.PatientName);
        }

        public static string GetCorrectedString(this DicomDataset dataset, ServerOptions serverOptions, DicomTag dicomTag)
        {
            var result = dataset.Get<string>(dicomTag);
            if (serverOptions.Codepage > 0)
            {
                var dicomItem = dataset.FirstOrDefault(x => x.Tag == dicomTag);
                var bytes = ((DicomElement)dicomItem).Buffer.Data;
                result = Encoding.GetEncoding(serverOptions.Codepage).GetString(bytes);
                result = result.Replace('^', ' ');
            }
            return result;
        }

    }
}
