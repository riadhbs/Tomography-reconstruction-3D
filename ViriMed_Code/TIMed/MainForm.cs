using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;



namespace TIMed
{
    public  partial class MainForm : Form
    {
        public static string chemin = Application.StartupPath + "\\travail\\travail";
        public enum ImageSettings { FullPage, FullPageWithMargin, OriginalSize, OriginalSizeCentered }
        public Outils outl;
        public static string palette_par_defaut = Application.StartupPath + "\\utilitaire\\BMPpalc.pal";
        public string currentFileName = "";
        public static int num_forme_creer = 0;
        public static int nb_forme_cree = 0;
        public ListeImage l_image;
        public static ImageBox forme_active;
        public bool etat = true;
        public Carateristiques_exam caract;
        private ImageSettings _settings = ImageSettings.OriginalSize;
        public Multi_images multi;
        public bool etat2 = true;
        public bool etat3 = true;
        public  static bool btofront = false;
        


        #region constructeur

        /// <summary>
        /// constrcuteur
        /// </summary>
        /// 
        public MainForm()
        {

            InitializeComponent();
            
            outl = new Outils(this);
            multi = new Multi_images(this);
            l_image = new ListeImage(this);
            init();

        }

        #endregion

        
        #region procedure_fonction

        /// <summary>
        /// localiser la fenetre
        /// </summary>

        public void init()
        {
            
           
            this.Height = this.Height - 10; this.Width = this.Width - 10;

           
            outl.MdiParent = this;
            multi.MdiParent = this;

            this.Controls.Add(l_image);


        }

        /// <summary>
        /// retourner le format
        /// </summary>
        /// <returns></returns>

        public ImageFormat GetImageFormat()
        {
            switch (saveFileDialog1.FilterIndex)
            {
                case 1:
                    return ImageFormat.MemoryBmp;
                case 2:
                    return ImageFormat.Jpeg;
                case 3:
                    return ImageFormat.Gif;
                default:
                    return ImageFormat.Tiff;
            }
        }

        /// <summary>
        /// activer les fonctionalité de la barre d'outil et de la sous barre
        /// </summary>
        /// <param name="enable"></param>

        public void activer_fonctionalité(bool enable)
        {
            fermer.Enabled = enable;
            enregistrerSous.Enabled = enable;
            imprimer.Enabled = enable;
            copierToolStripMenuItem.Enabled = enable;
            selectionnerToutToolStripMenuItem.Enabled = enable;
            
            s_copier.Enabled = enable;
            s_enregistrersous.Enabled = enable;
            s_imprimer.Enabled = enable;
            s_zoomarriere.Enabled = enable;
            s_zoomavant.Enabled = enable;
            outilsToolStripMenuItem.Enabled = enable;
            multiimagesToolStripMenuItem.Enabled = enable;
            palette_aec.Enabled = enable;
            palette_rouge.Enabled = enable;
            palette_bleue.Enabled = enable;
            palette_verte.Enabled = enable;
            palette_gris.Enabled = enable;
            film_avant.Enabled = enable;
            film_stop.Enabled = enable;
           


        }

        

        #endregion


        #region action

        /// <summary>
        /// ouvrir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
                                    
            ouvrir_fichier.Filter = "BMP (*.bmp)|*.bmp|JPEG (*.jpg,*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png|TIFF (*.tiff*.tif)|*.tif|GIF (*.gif)|*.gif|S (*.s)|*.s|BIM (*.bim)|*.bim|DICOM (*.dcm,*.dc3,*.dic)|*.dcm;*.dc3;*.dic|Tous les formats (*.*)|*.*";

