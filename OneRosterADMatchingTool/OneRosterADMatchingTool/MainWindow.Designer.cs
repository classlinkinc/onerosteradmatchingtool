namespace OneRosterMatchingTool
{
    partial class OneRosterDebugTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OneRosterDebugTool));
            this.startBtn = new System.Windows.Forms.Button();
            this.oneUsername = new System.Windows.Forms.Label();
            this.oneKey = new System.Windows.Forms.TextBox();
            this.oneSecret = new System.Windows.Forms.TextBox();
            this.oneRosterPassword = new System.Windows.Forms.Label();
            this.statusProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.totalUsers_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.storedUsers_label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.missingLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.oneUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.testOR = new System.Windows.Forms.Button();
            this.adUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.testAD = new System.Windows.Forms.Button();
            this.createCSV = new System.Windows.Forms.Button();
            this.adPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.adDomain = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.adTestWorker = new System.ComponentModel.BackgroundWorker();
            this.orTestWorker = new System.ComponentModel.BackgroundWorker();
            this.viewTable = new System.Windows.Forms.Button();
            this.saveSettings = new System.Windows.Forms.Button();
            this.foundUsers = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(515, 200);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(74, 34);
            this.startBtn.TabIndex = 9;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // oneUsername
            // 
            this.oneUsername.AutoSize = true;
            this.oneUsername.Location = new System.Drawing.Point(12, 35);
            this.oneUsername.Name = "oneUsername";
            this.oneUsername.Size = new System.Drawing.Size(82, 13);
            this.oneUsername.TabIndex = 1;
            this.oneUsername.Text = "OneRoster Key:";
            // 
            // oneKey
            // 
            this.oneKey.Location = new System.Drawing.Point(119, 32);
            this.oneKey.Name = "oneKey";
            this.oneKey.Size = new System.Drawing.Size(470, 20);
            this.oneKey.TabIndex = 2;
            // 
            // oneSecret
            // 
            this.oneSecret.Location = new System.Drawing.Point(119, 58);
            this.oneSecret.Name = "oneSecret";
            this.oneSecret.Size = new System.Drawing.Size(470, 20);
            this.oneSecret.TabIndex = 3;
            // 
            // oneRosterPassword
            // 
            this.oneRosterPassword.AutoSize = true;
            this.oneRosterPassword.Location = new System.Drawing.Point(12, 61);
            this.oneRosterPassword.Name = "oneRosterPassword";
            this.oneRosterPassword.Size = new System.Drawing.Size(95, 13);
            this.oneRosterPassword.TabIndex = 3;
            this.oneRosterPassword.Text = "OneRoster Secret:";
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.Location = new System.Drawing.Point(15, 171);
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.Size = new System.Drawing.Size(574, 23);
            this.statusProgressBar.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Status: ";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(55, 155);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(43, 13);
            this.statusLabel.TabIndex = 8;
            this.statusLabel.Text = "Status: ";
            // 
            // totalUsers_label
            // 
            this.totalUsers_label.AutoSize = true;
            this.totalUsers_label.Location = new System.Drawing.Point(91, 197);
            this.totalUsers_label.Name = "totalUsers_label";
            this.totalUsers_label.Size = new System.Drawing.Size(0, 13);
            this.totalUsers_label.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total Users:";
            // 
            // storedUsers_label
            // 
            this.storedUsers_label.AutoSize = true;
            this.storedUsers_label.Location = new System.Drawing.Point(91, 211);
            this.storedUsers_label.Name = "storedUsers_label";
            this.storedUsers_label.Size = new System.Drawing.Size(0, 13);
            this.storedUsers_label.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Stored Users:";
            // 
            // missingLabel
            // 
            this.missingLabel.AutoSize = true;
            this.missingLabel.Location = new System.Drawing.Point(268, 200);
            this.missingLabel.Name = "missingLabel";
            this.missingLabel.Size = new System.Drawing.Size(0, 13);
            this.missingLabel.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Missing Users:";
            // 
            // oneUrl
            // 
            this.oneUrl.Location = new System.Drawing.Point(119, 6);
            this.oneUrl.Name = "oneUrl";
            this.oneUrl.Size = new System.Drawing.Size(470, 20);
            this.oneUrl.TabIndex = 1;
            this.oneUrl.Enter += new System.EventHandler(this.oneUrl_Enter);
            this.oneUrl.Leave += new System.EventHandler(this.oneUrl_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "OneRoster URL:";
            // 
            // testOR
            // 
            this.testOR.Location = new System.Drawing.Point(603, 9);
            this.testOR.Name = "testOR";
            this.testOR.Size = new System.Drawing.Size(74, 69);
            this.testOR.TabIndex = 4;
            this.testOR.Text = "Test OneRoster Connection";
            this.testOR.UseVisualStyleBackColor = true;
            this.testOR.Click += new System.EventHandler(this.testOR_Click);
            // 
            // adUser
            // 
            this.adUser.Location = new System.Drawing.Point(119, 84);
            this.adUser.Name = "adUser";
            this.adUser.Size = new System.Drawing.Size(470, 20);
            this.adUser.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "AD Username:";
            // 
            // testAD
            // 
            this.testAD.Location = new System.Drawing.Point(603, 84);
            this.testAD.Name = "testAD";
            this.testAD.Size = new System.Drawing.Size(74, 71);
            this.testAD.TabIndex = 8;
            this.testAD.Text = "Test AD Connection";
            this.testAD.UseVisualStyleBackColor = true;
            this.testAD.Click += new System.EventHandler(this.testAD_Click);
            // 
            // createCSV
            // 
            this.createCSV.Location = new System.Drawing.Point(601, 161);
            this.createCSV.Name = "createCSV";
            this.createCSV.Size = new System.Drawing.Size(74, 34);
            this.createCSV.TabIndex = 11;
            this.createCSV.Text = "Export to CSV";
            this.createCSV.UseVisualStyleBackColor = true;
            this.createCSV.Click += new System.EventHandler(this.createCSV_Click);
            // 
            // adPassword
            // 
            this.adPassword.Location = new System.Drawing.Point(119, 110);
            this.adPassword.Name = "adPassword";
            this.adPassword.PasswordChar = '•';
            this.adPassword.Size = new System.Drawing.Size(470, 20);
            this.adPassword.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "AD Password:";
            // 
            // adDomain
            // 
            this.adDomain.Location = new System.Drawing.Point(119, 135);
            this.adDomain.Name = "adDomain";
            this.adDomain.Size = new System.Drawing.Size(470, 20);
            this.adDomain.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "AD Domain:";
            // 
            // viewTable
            // 
            this.viewTable.Location = new System.Drawing.Point(601, 200);
            this.viewTable.Name = "viewTable";
            this.viewTable.Size = new System.Drawing.Size(74, 34);
            this.viewTable.TabIndex = 10;
            this.viewTable.Text = "View Table";
            this.viewTable.UseVisualStyleBackColor = true;
            this.viewTable.Click += new System.EventHandler(this.viewTable_Click);
            // 
            // saveSettings
            // 
            this.saveSettings.Location = new System.Drawing.Point(435, 200);
            this.saveSettings.Name = "saveSettings";
            this.saveSettings.Size = new System.Drawing.Size(74, 34);
            this.saveSettings.TabIndex = 27;
            this.saveSettings.Text = "Save Settings";
            this.saveSettings.UseVisualStyleBackColor = true;
            this.saveSettings.Click += new System.EventHandler(this.saveSettings_Click);
            // 
            // foundUsers
            // 
            this.foundUsers.AutoSize = true;
            this.foundUsers.Location = new System.Drawing.Point(268, 213);
            this.foundUsers.Name = "foundUsers";
            this.foundUsers.Size = new System.Drawing.Size(0, 13);
            this.foundUsers.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(191, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Found Users:";
            // 
            // OneRosterDebugTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 245);
            this.Controls.Add(this.foundUsers);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.saveSettings);
            this.Controls.Add(this.viewTable);
            this.Controls.Add(this.adDomain);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.adPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.createCSV);
            this.Controls.Add(this.testAD);
            this.Controls.Add(this.adUser);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.testOR);
            this.Controls.Add(this.oneUrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.missingLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.storedUsers_label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.totalUsers_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusProgressBar);
            this.Controls.Add(this.oneSecret);
            this.Controls.Add(this.oneRosterPassword);
            this.Controls.Add(this.oneKey);
            this.Controls.Add(this.oneUsername);
            this.Controls.Add(this.startBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OneRosterDebugTool";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClassLink OneRoster Matching Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Label oneUsername;
        private System.Windows.Forms.TextBox oneKey;
        private System.Windows.Forms.TextBox oneSecret;
        private System.Windows.Forms.Label oneRosterPassword;
        private System.Windows.Forms.ProgressBar statusProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label totalUsers_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label storedUsers_label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label missingLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox oneUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button testOR;
        private System.Windows.Forms.TextBox adUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button testAD;
        private System.Windows.Forms.Button createCSV;
        private System.Windows.Forms.TextBox adPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox adDomain;
        private System.Windows.Forms.Label label8;
        private System.ComponentModel.BackgroundWorker adTestWorker;
        private System.ComponentModel.BackgroundWorker orTestWorker;
        private System.Windows.Forms.Button viewTable;
        private System.Windows.Forms.Button saveSettings;
        private System.Windows.Forms.Label foundUsers;
        private System.Windows.Forms.Label label10;
    }
}

