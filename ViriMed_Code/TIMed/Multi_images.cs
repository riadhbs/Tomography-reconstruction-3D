using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TIMed
{
    public partial class Multi_images : Form
    {
        MainForm parent;
        public static bool stop = false;
        public static int compteur=1;

        #region constructeur

        public Multi_images(MainForm parent)
        {
            InitializeComponent();
            this.parent = parent;

        }

        #endregion


        #region action

        private void Multi_images_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            
            parent.multiimagesToolStripMenuItem.Checked = false;
            parent.etat2 = false;
            

        }

        private void multi_image_CheckedChanged(object sender, EventArgs e)
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
            if (MainForm.forme_active.caracteristique_exam.nb_image == 1)
            {
                    string msg = "Nombre d'images maximal est égale à 1!\n";
                    MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                
            }
            box_multi.Enabled = multi_image.Checked;
            numéro_image.Enabled = !(multi_image.Checked);
            button1.Enabled = multi_image.Checked;
            MainForm.forme_active.multi_image = multi_image.Checked;
        }

        /*private void num_image_ValueChanged(object sender, EventArgs e)
        {
            if ((Util.extensiontraitée(MainForm.forme_active.nom_fichier) == true))
            {
                                         
                return;
            }
            bool depassement = false;
           
            if (num_image.Value > MainForm.forme_active.caracteristique_exam.nb_image)
            {
                depassement = true;
                num_image.Value = MainForm.forme_active.caracteristique_exam.nb_image;

                MessageBox.Show("Nombre d'images incorrect!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (depassement) return;
            parent.l_image.progressBar.Show();
            parent.l_image.progressBar.Value = 1;
            if (this.affiche_num.Checked == true) this.affiche_num.Checked = false;
            MainForm.forme_active.numero_image = (int)num_image.Value;
            MainForm.forme_active.image_debut=(int)num_image.Value;

            Util.créer_multi_image(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.nom_palette), MainForm.forme_active.caracteristique_exam.nb_image, MainForm.forme_active.numero_image, MainForm.forme_active.caracteristique_exam.nb_ligne,
              MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.caracteristique_exam.nb_ligne, MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.nom_dossier,
             MainForm.forme_active.nom_fichier);
           
            MainForm.forme_active.afficher_image_bim();
            parent.l_image.progressBar.Hide();

        }*/

        private void image_debut_ValueChanged(object sender, EventArgs e)
        {
            if((Util.extensiontraitée(MainForm.forme_active.nom_fichier) == true) && (MainForm.forme_active.bmp256 == false) ) return;
            /*if (image_debut.Value > MainForm.forme_active.caracteristique_exam.nb_image)
            {
                image_debut.Value = MainForm.forme_active.caracteristique_exam.nb_image;
                MessageBox.Show("Nombre d'images incorrect!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }*/
            MainForm.forme_active.image_debut = (int)image_debut.Value;
        }

       
        private void Multi_images_Load(object sender, EventArgs e)
        {
            
            this.mise_a_jour();

            Rectangle r = Screen.PrimaryScreen.Bounds;
           
            this.Left = r.Width-(parent.outl.Width+this.Width+11);
            this.Top = 20;

        }

        private void button1_Click(object sender, EventArgs e)
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
            if (((Util.extensiontraitée(MainForm.forme_active.nom_fichier) == true) && (MainForm.forme_active.bmp256 == false) )|| (MainForm.forme_active.caracteristique_exam.nb_image == 1))
            {
                
                return;
            }
            if (image_debut.Value > MainForm.forme_active.caracteristique_exam.nb_image)
            {
                string msg = "N° de l’image début > au nombre d’images dans l’examen !";
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
           
            MainForm.forme_active.image_debut = (int)image_debut.Value;
            if (parent.multi.affiche_num.Checked == true) parent.multi.affiche_num.Checked = false;

            Util.créer_multi_image(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.nom_palette), MainForm.forme_active.caracteristique_exam.nb_image, MainForm.forme_active.image_debut, MainForm.forme_active.caracteristique_exam.nb_ligne,
               MainForm.forme_active.caracteristique_exam.nb_colon,MainForm.forme_active.Height,MainForm.forme_active.Width,MainForm.forme_active.nom_dossier,
               MainForm.forme_active.nom_fichier);
            MainForm.forme_active.afficher_image_bim();
            
                   
        }

        private void affiche_num_CheckedChanged(object sender, EventArgs e)
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
            if ((Util.extensiontraitée(MainForm.forme_active.nom_fichier) == true)&&(MainForm.forme_active.bmp256 == false))
            {
                return;
            }
            if (affiche_num.Checked == true)
                Util.afficher_numéro();
            else
            {
              
                MainForm.forme_active.b_image.Image = MainForm.forme_active.image;
            }
            MainForm.forme_active.affichage_num_image = affiche_num.Checked;
        }

        public void mise_a_jour()
        {
            if (MainForm.forme_active.caracteristique_exam != null)
            {
                image_debut.Maximum = MainForm.forme_active.caracteristique_exam.nb_image;

                multi_image.Checked = MainForm.forme_active.multi_image;
                num_image.Value = MainForm.forme_active.numero_image;
                image_debut.Value = MainForm.forme_active.image_debut;
                affiche_num.Checked = MainForm.forme_active.affichage_num_image;
            }
            
            
        }

#endregion

        private void num_image_ValueChanged(object sender, EventArgs e)
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
            if (num_image.Value > MainForm.forme_active.caracteristique_exam.nb_image)
            {

                num_image.Value = MainForm.forme_active.caracteristique_exam.nb_image;
                return;
            }
           
            else 
            {
               
                if (this.affiche_num.Checked == true) this.affiche_num.Checked = false;
                MainForm.forme_active.numero_image = (int)num_image.Value;
                MainForm.forme_active.image_debut = (int)num_image.Value;

                Util.créer_multi_image(Util.créer_tableu_valeur_pour_palette(MainForm.forme_active.nom_palette), MainForm.forme_active.caracteristique_exam.nb_image, MainForm.forme_active.numero_image, MainForm.forme_active.caracteristique_exam.nb_ligne,
                  MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.caracteristique_exam.nb_ligne, MainForm.forme_active.caracteristique_exam.nb_colon, MainForm.forme_active.nom_dossier,
                 MainForm.forme_active.nom_fichier);
                
                MainForm.forme_active.afficher_image_bim();
                
            }
            
        }

        public void button2_Click(object sender, EventArgs e)
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
            if (MainForm.forme_active.caracteristique_exam.nb_image > 1)
            {
                compteur = (int)num_image.Value;
                timer1.Enabled = true;
            }


        }

        public void cine()
        {


            if (compteur > MainForm.forme_active.caracteristique_exam.nb_image) compteur = 1;         
                num_image.Value=compteur;
                this.Refresh();
                MainForm.forme_active.Refresh();
                MainForm.forme_active.b_image.Refresh();
                compteur++;

        }

        

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            timer1.Interval = (int)hScrollBar1.Value;
        }

        public void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cine();
        }

        

         
    }
}
