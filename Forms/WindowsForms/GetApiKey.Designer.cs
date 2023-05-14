namespace GoveeControl.Forms.WindowsForms
{
    partial class GetApiKey
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
            apiKeyTextBox = new TextBox();
            enterButton = new Button();
            label1 = new Label();
            titleLabel = new Label();
            errorLabel = new Label();
            SuspendLayout();
            // 
            // apiKeyTextBox
            // 
            apiKeyTextBox.Anchor = AnchorStyles.None;
            apiKeyTextBox.Location = new Point(91, 155);
            apiKeyTextBox.Name = "apiKeyTextBox";
            apiKeyTextBox.Size = new Size(181, 29);
            apiKeyTextBox.TabIndex = 0;
            // 
            // enterButton
            // 
            enterButton.Anchor = AnchorStyles.None;
            enterButton.ForeColor = SystemColors.ActiveCaptionText;
            enterButton.Location = new Point(299, 155);
            enterButton.Name = "enterButton";
            enterButton.Size = new Size(56, 29);
            enterButton.TabIndex = 1;
            enterButton.Text = "Enter";
            enterButton.UseVisualStyleBackColor = true;
            enterButton.Click += EnterButton_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(20, 159);
            label1.Name = "label1";
            label1.Size = new Size(65, 21);
            label1.TabIndex = 2;
            label1.Text = "API Key:";
            // 
            // titleLabel
            // 
            titleLabel.Anchor = AnchorStyles.None;
            titleLabel.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            titleLabel.Location = new Point(12, 25);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(388, 89);
            titleLabel.TabIndex = 3;
            titleLabel.Text = "Please enter your API key to use the application";
            titleLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // errorLabel
            // 
            errorLabel.Anchor = AnchorStyles.None;
            errorLabel.AutoSize = true;
            errorLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            errorLabel.ForeColor = Color.DarkRed;
            errorLabel.Location = new Point(80, 190);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(224, 21);
            errorLabel.TabIndex = 4;
            errorLabel.Text = "Please enter a valid API key!";
            errorLabel.Visible = false;
            // 
            // GetApiKey
            // 
            AcceptButton = enterButton;
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 30, 38);
            ClientSize = new Size(412, 220);
            Controls.Add(errorLabel);
            Controls.Add(titleLabel);
            Controls.Add(label1);
            Controls.Add(enterButton);
            Controls.Add(apiKeyTextBox);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = SystemColors.ControlLightLight;
            Margin = new Padding(4);
            Name = "GetApiKey";
            ShowIcon = false;
            Text = "Govee Controller";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox apiKeyTextBox;
        private Button enterButton;
        private Label label1;
        private Label titleLabel;
        private Label errorLabel;
    }
}