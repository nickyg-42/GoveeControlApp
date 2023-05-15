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
            button1 = new Button();
            DevicesPanel = new FlowLayoutPanel();
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
            panel1.Size = new Size(884, 1);
            panel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ActiveCaption;
            button1.Location = new Point(869, 28);
            button1.Name = "button1";
            button1.Size = new Size(39, 38);
            button1.TabIndex = 3;
            button1.UseVisualStyleBackColor = false;
            // 
            // DevicesPanel
            // 
            DevicesPanel.Location = new Point(24, 92);
            DevicesPanel.Name = "DevicesPanel";
            DevicesPanel.Size = new Size(884, 517);
            DevicesPanel.TabIndex = 4;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 30, 38);
            ClientSize = new Size(920, 621);
            Controls.Add(DevicesPanel);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = SystemColors.ControlLightLight;
            Margin = new Padding(4);
            Name = "Home";
            ShowIcon = false;
            Text = "Govee Controller";
            Load += Home_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Button button1;
        private FlowLayoutPanel DevicesPanel;
    }
}
