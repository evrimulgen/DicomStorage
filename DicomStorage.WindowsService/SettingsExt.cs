using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DicomStorage.WindowsService.Properties 
{
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase 
    {
        public string GetImportPath(string serverName)
        {
            var result = OptionsList.First(x => x.ServerName == serverName).ImportDir;
            if(!string.IsNullOrEmpty(result))
                result = Path.Combine(Path.GetFullPath(ImportBaseDir), result);
            return result;
        }

        public string GetStoragePath(string serverName)
        {
            return Path.Combine(Path.GetFullPath(StorageBaseDir),
                                OptionsList.First(x => x.ServerName == serverName).StorageDir);
        }

        public bool ServerExists(string serverName)
        {
            return OptionsList.All(x => x.ServerName != serverName);
        }

        public ServerOptions GetServerOptions(string serverName)
        {
            return OptionsList.FirstOrDefault(x => x.ServerName == serverName);
        }
    }
}
