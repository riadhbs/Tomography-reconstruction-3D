namespace TIMed
{
    partial class Outils
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.scrall_max = new System.Windows.Forms.HScrollBar();
            this.scrall_min = new System.Windows.Forms.HScrollBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.box_seuil = new System.Windows.Forms.GroupBox();
            this.reset = new System.Windows.Forms.Button();
            this.l_max = new System.Windows.Forms.Label();
            this.l_min = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.scrall_gamma = new System.Windows.Forms.HScrollBar();
            this.label7 = new System.Windows.Forms.Label();
            this.box_gamma = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.box_courbe_gamma = new System.Windows.Forms.PictureBox();
            this.zoom = new System.Windows.Forms.NumericUpDown();
            this.box_pallette = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.pourcentage = new System.Windows.Forms.NumericUpDown();
            this.b_paletteX = new System.Windows.Forms.Button();
            this.b_couleur = new System.Windows.Forms.Button();
            this.b_bleu = new System.Windows.Forms.Button();
            this.b_vert = new System.Windows.Forms.Button();
            this.b_rouge = new System.Windows.Forms.Button();
            this.b_gris = new System.Windows.Forms.Button();
            this.box_seuil.SuspendLayout();
            this.box_gamma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.box_courbe_gamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoom)).BeginInit();
            this.box_pallette.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pourcentage)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(142, 406);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Négatif";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // scrall_max
            // 
            this.scrall_max.LargeChange = 20;
            this.scrall_max.Location = new System.Drawing.Point(37, 20);
            this.scrall_max.Maximum = 264;
            this.scrall_max.Name = "scrall_max";
            this.scrall_max.Size = new System.Drawing.Size(118, 17);
            this.scrall_max.TabIndex = 4;
            this.scrall_max.Value = 255;
            this.scrall_max.ValueChanged += new System.EventHandler(this.scrall_max_ValueChanged);
            // 
            // scrall_min
            // 
            this.scrall_min.LargeChange = 20;
            this.scrall_min.Location = new System.Drawing.Point(37, 46);
            this.scrall_min.Maximum = 264;
            this.scrall_min.Name = "scrall_min";
            this.scrall_min.Size = new System.Drawing.Size(118, 17);
            this.scrall_min.TabIndex = 5;
            this.scrall_min.ValueChanged += new System.EventHandler(this.scrall_min_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Max";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Min";
            // 
            // box_seuil
            // 
            this.box_seuil.Controls.Add(this.reset);
            this.box_seuil.Controls.Add(this.l_max);
            this.box_seuil.Controls.Add(this.l_min);
            this.box_seuil.Controls.Add(this.scrall_max);
            this.box_seuil.Controls.Add(this.label3);
            this.box_seuil.Controls.Add(this.scrall_min);
            this.box_seuil.Controls.Add(this.label2);
            this.box_seuil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box_seuil.Location = new System.Drawing.Point(7, 81);
            this.box_seuil.Name = "box_seuil";
            this.box_seuil.Size = new System.Drawing.Size(210, 94);
            this.box_seuil.TabIndex = 8;
            this.box_seuil.TabStop = false;
            this.box_seuil.Text = "Seuillage";
            // 
            // reset
            // 
            this.reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.Location = new System.Drawing.Point(63, 69);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(72, 21);
            this.reset.TabIndex = 11;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // l_max
            // 
            this.l_max.AutoSize = true;
            this.l_max.Location = new System.Drawing.Point(158, 22);
            this.l_max.Name = "l_max";
            this.l_max.Size = new System.Drawing.Size(13, 13);
            this.l_max.TabIndex = 10;
            this.l_max.Text = "0";
            // 
            // l_min
            // 
            this.l_min.AutoSize = true;
            this.l_min.Location = new System.Drawing.Point(158, 48);
            this.l_min.Name = "l_min";
            this.l_min.Size = new System.Drawing.Size(13, 13);
            this.l_min.TabIndex = 8;
            this.l_min.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "ɤ";
            // 
            // scrall_gamma
            // 
            this.scrall_gamma.LargeChange = 4;
            this.scrall_gamma.Location = new System.Drawing.Point(66, 16);
            this.scrall_gamma.Maximum = 509;
            this.scrall_gamma.Minimum = -500;
            this.scrall_gamma.Name = "scrall_gamma";
            this.scrall_gamma.Size = new System.Drawing.Size(116, 17);
            this.scrall_gamma.SmallChange = 2;
            this.scrall_gamma.TabIndex = 11;
            this.scrall_gamma.ValueChanged += new System.EventHandler(this.scrall_gamma_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 406);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Zoom";
            // 
            // box_gamma
            // 
            this.box_gamma.Controls.Add(this.label14);
            this.box_gamma.Controls.Add(this.label5);
            this.box_gamma.Controls.Add(this.label13);
            this.box_gamma.Controls.Add(this.label12);
            this.box_gamma.Controls.Add(this.label11);
            this.box_gamma.Controls.Add(this.label10);
            this.box_gamma.Controls.Add(this.label9);
            this.box_gamma.Controls.Add(this.label8);
            this.box_gamma.Controls.Add(this.label6);
            this.box_gamma.Controls.Add(this.label1);
            this.box_gamma.Controls.Add(this.box_courbe_gamma);
            this.box_gamma.Controls.Add(this.scrall_gamma);
            this.box_gamma.Controls.Add(this.label4);
            this.box_gamma.Location = new System.Drawing.Point(1, 175);
            this.box_gamma.Name = "box_gamma";
            this.box_gamma.Size = new System.Drawing.Size(221, 224);
            this.box_gamma.TabIndex = 17;
            this.box_gamma.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(16, 188);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "255";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(7, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "O";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "U";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "L";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "R";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "E";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "U";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(71, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "V  A  L  E  U  R  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "C";
            // 
            // box_courbe_gamma
            // 
            this.box_courbe_gamma.BackColor = System.Drawing.Color.Black;
            this.box_courbe_gamma.Location = new System.Drawing.Point(30, 40);
            this.box_courbe_gamma.Name = "box_courbe_gamma";
            this.box_courbe_gamma.Size = new System.Drawing.Size(180, 160);
            this.box_courbe_gamma.TabIndex = 14;
            this.box_courbe_gamma.TabStop = false;
            // 
            // zoom
            // 
            this.zoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoom.Location = new System.Drawing.Point(71, 403);
            this.zoom.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.zoom.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.zoom.Name = "zoom";
            this.zoom.Size = new System.Drawing.Size(58, 20);
            this.zoom.TabIndex = 24;
            this.zoom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.zoom.ValueChanged += new System.EventHandler(this.zoom_ValueChanged);
            // 
            // box_pallette
            // 
            this.box_pallette.Controls.Add(this.label15);
            this.box_pallette.Controls.Add(this.pourcentage);
            this.box_pallette.Controls.Add(this.b_paletteX);
            this.box_pallette.Controls.Add(this.b_couleur);
            this.box_pallette.Controls.Add(this.b_bleu);
            this.box_pallette.Controls.Add(this.b_vert);
            this.box_pallette.Controls.Add(this.b_rouge);
            this.box_pallette.Controls.Add(this.b_gris);
            this.box_pallette.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box_pallette.Location = new System.Drawing.Point(4, 1);
            this.box_pallette.Name = "box_pallette";
            this.box_pallette.Size = new System.Drawing.Size(215, 80);
            this.box_pallette.TabIndex = 1;
            this.box_pallette.TabStop = false;
            this.box_pallette.Text = "Palette";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(152, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 16);
            this.label15.TabIndex = 7;
            this.label15.Text = "%";
            // 
            // pourcentage
            // 
            this.pourcentage.Location = new System.Drawing.Point(110, 52);
            this.pourcentage.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.pourcentage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pourcentage.Name = "pourcentage";
            this.pourcentage.Size = new System.Drawing.Size(39, 20);
            this.pourcentage.TabIndex = 6;
            this.pourcentage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // b_paletteX
            // 
            this.b_paletteX.BackgroundImage = global::TIMed.Properties.Resources.palette_x1;
            this.b_paletteX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.b_paletteX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_paletteX.ForeColor = System.Drawing.Color.Black;
            this.b_paletteX.Location = new System.Drawing.Point(41, 49);
            this.b_paletteX.Name = "b_paletteX";
            this.b_paletteX.Size = new System.Drawing.Size(59, 26);
            this.b_paletteX.TabIndex = 5;
            this.b_paletteX.Text = "Palette %";
            this.b_paletteX.UseVisualStyleBackColor = true;
            this.b_paletteX.Click += new System.EventHandler(this.button1_Click);
            // 
            // b_couleur
            // 
            this.b_couleur.BackColor = System.Drawing.Color.LightSlateGray;
            this.b_couleur.BackgroundImage = global::TIMed.Properties.Resources.palbmp1;
            this.b_couleur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.b_couleur.Location = new System.Drawing.Point(173, 17);
            this.b_couleur.Name = "b_couleur";
            this.b_couleur.Size = new System.Drawing.Size(38, 27);
            this.b_couleur.TabIndex = 4;
            this.b_couleur.Text = "C";
            this.b_couleur.UseVisualStyleBackColor = false;
            this.b_couleur.Click += new System.EventHandler(this.b_couleur_Click);
            // 
            // b_bleu
            // 
            this.b_bleu.BackColor = System.Drawing.Color.Blue;
            this.b_bleu.BackgroundImage = global::TIMed.Properties.Resources.BMPpalb;
            this.b_bleu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.b_bleu.Location = new System.Drawing.Point(130, 17);
            this.b_bleu.Name = "b_bleu";
            this.b_bleu.Size = new System.Drawing.Size(38, 27);
            this.b_bleu.TabIndex = 3;
            this.b_bleu.Text = "B";
            this.b_bleu.UseVisualStyleBackColor = false;
            this.b_bleu.Click += new System.EventHandler(this.b_bleu_Click);
            // 
            // b_vert
            // 
            this.b_vert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.b_vert.BackgroundImage = global::TIMed.Properties.Resources.BMPpalv;
            this.b_vert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.b_vert.Location = new System.Drawing.Point(87, 17);
            this.b_vert.Name = "b_vert";
            this.b_vert.Size = new System.Drawing.Size(38, 27);
            this.b_vert.TabIndex = 2;
            this.b_vert.Text = "V";
            this.b_vert.UseVisualStyleBackColor = false;
            this.b_vert.Click += new System.EventHandler(this.b_vert_Click);
            // 
            // b_rouge
            // 
            this.b_rouge.BackColor = System.Drawing.Color.Red;
            this.b_rouge.BackgroundImage = global::TIMed.Properties.Resources.BMPpalr;
            this.b_rouge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.b_rouge.Location = new System.Drawing.Point(45, 17);
            this.b_rouge.Name = "b_rouge";
            this.b_rouge.Size = new System.Drawing.Size(38, 27);
            this.b_rouge.TabIndex = 1;
            this.b_rouge.Text = "R";
            this.b_rouge.UseVisualStyleBackColor = false;
            this.b_rouge.Click += new System.EventHandler(this.b_rouge_Click);
            // 
            // b_gris
            // 
            this.b_gris.BackgroundImage = global::TIMed.Properties.Resources.BMPpalg;
            this.b_gris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.b_gris.Location = new System.Drawing.Point(4, 17);
            this.b_gris.Name = "b_gris";
            this.b_gris.Size = new System.Drawing.Size(38, 27);
            this.b_gris.TabIndex = 0;
            this.b_gris.Text = "G";
            this.b_gris.UseVisualStyleBackColor = true;
            this.b_gris.Click += new System.EventHandler(this.b_gris_Click);
            // 
            // Outils
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(224, 426);
            this.Controls.Add(this.zoom);
            this.Controls.Add(this.box_gamma);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.box_seuil);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.box_pallette);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Outils";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Outils";
            this.Load += new System.EventHandler(this.Outils_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Outils_FormClosed);
            this.box_seuil.ResumeLayout(false);
            this.box_seuil.PerformLayout();
            this.box_gamma.ResumeLayout(false);
            this.box_gamma.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.box_courbe_gamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoom)).EndInit();
            this.box_pallette.ResumeLayout(false);
            this.box_pallette.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pourcentage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox box_pallette;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.HScrollBar scrall_max;
        private System.Windows.Forms.HScrollBar scrall_min;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox box_seuil;
        private System.Windows.Forms.Label l_max;
        private System.Windows.Forms.Label l_min;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.HScrollBar scrall_gamma;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox box_gamma;
        private System.Windows.Forms.PictureBox box_courbe_gamma;
        public System.Windows.Forms.NumericUpDown zoom;
        private System.Windows.Forms.Button b_bleu;
        private System.Windows.Forms.Button b_vert;
        private System.Windows.Forms.Button b_rouge;
        private System.Windows.Forms.Button b_gris;
        private System.Windows.Forms.Button b_couleur;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown pourcentage;
        private System.Windows.Forms.Button b_paletteX;

    }
}