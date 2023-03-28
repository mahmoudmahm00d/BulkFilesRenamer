namespace BulkFilesRenamer.Forms
{
    partial class SelectType
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
            confirmSelectButton = new Button();
            extensionTextBox = new TextBox();
            hintLabel = new Label();
            typeExtenstionsLabel = new Label();
            SuspendLayout();
            // 
            // confirmSelectButton
            // 
            confirmSelectButton.Location = new Point(288, 80);
            confirmSelectButton.Name = "confirmSelectButton";
            confirmSelectButton.Size = new Size(60, 23);
            confirmSelectButton.TabIndex = 0;
            confirmSelectButton.Text = "Confirm";
            confirmSelectButton.UseVisualStyleBackColor = true;
            confirmSelectButton.Click += OnConfirmSelectButtonClick;
            // 
            // extensionTextBox
            // 
            extensionTextBox.Location = new Point(12, 80);
            extensionTextBox.Name = "extensionTextBox";
            extensionTextBox.Size = new Size(268, 23);
            extensionTextBox.TabIndex = 2;
            extensionTextBox.KeyUp += OnExtensionTextBoxKeyUp;
            // 
            // hintLabel
            // 
            hintLabel.AutoSize = true;
            hintLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            hintLabel.ForeColor = SystemColors.ControlDarkDark;
            hintLabel.Location = new Point(12, 60);
            hintLabel.Name = "hintLabel";
            hintLabel.Size = new Size(51, 13);
            hintLabel.TabIndex = 3;
            hintLabel.Text = ".mp4,.srt";
            // 
            // typeExtenstionsLabel
            // 
            typeExtenstionsLabel.AutoSize = true;
            typeExtenstionsLabel.Location = new Point(12, 32);
            typeExtenstionsLabel.Name = "typeExtenstionsLabel";
            typeExtenstionsLabel.Size = new Size(98, 15);
            typeExtenstionsLabel.TabIndex = 3;
            typeExtenstionsLabel.Text = "Type extension(s)";
            // 
            // SelectType
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 120);
            Controls.Add(typeExtenstionsLabel);
            Controls.Add(hintLabel);
            Controls.Add(extensionTextBox);
            Controls.Add(confirmSelectButton);
            Name = "SelectType";
            Text = "SelectType";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button confirmSelectButton;
        private TextBox extensionTextBox;
        private Label hintLabel;
        private Label typeExtenstionsLabel;
    }
}