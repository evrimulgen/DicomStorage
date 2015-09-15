using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DicomStorage.WindowsService
{
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class ServerOptions
    {
        public string ServerName { get; set; }
        public string StorageDir { get; set; }
        public string ImportDir { get; set; }
        public string ActionName { get; set; }
        public int Codepage { get; set; }

        public string ApplyCodepage(string source)
        {
            var result = source;
            if (Codepage > 0)
            {
                var buffer = Encoding.Default.GetBytes(result);
                result = Encoding.GetEncoding(Codepage).GetString(buffer);
            }
            return result;         
        }
    }

    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class ServerOptionsList: List<ServerOptions>
    {
        
    }
}
