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
    public partial class ImageBox : Form
    {
        public Examen caracteristique_exam;
        public string nom_dossier = MainForm.chemin;
        public string nom_fichier = "";
        public float gamma=0;
        public int seuil_min=0;
        public int seuil_max=255;
        public float zoom=1;
        public bool negatif = false;
        public int numero_image = 1;
        public int image_debut = 1;
        public bool multi_image = false;
        public MainForm parent;
        public int num_dossier;
        public string nom_palette = "";
        public string nom_palete_x = "";
        public int nb_image = 1;
        public float min_bim = 0;
        public float max_bim=0;
        public Image image;
        public string palette_negatif = Application.StartupPath + "\\utilitaire\\BMPpalcn.pal";
        public string palette_non_negatif = Application.StartupPath + "\\utilitaire\\BMPpalc.pal";
        public bool affichage_num_image = false;
        public bool modification = false;
        public int  origine_hauteur;
        public int origine_largeur;
        public Image image_originale = null;
        public DialogResult dr;
        public bool bmp256 = false;
        public string fichier_tomo_bim = "";
        public string fichier_sinog_bim = "";
        public static int xscrall = 0;
        public static int yscrall = 0;
        
       
       


         #region constructeur

        /// <summary>
        /// 1er constructeur(pour des extension non connues)
        /// </summary>
        /// <param name="caracteristique_exam"></param>
        /// <param name="parent"></param>
        /// <param name="nom_fichier"></param>

       
        public ImageBox(Examen caracteristique_exa,MainForm parent,string nom_fichier)
        {
            InitializeComponent();
            this.label1.Hide();
            this.Text = Path.GetFileName( nom_fichier);
            this.parent = parent;

            init();
            this.caracteristique_exam = caracteristique_exa;

            statu_format.Text = "Format :" + caracteristique_exa.nb_ligne + "X" + caracteristique_exa.nb_colon + "   ";
            statu_nb_image.Text = "Nbre Images :" + caracteristique_exa.nb_image + "   ";
            statu_type_examen.Text = "Type exam :" + caracteristique_exa.type_ex + "   ";

            
            this.nom_fichier = nom_fichier;

            num_dossier = MainForm.num_forme_creer++;
            nom_palette = MainForm.palette_par_defaut;
            nom_dossier+=""+num_dossier+"\\";
            
            
            Directory.CreateDirectory(nom_dossier);

            /*fichier_tomo_bim = nom_dossier + "tomo.bim";
            fichier_sinog_bim = nom_dossier + "sinog.bim";
            int nb_total = caracteristique_exam.nb_colon * caracteristique_exam.nb_ligne * caracteristique_exam.nb_image;
            int nb_total2 = caracteristique_exam.nb_colon * caracteristique_exam.nb_colon * caracteristique_exam.nb_ligne;

            byte[] t_tomo = new byte[nb_total2];
            for (int i = 0; i < nb_total2; i++)
            {
                t_tomo[i] = 1;
            }

            Stream buff_tomo = new FileStream(fichier_tomo_bim, FileMode.CreateNew, FileAccess.Write);
            buff_tomo.Write(t_tomo, 0, nb_total2);
            buff_tomo.Close();

            byte[] t_sinog = new byte[nb_total];
            for (int i = 0; i < nb_total; i++)
            {
                t_sinog[i] = 1;
            }

            Stream buff_sinog = new FileStream(fichier_sinog_bim, FileMode.CreateNew, FileAccess.Write);
            buff_sinog.Write(t_sinog, 0, nb_total);
            buff_sinog.Close();*/
            this.BringToFront();

                         
                       
        }

        /// <summary>
        /// 2eme constructeur,pour les extension connues
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="nom_fichier"></param>

                public ImageBox(MainForm parent,string nom_fichier)
                {
                    InitializeComponent();
                    this.Text = Path.GetFileName(nom_fichier);
                    this.label1.Hide();
                    this.parent = parent;
                    this.nom_fichier = nom_fichier;

                                                         
                    
                }

                #endregion


         #region methode

        /// <summary>
        /// definir les coordoners de la fentre
        /// </summary>

                public void init()
                {
                    this.MaximumSize = new Size(parent.Width - 20, parent.Height);
                    this.Dock = DockStyle.Left | DockStyle.Top;
                }

        /// <summary>
        /// afficher une image quelconque
        /// </summary>
        /// <param name="fileName"></param>

                public void afficher_image(string fileName)
                {
                   

                    
                    if (b_image.Image != null)
                        b_image.Image.Dispose();

                   
                    Bitmap Temp;
                    
                        // Bitmap temporaire
                        Temp = new Bitmap(fileName);
                    
                    
                    // Bitmap de travail
                    Bitmap m_Bitmap = new Bitmap(Temp.Width, Temp.Height);
                    // Objet Graphics de la Bitmap de travail
                    Graphics g = Graphics.FromImage(m_Bitmap);
                    // Transfert de l'image dans la Bitmap de travail
                    // avec tranformation en 32 bits par pixel
                    g.DrawImage(Temp, 0, 0, Temp.Width, Temp.Height);
                    // Suppression de l'objet Graphics
                    g.Dispose();
                    // Transfert de l'image
                    b_image.Image = m_Bitmap;

                    // Suppression de la Bitmap temporaire pour libérer le fichier en écriture
                    Temp.Dispose();
                    
                   
                    b_image.original = m_Bitmap;
                    origine_hauteur = (int)(zoom*b_image.Image.Height);
                    origine_largeur = (int)(zoom*b_image.Image.Width);
                    Size s = new Size(origine_largeur, origine_hauteur);
                    b_image.Size = s;

                    // Affichage image 
                    Invalidate();
                    image = b_image.Image;
                    if (image_originale == null) image_originale = b_image.Image;
                    
                }



                public void afficher_image_rvb()
                {

                    try
                    {
                        Stream ss = new FileStream(nom_fichier, FileMode.Open, FileAccess.Read);
                        ss.Seek(caracteristique_exam.taille+2, SeekOrigin.Begin);

                        byte[] bits = new byte[caracteristique_exam.nb_colon * caracteristique_exam.nb_ligne * 3];

                        ss.Read(bits, 0, bits.Length);


                        int stride = caracteristique_exam.nb_colon;

                        System.Drawing.Bitmap Temp;
                        unsafe
                        {
                            fixed (byte* pBits = bits)
                            {
                                IntPtr ptr = new IntPtr(pBits);

                                Temp = new System.Drawing.Bitmap(
                                   caracteristique_exam.nb_colon,
                                   caracteristique_exam.nb_ligne,
                                   stride * 3,
                                   System.Drawing.Imaging.PixelFormat.Format24bppRgb,
                                   ptr);

                            }
                        }
                    

                     
                         if (b_image.Image != null)
                             b_image.Image.Dispose();
                     

                    // Bitmap de travail
                    Bitmap m_Bitmap = new Bitmap(Temp.Width, Temp.Height);
                    // Objet Graphics de la Bitmap de travail
                    Graphics g = Graphics.FromImage(m_Bitmap);
                    // Transfert de l'image dans la Bitmap de travail
                    // avec tranformation en 32 bits par pixel
                    g.DrawImage(Temp, 0, 0, Temp.Width, Temp.Height);
                    // Suppression de l'objet Graphics
                    g.Dispose();
                    // Transfert de l'image
                    b_image.Image = m_Bitmap;

                    // Suppression de la Bitmap temporaire pour libérer le fichier en écriture
                    Temp.Dispose();


                    b_image.original = m_Bitmap;
                    origine_hauteur = (int)(zoom * b_image.Image.Height);
                    origine_largeur = (int)(zoom * b_image.Image.Width);
                    Size s = new Size(origine_largeur, origine_hauteur);
                    b_image.Size = s;

                    // Affichage image 
                    Invalidate();
                    image = b_image.Image;
                    if (image_originale == null) image_originale = b_image.Image;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
        
                


        /// <summary>
        /// afficher l'image de l'examen
        /// </summary>
                public void afficher_image_bim()
                {

                                       
                    string chemin=MainForm.forme_active.nom_dossier+Path.GetFileNameWithoutExtension(nom_fichier)+".bmp";
                    
                    afficher_image(chemin);
                }

        /// <summary>
        /// afficher l'image de la palette
        /// </summary>


                public void afficher_image_palette()
                {
                    if (image_palette.Image != null)
                         image_palette.Image.Dispose();
                    
                    string chemin=MainForm.forme_active.nom_dossier+Path.GetFileNameWithoutExtension(nom_palette)+".bmp";
                    FileStream stream1;

                    try
                    {
                        stream1 = new FileStream(chemin, FileMode.Open, FileAccess.Read);
                        image_palette.Image = Image.FromStream(stream1);
                    }
                    catch (Exception ex)
                    {
                        string msg = "Impossible d'afficher l'image de la palette!\n" + "Fichier introuvable";
                        MessageBox.Show(msg, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    
                    stream1.Close();
                    Size s = new Size(20, 256);
                    image_palette.Size = s;
                }

        /// <summary>
        /// enregistrer l'image
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="imageformat"></param>
        /// <returns></returns>


                public bool enregistrer_image(string FileName, ImageFormat imageformat)
                {
                    if (b_image.Image == null) return false;

                    try
                    {
                        b_image.Image.Save(FileName, imageformat);

                        return true;
                    }
                    catch (Exception ex)
                    {
                        string msg = "Impossible d'enregistrer l'image!";
                        MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

        /// <summary>
        /// fermer la fenetre
        /// </summary>

                public void fermer()
                {
                    if ((b_image.Image!=null)&&(b_image.Image.Equals(image_originale) == false))
                    {
                        string msg = "Enregistrer sous les modifications de ViRIMed \n" + "\"" + nom_fichier + "\"" + "avant de quitter?";
                        dr = MessageBox.Show(msg, "TiMed", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        if (dr == DialogResult.Yes)
                        {
                            parent.saveFileDialog1.FileName = "MonImage";
                            parent.saveFileDialog1.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg;*.jpeg|" +
                                "GIF (*.gif)|*.gif|TIF (*.tif)|*.tif";
                            if (parent.saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                if (this.enregistrer_image(parent.saveFileDialog1.FileName, parent.GetImageFormat()))
                                    MessageBox.Show("Image enregistrée...", "Enregistrement d'image",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show("Une erreur est survenue lors du sauvegarde."
                                        , Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    MainForm.nb_forme_cree--;
                    if(MainForm.nb_forme_cree==0)
                    {
                        parent.activer_fonctionalité(false);
                                               
                        parent.outl.Dispose();
                        parent.multi.Dispose();
                        parent.etat2 = false;
                        parent.reconstructionToolStripMenuItem.Enabled = false;
                        parent.multiimagesToolStripMenuItem.Enabled = false;
                        parent.outilsToolStripMenuItem.Enabled = false;
                        parent.etat = false;
                        //this.Dispose();
                    }
                    

                    if(Directory.Exists(nom_dossier))
                        try
                        {

                            Directory.Delete(nom_dossier, true);
                        }
                        catch (Exception e)
                        {
                            string msg = "Erreur lors de l'exécution!" + e.Message;
                            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    parent.l_image.fermer_fichier(nom_fichier);
                    
                    

                }

               
        /// <summary>
        /// effectuer un zoom
        /// </summary>
        /// <param name="factor"></param>


                public void Zoom(float factor)
                {
                    

                    int newwidth =(int) (b_image.Image.Size.Width * factor);
                    int newheight =(int) (b_image.Image.Size.Height * factor);
                    /*int newwidth = MainForm.forme_active.caracteristique_exam.nb_colon * factor;
                    int newheight = MainForm.forme_active.caracteristique_exam.nb_colon * factor;*/
                    Size size = new Size(newwidth, newheight);

                    b_image.Size = size;
                    b_image.Update();
                    b_image.Refresh();

                }
        
        /// <summary>
        /// effectuer un effet negatif
        /// </summary>

        public void effet_negatif()
        {

            MainForm.forme_active.nom_palette = MainForm.forme_active.palette_negatif;
            if (MainForm.forme_active.caracteristique_exam.nb_image > 1)
            {
                if (parent.multi.box_multi.Enabled == true)
                {

                    Util.créer_multi_image(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.palette_negatif), MainForm.forme_active.caracteristique_exam.nb_image, MainForm.forme_active.image_debut, MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.Height, MainForm.forme_active.Width, MainForm.forme_active.nom_dossier,
                   MainForm.forme_active.nom_fichier);
                }
                else
                {
                    Util.créer_multi_image(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.palette_negatif), MainForm.forme_active.caracteristique_exam.nb_image, MainForm.forme_active.image_debut, MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.nom_dossier, MainForm.forme_active.nom_fichier);
                }



            }
            else
            {
                Util.mono_image(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.palette_negatif), MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.nom_fichier, MainForm.forme_active.nom_dossier);
            }
            MainForm.forme_active.afficher_image_bim();
            Util.créer_image_palette(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.palette_negatif), MainForm.chemin + MainForm.forme_active.num_dossier + "\\");
            MainForm.forme_active.afficher_image_palette();
            
            
        }

        public void effet_non_negatif()
        {

            MainForm.forme_active.nom_palette = MainForm.forme_active.palette_non_negatif;
            if (MainForm.forme_active.caracteristique_exam.nb_image > 1)
            {
                if (parent.multi.box_multi.Enabled == true)
                {

                    Util.créer_multi_image(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.palette_non_negatif), MainForm.forme_active.caracteristique_exam.nb_image, MainForm.forme_active.image_debut, MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.Height, MainForm.forme_active.Width, MainForm.forme_active.nom_dossier,
                   MainForm.forme_active.nom_fichier);
                }
                else
                {
                    Util.créer_multi_image(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.palette_non_negatif), MainForm.forme_active.caracteristique_exam.nb_image, MainForm.forme_active.image_debut, MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.nom_dossier, MainForm.forme_active.nom_fichier);
                }



            }
            else
            {
                Util.mono_image(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.palette_non_negatif), MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.nom_fichier, MainForm.forme_active.nom_dossier);
            }
            MainForm.forme_active.afficher_image_bim();
            Util.créer_image_palette(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.palette_non_negatif), MainForm.chemin + MainForm.forme_active.num_dossier + "\\");
            MainForm.forme_active.afficher_image_palette();
            

        }


        /// <summary>
        /// changer la palette selon le choix
        /// </summary>
        /// <param name="palette"></param>


        public void changer_palette(string palette)
        {
            string chemin_gris = Application.StartupPath + "\\utilitaire\\BMPpalg.pal";
            string chemin_rouge = Application.StartupPath + "\\utilitaire\\BMPpalr.pal";
            string chemin_vert = Application.StartupPath + "\\utilitaire\\BMPpalv.pal";
            string chemin_bleu = Application.StartupPath + "\\utilitaire\\BMPpalb.pal";
            string chemin_couleur = Application.StartupPath + "\\utilitaire\\BMPpalc.pal";
            string chemin_couleurn = Application.StartupPath + "\\utilitaire\\BMPpalcn.pal";
            string chemin_grisn = Application.StartupPath + "\\utilitaire\\BMPpalgn.pal";
            string chemin_bleun = Application.StartupPath + "\\utilitaire\\BMPpalbn.pal";
            string chemin_rougen = Application.StartupPath + "\\utilitaire\\BMPpalrn.pal";
            string chemin_vertn = Application.StartupPath + "\\utilitaire\\BMPpalvn.pal";
    
            
            switch(palette)
                {

                    case "gris": nom_palette = chemin_gris; 
                                type_palette(chemin_gris);
                                   
                                 break;
                    case "rouge": nom_palette = chemin_rouge; 
                                type_palette(chemin_rouge);
                                 
                                 break;
                    case "vert": nom_palette = chemin_vert; 
                                type_palette(chemin_vert);
                                  
                                 break;
                    case "bleu": nom_palette = chemin_bleu;
                        
                                 
                                 
                                 break;
                    case "couleur": nom_palette = chemin_couleur;
                                    
                                 
                                 break;
                    case "grisn": nom_palette = chemin_grisn;
                                
                                 break;

                    case "rougen": nom_palette = chemin_rougen;
                                 
                                 break;

                    case "vertn": nom_palette = chemin_vertn;
                                 
                                 break;

                    case "bleun": nom_palette = chemin_bleun;
                                 
                                 break;

                    case "couleurn": nom_palette = chemin_couleurn;
                                 
                                 break;
            }
            nom_palete_x = nom_palette;
            type_palette(nom_palette);
        }

        /// <summary>
        /// changer la palette
        /// </summary>
        /// <param name="nom_pal"></param>

        public void type_palette(string nom_pal)
        {
            if (this.caracteristique_exam.nb_image > 1)
            {
                if (parent.multi.box_multi.Enabled == true)
                {

                    Util.créer_multi_image(Util.créer_tableu_valeur_pour_palette(this.nom_palette), this.caracteristique_exam.nb_image, this.image_debut, this.caracteristique_exam.nb_ligne,
                  this.caracteristique_exam.nb_colon, this.Height, this.Width, this.nom_dossier,
                   this.nom_fichier);
                }
                else
                {
                    Util.créer_multi_image(Util.créer_tableu_valeur_pour_palette(this.nom_palette), this.caracteristique_exam.nb_image, this.image_debut, this.caracteristique_exam.nb_ligne,
                  this.caracteristique_exam.nb_colon, this.caracteristique_exam.nb_ligne,
                  this.caracteristique_exam.nb_colon, this.nom_dossier,this.nom_fichier);
                }
               
            
            }
            else
            {
                Util.mono_image(Util.créer_tableu_valeur_pour_palette(this.nom_palette), MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon,this.nom_fichier,this.nom_dossier);
            }
            this.afficher_image_bim();
            Util.créer_image_palette(Util.créer_tableu_valeur_pour_palette(nom_pal), MainForm.chemin + MainForm.forme_active.num_dossier + "\\");
            this.afficher_image_palette();
            

        }
        

        public void initialisation()
        {
           /* 
            zoom = 1;
            */
                }
              


                #endregion

         #region action

        

        /// <summary>
        /// si on active la fenetre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

                private void ImageBox_Activated(object sender, EventArgs e)
                {

                    if (MainForm.btofront == true)
                    {
                        MainForm.btofront = false;
                        return;
                    }
                    
                   
                    MainForm.forme_active = this;


                    if ((Util.extensiontraitée(nom_fichier) == false)&&(this.b_image.Image!=null))
                    {
                        parent.outl.mise_a_jour();
                    }

                    if ((Util.extensiontraitée(nom_fichier) == false) && (this.b_image.Image != null) && (MainForm.forme_active.caracteristique_exam.nb_image > 1))
                    {
                        parent.multi.mise_a_jour();
                    }
                                        

                }

                private void ImageBox_SizeChanged(object sender, EventArgs e)
                {
                    
                    if (MainForm.forme_active.b_image.Image == null)
                    {
                        return;
                    }
                    if ((MainForm.forme_active.caracteristique_exam != null) && (MainForm.forme_active.caracteristique_exam.rvb == true))
                    {
                        return;
                    }
                    if ((Util.extensiontraitée(this.nom_fichier) == false )&& (this.caracteristique_exam.nb_image > 1) && (parent.multi.box_multi.Enabled == true))
                    {
                        if (parent.multi.affiche_num.Checked == true) parent.multi.affiche_num.Checked = false;
                        Util.créer_multi_image(Util.créer_tableu_valeur_pour_palette(this.nom_palette), MainForm.forme_active.caracteristique_exam.nb_image, this.image_debut, MainForm.forme_active.caracteristique_exam.nb_ligne,
                         MainForm.forme_active.caracteristique_exam.nb_colon, this.Height, this.Width, this.nom_dossier,
                         this.nom_fichier);
                        this.afficher_image_bim();
                    }
                }

                private void b_image_MouseDown(object sender, MouseEventArgs e)
                {
                    if ((MainForm.forme_active.caracteristique_exam != null) && (MainForm.forme_active.caracteristique_exam.rvb == true))
                    {
                        return;
                    }
                    if ((Util.extensiontraitée(nom_fichier) == true)&&(MainForm.forme_active.bmp256==false)) return;
                    float new_zoom = MainForm.forme_active.zoom;
                    if (new_zoom < 1) new_zoom = 1 / new_zoom;
                    int nb_ligne = caracteristique_exam.nb_ligne;
                    int nb_colon = caracteristique_exam.nb_colon;
                    int nic = (int)((b_image.Image.Width / new_zoom) / nb_colon);
                    int nil = (int)((b_image.Image.Height / new_zoom) / nb_ligne);
                    //string fichier_bim = nom_fichier;

                    Stream byte_originalstream=null;
                    
                    
                    try
                    {
                        string fichier = null;
                        string extension = Path.GetExtension(nom_fichier);

                        if (extension == ".bim") fichier = nom_fichier;
                        else fichier = MainForm.forme_active.nom_dossier + Path.GetFileNameWithoutExtension(nom_fichier) + ".bim";
                        byte_originalstream = new FileStream(fichier, FileMode.Open, FileAccess.Read);
                        
                    
                    }
                    catch (Exception ex)
                    {
                        string msg = "Fichier introuvable!";
                        MessageBox.Show(msg, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        byte_originalstream.Close();
                       
                        return;
                    }
                    Point p = new Point(e.X-xscrall, e.Y-yscrall);

                    int x = (int)(e.X / new_zoom);
                    int y = (int)(e.Y / new_zoom);
                    int num_ligne = y / nb_ligne;
                    int num_colon =x/nb_colon;
                    int num_image = num_ligne * nic  +num_colon ;/*(x / nb_ligne) * nic + (y / nb_colon);*/

                    int num_pixel=x%nb_colon+(y % nb_ligne)*nb_ligne;

                    int pos = (image_debut - 1 + num_image) * nb_ligne * nb_colon + num_pixel;
                    int size = nb_colon * nb_ligne * caracteristique_exam.nb_image;
                    if (pos > size - 1) return;
                    label1.Show();
                    byte[] tab = new byte[4];
                    byte_originalstream.Seek(pos, SeekOrigin.Begin);
                    byte_originalstream.Read(tab, 0, 4);
                    label1.Location = p;
                    
                    label1.Text = "" +BitConverter.ToSingle(tab, 0) ;
                    
                                       
                    byte_originalstream.Close();
                    byte_originalstream.Dispose();
                    nb_coup.Text = label1.Text;
                }

                

                private void b_image_MouseLeave(object sender, EventArgs e)
                {
                    if ((Util.extensiontraitée(nom_fichier) == true)&&(MainForm.forme_active.bmp256==false)) return;
                    if (MainForm.forme_active != null)
                    {
                        label1.Hide();
                        statu_X.Text = "";
                        statu_Y.Text = "";
                    }
                }
                private void b_image_MouseUp(object sender, MouseEventArgs e)
                {
                    if ((Util.extensiontraitée(nom_fichier) == true)&&(MainForm.forme_active.bmp256==false)) return;
                    label1.Hide();
                    nb_coup.Text = "0";
                }

                private void b_image_MouseMove(object sender, MouseEventArgs e)
                {
                    if (MainForm.forme_active != null)
                    {
                        statu_X.Text = "X :" + e.X / MainForm.forme_active.zoom + "   ";
                        statu_Y.Text = "Y :" + e.Y / MainForm.forme_active.zoom;
                    }
                }

                
                private void ImageBox_FormClosing(object sender, FormClosingEventArgs e)
                {
                    this.fermer();
                    MainForm.forme_active = null;
                }

                private void ImageBox_Scroll(object sender, ScrollEventArgs e)
                {
                    

                    if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                    {
                        xscrall = e.NewValue;
                        
                    }
                    else 
                    {
                        yscrall = e.NewValue;
                        
                    }

                }

                private void ImageBox_MouseDown(object sender, MouseEventArgs e)
                {
                    MainForm.btofront = false;
                }

                

                /*public void RotateFlipCurrentPicture(RotateFlipType type)
                {
                    int h = MainForm.forme_active.b_image.Image.Height;
                    int w = MainForm.forme_active.b_image.Image.Width;
                    Size newsize=new Size(h,w);
                    Image i = MainForm.forme_active.b_image.Image;

                    image.RotateFlip(type);
                    MainForm.forme_active.b_image.Image = i;
                    MainForm.forme_active.b_image.Size = newsize;
                    
                }*/

                #endregion

                

               
    }
    
}
