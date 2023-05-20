namespace GoveeControl.Forms.UserControls
{
    partial class DeviceGroupUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceGroupUserControl));
            PowerBtn = new Button();
            BrightnessSlider = new TrackBar();
            ColorBtn = new Button();
            DeviceCount = new Label();
            GroupName = new Label();
            TrashBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)BrightnessSlider).BeginInit();
            SuspendLayout();
            // 
            // PowerBtn
            // 
            PowerBtn.BackColor = Color.Transparent;
            PowerBtn.BackgroundImage = (Image)resources.GetObject("PowerBtn.BackgroundImage");
            PowerBtn.BackgroundImageLayout = ImageLayout.Zoom;
            PowerBtn.Cursor = Cursors.Hand;
            PowerBtn.FlatAppearance.BorderSize = 0;
            PowerBtn.FlatAppearance.MouseDownBackColor = Color.Gray;
            PowerBtn.FlatAppearance.MouseOverBackColor = Color.Gray;
            PowerBtn.FlatStyle = FlatStyle.Flat;
            PowerBtn.Location = new Point(187, 22);
            PowerBtn.Name = "PowerBtn";
            PowerBtn.Size = new Size(52, 45);
            PowerBtn.TabIndex = 1;
            PowerBtn.UseVisualStyleBackColor = false;
            PowerBtn.Click += PowerBtn_Click_1;
            // 
            // BrightnessSlider
            // 
            BrightnessSlider.AutoSize = false;
            BrightnessSlider.Cursor = Cursors.Hand;
            BrightnessSlider.LargeChange = 1;
            BrightnessSlider.Location = new Point(20, 105);
            BrightnessSlider.Maximum = 100;
            BrightnessSlider.Name = "BrightnessSlider";
            BrightnessSlider.Size = new Size(190, 24);
            BrightnessSlider.TabIndex = 2;
            BrightnessSlider.TickStyle = TickStyle.None;
            BrightnessSlider.MouseUp += BrightnessSlider_MouseUp;
            // 
            // ColorBtn
            // 
            ColorBtn.BackColor = Color.Transparent;
            ColorBtn.BackgroundImage = (Image)resources.GetObject("ColorBtn.BackgroundImage");
            ColorBtn.BackgroundImageLayout = ImageLayout.Zoom;
            ColorBtn.FlatAppearance.BorderSize = 0;
            ColorBtn.FlatStyle = FlatStyle.Flat;
            ColorBtn.Location = new Point(216, 105);
            ColorBtn.Name = "ColorBtn";
            ColorBtn.Size = new Size(28, 24);
            ColorBtn.TabIndex = 3;
            ColorBtn.UseVisualStyleBackColor = false;
            ColorBtn.Click += ColorBtn_Click;
            // 
            // DeviceCount
            // 
            DeviceCount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DeviceCount.ForeColor = SystemColors.AppWorkspace;
            DeviceCount.Location = new Point(20, 51);
            DeviceCount.Name = "DeviceCount";
            DeviceCount.Size = new Size(100, 23);
            DeviceCount.TabIndex = 4;
            DeviceCount.Text = "placeholder";
            // 
            // GroupName
            // 
            GroupName.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            GroupName.ForeColor = SystemColors.AppWorkspace;
            GroupName.Location = new Point(20, 22);
            GroupName.Name = "GroupName";
            GroupName.Size = new Size(166, 29);
            GroupName.TabIndex = 0;
            GroupName.Text = "Placeholder";
            // 
            // TrashBtn
            // 
            TrashBtn.BackColor = Color.Transparent;
            TrashBtn.BackgroundImage = (Image)resources.GetObject("TrashBtn.BackgroundImage");
            TrashBtn.BackgroundImageLayout = ImageLayout.Zoom;
            TrashBtn.Cursor = Cursors.Hand;
            TrashBtn.FlatAppearance.BorderSize = 0;
            TrashBtn.FlatAppearance.MouseDownBackColor = Color.Gray;
            TrashBtn.FlatAppearance.MouseOverBackColor = Color.Gray;
            TrashBtn.FlatStyle = FlatStyle.Flat;
            TrashBtn.Location = new Point(245, 3);
            TrashBtn.Name = "TrashBtn";
            TrashBtn.Size = new Size(20, 27);
            TrashBtn.TabIndex = 5;
            TrashBtn.UseVisualStyleBackColor = false;
            TrashBtn.Click += TrashBtn_Click;
            // 
            // DeviceGroupUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(59, 66, 82);
            Controls.Add(TrashBtn);
            Controls.Add(DeviceCount);
            Controls.Add(ColorBtn);
            Controls.Add(BrightnessSlider);
            Controls.Add(PowerBtn);
            Controls.Add(GroupName);
            Name = "DeviceGroupUserControl";
            Size = new Size(268, 148);
            ((System.ComponentModel.ISupportInitialize)BrightnessSlider).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button PowerBtn;
        private TrackBar BrightnessSlider;
        private Button ColorBtn;
        private Label DeviceCount;
        private Label GroupName;
        private Button TrashBtn;
    }
}
