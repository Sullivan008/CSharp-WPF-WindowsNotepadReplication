namespace Notepad.Windows
{
    partial class SearchWindow
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
            this.searchTextLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.directionGroupBox = new System.Windows.Forms.GroupBox();
            this.rearwardsRadioButton = new System.Windows.Forms.RadioButton();
            this.forwardRadioButton = new System.Windows.Forms.RadioButton();
            this.smallLargeCheckBox = new System.Windows.Forms.CheckBox();
            this.directionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // keresendoLabel
            // 
            this.searchTextLabel.AutoSize = true;
            this.searchTextLabel.Location = new System.Drawing.Point(12, 18);
            this.searchTextLabel.Name = "searchTextLabel";
            this.searchTextLabel.Size = new System.Drawing.Size(68, 13);
            this.searchTextLabel.TabIndex = 0;
            this.searchTextLabel.Text = "Search Text:";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(79, 15);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(208, 20);
            this.searchTextBox.TabIndex = 1;
            this.searchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // nextButton
            // 
            this.nextButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.nextButton.Location = new System.Drawing.Point(310, 11);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 26);
            this.nextButton.TabIndex = 2;
            this.nextButton.Tag = "Next";
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(310, 43);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 26);
            this.backButton.TabIndex = 3;
            this.backButton.Tag = "Back";
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // directionGroupBox
            // 
            this.directionGroupBox.Controls.Add(this.rearwardsRadioButton);
            this.directionGroupBox.Controls.Add(this.forwardRadioButton);
            this.directionGroupBox.Location = new System.Drawing.Point(131, 43);
            this.directionGroupBox.Name = "directionGroupBox";
            this.directionGroupBox.Size = new System.Drawing.Size(156, 45);
            this.directionGroupBox.TabIndex = 4;
            this.directionGroupBox.TabStop = false;
            this.directionGroupBox.Text = "Direction";
            // 
            // rearwardsRadioButton
            // 
            this.rearwardsRadioButton.AutoSize = true;
            this.rearwardsRadioButton.Location = new System.Drawing.Point(75, 19);
            this.rearwardsRadioButton.Name = "rearwardsRadioButton";
            this.rearwardsRadioButton.Size = new System.Drawing.Size(76, 17);
            this.rearwardsRadioButton.TabIndex = 1;
            this.rearwardsRadioButton.TabStop = true;
            this.rearwardsRadioButton.Tag = "2";
            this.rearwardsRadioButton.Text = "Rearwards";
            this.rearwardsRadioButton.UseVisualStyleBackColor = true;
            this.rearwardsRadioButton.CheckedChanged += new System.EventHandler(this.Direction_CheckedChanged);
            // 
            // forwardRadioButton
            // 
            this.forwardRadioButton.AutoSize = true;
            this.forwardRadioButton.Location = new System.Drawing.Point(6, 19);
            this.forwardRadioButton.Name = "forwardRadioButton";
            this.forwardRadioButton.Size = new System.Drawing.Size(63, 17);
            this.forwardRadioButton.TabIndex = 0;
            this.forwardRadioButton.TabStop = true;
            this.forwardRadioButton.Tag = "1";
            this.forwardRadioButton.Text = "Forward";
            this.forwardRadioButton.UseVisualStyleBackColor = true;
            this.forwardRadioButton.CheckedChanged += new System.EventHandler(this.Direction_CheckedChanged);
            // 
            // smallLargeCheckBox
            // 
            this.smallLargeCheckBox.AutoSize = true;
            this.smallLargeCheckBox.Location = new System.Drawing.Point(15, 71);
            this.smallLargeCheckBox.Name = "smallLargeCheckBox";
            this.smallLargeCheckBox.Size = new System.Drawing.Size(114, 17);
            this.smallLargeCheckBox.TabIndex = 5;
            this.smallLargeCheckBox.Text = "Small- Large Letter";
            this.smallLargeCheckBox.UseVisualStyleBackColor = true;
            this.smallLargeCheckBox.CheckedChanged += new System.EventHandler(this.SmallLargeLetterCheckBox_CheckedChanged);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(397, 100);
            this.Controls.Add(this.smallLargeCheckBox);
            this.Controls.Add(this.directionGroupBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchTextLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Search";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            this.directionGroupBox.ResumeLayout(false);
            this.directionGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label searchTextLabel;
		private System.Windows.Forms.Button backButton;
		private System.Windows.Forms.GroupBox directionGroupBox;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.RadioButton rearwardsRadioButton;
		private System.Windows.Forms.RadioButton forwardRadioButton;
		private System.Windows.Forms.CheckBox smallLargeCheckBox;
		private System.Windows.Forms.TextBox searchTextBox;
	}
}