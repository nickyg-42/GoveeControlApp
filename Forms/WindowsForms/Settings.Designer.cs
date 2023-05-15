namespace GoveeControl.Forms.WindowsForms
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            panel2 = new Panel();
            LocationLabel = new Label();
            BackBtn = new Button();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            ApiKeyTextBox = new TextBox();
            SaveApiKeyBtn = new Button();
            StatusLabel = new Label();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gray;
            panel2.Location = new Point(336, 36);
            panel2.Name = "panel2";
            panel2.Size = new Size(1, 26);
            panel2.TabIndex = 11;
            // 
            // LocationLabel
            // 
            LocationLabel.AutoSize = true;
            LocationLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LocationLabel.ForeColor = SystemColors.AppWorkspace;
            LocationLabel.Location = new Point(355, 36);
            LocationLabel.Name = "LocationLabel";
            LocationLabel.Size = new Size(66, 21);
            LocationLabel.TabIndex = 10;
            LocationLabel.Text = "Settings";
            // 
            // BackBtn
            // 
            BackBtn.BackColor = Color.Transparent;
            BackBtn.BackgroundImage = (Image)resources.GetObject("BackBtn.BackgroundImage");
            BackBtn.BackgroundImageLayout = ImageLayout.Zoom;
            BackBtn.FlatAppearance.BorderSize = 0;
            BackBtn.FlatStyle = FlatStyle.Flat;
            BackBtn.ForeColor = SystemColors.ActiveCaption;
            BackBtn.Location = new Point(867, 27);
            BackBtn.Name = "BackBtn";
            BackBtn.Size = new Size(39, 38);
            BackBtn.TabIndex = 9;
            BackBtn.UseVisualStyleBackColor = false;
            BackBtn.Click += BackBtn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 64, 64);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(22, 75);
            panel1.Name = "panel1";
            panel1.Size = new Size(884, 1);
            panel1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.AppWorkspace;
            label1.Location = new Point(22, 21);
            label1.Name = "label1";
            label1.Size = new Size(299, 47);
            label1.TabIndex = 7;
            label1.Text = "Govee Controller";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.AppWorkspace;
            label2.Location = new Point(22, 103);
            label2.Name = "label2";
            label2.Size = new Size(146, 25);
            label2.TabIndex = 12;
            label2.Text = "Govee API Key:";
            // 
            // ApiKeyTextBox
            // 
            ApiKeyTextBox.BackColor = SystemColors.AppWorkspace;
            ApiKeyTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ApiKeyTextBox.Location = new Point(174, 104);
            ApiKeyTextBox.Name = "ApiKeyTextBox";
            ApiKeyTextBox.Size = new Size(306, 29);
            ApiKeyTextBox.TabIndex = 15;
            // 
            // SaveApiKeyBtn
            // 
            SaveApiKeyBtn.BackgroundImage = (Image)resources.GetObject("SaveApiKeyBtn.BackgroundImage");
            SaveApiKeyBtn.BackgroundImageLayout = ImageLayout.Zoom;
            SaveApiKeyBtn.FlatAppearance.BorderSize = 0;
            SaveApiKeyBtn.FlatStyle = FlatStyle.Flat;
            SaveApiKeyBtn.Location = new Point(495, 105);
            SaveApiKeyBtn.Name = "SaveApiKeyBtn";
            SaveApiKeyBtn.Size = new Size(30, 26);
            SaveApiKeyBtn.TabIndex = 16;
            SaveApiKeyBtn.UseVisualStyleBackColor = true;
            SaveApiKeyBtn.Click += SaveApiKeyBtn_Click;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.ForeColor = Color.Green;
            StatusLabel.Location = new Point(531, 111);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(0, 15);
            StatusLabel.TabIndex = 17;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 30, 38);
            ClientSize = new Size(920, 621);
            Controls.Add(StatusLabel);
            Controls.Add(SaveApiKeyBtn);
            Controls.Add(ApiKeyTextBox);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(LocationLabel);
            Controls.Add(BackBtn);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "Settings";
            ShowIcon = false;
            Text = "Govee Controller";
            FormClosing += Settings_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private Label LocationLabel;
        private Button BackBtn;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox ApiKeyTextBox;
        private Button SaveApiKeyBtn;
        private Label StatusLabel;
    }
}