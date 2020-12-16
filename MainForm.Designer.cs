namespace AutoBackup
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sourceFoldersListBox = new System.Windows.Forms.ListBox();
            this.destinationFoldersListBox = new System.Windows.Forms.ListBox();
            this.addSourceFolderButton = new System.Windows.Forms.Button();
            this.removeSourceFolderButton = new System.Windows.Forms.Button();
            this.removeDestinationFolderButton = new System.Windows.Forms.Button();
            this.addDestinationFolderButton = new System.Windows.Forms.Button();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.addFolderPopup = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.selectFolderButton = new System.Windows.Forms.Button();
            this.selectFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.onOffToggleButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.maxBackupsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.timeUnitComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backupTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.destinationDirectoriesLabel = new System.Windows.Forms.Label();
            this.sourceDirectoriesLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.addFolderPopup.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxBackupsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backupTimeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // sourceFoldersListBox
            // 
            this.sourceFoldersListBox.FormattingEnabled = true;
            this.sourceFoldersListBox.Location = new System.Drawing.Point(12, 23);
            this.sourceFoldersListBox.Name = "sourceFoldersListBox";
            this.sourceFoldersListBox.Size = new System.Drawing.Size(263, 173);
            this.sourceFoldersListBox.TabIndex = 0;
            this.sourceFoldersListBox.SelectedIndexChanged += new System.EventHandler(this.SourceFoldersListBox_SelectedIndexChanged);
            // 
            // destinationFoldersListBox
            // 
            this.destinationFoldersListBox.FormattingEnabled = true;
            this.destinationFoldersListBox.Location = new System.Drawing.Point(480, 23);
            this.destinationFoldersListBox.Name = "destinationFoldersListBox";
            this.destinationFoldersListBox.Size = new System.Drawing.Size(263, 173);
            this.destinationFoldersListBox.TabIndex = 1;
            // 
            // addSourceFolderButton
            // 
            this.addSourceFolderButton.Location = new System.Drawing.Point(12, 202);
            this.addSourceFolderButton.Name = "addSourceFolderButton";
            this.addSourceFolderButton.Size = new System.Drawing.Size(108, 23);
            this.addSourceFolderButton.TabIndex = 2;
            this.addSourceFolderButton.Text = "Add Folder";
            this.addSourceFolderButton.UseVisualStyleBackColor = true;
            this.addSourceFolderButton.Click += new System.EventHandler(this.AddSourceFolderButton_Click);
            // 
            // removeSourceFolderButton
            // 
            this.removeSourceFolderButton.Location = new System.Drawing.Point(167, 202);
            this.removeSourceFolderButton.Name = "removeSourceFolderButton";
            this.removeSourceFolderButton.Size = new System.Drawing.Size(108, 23);
            this.removeSourceFolderButton.TabIndex = 3;
            this.removeSourceFolderButton.Text = "Remove Folder";
            this.removeSourceFolderButton.UseVisualStyleBackColor = true;
            this.removeSourceFolderButton.Click += new System.EventHandler(this.RemoveSourceFolderButton_Click);
            // 
            // removeDestinationFolderButton
            // 
            this.removeDestinationFolderButton.Location = new System.Drawing.Point(635, 201);
            this.removeDestinationFolderButton.Name = "removeDestinationFolderButton";
            this.removeDestinationFolderButton.Size = new System.Drawing.Size(108, 23);
            this.removeDestinationFolderButton.TabIndex = 5;
            this.removeDestinationFolderButton.Text = "Remove Folder";
            this.removeDestinationFolderButton.UseVisualStyleBackColor = true;
            this.removeDestinationFolderButton.Click += new System.EventHandler(this.RemoveDestinationFolderButton_Click);
            // 
            // addDestinationFolderButton
            // 
            this.addDestinationFolderButton.Location = new System.Drawing.Point(480, 202);
            this.addDestinationFolderButton.Name = "addDestinationFolderButton";
            this.addDestinationFolderButton.Size = new System.Drawing.Size(108, 23);
            this.addDestinationFolderButton.TabIndex = 4;
            this.addDestinationFolderButton.Text = "Add Folder";
            this.addDestinationFolderButton.UseVisualStyleBackColor = true;
            this.addDestinationFolderButton.Click += new System.EventHandler(this.AddDestinationFolderButton_Click);
            // 
            // MainTimer
            // 
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // addFolderPopup
            // 
            this.addFolderPopup.BackColor = System.Drawing.SystemColors.ControlDark;
            this.addFolderPopup.Controls.Add(this.label1);
            this.addFolderPopup.Controls.Add(this.selectFolderButton);
            this.addFolderPopup.Controls.Add(this.selectFolderPathTextBox);
            this.addFolderPopup.Controls.Add(this.cancelButton);
            this.addFolderPopup.Controls.Add(this.okButton);
            this.addFolderPopup.Location = new System.Drawing.Point(312, 321);
            this.addFolderPopup.Name = "addFolderPopup";
            this.addFolderPopup.Size = new System.Drawing.Size(276, 161);
            this.addFolderPopup.TabIndex = 6;
            this.addFolderPopup.Visible = false;
            this.addFolderPopup.VisibleChanged += new System.EventHandler(this.AddFolderPopup_VisibleChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Folder:";
            // 
            // selectFolderButton
            // 
            this.selectFolderButton.Location = new System.Drawing.Point(246, 70);
            this.selectFolderButton.Name = "selectFolderButton";
            this.selectFolderButton.Size = new System.Drawing.Size(27, 20);
            this.selectFolderButton.TabIndex = 3;
            this.selectFolderButton.Text = "...";
            this.selectFolderButton.UseVisualStyleBackColor = true;
            this.selectFolderButton.Click += new System.EventHandler(this.SelectFolderButton_Click);
            // 
            // selectFolderPathTextBox
            // 
            this.selectFolderPathTextBox.Location = new System.Drawing.Point(4, 70);
            this.selectFolderPathTextBox.Multiline = true;
            this.selectFolderPathTextBox.Name = "selectFolderPathTextBox";
            this.selectFolderPathTextBox.Size = new System.Drawing.Size(239, 20);
            this.selectFolderPathTextBox.TabIndex = 2;
            this.selectFolderPathTextBox.TextChanged += new System.EventHandler(this.SelectFolderPathTextBox_TextChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(198, 135);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "CANCEL";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(3, 135);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // onOffToggleButton
            // 
            this.onOffToggleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.onOffToggleButton.BackColor = System.Drawing.Color.Red;
            this.onOffToggleButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("onOffToggleButton.BackgroundImage")));
            this.onOffToggleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.onOffToggleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.onOffToggleButton.Location = new System.Drawing.Point(12, 459);
            this.onOffToggleButton.Name = "onOffToggleButton";
            this.onOffToggleButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.onOffToggleButton.Size = new System.Drawing.Size(70, 23);
            this.onOffToggleButton.TabIndex = 7;
            this.onOffToggleButton.UseVisualStyleBackColor = false;
            this.onOffToggleButton.Click += new System.EventHandler(this.OnOffToggleButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Controls.Add(this.addFolderPopup);
            this.mainPanel.Controls.Add(this.optionsPanel);
            this.mainPanel.Controls.Add(this.destinationDirectoriesLabel);
            this.mainPanel.Controls.Add(this.sourceDirectoriesLabel);
            this.mainPanel.Controls.Add(this.sourceFoldersListBox);
            this.mainPanel.Controls.Add(this.addSourceFolderButton);
            this.mainPanel.Controls.Add(this.removeSourceFolderButton);
            this.mainPanel.Controls.Add(this.removeDestinationFolderButton);
            this.mainPanel.Controls.Add(this.destinationFoldersListBox);
            this.mainPanel.Controls.Add(this.addDestinationFolderButton);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(774, 440);
            this.mainPanel.TabIndex = 8;
            // 
            // optionsPanel
            // 
            this.optionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.optionsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.optionsPanel.Controls.Add(this.maxBackupsNumericUpDown);
            this.optionsPanel.Controls.Add(this.label3);
            this.optionsPanel.Controls.Add(this.timeUnitComboBox);
            this.optionsPanel.Controls.Add(this.label2);
            this.optionsPanel.Controls.Add(this.backupTimeNumericUpDown);
            this.optionsPanel.Location = new System.Drawing.Point(0, 250);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(256, 100);
            this.optionsPanel.TabIndex = 12;
            // 
            // maxBackupsNumericUpDown
            // 
            this.maxBackupsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.maxBackupsNumericUpDown.Location = new System.Drawing.Point(93, 69);
            this.maxBackupsNumericUpDown.Name = "maxBackupsNumericUpDown";
            this.maxBackupsNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.maxBackupsNumericUpDown.TabIndex = 13;
            this.maxBackupsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxBackupsNumericUpDown.ValueChanged += new System.EventHandler(this.MaxBackupsNumericUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Max Backups:";
            // 
            // timeUnitComboBox
            // 
            this.timeUnitComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timeUnitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeUnitComboBox.Items.AddRange(new object[] {
            "seconds",
            "minutes",
            "hours",
            "days",
            "weeks"});
            this.timeUnitComboBox.Location = new System.Drawing.Point(146, 38);
            this.timeUnitComboBox.Name = "timeUnitComboBox";
            this.timeUnitComboBox.Size = new System.Drawing.Size(94, 21);
            this.timeUnitComboBox.TabIndex = 11;
            this.timeUnitComboBox.SelectedIndexChanged += new System.EventHandler(this.TimeUnitComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Backup every:";
            // 
            // backupTimeNumericUpDown
            // 
            this.backupTimeNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backupTimeNumericUpDown.Location = new System.Drawing.Point(93, 38);
            this.backupTimeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.backupTimeNumericUpDown.Name = "backupTimeNumericUpDown";
            this.backupTimeNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.backupTimeNumericUpDown.TabIndex = 10;
            this.backupTimeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.backupTimeNumericUpDown.ValueChanged += new System.EventHandler(this.BackupTimeNumericUpDown_ValueChanged);
            // 
            // destinationDirectoriesLabel
            // 
            this.destinationDirectoriesLabel.AutoSize = true;
            this.destinationDirectoriesLabel.Location = new System.Drawing.Point(560, 9);
            this.destinationDirectoriesLabel.Name = "destinationDirectoriesLabel";
            this.destinationDirectoriesLabel.Size = new System.Drawing.Size(113, 13);
            this.destinationDirectoriesLabel.TabIndex = 7;
            this.destinationDirectoriesLabel.Text = "Destination Directories";
            // 
            // sourceDirectoriesLabel
            // 
            this.sourceDirectoriesLabel.AutoSize = true;
            this.sourceDirectoriesLabel.Location = new System.Drawing.Point(96, 9);
            this.sourceDirectoriesLabel.Name = "sourceDirectoriesLabel";
            this.sourceDirectoriesLabel.Size = new System.Drawing.Size(94, 13);
            this.sourceDirectoriesLabel.TabIndex = 6;
            this.sourceDirectoriesLabel.Text = "Source Directories";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(177, 456);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(73, 13);
            this.statusLabel.TabIndex = 9;
            this.statusLabel.Text = "statusLabel    ";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 494);
            this.Controls.Add(this.onOffToggleButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 395);
            this.Name = "MainForm";
            this.Text = "Auto Backup";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.addFolderPopup.ResumeLayout(false);
            this.addFolderPopup.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxBackupsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backupTimeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox sourceFoldersListBox;
        private System.Windows.Forms.ListBox destinationFoldersListBox;
        private System.Windows.Forms.Button addSourceFolderButton;
        private System.Windows.Forms.Button removeSourceFolderButton;
        private System.Windows.Forms.Button removeDestinationFolderButton;
        private System.Windows.Forms.Button addDestinationFolderButton;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.Panel addFolderPopup;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button selectFolderButton;
        private System.Windows.Forms.TextBox selectFolderPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button onOffToggleButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label destinationDirectoriesLabel;
        private System.Windows.Forms.Label sourceDirectoriesLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox timeUnitComboBox;
        private System.Windows.Forms.NumericUpDown backupTimeNumericUpDown;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.NumericUpDown maxBackupsNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

