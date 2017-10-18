using System.Windows.Forms;
namespace TIMed
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.barre_outils = new System.Windows.Forms.MenuStrip();
            this.fichier = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrir = new System.Windows.Forms.ToolStripMenuItem();
            this.fermer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.enregistrerSous = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.imprimer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.selectionnerToutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconstructionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mLEMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.aSIRTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.oSEM2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_8 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_16 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_32 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_64 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_128 = new System.Windows.Forms.ToolStripMenuItem();
            this.fenêtreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiimagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.explorateurDimagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sous_barre = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.ouvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.s_enregistrersous = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.s_copier = new System.Windows.Forms.ToolStripButton();
            this.s_imprimer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.s_zoomarriere = new System.Windows.Forms.ToolStripButton();
            this.s_zoomavant = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.palette_gris = new System.Windows.Forms.ToolStripButton();
            this.palette_rouge = new System.Windows.Forms.ToolStripButton();
            this.palette_verte = new System.Windows.Forms.ToolStripButton();
            this.palette_bleue = new System.Windows.Forms.ToolStripButton();
            this.palette_aec = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.film_avant = new System.Windows.Forms.ToolStripButton();
            this.film_stop = new System.Windows.Forms.ToolStripButton();
            this.ouvrir_fichier = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.barre_outils.SuspendLayout();
            this.sous_barre.SuspendLayout();
            this.SuspendLayout();
            // 
            // barre_outils
            // 
            this.barre_outils.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichier,
            this.editionToolStripMenuItem,
            this.reconstructionToolStripMenuItem,
            this.fenêtreToolStripMenuItem,
            this.aideToolStripMenuItem});
            resources.ApplyResources(this.barre_outils, "barre_outils");
            this.barre_outils.Name = "barre_outils";
            // 
            // fichier
            // 
            this.fichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouvrir,
            this.fermer,
            this.toolStripSeparator1,
            this.enregistrerSous,
            this.toolStripSeparator4,
            this.imprimer,
            this.toolStripSeparator2,
            this.quitterToolStripMenuItem});
            this.fichier.Name = "fichier";
            resources.ApplyResources(this.fichier, "fichier");
            // 
            // ouvrir
            // 
            this.ouvrir.Image = global::TIMed.Properties.Resources.image_add;
            this.ouvrir.Name = "ouvrir";
            resources.ApplyResources(this.ouvrir, "ouvrir");
            this.ouvrir.Click += new System.EventHandler(this.ouvrirToolStripMenuItem_Click);
            // 
            // fermer
            // 
            resources.ApplyResources(this.fermer, "fermer");
            this.fermer.Image = global::TIMed.Properties.Resources.fermer;
            this.fermer.Name = "fermer";
            this.fermer.Click += new System.EventHandler(this.fermer_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // enregistrerSous
            // 
            resources.ApplyResources(this.enregistrerSous, "enregistrerSous");
            this.enregistrerSous.Image = global::TIMed.Properties.Resources.MenuFileSaveAsIcon;
            this.enregistrerSous.Name = "enregistrerSous";
            this.enregistrerSous.Click += new System.EventHandler(this.enregistrerSous_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // imprimer
            // 
            resources.ApplyResources(this.imprimer, "imprimer");
            this.imprimer.Image = global::TIMed.Properties.Resources.printer;
            this.imprimer.Name = "imprimer";
            this.imprimer.Click += new System.EventHandler(this.imprimer_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Image = global::TIMed.Properties.Resources.sortir;
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            resources.ApplyResources(this.quitterToolStripMenuItem, "quitterToolStripMenuItem");
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // editionToolStripMenuItem
            // 
            this.editionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copierToolStripMenuItem,
            this.toolStripSeparator3,
            this.selectionnerToutToolStripMenuItem});
            this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            resources.ApplyResources(this.editionToolStripMenuItem, "editionToolStripMenuItem");
            // 
            // copierToolStripMenuItem
            // 
            resources.ApplyResources(this.copierToolStripMenuItem, "copierToolStripMenuItem");
            this.copierToolStripMenuItem.Image = global::TIMed.Properties.Resources.page_copy1;
            this.copierToolStripMenuItem.Name = "copierToolStripMenuItem";
            this.copierToolStripMenuItem.Click += new System.EventHandler(this.copierToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // selectionnerToutToolStripMenuItem
            // 
            resources.ApplyResources(this.selectionnerToutToolStripMenuItem, "selectionnerToutToolStripMenuItem");
            this.selectionnerToutToolStripMenuItem.Name = "selectionnerToutToolStripMenuItem";
            this.selectionnerToutToolStripMenuItem.Click += new System.EventHandler(this.selectionnerToutToolStripMenuItem_Click);
            // 
            // reconstructionToolStripMenuItem
            // 
            this.reconstructionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mLEMToolStripMenuItem,
            this.toolStripSeparator9,
            this.aSIRTToolStripMenuItem,
            this.toolStripSeparator8,
            this.oSEM2ToolStripMenuItem});
            resources.ApplyResources(this.reconstructionToolStripMenuItem, "reconstructionToolStripMenuItem");
            this.reconstructionToolStripMenuItem.Name = "reconstructionToolStripMenuItem";
            // 
            // mLEMToolStripMenuItem
            // 
            this.mLEMToolStripMenuItem.Name = "mLEMToolStripMenuItem";
            resources.ApplyResources(this.mLEMToolStripMenuItem, "mLEMToolStripMenuItem");
            this.mLEMToolStripMenuItem.Click += new System.EventHandler(this.mLEMToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // aSIRTToolStripMenuItem
            // 
            this.aSIRTToolStripMenuItem.Name = "aSIRTToolStripMenuItem";
            resources.ApplyResources(this.aSIRTToolStripMenuItem, "aSIRTToolStripMenuItem");
            this.aSIRTToolStripMenuItem.Click += new System.EventHandler(this.aSIRTToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // oSEM2ToolStripMenuItem
            // 
            this.oSEM2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_1,
            this.tool_2,
            this.tool_4,
            this.tool_8,
            this.tool_16,
            this.tool_32,
            this.tool_64,
            this.tool_128});
            this.oSEM2ToolStripMenuItem.Name = "oSEM2ToolStripMenuItem";
            resources.ApplyResources(this.oSEM2ToolStripMenuItem, "oSEM2ToolStripMenuItem");
            this.oSEM2ToolStripMenuItem.MouseEnter += new System.EventHandler(this.oSEM2ToolStripMenuItem_MouseEnter);
            // 
            // tool_1
            // 
            this.tool_1.Name = "tool_1";
            resources.ApplyResources(this.tool_1, "tool_1");
            this.tool_1.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // tool_2
            // 
            this.tool_2.Name = "tool_2";
            resources.ApplyResources(this.tool_2, "tool_2");
            this.tool_2.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // tool_4
            // 
            this.tool_4.Name = "tool_4";
            resources.ApplyResources(this.tool_4, "tool_4");
            this.tool_4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // tool_8
            // 
            this.tool_8.Name = "tool_8";
            resources.ApplyResources(this.tool_8, "tool_8");
            this.tool_8.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // tool_16
            // 
            this.tool_16.Name = "tool_16";
            resources.ApplyResources(this.tool_16, "tool_16");
            this.tool_16.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // tool_32
            // 
            this.tool_32.Name = "tool_32";
            resources.ApplyResources(this.tool_32, "tool_32");
            this.tool_32.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // tool_64
            // 
            this.tool_64.Name = "tool_64";
            resources.ApplyResources(this.tool_64, "tool_64");
            this.tool_64.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // tool_128
            // 
            this.tool_128.Name = "tool_128";
            resources.ApplyResources(this.tool_128, "tool_128");
            this.tool_128.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // fenêtreToolStripMenuItem
            // 
            this.fenêtreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outilsToolStripMenuItem,
            this.multiimagesToolStripMenuItem,
            this.toolStripSeparator7,
            this.explorateurDimagesToolStripMenuItem});
            this.fenêtreToolStripMenuItem.Name = "fenêtreToolStripMenuItem";
            resources.ApplyResources(this.fenêtreToolStripMenuItem, "fenêtreToolStripMenuItem");
            // 
            // outilsToolStripMenuItem
            // 
            this.outilsToolStripMenuItem.Checked = true;
            this.outilsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.outilsToolStripMenuItem, "outilsToolStripMenuItem");
            this.outilsToolStripMenuItem.Name = "outilsToolStripMenuItem";
            this.outilsToolStripMenuItem.Click += new System.EventHandler(this.outilsToolStripMenuItem_Click);
            // 
            // multiimagesToolStripMenuItem
            // 
            this.multiimagesToolStripMenuItem.Checked = true;
            this.multiimagesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.multiimagesToolStripMenuItem, "multiimagesToolStripMenuItem");
            this.multiimagesToolStripMenuItem.Name = "multiimagesToolStripMenuItem";
            this.multiimagesToolStripMenuItem.Click += new System.EventHandler(this.multiimagesToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // explorateurDimagesToolStripMenuItem
            // 
            this.explorateurDimagesToolStripMenuItem.Checked = true;
            this.explorateurDimagesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.explorateurDimagesToolStripMenuItem.Name = "explorateurDimagesToolStripMenuItem";
            resources.ApplyResources(this.explorateurDimagesToolStripMenuItem, "explorateurDimagesToolStripMenuItem");
            this.explorateurDimagesToolStripMenuItem.Click += new System.EventHandler(this.explorateurDimagesToolStripMenuItem_Click);
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aProposToolStripMenuItem});
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            resources.ApplyResources(this.aideToolStripMenuItem, "aideToolStripMenuItem");
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            resources.ApplyResources(this.aProposToolStripMenuItem, "aProposToolStripMenuItem");
            this.aProposToolStripMenuItem.Click += new System.EventHandler(this.aProposToolStripMenuItem_Click);
            // 
            // sous_barre
            // 
            this.sous_barre.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.sous_barre.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.s_enregistrersous,
            this.toolStripSeparator5,
            this.s_copier,
            this.s_imprimer,
            this.toolStripSeparator6,
            this.s_zoomarriere,
            this.s_zoomavant,
            this.toolStripSeparator10,
            this.palette_gris,
            this.palette_rouge,
            this.palette_verte,
            this.palette_bleue,
            this.palette_aec,
            this.toolStripSeparator11,
            this.film_avant,
            this.film_stop});
            resources.ApplyResources(this.sous_barre, "sous_barre");
            this.sous_barre.Name = "sous_barre";
            this.sous_barre.Stretch = true;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouvrirToolStripMenuItem});
            this.toolStripButton1.Image = global::TIMed.Properties.Resources.image_add;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            // 
            // ouvrirToolStripMenuItem
            // 
            this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
            resources.ApplyResources(this.ouvrirToolStripMenuItem, "ouvrirToolStripMenuItem");
            this.ouvrirToolStripMenuItem.Click += new System.EventHandler(this.ouvrirToolStripMenuItem_Click_1);
            // 
            // s_enregistrersous
            // 
            this.s_enregistrersous.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.s_enregistrersous, "s_enregistrersous");
            this.s_enregistrersous.Image = global::TIMed.Properties.Resources.MenuFileSaveAsIcon;
            this.s_enregistrersous.Name = "s_enregistrersous";
            this.s_enregistrersous.Click += new System.EventHandler(this.s_enregistrersous_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // s_copier
            // 
            this.s_copier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.s_copier, "s_copier");
            this.s_copier.Image = global::TIMed.Properties.Resources.page_copy;
            this.s_copier.Name = "s_copier";
            this.s_copier.Click += new System.EventHandler(this.s_copier_Click);
            // 
            // s_imprimer
            // 
            this.s_imprimer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.s_imprimer, "s_imprimer");
            this.s_imprimer.Image = global::TIMed.Properties.Resources.printer;
            this.s_imprimer.Name = "s_imprimer";
            this.s_imprimer.Click += new System.EventHandler(this.s_imprimer_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // s_zoomarriere
            // 
            this.s_zoomarriere.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.s_zoomarriere, "s_zoomarriere");
            this.s_zoomarriere.Image = global::TIMed.Properties.Resources.zomm_out;
            this.s_zoomarriere.Name = "s_zoomarriere";
            this.s_zoomarriere.Click += new System.EventHandler(this.s_zoomarriere_Click);
            // 
            // s_zoomavant
            // 
            this.s_zoomavant.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.s_zoomavant, "s_zoomavant");
            this.s_zoomavant.Image = global::TIMed.Properties.Resources.zoom_in;
            this.s_zoomavant.Name = "s_zoomavant";
            this.s_zoomavant.Click += new System.EventHandler(this.s_zoomavant_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
            // 
            // palette_gris
            // 
            this.palette_gris.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.palette_gris, "palette_gris");
            this.palette_gris.Image = global::TIMed.Properties.Resources.gris;
            this.palette_gris.Name = "palette_gris";
            this.palette_gris.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // palette_rouge
            // 
            this.palette_rouge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.palette_rouge, "palette_rouge");
            this.palette_rouge.Image = global::TIMed.Properties.Resources.rouge;
            this.palette_rouge.Name = "palette_rouge";
            this.palette_rouge.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // palette_verte
            // 
            this.palette_verte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.palette_verte, "palette_verte");
            this.palette_verte.Image = global::TIMed.Properties.Resources.vert;
            this.palette_verte.Name = "palette_verte";
            this.palette_verte.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // palette_bleue
            // 
            this.palette_bleue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.palette_bleue, "palette_bleue");
            this.palette_bleue.Image = global::TIMed.Properties.Resources.bleu;
            this.palette_bleue.Name = "palette_bleue";
            this.palette_bleue.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // palette_aec
            // 
            this.palette_aec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.palette_aec, "palette_aec");
            this.palette_aec.Image = global::TIMed.Properties.Resources.couleur;
            this.palette_aec.Name = "palette_aec";
            this.palette_aec.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            // 
            // film_avant
            // 
            this.film_avant.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.film_avant, "film_avant");
            this.film_avant.Image = global::TIMed.Properties.Resources.film_go;
            this.film_avant.Name = "film_avant";
            this.film_avant.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // film_stop
            // 
            this.film_stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.film_stop, "film_stop");
            this.film_stop.Image = global::TIMed.Properties.Resources.film_delete;
            this.film_stop.Name = "film_stop";
            this.film_stop.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // ouvrir_fichier
            // 
            this.ouvrir_fichier.FilterIndex = 9;
            resources.ApplyResources(this.ouvrir_fichier, "ouvrir_fichier");
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.sous_barre);
            this.Controls.Add(this.barre_outils);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.barre_outils;
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.barre_outils.ResumeLayout(false);
            this.barre_outils.PerformLayout();
            this.sous_barre.ResumeLayout(false);
            this.sous_barre.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip barre_outils;
        private System.Windows.Forms.ToolStripMenuItem fichier;
        private System.Windows.Forms.ToolStripMenuItem ouvrir;
        private System.Windows.Forms.ToolStripMenuItem fermer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem enregistrerSous;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectionnerToutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem fenêtreToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem outilsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStrip sous_barre;
        private System.Windows.Forms.ToolStripButton s_enregistrersous;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton s_copier;
        private System.Windows.Forms.ToolStripButton s_imprimer;
        private System.Windows.Forms.ToolStripButton s_zoomavant;
        private System.Windows.Forms.ToolStripButton s_zoomarriere;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.OpenFileDialog ouvrir_fichier;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ToolStripMenuItem explorateurDimagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        public System.Windows.Forms.ToolStripMenuItem multiimagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem ouvrirToolStripMenuItem;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public ToolStripMenuItem reconstructionToolStripMenuItem;
        private ToolStripMenuItem mLEMToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem aSIRTToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem oSEM2ToolStripMenuItem;
        private ToolStripMenuItem tool_1;
        private ToolStripMenuItem tool_2;
        private ToolStripMenuItem tool_4;
        private ToolStripMenuItem tool_8;
        private ToolStripMenuItem tool_16;
        private ToolStripMenuItem tool_32;
        private ToolStripMenuItem tool_64;
        private ToolStripMenuItem tool_128;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripButton palette_bleue;
        private ToolStripButton palette_rouge;
        private ToolStripButton palette_gris;
        private ToolStripButton palette_verte;
        private ToolStripButton palette_aec;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripButton film_avant;
        private ToolStripButton film_stop;
    }
}

