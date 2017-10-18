namespace TIMed
{
    partial class ListeImage
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
            this.components = new System.ComponentModel.Container();
            this.contextimage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copierEnTantQueImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.containerImage = new System.Windows.Forms.ListView();
            this.l_info = new System.Windows.Forms.Label();
            this.contextimage.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextimage
            // 
            this.contextimage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatToolStripMenuItem,
            this.copierEnTantQueImageToolStripMenuItem});
            this.contextimage.Name = "contextMenuStrip1";
            this.contextimage.Size = new System.Drawing.Size(209, 48);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.formatToolStripMenuItem.Text = "Copier en tant que fichier";
            this.formatToolStripMenuItem.Click += new System.EventHandler(this.formatToolStripMenuItem_Click);
            // 
            // copierEnTantQueImageToolStripMenuItem
            // 
            this.copierEnTantQueImageToolStripMenuItem.Name = "copierEnTantQueImageToolStripMenuItem";
            this.copierEnTantQueImageToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.copierEnTantQueImageToolStripMenuItem.Text = "Copier en tant qu\'image";
            this.copierEnTantQueImageToolStripMenuItem.Click += new System.EventHandler(this.copierEnTantQueImageToolStripMenuItem_Click);
            // 
            // containerImage
            // 
            this.containerImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.containerImage.BackColor = System.Drawing.Color.Beige;
            this.containerImage.Location = new System.Drawing.Point(3, 6);
            this.containerImage.Name = "containerImage";
            this.containerImage.Size = new System.Drawing.Size(1363, 143);
            this.containerImage.TabIndex = 1;
            this.containerImage.UseCompatibleStateImageBehavior = false;
            this.containerImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.containerImage_MouseUp);
            // 
            // l_info
            // 
            this.l_info.AutoSize = true;
            this.l_info.Location = new System.Drawing.Point(18, 152);
            this.l_info.Name = "l_info";
            this.l_info.Size = new System.Drawing.Size(16, 13);
            this.l_info.TabIndex = 3;
            this.l_info.Text = "...";
            // 
            // ListeImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.containerImage);
            this.Controls.Add(this.l_info);
            this.Name = "ListeImage";
            this.Size = new System.Drawing.Size(1300, 170);
            this.contextimage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextimage;
        private System.Windows.Forms.ListView containerImage;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copierEnTantQueImageToolStripMenuItem;
        private System.Windows.Forms.Label l_info;

    }
}
