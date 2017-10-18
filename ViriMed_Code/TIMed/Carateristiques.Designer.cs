namespace TIMed
{
    partial class Carateristiques_exam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Carateristiques_exam));
            this.l_nbrligne = new System.Windows.Forms.Label();
            this.l_nbrcolonne = new System.Windows.Forms.Label();
            this.l_nbroctet = new System.Windows.Forms.Label();
            this.Box_carac_valeur = new System.Windows.Forms.GroupBox();
            this.radio_reel = new System.Windows.Forms.RadioButton();
            this.radio_entier = new System.Windows.Forms.RadioButton();
            this.check_swap = new System.Windows.Forms.CheckBox();
            this.radio_pos_neg = new System.Windows.Forms.RadioButton();
            this.radio_positif = new System.Windows.Forms.RadioButton();
            this.nbr_oct_valeur = new System.Windows.Forms.ComboBox();
            this.group_entete = new System.Windows.Forms.GroupBox();
            this.taille = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.radio_Fin = new System.Windows.Forms.RadioButton();
            this.radio_début = new System.Windows.Forms.RadioButton();
            this.l_typ_exam = new System.Windows.Forms.Label();
            this.Combo_type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.box_angle = new System.Windows.Forms.GroupBox();
            this.deupi = new System.Windows.Forms.RadioButton();
            this.pi = new System.Windows.Forms.RadioButton();
            this.box_positif_negatif = new System.Windows.Forms.GroupBox();
            this.b_ok = new System.Windows.Forms.Button();
            this.b_annuler = new System.Windows.Forms.Button();
            this.nb_ligne = new System.Windows.Forms.NumericUpDown();
            this.nbr_colon = new System.Windows.Forms.NumericUpDown();
            this.nbr_image = new System.Windows.Forms.NumericUpDown();
            this.box_lc = new System.Windows.Forms.GroupBox();
            this.box_nb_image = new System.Windows.Forms.GroupBox();
            this.box_type_exam = new System.Windows.Forms.GroupBox();
            this.box_nb_oct_valeur = new System.Windows.Forms.GroupBox();
            this.check_rvb = new System.Windows.Forms.CheckBox();
            this.Box_carac_valeur.SuspendLayout();
            this.group_entete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taille)).BeginInit();
            this.box_angle.SuspendLayout();
            this.box_positif_negatif.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_ligne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbr_colon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbr_image)).BeginInit();
            this.box_lc.SuspendLayout();
            this.box_nb_image.SuspendLayout();
            this.box_type_exam.SuspendLayout();
            this.box_nb_oct_valeur.SuspendLayout();
            this.SuspendLayout();
            // 
            // l_nbrligne
            // 
            this.l_nbrligne.AutoSize = true;
            this.l_nbrligne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_nbrligne.ForeColor = System.Drawing.Color.Black;
            this.l_nbrligne.Location = new System.Drawing.Point(6, 26);
            this.l_nbrligne.Name = "l_nbrligne";
            this.l_nbrligne.Size = new System.Drawing.Size(105, 13);
            this.l_nbrligne.TabIndex = 0;
            this.l_nbrligne.Text = "Nombre de lignes";
            // 
            // l_nbrcolonne
            // 
            this.l_nbrcolonne.AutoSize = true;
            this.l_nbrcolonne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_nbrcolonne.Location = new System.Drawing.Point(6, 59);
            this.l_nbrcolonne.Name = "l_nbrcolonne";
            this.l_nbrcolonne.Size = new System.Drawing.Size(123, 13);
            this.l_nbrcolonne.TabIndex = 2;
            this.l_nbrcolonne.Text = "Nombre de colonnes";
            // 
            // l_nbroctet
            // 
            this.l_nbroctet.AutoSize = true;
            this.l_nbroctet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.l_nbroctet.Location = new System.Drawing.Point(14, 21);
            this.l_nbroctet.Name = "l_nbroctet";
            this.l_nbroctet.Size = new System.Drawing.Size(154, 13);
            this.l_nbroctet.TabIndex = 4;
            this.l_nbroctet.Text = "Nombre d\'octet par valeur";
            // 
            // Box_carac_valeur
            // 
            this.Box_carac_valeur.Controls.Add(this.radio_reel);
            this.Box_carac_valeur.Controls.Add(this.radio_entier);
            this.Box_carac_valeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.Box_carac_valeur.Location = new System.Drawing.Point(17, 105);
            this.Box_carac_valeur.Name = "Box_carac_valeur";
            this.Box_carac_valeur.Size = new System.Drawing.Size(183, 48);
            this.Box_carac_valeur.TabIndex = 6;
            this.Box_carac_valeur.TabStop = false;
            // 
            // radio_reel
            // 
            this.radio_reel.AutoSize = true;
            this.radio_reel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.radio_reel.Location = new System.Drawing.Point(107, 20);
            this.radio_reel.Name = "radio_reel";
            this.radio_reel.Size = new System.Drawing.Size(51, 17);
            this.radio_reel.TabIndex = 1;
            this.radio_reel.TabStop = true;
            this.radio_reel.Text = "Réel";
            this.radio_reel.UseVisualStyleBackColor = true;
            this.radio_reel.Click += new System.EventHandler(this.radio_reel_Click);
            // 
            // radio_entier
            // 
            this.radio_entier.AutoSize = true;
            this.radio_entier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.radio_entier.Location = new System.Drawing.Point(30, 20);
            this.radio_entier.Name = "radio_entier";
            this.radio_entier.Size = new System.Drawing.Size(58, 17);
            this.radio_entier.TabIndex = 0;
            this.radio_entier.TabStop = true;
            this.radio_entier.Text = "Entier";
            this.radio_entier.UseVisualStyleBackColor = true;
            this.radio_entier.Click += new System.EventHandler(this.radio_entier_Click);
            // 
            // check_swap
            // 
            this.check_swap.AutoSize = true;
            this.check_swap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.check_swap.Location = new System.Drawing.Point(223, 126);
            this.check_swap.Name = "check_swap";
            this.check_swap.Size = new System.Drawing.Size(55, 17);
            this.check_swap.TabIndex = 4;
            this.check_swap.Text = "swap";
            this.check_swap.UseVisualStyleBackColor = true;
            // 
            // radio_pos_neg
            // 
            this.radio_pos_neg.AutoSize = true;
            this.radio_pos_neg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.radio_pos_neg.Location = new System.Drawing.Point(98, 21);
            this.radio_pos_neg.Name = "radio_pos_neg";
            this.radio_pos_neg.Size = new System.Drawing.Size(107, 17);
            this.radio_pos_neg.TabIndex = 3;
            this.radio_pos_neg.TabStop = true;
            this.radio_pos_neg.Text = "Positif/Négatif";
            this.radio_pos_neg.UseVisualStyleBackColor = true;
            this.radio_pos_neg.Click += new System.EventHandler(this.radio_pos_neg_Click);
            // 
            // radio_positif
            // 
            this.radio_positif.AutoSize = true;
            this.radio_positif.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.radio_positif.Location = new System.Drawing.Point(18, 21);
            this.radio_positif.Name = "radio_positif";
            this.radio_positif.Size = new System.Drawing.Size(60, 17);
            this.radio_positif.TabIndex = 2;
            this.radio_positif.TabStop = true;
            this.radio_positif.Text = "Positif";
            this.radio_positif.UseVisualStyleBackColor = true;
            this.radio_positif.Click += new System.EventHandler(this.radio_positif_Click);
            // 
            // nbr_oct_valeur
            // 
            this.nbr_oct_valeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbr_oct_valeur.FormattingEnabled = true;
            this.nbr_oct_valeur.Items.AddRange(new object[] {
            "1",
            "2",
            "4"});
            this.nbr_oct_valeur.Location = new System.Drawing.Point(175, 19);
            this.nbr_oct_valeur.Name = "nbr_oct_valeur";
            this.nbr_oct_valeur.Size = new System.Drawing.Size(38, 21);
            this.nbr_oct_valeur.TabIndex = 7;
            this.nbr_oct_valeur.SelectedIndexChanged += new System.EventHandler(this.nbr_oct_valeur_SelectedIndexChanged);
            // 
            // group_entete
            // 
            this.group_entete.Controls.Add(this.taille);
            this.group_entete.Controls.Add(this.label1);
            this.group_entete.Controls.Add(this.radio_Fin);
            this.group_entete.Controls.Add(this.radio_début);
            this.group_entete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.group_entete.Location = new System.Drawing.Point(18, 161);
            this.group_entete.Name = "group_entete";
            this.group_entete.Size = new System.Drawing.Size(260, 100);
            this.group_entete.TabIndex = 8;
            this.group_entete.TabStop = false;
            this.group_entete.Text = "Entête";
            // 
            // taille
            // 
            this.taille.Location = new System.Drawing.Point(157, 65);
            this.taille.Maximum = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            0});
            this.taille.Name = "taille";
            this.taille.Size = new System.Drawing.Size(55, 21);
            this.taille.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(44, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Taille (en octet)";
            // 
            // radio_Fin
            // 
            this.radio_Fin.AutoSize = true;
            this.radio_Fin.Location = new System.Drawing.Point(170, 31);
            this.radio_Fin.Name = "radio_Fin";
            this.radio_Fin.Size = new System.Drawing.Size(47, 20);
            this.radio_Fin.TabIndex = 1;
            this.radio_Fin.TabStop = true;
            this.radio_Fin.Text = "Fin";
            this.radio_Fin.UseVisualStyleBackColor = true;
            // 
            // radio_début
            // 
            this.radio_début.AutoSize = true;
            this.radio_début.Location = new System.Drawing.Point(29, 31);
            this.radio_début.Name = "radio_début";
            this.radio_début.Size = new System.Drawing.Size(67, 20);
            this.radio_début.TabIndex = 0;
            this.radio_début.TabStop = true;
            this.radio_début.Text = "Début";
            this.radio_début.UseVisualStyleBackColor = true;
            // 
            // l_typ_exam
            // 
            this.l_typ_exam.AutoSize = true;
            this.l_typ_exam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.l_typ_exam.Location = new System.Drawing.Point(25, 22);
            this.l_typ_exam.Name = "l_typ_exam";
            this.l_typ_exam.Size = new System.Drawing.Size(92, 13);
            this.l_typ_exam.TabIndex = 9;
            this.l_typ_exam.Text = "Type d\'examen";
            // 
            // Combo_type
            // 
            this.Combo_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Combo_type.FormattingEnabled = true;
            this.Combo_type.Items.AddRange(new object[] {
            "statique",
            "dynamique",
            "tomographique",
            "synchronisé"});
            this.Combo_type.Location = new System.Drawing.Point(129, 19);
            this.Combo_type.Name = "Combo_type";
            this.Combo_type.Size = new System.Drawing.Size(114, 21);
            this.Combo_type.TabIndex = 10;
            this.Combo_type.SelectedIndexChanged += new System.EventHandler(this.Combo_type_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(22, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nombre d\'images";
            // 
            // box_angle
            // 
            this.box_angle.Controls.Add(this.deupi);
            this.box_angle.Controls.Add(this.pi);
            this.box_angle.Enabled = false;
            this.box_angle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.box_angle.Location = new System.Drawing.Point(289, 271);
            this.box_angle.Name = "box_angle";
            this.box_angle.Size = new System.Drawing.Size(225, 62);
            this.box_angle.TabIndex = 9;
            this.box_angle.TabStop = false;
            this.box_angle.Text = "Angle de rotation";
            // 
            // deupi
            // 
            this.deupi.AutoSize = true;
            this.deupi.Location = new System.Drawing.Point(125, 28);
            this.deupi.Name = "deupi";
            this.deupi.Size = new System.Drawing.Size(43, 20);
            this.deupi.TabIndex = 1;
            this.deupi.TabStop = true;
            this.deupi.Text = "2π";
            this.deupi.UseVisualStyleBackColor = true;
            // 
            // pi
            // 
            this.pi.AutoSize = true;
            this.pi.Location = new System.Drawing.Point(67, 28);
            this.pi.Name = "pi";
            this.pi.Size = new System.Drawing.Size(35, 20);
            this.pi.TabIndex = 0;
            this.pi.TabStop = true;
            this.pi.Text = "π";
            this.pi.UseVisualStyleBackColor = true;
            // 
            // box_positif_negatif
            // 
            this.box_positif_negatif.Controls.Add(this.radio_positif);
            this.box_positif_negatif.Controls.Add(this.radio_pos_neg);
            this.box_positif_negatif.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.box_positif_negatif.Location = new System.Drawing.Point(289, 105);
            this.box_positif_negatif.Name = "box_positif_negatif";
            this.box_positif_negatif.Size = new System.Drawing.Size(225, 50);
            this.box_positif_negatif.TabIndex = 7;
            this.box_positif_negatif.TabStop = false;
            // 
            // b_ok
            // 
            this.b_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_ok.Location = new System.Drawing.Point(192, 355);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(75, 23);
            this.b_ok.TabIndex = 13;
            this.b_ok.Text = "OK";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // b_annuler
            // 
            this.b_annuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_annuler.Location = new System.Drawing.Point(301, 355);
            this.b_annuler.Name = "b_annuler";
            this.b_annuler.Size = new System.Drawing.Size(75, 23);
            this.b_annuler.TabIndex = 14;
            this.b_annuler.Text = "Annuler";
            this.b_annuler.UseVisualStyleBackColor = true;
            this.b_annuler.Click += new System.EventHandler(this.b_annuler_Click);
            // 
            // nb_ligne
            // 
            this.nb_ligne.Location = new System.Drawing.Point(189, 19);
            this.nb_ligne.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nb_ligne.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nb_ligne.Name = "nb_ligne";
            this.nb_ligne.Size = new System.Drawing.Size(55, 20);
            this.nb_ligne.TabIndex = 15;
            this.nb_ligne.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // nbr_colon
            // 
            this.nbr_colon.Location = new System.Drawing.Point(189, 57);
            this.nbr_colon.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nbr_colon.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbr_colon.Name = "nbr_colon";
            this.nbr_colon.Size = new System.Drawing.Size(55, 20);
            this.nbr_colon.TabIndex = 16;
            this.nbr_colon.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // nbr_image
            // 
            this.nbr_image.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbr_image.Location = new System.Drawing.Point(158, 26);
            this.nbr_image.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nbr_image.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbr_image.Name = "nbr_image";
            this.nbr_image.Size = new System.Drawing.Size(47, 20);
            this.nbr_image.TabIndex = 17;
            this.nbr_image.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // box_lc
            // 
            this.box_lc.Controls.Add(this.l_nbrligne);
            this.box_lc.Controls.Add(this.l_nbrcolonne);
            this.box_lc.Controls.Add(this.nbr_colon);
            this.box_lc.Controls.Add(this.nb_ligne);
            this.box_lc.Location = new System.Drawing.Point(18, 12);
            this.box_lc.Name = "box_lc";
            this.box_lc.Size = new System.Drawing.Size(260, 87);
            this.box_lc.TabIndex = 18;
            this.box_lc.TabStop = false;
            // 
            // box_nb_image
            // 
            this.box_nb_image.Controls.Add(this.label2);
            this.box_nb_image.Controls.Add(this.nbr_image);
            this.box_nb_image.Location = new System.Drawing.Point(289, 179);
            this.box_nb_image.Name = "box_nb_image";
            this.box_nb_image.Size = new System.Drawing.Size(225, 56);
            this.box_nb_image.TabIndex = 19;
            this.box_nb_image.TabStop = false;
            // 
            // box_type_exam
            // 
            this.box_type_exam.Controls.Add(this.Combo_type);
            this.box_type_exam.Controls.Add(this.l_typ_exam);
            this.box_type_exam.Location = new System.Drawing.Point(18, 276);
            this.box_type_exam.Name = "box_type_exam";
            this.box_type_exam.Size = new System.Drawing.Size(260, 54);
            this.box_type_exam.TabIndex = 20;
            this.box_type_exam.TabStop = false;
            // 
            // box_nb_oct_valeur
            // 
            this.box_nb_oct_valeur.Controls.Add(this.l_nbroctet);
            this.box_nb_oct_valeur.Controls.Add(this.nbr_oct_valeur);
            this.box_nb_oct_valeur.Location = new System.Drawing.Point(289, 29);
            this.box_nb_oct_valeur.Name = "box_nb_oct_valeur";
            this.box_nb_oct_valeur.Size = new System.Drawing.Size(225, 51);
            this.box_nb_oct_valeur.TabIndex = 21;
            this.box_nb_oct_valeur.TabStop = false;
            // 
            // check_rvb
            // 
            this.check_rvb.AutoSize = true;
            this.check_rvb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_rvb.Location = new System.Drawing.Point(377, 12);
            this.check_rvb.Name = "check_rvb";
            this.check_rvb.Size = new System.Drawing.Size(51, 17);
            this.check_rvb.TabIndex = 22;
            this.check_rvb.Text = "RVB";
            this.check_rvb.UseVisualStyleBackColor = true;
            // 
            // Carateristiques_exam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 393);
            this.Controls.Add(this.check_rvb);
            this.Controls.Add(this.box_nb_oct_valeur);
            this.Controls.Add(this.box_type_exam);
            this.Controls.Add(this.box_nb_image);
            this.Controls.Add(this.box_lc);
            this.Controls.Add(this.b_annuler);
            this.Controls.Add(this.b_ok);
            this.Controls.Add(this.box_positif_negatif);
            this.Controls.Add(this.check_swap);
            this.Controls.Add(this.box_angle);
            this.Controls.Add(this.group_entete);
            this.Controls.Add(this.Box_carac_valeur);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Carateristiques_exam";
            this.Text = "Proprietés de l\'examen";
            this.Load += new System.EventHandler(this.Carateristiques_exam_Load);
            this.Box_carac_valeur.ResumeLayout(false);
            this.Box_carac_valeur.PerformLayout();
            this.group_entete.ResumeLayout(false);
            this.group_entete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taille)).EndInit();
            this.box_angle.ResumeLayout(false);
            this.box_angle.PerformLayout();
            this.box_positif_negatif.ResumeLayout(false);
            this.box_positif_negatif.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_ligne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbr_colon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbr_image)).EndInit();
            this.box_lc.ResumeLayout(false);
            this.box_lc.PerformLayout();
            this.box_nb_image.ResumeLayout(false);
            this.box_nb_image.PerformLayout();
            this.box_type_exam.ResumeLayout(false);
            this.box_type_exam.PerformLayout();
            this.box_nb_oct_valeur.ResumeLayout(false);
            this.box_nb_oct_valeur.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_nbrligne;
        private System.Windows.Forms.Label l_nbrcolonne;
        private System.Windows.Forms.Label l_nbroctet;
        private System.Windows.Forms.GroupBox Box_carac_valeur;
        private System.Windows.Forms.RadioButton radio_entier;
        private System.Windows.Forms.RadioButton radio_positif;
        private System.Windows.Forms.RadioButton radio_reel;
        private System.Windows.Forms.CheckBox check_swap;
        private System.Windows.Forms.RadioButton radio_pos_neg;
        private System.Windows.Forms.ComboBox nbr_oct_valeur;
        private System.Windows.Forms.GroupBox group_entete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radio_Fin;
        private System.Windows.Forms.RadioButton radio_début;
        private System.Windows.Forms.Label l_typ_exam;
        private System.Windows.Forms.ComboBox Combo_type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox box_angle;
        private System.Windows.Forms.RadioButton deupi;
        private System.Windows.Forms.RadioButton pi;
        private System.Windows.Forms.GroupBox box_positif_negatif;
        private System.Windows.Forms.Button b_ok;
        private System.Windows.Forms.Button b_annuler;
        private System.Windows.Forms.NumericUpDown nb_ligne;
        private System.Windows.Forms.NumericUpDown nbr_colon;
        private System.Windows.Forms.NumericUpDown nbr_image;
        private System.Windows.Forms.NumericUpDown taille;
        private System.Windows.Forms.GroupBox box_lc;
        private System.Windows.Forms.GroupBox box_nb_image;
        private System.Windows.Forms.GroupBox box_type_exam;
        private System.Windows.Forms.GroupBox box_nb_oct_valeur;
        private System.Windows.Forms.CheckBox check_rvb;
    }
}