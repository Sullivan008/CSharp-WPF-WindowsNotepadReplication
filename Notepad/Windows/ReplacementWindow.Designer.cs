namespace Notepad.Windows
{
    partial class ReplacementWindow
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
            this.searchTermLabel = new System.Windows.Forms.Label();
            this.replacementExpLabel = new System.Windows.Forms.Label();
            this.searchTermTextBox = new System.Windows.Forms.TextBox();
            this.replacementExpTextBox = new System.Windows.Forms.TextBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.replaceButton = new System.Windows.Forms.Button();
            this.replaceAllButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.smallLargeCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // searchTermLabel
            // 
            this.searchTermLabel.AutoSize = true;
            this.searchTermLabel.Location = new System.Drawing.Point(12, 18);
            this.searchTermLabel.Name = "searchTermLabel";
            this.searchTermLabel.Size = new System.Drawing.Size(67, 13);
            this.searchTermLabel.TabIndex = 0;
            this.searchTermLabel.Text = "Search term:";
            // 
            // replacementExpLabel
            // 
            this.replacementExpLabel.AutoSize = true;
            this.replacementExpLabel.Location = new System.Drawing.Point(12, 47);
            this.replacementExpLabel.Name = "replacementExpLabel";
            this.replacementExpLabel.Size = new System.Drawing.Size(126, 13);
            this.replacementExpLabel.TabIndex = 1;
            this.replacementExpLabel.Text = "Replacement expression:";
            // 
            // searchTermTextBox
            // 
            this.searchTermTextBox.Location = new System.Drawing.Point(144, 15);
            this.searchTermTextBox.Name = "searchTermTextBox";
            this.searchTermTextBox.Size = new System.Drawing.Size(127, 20);
            this.searchTermTextBox.TabIndex = 2;
            this.searchTermTextBox.TextChanged += new System.EventHandler(this.SearchTermTextBox_TextChanged);
            // 
            // replacementExpTextBox
            // 
            this.replacementExpTextBox.Location = new System.Drawing.Point(144, 44);
            this.replacementExpTextBox.Name = "replacementExpTextBox";
            this.replacementExpTextBox.Size = new System.Drawing.Size(127, 20);
            this.replacementExpTextBox.TabIndex = 3;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(287, 5);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(78, 26);
            this.nextButton.TabIndex = 4;
            this.nextButton.Tag = "Next";
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // replaceButton
            // 
            this.replaceButton.Location = new System.Drawing.Point(287, 37);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(78, 26);
            this.replaceButton.TabIndex = 5;
            this.replaceButton.Tag = "Replace";
            this.replaceButton.Text = "Replace";
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // replaceAllButton
            // 
            this.replaceAllButton.Location = new System.Drawing.Point(287, 69);
            this.replaceAllButton.Name = "replaceAllButton";
            this.replaceAllButton.Size = new System.Drawing.Size(78, 26);
            this.replaceAllButton.TabIndex = 6;
            this.replaceAllButton.Tag = "ReplaceAll";
            this.replaceAllButton.Text = "Replace All";
            this.replaceAllButton.UseVisualStyleBackColor = true;
            this.replaceAllButton.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(287, 101);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(78, 26);
            this.backButton.TabIndex = 7;
            this.backButton.Tag = "Back";
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // smallLargeCheckBox
            // 
            this.smallLargeCheckBox.AutoSize = true;
            this.smallLargeCheckBox.Location = new System.Drawing.Point(23, 125);
            this.smallLargeCheckBox.Name = "smallLargeCheckBox";
            this.smallLargeCheckBox.Size = new System.Drawing.Size(114, 17);
            this.smallLargeCheckBox.TabIndex = 8;
            this.smallLargeCheckBox.Text = "Small- Large Letter";
            this.smallLargeCheckBox.UseVisualStyleBackColor = true;
            this.smallLargeCheckBox.CheckedChanged += new System.EventHandler(this.SmallLargeLetterCheckBox_CheckedChanged);
            // 
            // Csere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 163);
            this.Controls.Add(this.smallLargeCheckBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.replaceAllButton);
            this.Controls.Add(this.replaceButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.replacementExpTextBox);
            this.Controls.Add(this.searchTermTextBox);
            this.Controls.Add(this.replacementExpLabel);
            this.Controls.Add(this.searchTermLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Replacement";
            this.ShowIcon = false;
            this.Text = "Replacement";
            this.Load += new System.EventHandler(this.Replacement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label searchTermLabel;
		private System.Windows.Forms.Label replacementExpLabel;
		private System.Windows.Forms.TextBox searchTermTextBox;
		private System.Windows.Forms.TextBox replacementExpTextBox;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.Button replaceButton;
		private System.Windows.Forms.Button replaceAllButton;
		private System.Windows.Forms.Button backButton;
		private System.Windows.Forms.CheckBox smallLargeCheckBox;
	}
}