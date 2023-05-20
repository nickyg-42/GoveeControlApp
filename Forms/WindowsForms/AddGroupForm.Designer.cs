namespace GoveeControl.Forms.WindowsForms
{
    partial class AddGroupForm
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
            label1 = new Label();
            GroupNameText = new TextBox();
            DevicesLabel = new Label();
            CheckBoxPanel = new FlowLayoutPanel();
            AddGroupBtn = new Button();
            CancelBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.AppWorkspace;
            label1.Location = new Point(26, 32);
            label1.Name = "label1";
            label1.Size = new Size(111, 21);
            label1.TabIndex = 0;
            label1.Text = "Group Name:";
            // 
            // GroupNameText
            // 
            GroupNameText.BackColor = SystemColors.AppWorkspace;
            GroupNameText.Location = new Point(143, 32);
            GroupNameText.Name = "GroupNameText";
            GroupNameText.Size = new Size(129, 23);
            GroupNameText.TabIndex = 1;
            // 
            // DevicesLabel
            // 
            DevicesLabel.AutoSize = true;
            DevicesLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            DevicesLabel.ForeColor = SystemColors.AppWorkspace;
            DevicesLabel.Location = new Point(26, 83);
            DevicesLabel.Name = "DevicesLabel";
            DevicesLabel.Size = new Size(73, 21);
            DevicesLabel.TabIndex = 2;
            DevicesLabel.Text = "Devices:";
            // 
            // CheckBoxPanel
            // 
            CheckBoxPanel.FlowDirection = FlowDirection.TopDown;
            CheckBoxPanel.Location = new Point(26, 116);
            CheckBoxPanel.Name = "CheckBoxPanel";
            CheckBoxPanel.Size = new Size(246, 215);
            CheckBoxPanel.TabIndex = 3;
            // 
            // AddGroupBtn
            // 
            AddGroupBtn.BackColor = Color.White;
            AddGroupBtn.Location = new Point(26, 357);
            AddGroupBtn.Name = "AddGroupBtn";
            AddGroupBtn.Size = new Size(75, 23);
            AddGroupBtn.TabIndex = 4;
            AddGroupBtn.Text = "Add Group";
            AddGroupBtn.UseVisualStyleBackColor = false;
            AddGroupBtn.Click += AddGroupBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            CancelBtn.Location = new Point(124, 357);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(75, 23);
            CancelBtn.TabIndex = 5;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // AddGroupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 30, 38);
            ClientSize = new Size(331, 404);
            Controls.Add(CancelBtn);
            Controls.Add(AddGroupBtn);
            Controls.Add(CheckBoxPanel);
            Controls.Add(DevicesLabel);
            Controls.Add(GroupNameText);
            Controls.Add(label1);
            Name = "AddGroupForm";
            ShowIcon = false;
            Text = "Add Group";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox GroupNameText;
        private Label DevicesLabel;
        private FlowLayoutPanel CheckBoxPanel;
        private Button AddGroupBtn;
        private Button CancelBtn;
    }
}