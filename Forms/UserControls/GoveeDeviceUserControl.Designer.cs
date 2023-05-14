namespace GoveeControl.Forms.UserControls
{
    partial class GoveeDeviceUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoveeDeviceUserControl));
            deviceName = new Label();
            powerBtn = new Button();
            brightnessSlider = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)brightnessSlider).BeginInit();
            SuspendLayout();
            // 
            // deviceName
            // 
            deviceName.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            deviceName.ForeColor = SystemColors.ControlDark;
            deviceName.Location = new Point(20, 22);
            deviceName.Name = "deviceName";
            deviceName.Size = new Size(166, 62);
            deviceName.TabIndex = 0;
            deviceName.Text = "RGBIC Floor Lamp";
            // 
            // powerBtn
            // 
            powerBtn.BackColor = Color.Transparent;
            powerBtn.BackgroundImage = (Image)resources.GetObject("powerBtn.BackgroundImage");
            powerBtn.BackgroundImageLayout = ImageLayout.Zoom;
            powerBtn.Cursor = Cursors.Hand;
            powerBtn.FlatAppearance.BorderSize = 0;
            powerBtn.FlatAppearance.MouseDownBackColor = Color.Gray;
            powerBtn.FlatAppearance.MouseOverBackColor = Color.Gray;
            powerBtn.FlatStyle = FlatStyle.Flat;
            powerBtn.Location = new Point(192, 22);
            powerBtn.Name = "powerBtn";
            powerBtn.Size = new Size(52, 45);
            powerBtn.TabIndex = 1;
            powerBtn.UseVisualStyleBackColor = false;
            // 
            // brightnessSlider
            // 
            brightnessSlider.AutoSize = false;
            brightnessSlider.Cursor = Cursors.Hand;
            brightnessSlider.LargeChange = 1;
            brightnessSlider.Location = new Point(20, 104);
            brightnessSlider.Maximum = 100;
            brightnessSlider.Name = "brightnessSlider";
            brightnessSlider.Size = new Size(238, 24);
            brightnessSlider.TabIndex = 2;
            brightnessSlider.TickStyle = TickStyle.None;
            // 
            // GoveeDeviceUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(59, 66, 82);
            Controls.Add(brightnessSlider);
            Controls.Add(powerBtn);
            Controls.Add(deviceName);
            Name = "GoveeDeviceUserControl";
            Size = new Size(268, 148);
            ((System.ComponentModel.ISupportInitialize)brightnessSlider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label deviceName;
        private Button powerBtn;
        private TrackBar brightnessSlider;
    }
}
