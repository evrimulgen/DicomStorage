namespace DicomStorage.WindowsService
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ImportBaseDir = new System.Windows.Forms.TextBox();
            this.StorageBaseDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.serverNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storageDirDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importDirDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codepageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.stringBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QueueNameList = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverOptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stringBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Порт сервера:";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(99, 12);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(99, 20);
            this.Port.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Базовый каталог импорта:";
            // 
            // ImportBaseDir
            // 
            this.ImportBaseDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportBaseDir.Location = new System.Drawing.Point(16, 64);
            this.ImportBaseDir.Name = "ImportBaseDir";
            this.ImportBaseDir.Size = new System.Drawing.Size(667, 20);
            this.ImportBaseDir.TabIndex = 3;
            // 
            // StorageBaseDir
            // 
            this.StorageBaseDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StorageBaseDir.Location = new System.Drawing.Point(16, 103);
            this.StorageBaseDir.Name = "StorageBaseDir";
            this.StorageBaseDir.Size = new System.Drawing.Size(667, 20);
            this.StorageBaseDir.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Базовый каталог хранилища:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serverNameDataGridViewTextBoxColumn,
            this.storageDirDataGridViewTextBoxColumn,
            this.importDirDataGridViewTextBoxColumn,
            this.codepageDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.serverOptionsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(16, 143);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(667, 160);
            this.dataGridView1.TabIndex = 6;
            // 
            // serverNameDataGridViewTextBoxColumn
            // 
            this.serverNameDataGridViewTextBoxColumn.DataPropertyName = "ServerName";
            this.serverNameDataGridViewTextBoxColumn.HeaderText = "Имя сервера DICOM";
            this.serverNameDataGridViewTextBoxColumn.Name = "serverNameDataGridViewTextBoxColumn";
            // 
            // storageDirDataGridViewTextBoxColumn
            // 
            this.storageDirDataGridViewTextBoxColumn.DataPropertyName = "StorageDir";
            this.storageDirDataGridViewTextBoxColumn.HeaderText = "Подкаталог хранилища";
            this.storageDirDataGridViewTextBoxColumn.Name = "storageDirDataGridViewTextBoxColumn";
            this.storageDirDataGridViewTextBoxColumn.Width = 200;
            // 
            // importDirDataGridViewTextBoxColumn
            // 
            this.importDirDataGridViewTextBoxColumn.DataPropertyName = "ImportDir";
            this.importDirDataGridViewTextBoxColumn.HeaderText = "Подкаталог импорта";
            this.importDirDataGridViewTextBoxColumn.Name = "importDirDataGridViewTextBoxColumn";
            this.importDirDataGridViewTextBoxColumn.Width = 200;
            // 
            // codepageDataGridViewTextBoxColumn
            // 
            this.codepageDataGridViewTextBoxColumn.DataPropertyName = "Codepage";
            this.codepageDataGridViewTextBoxColumn.HeaderText = "Кодовая таблица";
            this.codepageDataGridViewTextBoxColumn.Name = "codepageDataGridViewTextBoxColumn";
            // 
            // serverOptionsBindingSource
            // 
            this.serverOptionsBindingSource.DataSource = typeof(DicomStorage.WindowsService.ServerOptions);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(608, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(488, 429);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Сохранить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // stringBindingSource
            // 
            this.stringBindingSource.DataSource = typeof(string);
            // 
            // QueueNameList
            // 
            this.QueueNameList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QueueNameList.Location = new System.Drawing.Point(16, 322);
            this.QueueNameList.Multiline = true;
            this.QueueNameList.Name = "QueueNameList";
            this.QueueNameList.Size = new System.Drawing.Size(667, 91);
            this.QueueNameList.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Хранилища:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Системные очереди:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 464);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.QueueNameList);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.StorageBaseDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ImportBaseDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.label1);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки DicomStorage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverOptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stringBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ImportBaseDir;
        private System.Windows.Forms.TextBox StorageBaseDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource serverOptionsBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource stringBindingSource;
        private System.Windows.Forms.TextBox QueueNameList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn storageDirDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importDirDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codepageDataGridViewTextBoxColumn;
    }
}