using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace TIMed
{
    public partial class Outils : Form
    {
        private MainForm parent;
        
        public decimal val;
        Image image_courbe;


        #region constructeur

        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="parent"></param>
        public Outils(MainForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            
            val = this.zoom.Value;
            initialiser_courbe();
            


        }
        #endregion

        #region methode

        /// <summary>
        /// mettre a jour les composant 
        /// </summary>
        public void mise_a_jour()
        {
            if (MainForm.forme_active.zoom < 1)
            {
                zoom.Value = (decimal)(-1 / MainForm.forme_active.zoom);
            }
            else
            {

                zoom.Value = (decimal)MainForm.forme_active.zoom;
            }
            scrall_gamma.Value = (int)MainForm.forme_active.gamma;
            
            scrall_min.Value =  MainForm.forme_active.seuil_min;
            scrall_max.Value = MainForm.forme_active.seuil_max;
            
            checkBox1.Checked = MainForm.forme_active.negatif;
           
            double s_min = scrall_min.Value * (MainForm.forme_active.max_bim - MainForm.forme_active.min_bim) / 255 + MainForm.forme_active.min_bim;
            l_min.Text = s_min.ToString(".##");
            double s_max = scrall_max.Value * (MainForm.forme_active.max_bim - MainForm.forme_active.min_bim) / 255 + MainForm.forme_active.min_bim;
            l_max.Text = s_max.ToString(".##");
            scrall_gamma.Value =(int) MainForm.forme_active.gamma;
               
        }

        public void initialiser_courbe()
        {
            //(208,153)
            Pen p = new Pen(Brushes.Black);
            p.Color = Color.Black;
            p.Width = 2;

            Bitmap bit = new Bitmap(box_courbe_gamma.Width,box_courbe_gamma.Height);
            Graphics g = Graphics.FromImage(bit);
            /*Point p1 = new Point(20,box_courbe_gamma.Height - 15);
            Point p2 = new Point(box_courbe_gamma.Width - 25, box_courbe_gamma.Height - 15);
            Point p3 = new Point(25,15);
            Point p4 = new Point(25, box_courbe_gamma.Height - 12);
            g.DrawLine(p, p1, p2);
            g.DrawLine(p, p3, p4);

           /* Point p5 = new Point(20, 20);
            Point p6 = new Point(25, 15);
            Point p7 = new Point(30, 20);
            g.DrawLine(p, p5, p6);
            g.DrawLine(p, p6, p7);

            Point p8 = new Point(box_courbe_gamma.Width-30 , box_courbe_gamma.Height - 10);
            Point p9 = new Point(box_courbe_gamma.Width - 25, box_courbe_gamma.Height - 15);
            Point p10 = new Point(box_courbe_gamma.Width -30, box_courbe_gamma.Height - 20);
            g.DrawLine(p, p9, p8);
            g.DrawLine(p, p10, p9);

            Point p11 = new Point(box_courbe_gamma.Width - 23, box_courbe_gamma.Height - 25);
            Point p12 = new Point(0, 0);
            Point p13 = new Point(5, box_courbe_gamma.Height - 25);
            Point p14 = new Point(0, 20);
            Font drawFont = new Font("Times New Roman ", 8);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            g.DrawString("val", drawFont, drawBrush, p11);
            g.DrawString("couleurs", drawFont, drawBrush, p12);
            g.DrawString("0", drawFont, drawBrush, p13);
            g.DrawString("255", drawFont, drawBrush, p14);*/

            Pen pp = new Pen(Brushes.White);
            pp.Color = Color.White;
            pp.Width = 1;
            pp.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            Point pp1 = new Point(0,0);
            Point pp2 = new Point(box_courbe_gamma.Width-1, 0);
            Point pp3 = new Point(box_courbe_gamma.Width-1, box_courbe_gamma.Height-1);
            Point pp16 = new Point(0, box_courbe_gamma.Height-1);
            Point pp4 = new Point(0, (box_courbe_gamma.Height - 1)/4);
            Point pp5 = new Point(box_courbe_gamma.Width - 1, (box_courbe_gamma.Height - 1) / 4);
            Point pp6 = new Point(0, (box_courbe_gamma.Height - 1) / 2);
            Point pp7 = new Point(box_courbe_gamma.Width - 1, (box_courbe_gamma.Height - 1) / 2);
            Point pp8 = new Point(0, 3*(box_courbe_gamma.Height - 1) / 4);
            Point pp9 = new Point(box_courbe_gamma.Width - 1, 3*(box_courbe_gamma.Height - 1) / 4);
            Point pp10 = new Point((box_courbe_gamma.Width - 1) / 4, 0);
            Point pp11 = new Point((box_courbe_gamma.Width - 1) / 4, box_courbe_gamma.Height -1);
            Point pp12 = new Point((box_courbe_gamma.Width - 1) / 2, 0);
            Point pp13 = new Point((box_courbe_gamma.Width - 1) / 2, box_courbe_gamma.Height - 1);
            Point pp14 = new Point(3*(box_courbe_gamma.Width - 1) / 4, 0);
            Point pp15 = new Point(3*(box_courbe_gamma.Width - 1) / 4, box_courbe_gamma.Height - 1);

            g.DrawLine(pp, pp1, pp2);
            g.DrawLine(pp, pp2, pp3);
            g.DrawLine(pp, pp1, pp16);
            g.DrawLine(pp, pp16, pp3);
            g.DrawLine(pp, pp4, pp5);
            g.DrawLine(pp, pp6, pp7);
            g.DrawLine(pp, pp8, pp9);
            g.DrawLine(pp, pp10, pp11);
            g.DrawLine(pp, pp12, pp13);
            g.DrawLine(pp, pp14, pp15);
                        
            box_courbe_gamma.Image = bit;
            g.Dispose();
            image_courbe = box_courbe_gamma.Image;
            
             
        }

        public void dessiner_courbe()
        {
            Size s=new Size(box_courbe_gamma.Width,box_courbe_gamma.Height);
            Bitmap bit = new Bitmap(image_courbe,s);
            Graphics g = Graphics.FromImage(bit);
            int[]tab=Util.seuillage_ou_gamma_tableau();
            
            Pen p = new Pen(Brushes.DeepSkyBlue);
            p.Color = Color.Red;
            p.Width = 2;

            Point p1;
            Point p2;
            int x=0;
            int y = 0;
            int x1 = 0;
            int y1 = 0;
                        
            for (int i = 0; i < 255; i++)
            {
                x=i*(box_courbe_gamma.Width-1)/255;
                y=tab[i]*(-box_courbe_gamma.Height+1)/255 +(box_courbe_gamma.Height-1);
                x1=(i+1)*(box_courbe_gamma.Width-1)/255;
                y1 = tab[i + 1] * (-box_courbe_gamma.Height + 1) / 255 + (box_courbe_gamma.Height - 1);
                p2=new Point(x1,y1);
                p1=new Point(x,y);
                g.DrawLine(p,p1,p2);
            }

            box_courbe_gamma.Image = bit;
            g.Dispose();


        }

        /// <summary>
        /// palette
        /// </summary>
        /// <param name="type_pal"></param>
        public void palette(string type_pal)
        {
            if ((MainForm.forme_active.caracteristique_exam!=null)&&(MainForm.forme_active.caracteristique_exam.rvb == true))
            {
                return;
            }
                     
            if ((Util.extensiontraitée(MainForm.forme_active.nom_fichier) == true)&&(MainForm.forme_active.bmp256==false))
            {
                return;
            }
           
            MainForm.forme_active.changer_palette(type_pal);

            

        }
        

        #endregion

        #region action
        /// <summary>
        /// si on ferme la fenetre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Outils_FormClosed(object sender, FormClosedEventArgs e)
        {

            parent.outilsToolStripMenuItem.Checked = false;
            parent.etat = false;

        }

        /// <summary>
        /// si on fait un zoooooom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

      

               
       
        /// <summary>
        /// ouverture de outils
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Outils_Load(object sender, EventArgs e)
        {
            this.mise_a_jour();
            Rectangle r = Screen.PrimaryScreen.Bounds;
            this.Left = r.Width  - (this.Width +8);
            this.Top = 20;
            
            
        }
        
        /// <summary>
        /// palette rouge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void b_rouge_Click(object sender, EventArgs e)
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
            MainForm.forme_active.palette_non_negatif = Application.StartupPath + "\\utilitaire\\BMPpalr.pal";
            MainForm.forme_active.palette_negatif = Application.StartupPath + "\\utilitaire\\BMPpalrn.pal";
            if (parent.multi.affiche_num.Checked == true) parent.multi.affiche_num.Checked = false;
            if (checkBox1.Checked == true) palette("rougen");
            else  palette("rouge");
            MainForm.forme_active.initialisation();
            

        }
        /// <summary>
        /// palette vert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  void b_vert_Click(object sender, EventArgs e)
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
            MainForm.forme_active.palette_non_negatif = Application.StartupPath + "\\utilitaire\\BMPpalv.pal";
            MainForm.forme_active.palette_negatif = Application.StartupPath + "\\utilitaire\\BMPpalvn.pal";
            if (parent.multi.affiche_num.Checked == true) parent.multi.affiche_num.Checked = false;
            if (checkBox1.Checked == true) palette("vertn");
            else palette("vert");
            MainForm.forme_active.initialisation();
            
        }

        /// <summary>
        /// palette bleu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public  void b_bleu_Click(object sender, EventArgs e)
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
            MainForm.forme_active.palette_non_negatif = Application.StartupPath + "\\utilitaire\\BMPpalb.pal";
            MainForm.forme_active.palette_negatif = Application.StartupPath + "\\utilitaire\\BMPpalbn.pal";
            if (parent.multi.affiche_num.Checked == true) parent.multi.affiche_num.Checked = false;
            if (checkBox1.Checked == true) palette("bleun");
            else palette("bleu");
            MainForm.forme_active.initialisation();
           


        }
        /// <summary>
        /// palette gris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void b_gris_Click(object sender, EventArgs e)
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

                MainForm.forme_active.palette_non_negatif = Application.StartupPath + "\\utilitaire\\BMPpalg.pal";
                MainForm.forme_active.palette_negatif = Application.StartupPath + "\\utilitaire\\BMPpalgn.pal";
                if (parent.multi.affiche_num.Checked == true) parent.multi.affiche_num.Checked = false;
                if (checkBox1.Checked == true) palette("grisn");
                else palette("gris");
                //MainForm.forme_active.initialisation();
            
        }

        /// <summary>
        /// palette couleur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void b_couleur_Click(object sender, EventArgs e)
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
            MainForm.forme_active.palette_non_negatif = Application.StartupPath + "\\utilitaire\\BMPpalc.pal";
            MainForm.forme_active.palette_negatif = Application.StartupPath + "\\utilitaire\\BMPpalcn.pal";
            if (parent.multi.affiche_num.Checked == true) parent.multi.affiche_num.Checked = false;
            if (checkBox1.Checked == true) palette("couleurn");
            else palette("couleur");
            MainForm.forme_active.initialisation();
            

        }

        /// <summary>
        /// seuillage min
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void scrall_min_ValueChanged(object sender, EventArgs e)
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
            if ((MainForm.forme_active.caracteristique_exam != null) && (MainForm.forme_active.caracteristique_exam.rvb == true))
            {
                return;
            }
            if ((Util.extensiontraitée(MainForm.forme_active.nom_fichier) == true) && (MainForm.forme_active.bmp256 == false))
            {
                return;
            }
            if (scrall_min.Value >= scrall_max.Value)
            {
               
                if (scrall_max.Value != 0)
                {

                    scrall_min.Value = scrall_max.Value - 1;

                }
                else
                {

                    scrall_min.Value = 0;

                }
                return;
            }
           
            if (parent.multi.affiche_num.Checked == true) parent.multi.affiche_num.Checked = false;

            MainForm.forme_active.seuil_min = scrall_min.Value;
            
            double s_min=scrall_min.Value * (MainForm.forme_active.max_bim - MainForm.forme_active.min_bim) / 255 + MainForm.forme_active.min_bim;
            l_min.Text = s_min.ToString(".##");
            if (scrall_min.Value == 0) l_min.Text = "0";
            if (MainForm.forme_active.caracteristique_exam.nb_image > 1)
            {
                if (parent.multi.box_multi.Enabled == true)
                {

                    Util.créer_multi_image(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.nom_palette), MainForm.forme_active.caracteristique_exam.nb_image, MainForm.forme_active.image_debut, MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.Height, MainForm.forme_active.Width, MainForm.forme_active.nom_dossier,
                   MainForm.forme_active.nom_fichier);
                }
                else
                {
                    Util.créer_multi_image(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.nom_palette), MainForm.forme_active.caracteristique_exam.nb_image, MainForm.forme_active.image_debut, MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.nom_dossier, MainForm.forme_active.nom_fichier);
                }



            }
            else
            {
                Util.mono_image(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.nom_palette), MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.nom_fichier, MainForm.forme_active.nom_dossier);
            }
            MainForm.forme_active.afficher_image_bim();
            Util.créer_image_palette(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.nom_palette), MainForm.chemin + MainForm.forme_active.num_dossier + "\\");
            MainForm.forme_active.afficher_image_palette();

            dessiner_courbe();
            
        }

        /// <summary>
        /// seuillage max
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       

       
       
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
            if ((MainForm.forme_active.caracteristique_exam != null) && (MainForm.forme_active.caracteristique_exam.rvb == true))
            {
                return;
            }
            if ((Util.extensiontraitée(MainForm.forme_active.nom_fichier) == true) && (MainForm.forme_active.bmp256 == false))
            {
               return;
            }
            
            MainForm.forme_active.negatif = checkBox1.Checked;
            
            if (parent.multi.affiche_num.Checked == true) parent.multi.affiche_num.Checked = false;

            dessiner_courbe();
            if (checkBox1.Checked == true)
            {

                MainForm.forme_active.nom_palete_x = MainForm.forme_active.palette_negatif;
                MainForm.forme_active.effet_negatif();

            }
            else
            {
                MainForm.forme_active.nom_palete_x = MainForm.forme_active.palette_non_negatif;
                MainForm.forme_active.effet_non_negatif();
            }

           
        }

           

        #endregion

        private void reset_Click(object sender, EventArgs e)
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
            if ((MainForm.forme_active.caracteristique_exam != null) && (MainForm.forme_active.caracteristique_exam.rvb == true))
            {
                return;
            }
            if ((Util.extensiontraitée(MainForm.forme_active.nom_fichier) == true) && (MainForm.forme_active.bmp256 == false))
            {
                return;
            }
            scrall_max.Value = 255;
            scrall_min.Value = 0;
            scrall_gamma.Value = 0;
           
        }


       
        private void scrall_max_ValueChanged(object sender, EventArgs e)
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
            if ((MainForm.forme_active.caracteristique_exam != null) && (MainForm.forme_active.caracteristique_exam.rvb == true))
            {
                return;
            }
            if ((Util.extensiontraitée(MainForm.forme_active.nom_fichier) == true) && (MainForm.forme_active.bmp256 == false))
            {

                return;
            }
            if (scrall_max.Value <= scrall_min.Value)
            {
                scrall_max.Value = scrall_min.Value + 1;


                return;
            }
           
            if (parent.multi.affiche_num.Checked == true) parent.multi.affiche_num.Checked = false;

            MainForm.forme_active.seuil_max = scrall_max.Value;
            double s_max = scrall_max.Value * (MainForm.forme_active.max_bim - MainForm.forme_active.min_bim) / 255 + MainForm.forme_active.min_bim;
            l_max.Text = s_max.ToString(".##");

            if (MainForm.forme_active.caracteristique_exam.nb_image > 1)
            {
                if (parent.multi.box_multi.Enabled == true)
                {

                    Util.créer_multi_image(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.nom_palette), MainForm.forme_active.caracteristique_exam.nb_image, MainForm.forme_active.image_debut, MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.Height, MainForm.forme_active.Width, MainForm.forme_active.nom_dossier,
                   MainForm.forme_active.nom_fichier);
                }
                else
                {
                    Util.créer_multi_image(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.nom_palette), MainForm.forme_active.caracteristique_exam.nb_image, MainForm.forme_active.image_debut, MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.nom_dossier, MainForm.forme_active.nom_fichier);
                }


            }
            else
            {
                Util.mono_image(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.nom_palette), MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.nom_fichier, MainForm.forme_active.nom_dossier);
            }
            MainForm.forme_active.afficher_image_bim();
            Util.créer_image_palette(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.nom_palette), MainForm.chemin + MainForm.forme_active.num_dossier + "\\");
            MainForm.forme_active.afficher_image_palette();

            dessiner_courbe();
            

        }


        /// <summary>
        /// gamma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void scrall_gamma_ValueChanged(object sender, EventArgs e)
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
            if ((MainForm.forme_active.caracteristique_exam != null) && (MainForm.forme_active.caracteristique_exam.rvb == true))
            {
                return;
            }
            if ((Util.extensiontraitée(MainForm.forme_active.nom_fichier) == true) && (MainForm.forme_active.bmp256 == false))
            {
                return;
            }
            MainForm.forme_active.gamma = scrall_gamma.Value;
           
            
            if (parent.multi.affiche_num.Checked == true) parent.multi.affiche_num.Checked = false;

            if (MainForm.forme_active.caracteristique_exam.nb_image > 1)
            {
                if (parent.multi.box_multi.Enabled == true)
                {

                    Util.créer_multi_image(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.nom_palette), MainForm.forme_active.caracteristique_exam.nb_image, MainForm.forme_active.image_debut, MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.Height, MainForm.forme_active.Width, MainForm.forme_active.nom_dossier,
                   MainForm.forme_active.nom_fichier);
                }
                else
                {
                    Util.créer_multi_image(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.nom_palette), MainForm.forme_active.caracteristique_exam.nb_image, MainForm.forme_active.image_debut, MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.nom_dossier, MainForm.forme_active.nom_fichier);
                }



            }
            else
            {
                Util.mono_image(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.nom_palette), MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.nom_fichier, MainForm.forme_active.nom_dossier);
            }
            MainForm.forme_active.afficher_image_bim();
            Util.créer_image_palette(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.nom_palette), MainForm.chemin + MainForm.forme_active.num_dossier + "\\");
            MainForm.forme_active.afficher_image_palette();

            dessiner_courbe();
            

        }

        private void zoom_ValueChanged(object sender, EventArgs e)
        {
                        
            
            if (zoom.Value == 0) zoom.Value = -2;
            if (zoom.Value == -1) zoom.Value = 1;
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

            float factor = 0;
            if (this.zoom.Value < 0)
            {
                MainForm.forme_active.zoom =(float) (1 / Math.Abs(this.zoom.Value));
                factor = (float)(1 / Math.Abs(this.zoom.Value));
            }
            else
            {

                MainForm.forme_active.zoom =(float) this.zoom.Value;
                factor =(float) this.zoom.Value;
            }
            MainForm.forme_active.Zoom(factor);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MainForm.forme_active.nom_palete_x != "")
            {

                byte[] pal_x = Util.creer_palette_x((float)pourcentage.Value);

                if (MainForm.forme_active.caracteristique_exam.nb_image > 1)
                {
                    if (parent.multi.box_multi.Enabled == true)
                    {

                        Util.créer_multi_image(pal_x, MainForm.forme_active.caracteristique_exam.nb_image, MainForm.forme_active.image_debut, MainForm.forme_active.caracteristique_exam.nb_ligne,
                      MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.Height, MainForm.forme_active.Width, MainForm.forme_active.nom_dossier,
                       MainForm.forme_active.nom_fichier);
                    }
                    else
                    {
                        Util.créer_multi_image(pal_x, MainForm.forme_active.caracteristique_exam.nb_image, MainForm.forme_active.image_debut, MainForm.forme_active.caracteristique_exam.nb_ligne,
                      MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.caracteristique_exam.nb_ligne,
                      MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.nom_dossier, MainForm.forme_active.nom_fichier);
                    }


                }
                else
                {
                    Util.mono_image(pal_x, MainForm.forme_active.caracteristique_exam.nb_ligne,
                      MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.nom_fichier, MainForm.forme_active.nom_dossier);
                }
                MainForm.forme_active.afficher_image_bim();
                Util.créer_image_palette(pal_x, MainForm.chemin + MainForm.forme_active.num_dossier + "\\");
                MainForm.forme_active.afficher_image_palette();



            }
            else
            {
                string msg = "Choisissez une palette!" ;
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        


             

    }
}
