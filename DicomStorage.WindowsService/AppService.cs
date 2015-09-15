using System.Collections.Generic;
using System.ServiceProcess;
using Dicom.Network;

namespace DicomStorage.WindowsService
{
    public partial class AppService : ServiceBase
    {
        public static AppService Default;

        public AppService()
        {
            InitializeComponent();
            Default = this;
        }

        private DicomServer<CStoreScp> storeServer;

        public bool IsWorking { get { return storeServer != null; } }

        protected override void OnStart(string[] args)
        {
            clearServices();

            storeServer = new DicomServer<CStoreScp>(Properties.Settings.Default.Port);
            (new ImportService()).Start();
        }

        private void clearServices()
        {
            if (storeServer != null)
            {
                try
                {
                    storeServer.Dispose();
                }
                catch
                {
                }
                storeServer = null;
            }

            while (BackgroundService.Services.Count>0)
            {
                BackgroundService.Services[0].Dispose();
            }
        }

        public void Start()
        {
            OnStart(null);
        }

        protected override void OnStop()
        {
            clearServices();
        }
    }
}
