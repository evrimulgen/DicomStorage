using System;
using System.Linq;
using System.Windows.Forms;
using DicomStorage.WindowsService.Properties;

namespace DicomStorage.WindowsService
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            Port.Text = Settings.Default.Port.ToString();
            ImportBaseDir.Text = Settings.Default.ImportBaseDir;
            StorageBaseDir.Text = Settings.Default.StorageBaseDir;
            var list = new ServerOptionsList();
            list.AddRange(Settings.Default.OptionsList);
            serverOptionsBindingSource.DataSource = list;
            QueueNameList.Text = string.Join("\r\n", Settings.Default.QueueNameList.Cast<string>());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }

        private void SaveSettings()
        {
            AppService.Default.Stop();

            Settings.Default.Port = int.Parse(Port.Text);
            Settings.Default.ImportBaseDir = ImportBaseDir.Text;
            Settings.Default.StorageBaseDir = StorageBaseDir.Text;
            var list = (ServerOptionsList) serverOptionsBindingSource.DataSource;
            Settings.Default.OptionsList.Clear();
            Settings.Default.OptionsList.AddRange(list);
            var queues = QueueNameList.Lines.Where(x => x.Trim() != "");
            Settings.Default.QueueNameList.Clear();
            Settings.Default.QueueNameList.AddRange(queues.ToArray());
            Settings.Default.Save();

            AppService.Default.Start();
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
