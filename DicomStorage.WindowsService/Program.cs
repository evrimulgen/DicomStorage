using System;
using System.ComponentModel;
using System.Drawing;
using System.ServiceProcess;
using System.Windows.Forms;

namespace DicomStorage.WindowsService
{
    public static class Program
    {
        private static NotifyIcon noti;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main()
        {
            var appService = new AppService();
            appService.Start();

            noti  = new NotifyIcon();
            noti.Icon = Properties.Resources.ClientToServer;
            noti.Visible = true;
            noti.Text = @"Сервер DicomStorage";
            noti.ContextMenuStrip = new ContextMenuStrip();
            noti.MouseDoubleClick += NotiOnMouseDoubleClick;
            noti.ContextMenuStrip.Opening += ContextMenuStripOnOpening;

            var settingsItems = noti.ContextMenuStrip.Items.Add(@"Настройки");
            settingsItems.Click += SettingsItemsOnClick;
            settingsItems.Font = new Font(settingsItems.Font, settingsItems.Font.Style | FontStyle.Bold);

            var startStopItem = noti.ContextMenuStrip.Items.Add(@"Остановить сервер");
            startStopItem.Click += StartStopItemOnClick;

            noti.ContextMenuStrip.Items.Add(new ToolStripSeparator());

            var exitItem = noti.ContextMenuStrip.Items.Add(@"Выйти из DicomStorage");
            exitItem.Click += OnClick;

            Application.Run();
            appService.Stop();
//#else
//            var servicesToRun = new ServiceBase[] { new AppService() };
//            ServiceBase.Run(servicesToRun);
//#endif
        }

        private static void NotiOnMouseDoubleClick(object sender, MouseEventArgs mouseEventArgs)
        {
            SettingsItemsOnClick(null, new EventArgs());
        }

        private static void StartStopItemOnClick(object sender, EventArgs eventArgs)
        {
            if(AppService.Default.IsWorking)
                AppService.Default.Stop();
            else
                AppService.Default.Start();
        }

        private static void ContextMenuStripOnOpening(object sender, CancelEventArgs cancelEventArgs)
        {
            noti.ContextMenuStrip.Items[1].Text = AppService.Default.IsWorking
                                                      ? @"Остановить сервер"
                                                      : @"Запустить сервер";
        }

        private static void SettingsItemsOnClick(object sender, EventArgs eventArgs)
        {
            (new SettingsForm()).Show();
        }

        private static void OnClick(object sender, EventArgs eventArgs)
        {
            noti.Visible = false;
            Application.Exit();
        }
    }
}
