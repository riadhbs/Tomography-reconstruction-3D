namespace TIMed
{
    partial class Multi_images
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
            this.numéro_image = new System.Windows.Forms.GroupBox();
            this.num_image = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.multi_image = new System.Windows.Forms.CheckBox();
            this.box_multi = new System.Windows.Forms.GroupBox();
            this.image_debut = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.affiche_num = new System.Windows.Forms.CheckBox();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.numéro_image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_image)).BeginInit();
            this.box_multi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_debut)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numéro_image
            // 
            this.numéro_image.Controls.Add(this.num_image);
            this.numéro_image.Controls.Add(this.label1);
            this.numéro_image.Location = new System.Drawing.Point(19, -2);
            this.numéro_image.Name = "numéro_image";
            this.numéro_image.Size = new System.Drawing.Size(145, 35);
            this.numéro_image.TabIndex = 31;
            this.numéro_image.TabStop = false;
            // 
            // num_image
            // 
            this.num_image.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_image.Location = new System.Drawing.Point(75, 11);
            this.num_image.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.num_image.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_image.Name = "num_image";
            this.num_image.Size = new System.Drawing.Size(58, 20);
            this.num_image.TabIndex = 26;
            this.num_image.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_image.ValueChanged += new System.EventHandler(this.num_image_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "N° image";
            // 
            // multi_image
            // 
            this.multi_image.AutoSize = true;
            this.multi_image.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multi_image.Location = new System.Drawing.Point(42, 35);
            this.multi_image.Name = "multi_image";
            this.multi_image.Size = new System.Drawing.Size(87, 17);
            this.multi_image.TabIndex = 30;
            this.multi_image.Text = "Multi_images";
            this.multi_image.UseVisualStyleBackColor = true;
            this.multi_image.CheckedChanged += new System.EventHandler(this.multi_image_CheckedChanged);
            // 
            // box_multi
            // 
            this.box_multi.Controls.Add(this.image_debut);
            this.box_multi.Controls.Add(this.button1);
            this.box_multi.Controls.Add(this.label5);
            this.box_multi.Enabled = false;
            this.box_multi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box_multi.Location = new System.Drawing.Point(7, 46);
            this.box_multi.Name = "box_multi";
            this.box_multi.Size = new System.Drawing.Size(167, 62);
            this.box_multi.TabIndex = 29;
            this.box_multi.TabStop = false;
            // 
            // image_debut
            // 
            this.image_debut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.image_debut.Location = new System.Drawing.Point(94, 11);
            this.image_debut.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.image_debut.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.image_debut.Name = "image_debut";
            this.image_debut.Size = new System.Drawing.Size(57, 20);
            this.image_debut.TabIndex = 24;
            this.image_debut.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.image_debut.ValueChanged += new System.EventHandler(this.image_debut_ValueChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(39, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 20);
            this.button1.TabIndex = 32;
            this.button1.Text = "Afficher";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Image debut";
            // 
            // affiche_num
            // 
            this.affiche_num.AutoSize = true;
            this.affiche_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.affiche_num.Location = new System.Drawing.Point(38, 191);
            this.affiche_num.Name = "affiche_num";
            this.affiche_num.Size = new System.Drawing.Size(100, 17);
            this.affiche_num.TabIndex = 33;
            this.affiche_num.Text = "Afficher numéro";
            this.affiche_num.UseVisualStyleBackColor = true;
            this.affiche_num.CheckedChanged += new System.EventHandler(this.affiche_num_CheckedChanged);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(28, 48);
            this.hScrollBar1.Maximum = 1000;
            this.hScrollBar1.Minimum = 10;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(111, 18);
            this.hScrollBar1.SmallChange = 10;
            this.hScrollBar1.TabIndex = 35;
            this.hScrollBar1.Value = 10;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.hScrollBar1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 77);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode ciné";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(143, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 25);
            this.label3.TabIndex = 38;
            this.label3.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 25);
            this.label2.TabIndex = 37;
            this.label2.Text = "+";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::TIMed.Properties.Resources.control_play_blue;
            this.button2.Location = new System.Drawing.Point(32, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 23);
            this.button2.TabIndex = 34;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::TIMed.Properties.Resources.control_stop_blue;
            this.button3.Location = new System.Drawing.Point(94, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 23);
            this.button3.TabIndex = 36;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Multi_images
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 212);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.affiche_num);
            this.Controls.Add(this.numéro_image);
            this.Controls.Add(this.multi_image);
            this.Controls.Add(this.box_multi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Multi_images";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Multi-images";
            this.Load += new System.EventHandler(this.Multi_images_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Multi_images_FormClosed);
            this.numéro_image.ResumeLayout(false);
            this.numéro_image.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_image)).EndInit();
            this.box_multi.ResumeLayout(false);
            this.box_multi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_debut)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox numéro_image;
        private System.Windows.Forms.NumericUpDown num_image;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox multi_image;
        private System.Windows.Forms.NumericUpDown image_debut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.GroupBox box_multi;
        public System.Windows.Forms.CheckBox affiche_num;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}