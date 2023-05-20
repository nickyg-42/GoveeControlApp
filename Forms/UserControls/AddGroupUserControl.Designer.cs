namespace GoveeControl.Forms.UserControls
{
    partial class AddGroupUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGroupUserControl));
            AddBtn = new Button();
            SuspendLayout();
            // 
            // AddBtn
            // 
            AddBtn.BackColor = Color.Transparent;
            AddBtn.BackgroundImage = (Image)resources.GetObject("AddBtn.BackgroundImage");
            AddBtn.BackgroundImageLayout = ImageLayout.Zoom;
            AddBtn.Cursor = Cursors.Hand;
            AddBtn.FlatAppearance.BorderSize = 0;
            AddBtn.FlatAppearance.MouseDownBackColor = Color.Gray;
            AddBtn.FlatAppearance.MouseOverBackColor = Color.Gray;
            AddBtn.FlatStyle = FlatStyle.Flat;
            AddBtn.Location = new Point(80, 38);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(101, 73);
            AddBtn.TabIndex = 1;
            AddBtn.UseVisualStyleBackColor = false;
            AddBtn.Click += AddBtn_Click;
            // 
            // AddGroupUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(AddBtn);
            Name = "AddGroupUserControl";
            Size = new Size(268, 148);
            ResumeLayout(false);
        }

        #endregion

        private Button AddBtn;
    }
}
