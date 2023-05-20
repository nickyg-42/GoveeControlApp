namespace GoveeControl.Forms.WindowsForms
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            label1 = new Label();
            panel1 = new Panel();
            SettingsBtn = new Button();
            DevicesPanel = new FlowLayoutPanel();
            LocationLabel = new Label();
            panel2 = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.AppWorkspace;
            label1.Location = new Point(24, 22);
            label1.Name = "label1";
            label1.Size = new Size(299, 47);
            label1.TabIndex = 0;
            label1.Text = "Govee Controller";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 64, 64);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(24, 76);
            panel1.Name = "panel1";
            panel1.Size = new Size(925, 1);
            panel1.TabIndex = 1;
            // 
            // SettingsBtn
            // 
            SettingsBtn.BackColor = Color.Transparent;
            SettingsBtn.BackgroundImage = (Image)resources.GetObject("SettingsBtn.BackgroundImage");
            SettingsBtn.BackgroundImageLayout = ImageLayout.Zoom;
            SettingsBtn.FlatAppearance.BorderSize = 0;
            SettingsBtn.FlatStyle = FlatStyle.Flat;
            SettingsBtn.ForeColor = SystemColors.ActiveCaption;
            SettingsBtn.Location = new Point(910, 31);
            SettingsBtn.Name = "SettingsBtn";
            SettingsBtn.Size = new Size(39, 38);
            SettingsBtn.TabIndex = 3;
            SettingsBtn.UseVisualStyleBackColor = false;
            SettingsBtn.Click += SettingsBtn_Click;
            // 
            // DevicesPanel
            // 
            DevicesPanel.Location = new Point(107, 92);
            DevicesPanel.Name = "DevicesPanel";
            DevicesPanel.Size = new Size(904, 517);
            DevicesPanel.TabIndex = 4;
            // 
            // LocationLabel
            // 
            LocationLabel.AutoSize = true;
            LocationLabel.ForeColor = SystemColors.AppWorkspace;
            LocationLabel.Location = new Point(357, 37);
            LocationLabel.Name = "LocationLabel";
            LocationLabel.Size = new Size(63, 21);
            LocationLabel.TabIndex = 5;
            LocationLabel.Text = "Devices";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gray;
            panel2.Location = new Point(338, 37);
            panel2.Name = "panel2";
            panel2.Size = new Size(1, 26);
            panel2.TabIndex = 6;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 30, 38);
            ClientSize = new Size(980, 621);
            Controls.Add(panel2);
            Controls.Add(LocationLabel);
            Controls.Add(DevicesPanel);
            Controls.Add(SettingsBtn);
            Controls.Add(panel1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = SystemColors.ControlLightLight;
            Margin = new Padding(4);
            Name = "Home";
            ShowIcon = false;
            Text = "Govee Controller";
            FormClosing += Home_FormClosing;
            Load += Home_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Button SettingsBtn;
        private FlowLayoutPanel DevicesPanel;
        private Label LocationLabel;
        private Panel panel2;
    }
}
