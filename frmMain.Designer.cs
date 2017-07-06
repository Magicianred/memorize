namespace Memorize
{
    partial class frmMain
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
            this.mnuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEnglishFirst = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditWords = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEnglishFirst,
            this.mnuEditWords});
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(143, 48);
            // 
            // mnuEnglishFirst
            // 
            this.mnuEnglishFirst.Checked = true;
            this.mnuEnglishFirst.CheckOnClick = true;
            this.mnuEnglishFirst.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuEnglishFirst.Name = "mnuEnglishFirst";
            this.mnuEnglishFirst.Size = new System.Drawing.Size(142, 22);
            this.mnuEnglishFirst.Text = "English First";
            this.mnuEnglishFirst.Click += new System.EventHandler(this.mnuEnglishFirst_Click);
            // 
            // mnuEditWords
            // 
            this.mnuEditWords.Name = "mnuEditWords";
            this.mnuEditWords.Size = new System.Drawing.Size(142, 22);
            this.mnuEditWords.Text = "Edit words";
            this.mnuEditWords.Click += new System.EventHandler(this.mnuEditWords_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 707);
            this.ContextMenuStrip = this.mnuMain;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memorize";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.mnuMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuEnglishFirst;
        private System.Windows.Forms.ToolStripMenuItem mnuEditWords;
    }
}