            if (ouvrir_fichier.ShowDialog() == DialogResult.OK)
            {
               
                
                if (nb_forme_cree == 0)
                    activer_fonctionalité(true);

                currentFileName = ouvrir_fichier.FileName;
                int num_type = 0;
                try
                {
                    num_type = Util.type_fichier(ouvrir_fichier.FileName);
                }
                catch (Exception ex1)
                {
                    string msg_2 = "Fichier invalide";
                    MessageBox.Show(msg_2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    activer_fonctionalité(false);
                    return;
                }

                //bool type = Util.type_dicom(currentFileName);
                switch (num_type)
                {
                    case 1:
                        MainForm.btofront = false;
                        ImageBox childform = new ImageBox(this, currentFileName);
                        
                        
                        childform.MdiParent = this;
                        childform.Show();
                        childform.BringToFront();
                        
                        try
                        {
                            childform.afficher_image(ouvrir_fichier.FileName);
                        }
                        catch (Exception ex2)
                        {
                            string msg_3 = "Fichier invalide";
                            MessageBox.Show(msg_3, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            childform.Dispose();
                            activer_fonctionalité(false);
                            return;
                        }
                        nb_forme_cree++;
                        l_image.ajouterfichier(ouvrir_fichier.FileName);
                        
                       
                            string msg = "Vous ne pouvez pas appliquer des modifications pour ce type de fichiers!\n";
                            MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        break;
                    case 2:
                    case 3:
                        MessageBox.Show("Veuillez entrer les paramètres nécessaires du fichier \"" + ouvrir_fichier.SafeFileName + "\" pour l’ouvrir", "Notification",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                        caract = new Carateristiques_exam(this, num_type);
                        caract.ShowDialog();

                        if (MainForm.forme_active!=null)  MainForm.forme_active.BringToFront();
                                          
                        break;
                    case 4:
                        MainForm.btofront = false;
                        int l = 0;
                        try
                        {

                            l = Util.nb_ligne_s(this.currentFileName);
                        }
                        catch (Exception exx)
                        {
                            string msg_1 = "Fichier invalide";
                            MessageBox.Show(msg_1, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            activer_fonctionalité(false);

                            return;
                        }
                        Examen examen = new Examen(l, Util.nb_ligne_s(this.currentFileName), Util.nb_image_s(this.currentFileName), Util.type_exam_s(this.currentFileName), true,
                        true, false, 512, true, 2, true,false);
                        ImageBox child = new ImageBox(examen, this, this.currentFileName);
                        MainForm.nb_forme_cree++;
                        child.MdiParent = this;
                        child.Show();
                        child.BringToFront();
                       
                        string s = Util.conversion_S_to_bim(MainForm.forme_active.nom_fichier);

                        Util.créer_image(Util.créer_tableu_valeur_pour_palette(MainForm.palette_par_defaut), Util.nb_ligne_s(MainForm.forme_active.nom_fichier), Util.nb_ligne_s(MainForm.forme_active.nom_fichier),
                            s, MainForm.forme_active.nom_dossier);
                        MainForm.forme_active.afficher_image_bim();

                        this.l_image.ajouterfichier(MainForm.forme_active.nom_fichier);

                        Util.créer_image_palette(Util.créer_tableu_valeur_pour_palette(MainForm.palette_par_defaut), MainForm.forme_active.nom_dossier);
                        MainForm.forme_active.afficher_image_palette();
                        break;

                    case 5:
                            MainForm.btofront = false;

                            int l1 = Util.nb_ligne_bmp(this.currentFileName);
                            int c1 = Util.nb_colon_bmp(this.currentFileName);
                            Examen examen1 = new Examen(l1, c1, 1, Examen.type_examen.statique, true,
                            false, true, 1078, false, 1, false,false);
                            ImageBox child1 = new ImageBox(examen1, this, this.currentFileName);
                            MainForm.nb_forme_cree++;
                            child1.MdiParent = this;
                            child1.Show();
                            child1.BringToFront();
                            MainForm.forme_active.bmp256 = true;
                            string s2 = Util.convrsion_BMP_to_bim(MainForm.forme_active.nom_fichier);
                            Util.créer_image(Util.créer_tableu_valeur_pour_palette(MainForm.palette_par_defaut), l1, c1,
                                s2, MainForm.forme_active.nom_dossier);
                            MainForm.forme_active.afficher_image_bim();

                            this.l_image.ajouterfichier(MainForm.forme_active.nom_fichier);

                            Util.créer_image_palette(Util.créer_tableu_valeur_pour_palette(MainForm.palette_par_defaut), MainForm.forme_active.nom_dossier);
                            MainForm.forme_active.afficher_image_palette();
                        
                       
                        break;

                    case 6:
                        
                        MainForm.btofront = false;
                        try
                        {
                            Dicom.info_DCM(this.currentFileName);
                        }
                        catch (Exception ex4)
                        {
                            string msg_5 = "Fichier invalide";
                            MessageBox.Show(msg_5, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            activer_fonctionalité(false);

                            return;
                        }
                        bool rvb = false;
                        if (Dicom.m == 2) rvb = true;
                        else
                        {
                            if ((Dicom.m == 0) || (Dicom.m == 1))
                                rvb = false;
                        }

                        if (Dicom.m == 4)
                        {
                            string msg_6 = "Fichier compressé, affichage impossible!";
                            MessageBox.Show(msg_6, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //activer_fonctionalité(false);
                            return;
                        }
                        if (Dicom.m == 3)
                        {
                            string msg_6 = "PaletteColor, affichage impossible!";
                            MessageBox.Show(msg_6, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //activer_fonctionalité(false);
                            return;
                        }

                        int tail = Dicom.tail_entet;// (int)(((int)new System.IO.FileInfo(currentFileName).Length) - (Dicom.nb_colon * Dicom.nb_ligne * Dicom.nbr_oct_valeur));
                        Examen.type_examen type_ex;
                        if (Dicom.n == 5)
                        {
                            type_ex = Examen.type_examen.tomographique;
                        }
                        else
                        {

                            if (Dicom.n == 6)
                            {
                                type_ex = Examen.type_examen.dynamique;
                            }
                            else
                            {

                                if (Dicom.n == 7)
                                {
                                    type_ex = Examen.type_examen.synchronisé;
                                }
                                else
                                { type_ex = Examen.type_examen.statique; }
                            }
                        }
                            Examen examen2 = new Examen(Dicom.nb_ligne, Dicom.nb_colon, Dicom.nb_image,type_ex/* Examen.type_examen.tomographique*/, true,
                            false, true, tail, false, Dicom.nbr_oct_valeur, false, rvb);

                            ImageBox child2 = new ImageBox(examen2, this, this.currentFileName);
                        
                        MainForm.nb_forme_cree++;
                        child2.MdiParent = this;
                        child2.Show();
                        string palette = Application.StartupPath + "\\utilitaire\\";
                        string palette_négatif=Application.StartupPath + "\\utilitaire\\";
                        string s3=null;
                        if (Dicom.m == 2)
                        {
                            palette += "BMPpalc.pal";
                            MainForm.forme_active.afficher_image_rvb();
                            string msg1 = "Image RVB, vous ne pourriez appliquer aucun traitement sur ce type d’examen!";
                            MessageBox.Show(msg1, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            
                                s3 = Util.convrsion_DCM_bim(MainForm.forme_active.nom_fichier);
                                if (s3 == null)
                                {
                                    return;
                                }
                                
                                                                           
                            
                            if (Dicom.m == 0)
                            { 
                                palette += "BMPpalg.pal";
                                palette_négatif+="BMPpalgn.pal";
                                
                                
                              
                            }
                            if (Dicom.m == 1)
                            { 
                                palette += "BMPpalgn.pal";
                                palette_négatif+="BMPpalg.pal";

                            }
                        }
                        child2.palette_non_negatif = palette;
                        child2.palette_negatif = palette_négatif;
                        

                        if ((Dicom.m == 0) || (Dicom.m == 1))
                        {
                            Util.créer_image(Util.créer_tableu_valeur_pour_palette(palette), Dicom.nb_ligne, Dicom.nb_colon,
                            s3, MainForm.forme_active.nom_dossier);
                            MainForm.forme_active.afficher_image_bim();
                        }

                        this.l_image.ajouterfichier(MainForm.forme_active.nom_fichier);

                        Util.créer_image_palette(Util.créer_tableu_valeur_pour_palette(palette), MainForm.forme_active.nom_dossier);
                        MainForm.forme_active.afficher_image_palette();

                        break;
                 
                }


                   
                
                //si on a appuier sur annuler dans la forme caracteristique
                if (etat3 == false) { etat3 = true; return; }
                
                if ((MainForm.forme_active.caracteristique_exam != null) && (MainForm.forme_active.caracteristique_exam.type_ex == Examen.type_examen.tomographique) && (reconstructionToolStripMenuItem.Enabled == false))
                {
                    reconstructionToolStripMenuItem.Enabled = true;
                }
                
                if (etat == false)
                {
                    outl = new Outils(this);
                    outl.MdiParent = this;
                    etat = true;
                    
                }
                if (etat2 == false)
                {
                    multi = new Multi_images(this);
                    multi.MdiParent = this;
                    etat2 = true;
                }
                outilsToolStripMenuItem.Checked = true;
                multiimagesToolStripMenuItem.Checked = true;
                outl.Show();
                multi.Show();
                //this.ActivateMdiChild(MainForm.forme_active);
                    
               
            }
        }
        
        /// <summary>
        /// quitter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        

        /// <summary>
        /// fermer fenetre de l'image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void fermer_Click(object sender, EventArgs e)
        {
            if (MainForm.forme_active == null)
            {
                string msg = "Appuyer d'abord une fenêtre d'examen";
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            forme_active.fermer();
            //l_image.fermer_fichier(forme_active.nom_fichier);

        }

        /// <summary>
        /// enregistrer sous
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void enregistrerSous_Click(object sender, EventArgs e)
        {
            
            if (MainForm.forme_active == null)
            {
                string msg = "Activer d'abord une fenêtre d'examen";
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MainForm.forme_active.b_image.Image == null)
            {
                return;
            }
            
            saveFileDialog1.FileName = "MonImage";
            saveFileDialog1.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg;*.jpeg|" +
                "GIF (*.gif)|*.gif|TIF (*.tif)|*.tif";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (forme_active.enregistrer_image(saveFileDialog1.FileName, GetImageFormat()))
                    MessageBox.Show("Image enregistrée...", "Enregistrement d'image",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Une erreur est survenue lors du sauvegarde."
                        , Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// imprimer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void imprimer_Click(object sender, EventArgs e)
        {
            if (MainForm.forme_active == null)
            {
                string msg = "Activer d'abord une fenêtre d'examen";
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MainForm.forme_active.b_image.Image == null)
            {
                return;
            }
            printDialog1.Document = printDocument1;
            if (this.printDialog1.ShowDialog() == DialogResult.OK)
            {

                this.printDocument1.Print();
            }
        }

        /// <summary>
        /// suite_imprimer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle bounds = new Rectangle(0, 0, 0, 0);

            switch (_settings)
            {
                case ImageSettings.FullPage:
                    bounds = new Rectangle(0, 0, e.PageBounds.Width, e.PageBounds.Height);
                    break;
                case ImageSettings.FullPageWithMargin:
                    bounds = new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width, e.MarginBounds.Height);
                    break;
                case ImageSettings.OriginalSize:
                    bounds = new Rectangle(10, 10, forme_active.b_image.Image.Width, forme_active.b_image.Image.Height);
                    break;
                case ImageSettings.OriginalSizeCentered:
                    bounds = new Rectangle((e.PageBounds.Width - forme_active.b_image.Image.Width) / 2, (e.PageBounds.Height - forme_active.b_image.Image.Height) / 2, forme_active.b_image.Image.Width, forme_active.b_image.Image.Height);
                    break;
            }


            e.Graphics.DrawImage(forme_active.b_image.Image, bounds);

        }

        /// <summary>
        /// quitter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
            try
            {
                Directory.Delete(Application.StartupPath + "\\travail", true);
            }
            catch (Exception ex)
            {
                string msg = "Le Dossier de travail est introuvable!\n" + "possibilité d'être déplacé ou supprimé";
                MessageBox.Show(msg, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                     
           
        }
        /// <summary>
        /// copier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void copierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            l_image.CopySelectedFilesToClipboard();
        }

        /// <summary>
        /// selectionner tout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void selectionnerToutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            l_image.SelectAllFiles();
        }
        /// <summary>
        /// afficher/masquer outil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void outilsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.etat == true)
            {
                if (outilsToolStripMenuItem.Checked == true)
                {
                    outilsToolStripMenuItem.Checked = false;
                    outl.Hide();
                   
                }
                else
                {
                    outilsToolStripMenuItem.Checked = true;
                    outl.Show();
                   
                }
            }
            else
            {
                outilsToolStripMenuItem.Checked = true;
                outl = new Outils(this);
                outl.Show();
                outl.MdiParent = this;
                
                this.etat = true;
                
            }

        }

        /// <summary>
        /// a propos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            A_propos p = new A_propos();
            p.ShowDialog();

        }
        

       
        /// <summary>
        /// enregistrer sous
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void s_enregistrersous_Click(object sender, EventArgs e)
        {
            enregistrerSous_Click(sender, e);
        }
        /// <summary>
        /// copier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void s_copier_Click(object sender, EventArgs e)
        {
            copierToolStripMenuItem_Click(sender, e);
        }
        /// <summary>
        /// imprimer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void s_imprimer_Click(object sender, EventArgs e)
        {
            imprimer_Click(sender, e);
        }

        /// <summary>
        /// lor de l'ouverture de la forme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }

        /// <summary>
        /// zoooooom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void s_zoomarriere_Click(object sender, EventArgs e)
        {
            if (MainForm.forme_active == null)
            {
                string msg = "Appuyer d'abord sur une fenêtre d'examen";
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MainForm.forme_active.zoom > 1)
            {
                MainForm.forme_active.zoom--;
                this.outl.zoom.Value =(decimal) MainForm.forme_active.zoom;
                MainForm.forme_active.Zoom(MainForm.forme_active.zoom);
            }
            
        }
        /// <summary>
        /// afficher masquer l'explorateur d'image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void explorateurDimagesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.explorateurDimagesToolStripMenuItem.Checked == true)
            {
                explorateurDimagesToolStripMenuItem.Checked = false;
                l_image.Hide();
            }
            else
            {
                explorateurDimagesToolStripMenuItem.Checked = true;
                l_image.Show();


            }

        }

        /// <summary>
        /// cacher/afficher multi _image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void multiimagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.etat2 == true)
            {
                if (multiimagesToolStripMenuItem.Checked == true)
                {
                    multiimagesToolStripMenuItem.Checked = false;
                    multi.Hide();

                }
                else
                {
                    multiimagesToolStripMenuItem.Checked = true;
                    multi.Show();

                }
            }
            else
            {
                multiimagesToolStripMenuItem.Checked = true;
                multi = new Multi_images(this);
                multi.Show();
                multi.MdiParent = this;
                this.etat2 = true;

            }
        }

        /// <summary>
        /// zoooooooooom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void s_zoomavant_Click(object sender, EventArgs e)
        {
            if (MainForm.forme_active == null)
            {
                string msg = "Appuyer d'abord sur une fenêtre d'examen";
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MainForm.forme_active.zoom < 5)
            {
                MainForm.forme_active.zoom++;
                this.outl.zoom.Value =(decimal) MainForm.forme_active.zoom;
                MainForm.forme_active.Zoom(MainForm.forme_active.zoom);
            }
        }

        /// <summary>
        /// ouvrir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ouvrirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ouvrirToolStripMenuItem_Click(sender, e);

        }


        #endregion

        private void mLEMToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            
            Reconstruction.capteur = 1;
            Reconstruction form = new Reconstruction(this);
            form.Text = "MLEM";
            form.ShowDialog();
            MainForm.forme_active.BringToFront();
            
            
                       

        }

        private void aSIRTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reconstruction.capteur = 2;
            Reconstruction form = new Reconstruction(this);
            form.Text = "ASIRT";
            form.ShowDialog();
            MainForm.forme_active.BringToFront();
        }

        

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Directory.Delete(Application.StartupPath + "\\travail", true);
            }
            catch (Exception ex)
            {
                string msg = "Le Dossier de travail est introuvable!\n" + "possibilité d'être déplacé ou supprimé";
                MessageBox.Show(msg, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Reconstruction.capteur = 3;
            Reconstruction form = new Reconstruction(this);
            form.Text = "OSEM_1";
            form.ShowDialog();
            MainForm.forme_active.BringToFront();

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Reconstruction.capteur = 4;
            Reconstruction form = new Reconstruction(this);
            form.Text = "OSEM_2";
            form.ShowDialog();
            MainForm.forme_active.BringToFront();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Reconstruction.capteur = 5;
            Reconstruction form = new Reconstruction(this);
            form.Text = "OSEM_4";
            form.ShowDialog();
            MainForm.forme_active.BringToFront();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Reconstruction.capteur = 6;
            Reconstruction form = new Reconstruction(this);
            form.Text = "OSEM_8";
            form.ShowDialog();
            MainForm.forme_active.BringToFront();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Reconstruction.capteur = 7;
            Reconstruction form = new Reconstruction(this);
            form.Text = "OSEM_16";
            form.ShowDialog();
            MainForm.forme_active.BringToFront();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Reconstruction.capteur = 8;
            Reconstruction form = new Reconstruction(this);
            form.Text = "OSEM_32";
            form.ShowDialog();
            MainForm.forme_active.BringToFront();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Reconstruction.capteur = 9;
            Reconstruction form = new Reconstruction(this);
            form.Text = "OSEM_64";
            form.ShowDialog();
            MainForm.forme_active.BringToFront();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Reconstruction.capteur = 10;
            Reconstruction form = new Reconstruction(this);
            form.Text = "OSEM_128";
            form.ShowDialog();
            MainForm.forme_active.BringToFront();
        }

        private void oSEM2ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            int n =(int)( Math.Log(MainForm.forme_active.caracteristique_exam.nb_image) / Math.Log(2));

            if (n <= 7) desactiver_activer_osem(n, false);
            
        }

        public  void desactiver_activer_osem(int n,bool enable)
        {
            tool_128.Enabled = false;
            if (n < 7) tool_64.Enabled = enable;
            else return;
            if (n < 6) tool_32.Enabled = enable;
            else return;
            if (n < 5) tool_16.Enabled = enable;
            else return;
            if (n < 4) tool_8.Enabled = enable;
            else return;
            if (n < 3) tool_4.Enabled = enable;
            else return;
            if (n < 2) tool_2.Enabled = enable;
            else return;
         
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            outl.b_gris_Click(sender, e);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            outl.b_rouge_Click(sender, e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            outl.b_vert_Click(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            outl.b_bleu_Click(sender, e);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            outl.b_couleur_Click(sender, e);

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            multi.button2_Click(sender, e);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            multi.button3_Click(sender, e);
        }

              

        

        
                 
        #region util
        //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        //this.b_image.Location = new System.Drawing.Point(8, this.barre_outils.Height + this.sous_barre.Height + 5);
        //outl.Anchor = AnchorStyles.Top;
        //outl.MdiParent = this;
        #endregion

    }
}
