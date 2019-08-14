namespace Notepad.Windows
{
    partial class NotepadWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotepadWindow));
            this.notepadRichTextBox = new System.Windows.Forms.RichTextBox();
            this.RightClickContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RedoCTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoCTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.CutCTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyCTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteCTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteCTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAllCTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewDocumentTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RedoTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CutTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SearchTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindNextTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReplaceTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JumpTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAllTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeDateTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WordWrapTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BackgroundColorTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HighlightingTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenuStrip = new System.Windows.Forms.MenuStrip();
            this.RightClickContextMenuStrip.SuspendLayout();
            this.ToolsMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notepadRichTextBox
            // 
            notepadRichTextBox.AcceptsTab = true;
            notepadRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            notepadRichTextBox.ContextMenuStrip = this.RightClickContextMenuStrip;
            notepadRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            notepadRichTextBox.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            notepadRichTextBox.Location = new System.Drawing.Point(0, 24);
            notepadRichTextBox.Name = "notepadRichTextBox";
            notepadRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            notepadRichTextBox.Size = new System.Drawing.Size(811, 467);
            notepadRichTextBox.TabIndex = 6;
            notepadRichTextBox.Text = "";
            notepadRichTextBox.WordWrap = false;
            notepadRichTextBox.SelectionChanged += new System.EventHandler(this.NotepadRichTextBox_SelectionChanged);
            notepadRichTextBox.TextChanged += new System.EventHandler(this.NotepadRichTextBox_TextChanged);
            // 
            // RightClickContextMenuStrip
            // 
            this.RightClickContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RedoCTSMenuItem,
            this.UndoCTSMenuItem,
            this.toolStripSeparator6,
            this.CutCTSMenuItem,
            this.CopyCTSMenuItem,
            this.PasteCTSMenuItem,
            this.DeleteCTSMenuItem,
            this.toolStripSeparator7,
            this.SelectAllCTSMenuItem});
            this.RightClickContextMenuStrip.Name = "notepadContextMenuStrip";
            this.RightClickContextMenuStrip.Size = new System.Drawing.Size(181, 192);
            // 
            // ForwardCTSMenuItem
            // 
            this.RedoCTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ForwardCTSMenuItem.Image")));
            this.RedoCTSMenuItem.Name = "ForwardCTSMenuItem";
            this.RedoCTSMenuItem.Size = new System.Drawing.Size(180, 22);
            this.RedoCTSMenuItem.Tag = "Redo";
            this.RedoCTSMenuItem.Text = "Redo";
            this.RedoCTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // BackCTSMenuItem
            // 
            this.UndoCTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("BackCTSMenuItem.Image")));
            this.UndoCTSMenuItem.Name = "BackCTSMenuItem";
            this.UndoCTSMenuItem.Size = new System.Drawing.Size(122, 22);
            this.UndoCTSMenuItem.Tag = "Undo";
            this.UndoCTSMenuItem.Text = "Undo";
            this.UndoCTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(119, 6);
            // 
            // CutCTSMenuItem
            // 
            this.CutCTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CutCTSMenuItem.Image")));
            this.CutCTSMenuItem.Name = "CutCTSMenuItem";
            this.CutCTSMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CutCTSMenuItem.Tag = "Cut";
            this.CutCTSMenuItem.Text = "Cut";
            this.CutCTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // CopyCTSMenuItem
            // 
            this.CopyCTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CopyCTSMenuItem.Image")));
            this.CopyCTSMenuItem.Name = "CopyCTSMenuItem";
            this.CopyCTSMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CopyCTSMenuItem.Tag = "Copy";
            this.CopyCTSMenuItem.Text = "Copy";
            this.CopyCTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // PasteCTSMenuItem
            // 
            this.PasteCTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PasteCTSMenuItem.Image")));
            this.PasteCTSMenuItem.Name = "PasteCTSMenuItem";
            this.PasteCTSMenuItem.Size = new System.Drawing.Size(180, 22);
            this.PasteCTSMenuItem.Tag = "Paste";
            this.PasteCTSMenuItem.Text = "Paste";
            this.PasteCTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // DeleteCTSMenuItem
            // 
            this.DeleteCTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DeleteCTSMenuItem.Image")));
            this.DeleteCTSMenuItem.Name = "DeleteCTSMenuItem";
            this.DeleteCTSMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DeleteCTSMenuItem.Tag = "Delete";
            this.DeleteCTSMenuItem.Text = "Delete";
            this.DeleteCTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(119, 6);
            // 
            // SelectAllCTSMenuItem
            // 
            this.SelectAllCTSMenuItem.Name = "SelectAllCTSMenuItem";
            this.SelectAllCTSMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SelectAllCTSMenuItem.Tag = "SelectAll";
            this.SelectAllCTSMenuItem.Text = "Select All";
            this.SelectAllCTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // FileTSMenuItem
            // 
            this.FileTSMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewDocumentTSMenuItem,
            this.OpenTSMenuItem,
            this.SaveTSMenuItem,
            this.SaveAsTSMenuItem,
            this.toolStripSeparator1,
            this.ExitTSMenuItem});
            this.FileTSMenuItem.Name = "FileTSMenuItem";
            this.FileTSMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileTSMenuItem.Text = "File";
            // 
            // NewDocumentTSMenuItem
            // 
            this.NewDocumentTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("NewDocumentTSMenuItem.Image")));
            this.NewDocumentTSMenuItem.Name = "NewDocumentTSMenuItem";
            this.NewDocumentTSMenuItem.Size = new System.Drawing.Size(157, 22);
            this.NewDocumentTSMenuItem.Tag = "NewDocument";
            this.NewDocumentTSMenuItem.Text = "New Document";
            this.NewDocumentTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // OpenTSMenuItem
            // 
            this.OpenTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenTSMenuItem.Image")));
            this.OpenTSMenuItem.Name = "OpenTSMenuItem";
            this.OpenTSMenuItem.Size = new System.Drawing.Size(157, 22);
            this.OpenTSMenuItem.Tag = "OpenDocument";
            this.OpenTSMenuItem.Text = "Open";
            this.OpenTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // SaveTSMenuItem
            // 
            this.SaveTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveTSMenuItem.Image")));
            this.SaveTSMenuItem.Name = "SaveTSMenuItem";
            this.SaveTSMenuItem.Size = new System.Drawing.Size(157, 22);
            this.SaveTSMenuItem.Tag = "SaveDocument";
            this.SaveTSMenuItem.Text = "Save";
            this.SaveTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // SaveAsTSMenuItem
            // 
            this.SaveAsTSMenuItem.Name = "SaveAsTSMenuItem";
            this.SaveAsTSMenuItem.Size = new System.Drawing.Size(157, 22);
            this.SaveAsTSMenuItem.Tag = "SaveAsDocument";
            this.SaveAsTSMenuItem.Text = "Save As...";
            this.SaveAsTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // ExitTSMenuItem
            // 
            this.ExitTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ExitTSMenuItem.Image")));
            this.ExitTSMenuItem.Name = "ExitTSMenuItem";
            this.ExitTSMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ExitTSMenuItem.Tag = "Exit";
            this.ExitTSMenuItem.Text = "Exit";
            this.ExitTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // EditTSMenuItem
            // 
            this.EditTSMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RedoTSMenuItem,
            this.UndoTSMenuItem,
            this.toolStripSeparator2,
            this.CutTSMenuItem,
            this.CopyTSMenuItem,
            this.PasteTSMenuItem,
            this.DeleteTSMenuItem,
            this.toolStripSeparator3,
            this.SearchTSMenuItem,
            this.FindNextTSMenuItem,
            this.ReplaceTSMenuItem,
            this.JumpTSMenuItem,
            this.toolStripSeparator4,
            this.SelectAllTSMenuItem,
            this.TimeDateTSMenuItem});
            this.EditTSMenuItem.Name = "EditTSMenuItem";
            this.EditTSMenuItem.Size = new System.Drawing.Size(39, 20);
            this.EditTSMenuItem.Text = "Edit";
            // 
            // ForwardTSMenuItem
            // 
            this.RedoTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ForwardTSMenuItem.Image")));
            this.RedoTSMenuItem.Name = "ForwardTSMenuItem";
            this.RedoTSMenuItem.Size = new System.Drawing.Size(180, 22);
            this.RedoTSMenuItem.Tag = "Redo";
            this.RedoTSMenuItem.Text = "Redo";
            this.RedoTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // BackTSMenuItem
            // 
            this.UndoTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("BackTSMenuItem.Image")));
            this.UndoTSMenuItem.Name = "BackTSMenuItem";
            this.UndoTSMenuItem.Size = new System.Drawing.Size(180, 22);
            this.UndoTSMenuItem.Tag = "Undo";
            this.UndoTSMenuItem.Text = "Undo";
            this.UndoTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // CutTSMenuItem
            // 
            this.CutTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CutTSMenuItem.Image")));
            this.CutTSMenuItem.Name = "CutTSMenuItem";
            this.CutTSMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CutTSMenuItem.Tag = "Cut";
            this.CutTSMenuItem.Text = "Cut";
            this.CutTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // CopyTSMenuItem
            // 
            this.CopyTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CopyTSMenuItem.Image")));
            this.CopyTSMenuItem.Name = "CopyTSMenuItem";
            this.CopyTSMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CopyTSMenuItem.Tag = "Copy";
            this.CopyTSMenuItem.Text = "Copy";
            this.CopyTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // PasteTSMenuItem
            // 
            this.PasteTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PasteTSMenuItem.Image")));
            this.PasteTSMenuItem.Name = "PasteTSMenuItem";
            this.PasteTSMenuItem.Size = new System.Drawing.Size(180, 22);
            this.PasteTSMenuItem.Tag = "Paste";
            this.PasteTSMenuItem.Text = "Paste";
            this.PasteTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // DeleteTSMenuItem
            // 
            this.DeleteTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DeleteTSMenuItem.Image")));
            this.DeleteTSMenuItem.Name = "DeleteTSMenuItem";
            this.DeleteTSMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DeleteTSMenuItem.Tag = "Delete";
            this.DeleteTSMenuItem.Text = "Delete";
            this.DeleteTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // SearchTSMenuItem
            // 
            this.SearchTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SearchTSMenuItem.Image")));
            this.SearchTSMenuItem.Name = "SearchTSMenuItem";
            this.SearchTSMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SearchTSMenuItem.Tag = "Search";
            this.SearchTSMenuItem.Text = "Search...";
            this.SearchTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // FindNextTSMenuItem
            // 
            this.FindNextTSMenuItem.Name = "FindNextTSMenuItem";
            this.FindNextTSMenuItem.Size = new System.Drawing.Size(180, 22);
            this.FindNextTSMenuItem.Tag = "FindNext";
            this.FindNextTSMenuItem.Text = "Find Next";
            this.FindNextTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // ReplaceTSMenuItem
            // 
            this.ReplaceTSMenuItem.Name = "ReplaceTSMenuItem";
            this.ReplaceTSMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ReplaceTSMenuItem.Tag = "Replace";
            this.ReplaceTSMenuItem.Text = "Replace...";
            this.ReplaceTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // JumpTSMenuItem
            // 
            this.JumpTSMenuItem.Name = "JumpTSMenuItem";
            this.JumpTSMenuItem.Size = new System.Drawing.Size(180, 22);
            this.JumpTSMenuItem.Tag = "Jump";
            this.JumpTSMenuItem.Text = "Jump...";
            this.JumpTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // SelectAllTSMenuItem
            // 
            this.SelectAllTSMenuItem.Name = "SelectAllTSMenuItem";
            this.SelectAllTSMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SelectAllTSMenuItem.Tag = "SelectAll";
            this.SelectAllTSMenuItem.Text = "Select All";
            this.SelectAllTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // TimeDateTSMenuItem
            // 
            this.TimeDateTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("TimeDateTSMenuItem.Image")));
            this.TimeDateTSMenuItem.Name = "TimeDateTSMenuItem";
            this.TimeDateTSMenuItem.Size = new System.Drawing.Size(180, 22);
            this.TimeDateTSMenuItem.Tag = "TimeDate";
            this.TimeDateTSMenuItem.Text = "Time/Date";
            this.TimeDateTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // FormatTSMenuItem
            // 
            this.FormatTSMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WordWrapTSMenuItem,
            this.FontTSMenuItem,
            this.toolStripSeparator5,
            this.BackgroundColorTSMenuItem,
            this.HighlightingTSMenuItem});
            this.FormatTSMenuItem.Name = "FormatTSMenuItem";
            this.FormatTSMenuItem.Size = new System.Drawing.Size(57, 20);
            this.FormatTSMenuItem.Text = "Format";
            // 
            // LineBreakTSMenuItem
            // 
            this.WordWrapTSMenuItem.Name = "LineBreakTSMenuItem";
            this.WordWrapTSMenuItem.Size = new System.Drawing.Size(168, 22);
            this.WordWrapTSMenuItem.Tag = "WordWrap";
            this.WordWrapTSMenuItem.Text = "Word Wrap";
            this.WordWrapTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // FontTSMenuItem
            // 
            this.FontTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("FontTSMenuItem.Image")));
            this.FontTSMenuItem.Name = "FontTSMenuItem";
            this.FontTSMenuItem.Size = new System.Drawing.Size(168, 22);
            this.FontTSMenuItem.Tag = "Font";
            this.FontTSMenuItem.Text = "Font";
            this.FontTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(165, 6);
            // 
            // BackgroundColorTSMenuItem
            // 
            this.BackgroundColorTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("BackgroundColorTSMenuItem.Image")));
            this.BackgroundColorTSMenuItem.Name = "BackgroundColorTSMenuItem";
            this.BackgroundColorTSMenuItem.Size = new System.Drawing.Size(168, 22);
            this.BackgroundColorTSMenuItem.Tag = "BackgroundColor";
            this.BackgroundColorTSMenuItem.Text = "Background color";
            this.BackgroundColorTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // HighlightingTSMenuItem
            // 
            this.HighlightingTSMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("HighlightingTSMenuItem.Image")));
            this.HighlightingTSMenuItem.Name = "HighlightingTSMenuItem";
            this.HighlightingTSMenuItem.Size = new System.Drawing.Size(168, 22);
            this.HighlightingTSMenuItem.Tag = "Highlighting";
            this.HighlightingTSMenuItem.Text = "Highlighting";
            this.HighlightingTSMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // ToolsMenuStrip
            // 
            this.ToolsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileTSMenuItem,
            this.EditTSMenuItem,
            this.FormatTSMenuItem});
            this.ToolsMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolsMenuStrip.Name = "ToolsMenuStrip";
            this.ToolsMenuStrip.Size = new System.Drawing.Size(811, 24);
            this.ToolsMenuStrip.TabIndex = 5;
            this.ToolsMenuStrip.Text = "menuStrip1";
            // 
            // Notepad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 491);
            this.Controls.Add(notepadRichTextBox);
            this.Controls.Add(this.ToolsMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ToolsMenuStrip;
            this.Name = "Notepad";
            this.Text = "Unsaved - Notepad";
            this.Load += new System.EventHandler(this.Notepad_Load);
            this.RightClickContextMenuStrip.ResumeLayout(false);
            this.ToolsMenuStrip.ResumeLayout(false);
            this.ToolsMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ContextMenuStrip RightClickContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem UndoCTSMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem CutCTSMenuItem;
		private System.Windows.Forms.ToolStripMenuItem CopyCTSMenuItem;
		private System.Windows.Forms.ToolStripMenuItem PasteCTSMenuItem;
		private System.Windows.Forms.ToolStripMenuItem DeleteCTSMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem SelectAllCTSMenuItem;
		private System.Windows.Forms.ToolStripMenuItem RedoCTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewDocumentTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsTSMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RedoTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UndoTSMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem CutTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteTSMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem SearchTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FindNextTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReplaceTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JumpTSMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem SelectAllTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TimeDateTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FormatTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WordWrapTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FontTSMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem BackgroundColorTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HighlightingTSMenuItem;
        private System.Windows.Forms.MenuStrip ToolsMenuStrip;
        private System.Windows.Forms.RichTextBox notepadRichTextBox;
    }
}