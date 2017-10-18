
namespace TIMed
{
    partial class ImageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageBox));
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statu_format = new System.Windows.Forms.ToolStripStatusLabel();
            this.statu_nb_image = new System.Windows.Forms.ToolStripStatusLabel();
            this.statu_type_examen = new System.Windows.Forms.ToolStripStatusLabel();
            this.statu_X = new System.Windows.Forms.ToolStripStatusLabel();
            this.statu_Y = new System.Windows.Forms.ToolStripStatusLabel();
            this.nb_coup = new System.Windows.Forms.ToolStripStatusLabel();
            this.image_palette = new System.Windows.Forms.PictureBox();
            this.b_image = new TIMed.RichPictureBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_palette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_image)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(264, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = ".";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statu_format,
            this.statu_nb_image,
            this.statu_type_examen,
            this.statu_X,
            this.statu_Y,
            this.nb_coup});
            this.statusStrip1.Location = new System.Drawing.Point(0, 257);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(282, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statu_format
            // 
            this.statu_format.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statu_format.Name = "statu_format";
            this.statu_format.Size = new System.Drawing.Size(10, 17);
            this.statu_format.Text = ".";
            // 
            // statu_nb_image
            // 
            this.statu_nb_image.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statu_nb_image.Name = "statu_nb_image";
            this.statu_nb_image.Size = new System.Drawing.Size(10, 17);
            this.statu_nb_image.Text = ".";
            // 
            // statu_type_examen
            // 
            this.statu_type_examen.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statu_type_examen.Name = "statu_type_examen";
            this.statu_type_examen.Size = new System.Drawing.Size(10, 17);
            this.statu_type_examen.Text = ".";
            // 
            // statu_X
            // 
            this.statu_X.Name = "statu_X";
            this.statu_X.Size = new System.Drawing.Size(0, 17);
            // 
            // statu_Y
            // 
            this.statu_Y.Name = "statu_Y";
            this.statu_Y.Size = new System.Drawing.Size(0, 17);
            // 
            // nb_coup
            // 
            this.nb_coup.Name = "nb_coup";
            this.nb_coup.Size = new System.Drawing.Size(13, 17);
            this.nb_coup.Text = "0";
            // 
            // image_palette
            // 
            this.image_palette.Location = new System.Drawing.Point(1, 1);
            this.image_palette.Name = "image_palette";
            this.image_palette.Size = new System.Drawing.Size(20, 256);
            this.image_palette.TabIndex = 3;
            this.image_palette.TabStop = false;
            // 
            // b_image
            // 
            this.b_image.BackColor = System.Drawing.SystemColors.Control;
            this.b_image.Cursor = System.Windows.Forms.Cursors.Default;
            this.b_image.Location = new System.Drawing.Point(22, 1);
            this.b_image.Name = "b_image";
            this.b_image.Size = new System.Drawing.Size(128, 128);
            this.b_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.b_image.TabIndex = 2;
            this.b_image.TabStop = false;
            this.b_image.MouseLeave += new System.EventHandler(this.b_image_MouseLeave);
            this.b_image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.b_image_MouseMove);
            this.b_image.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_image_MouseDown);
            this.b_image.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_image_MouseUp);
            // 
            // ImageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(282, 279);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.image_palette);
            this.Controls.Add(this.b_image);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(64, 64);
            this.Name = "ImageBox";
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ImageBox_Scroll);
            this.SizeChanged += new System.EventHandler(this.ImageBox_SizeChanged);
            this.Activated += new System.EventHandler(this.ImageBox_Activated);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageBox_MouseDown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageBox_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_palette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public RichPictureBox b_image;
        public  System.Windows.Forms.PictureBox image_palette;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statu_format;
        private System.Windows.Forms.ToolStripStatusLabel statu_nb_image;
        private System.Windows.Forms.ToolStripStatusLabel statu_type_examen;
        private System.Windows.Forms.ToolStripStatusLabel statu_X;
        private System.Windows.Forms.ToolStripStatusLabel statu_Y;
        private System.Windows.Forms.ToolStripStatusLabel nb_coup;

    }
}