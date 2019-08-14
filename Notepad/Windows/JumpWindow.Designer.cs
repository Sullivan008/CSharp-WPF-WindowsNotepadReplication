namespace Notepad.Windows
{
    partial class JumpWindow
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
            this.lineNumberLabel = new System.Windows.Forms.Label();
            this.lineNumberTextBox = new System.Windows.Forms.TextBox();
            this.jumpButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lineNumberLabel
            // 
            this.lineNumberLabel.AutoSize = true;
            this.lineNumberLabel.Location = new System.Drawing.Point(14, 22);
            this.lineNumberLabel.Name = "lineNumberLabel";
            this.lineNumberLabel.Size = new System.Drawing.Size(68, 13);
            this.lineNumberLabel.TabIndex = 0;
            this.lineNumberLabel.Text = "Line number:";
            // 
            // lineNumberTextBox
            // 
            this.lineNumberTextBox.Location = new System.Drawing.Point(17, 38);
            this.lineNumberTextBox.Name = "lineNumberTextBox";
            this.lineNumberTextBox.Size = new System.Drawing.Size(226, 20);
            this.lineNumberTextBox.TabIndex = 1;
            this.lineNumberTextBox.Text = "1";
            this.lineNumberTextBox.TextChanged += new System.EventHandler(this.LineNumberTextBox_TextChanged);
            // 
            // jumpButton
            // 
            this.jumpButton.Location = new System.Drawing.Point(73, 72);
            this.jumpButton.Name = "jumpButton";
            this.jumpButton.Size = new System.Drawing.Size(82, 28);
            this.jumpButton.TabIndex = 2;
            this.jumpButton.Tag = "Jump";
            this.jumpButton.Text = "Jump";
            this.jumpButton.UseVisualStyleBackColor = true;
            this.jumpButton.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(161, 72);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(82, 28);
            this.backButton.TabIndex = 3;
            this.backButton.Tag = "Back";
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // Ugras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 118);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.jumpButton);
            this.Controls.Add(this.lineNumberTextBox);
            this.Controls.Add(this.lineNumberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Jump";
            this.ShowIcon = false;
            this.Text = "Jump";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lineNumberLabel;
		private System.Windows.Forms.TextBox lineNumberTextBox;
		private System.Windows.Forms.Button jumpButton;
		private System.Windows.Forms.Button backButton;
	}
}