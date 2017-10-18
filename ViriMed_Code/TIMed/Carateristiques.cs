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
    public partial class Carateristiques_exam : Form
    {
        public MainForm parent;
        Button btn = null;
        

        #region constructeur
        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="type"></param>

        public Carateristiques_exam(MainForm parent,int type)
        {
            InitializeComponent();
            this.parent = parent;


            if (type == 2) this.desactiver_bim();
            else
            {
                nbr_oct_valeur.SelectedIndex = 0;
                radio_entier.Checked = true;
                radio_positif.Checked = true;
                radio_début.Checked = true;
                Combo_type.SelectedIndex = 0;
                pi.Checked = true;
            }
            try
            {
                int valeur=(int) ((new System.IO.FileInfo(parent.currentFileName).Length/4) / (nb_ligne.Value * nbr_colon.Value));
                if(valeur==0)valeur=1;

                nbr_image.Value = valeur;
                        
            }
            catch (Exception ex)
            {
                string msg = "Fichier introuvable!"+ex.Message;
                MessageBox.Show(msg, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion



        #region methode


        /// <summary>
        /// desactiver les fonctionalité si fichier bim
        /// </summary>
        public void desactiver_bim()
        {
            nbr_oct_valeur.SelectedIndex=2;
            nbr_oct_valeur.Enabled=false;
            radio_reel.Checked=true;
            Box_carac_valeur.Enabled=false;
            check_swap.Enabled=false;
            radio_pos_neg.Checked=true;
            box_positif_negatif.Enabled=false;
            group_entete.Enabled=false;
            Combo_type.SelectedIndex=0;
            check_rvb.Enabled = false;


        }
        #endregion


        #region action
        /// <summary>
        /// activer/desactiver selon le type de l'examen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Combo_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Combo_type.SelectedIndex==2)
            {
                box_angle.Enabled=true;
                deupi.Checked=true;
            }
            else
                box_angle.Enabled=false;
        }
            
        /// <summary>
        /// bouton OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  void b_ok_Click(object sender, EventArgs e)
        {
            if ((Combo_type.SelectedIndex == 2) && (nbr_image.Value < 2))
            {
                string msg = "Examen tomographique, le nombre d'images doit être > 1";
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            this.b_ok.Cursor = System.Windows.Forms.Cursors.WaitCursor; 
         
            Examen.type_examen type=Examen.type_examen.statique;
            switch(Combo_type.SelectedIndex)
            {
                case 0:type=Examen.type_examen.statique;
                        break;
                case 1:type=Examen.type_examen.dynamique;
                        break;
                case 2:type=Examen.type_examen.tomographique;
                       break;
                case 3:type=Examen.type_examen.synchronisé;
                       break;
            }
            int nbr = 0;
            switch (nbr_oct_valeur.SelectedIndex)
            {
                case 0: nbr = 1;
                    break;
                case 1: nbr=2;
                    break;
                case 2: nbr = 4;
                    break;
               
            }
            btn = b_ok;
            this.Hide();
            this.Dispose();

            if (check_rvb.Checked == true)
            {
                string msg = "Image RVB, vous ne pourriez appliquer aucun traitement sur ce type d’examen!";
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Refresh();
            try
            {
                Examen examen = new Examen((int)nb_ligne.Value, (int)nbr_colon.Value, (int)nbr_image.Value, type, radio_entier.Checked,
                    radio_positif.Checked, radio_début.Checked, (int)taille.Value, pi.Checked, nbr, check_swap.Checked, check_rvb.Checked);
                ImageBox childform = new ImageBox(examen,parent,parent.currentFileName);
                MainForm.nb_forme_cree++;
                childform.MdiParent = parent;
                MainForm.btofront = false;
                childform.Show();
                MainForm.btofront = true;
                
                
                                
               if (Util.type_fichier(MainForm.forme_active.nom_fichier) == 3)
                {
                    if (examen.rvb == true)
                    {
                        MainForm.forme_active.afficher_image_rvb();
                        parent.l_image.ajouterfichier(MainForm.forme_active.nom_fichier);

                        Util.créer_image_palette(Util.créer_tableu_valeur_pour_palette(MainForm.palette_par_defaut), MainForm.forme_active.nom_dossier);
                        MainForm.forme_active.afficher_image_palette();
                        return;
                    }
                    else
                    {

                        string s = Util.conversion_fich_non_connu_to_bim(MainForm.forme_active.nom_fichier);
                        Util.créer_image(Util.créer_tableu_valeur_pour_palette(MainForm.palette_par_defaut), (int)nb_ligne.Value, (int)nbr_colon.Value,
                          s, MainForm.forme_active.nom_dossier);
                    }
                }
                if (Util.type_fichier(MainForm.forme_active.nom_fichier) == 2)
                {
                    Util.créer_image(Util.créer_tableu_valeur_pour_palette(MainForm.palette_par_defaut), (int)nb_ligne.Value, (int)nbr_colon.Value,
                        MainForm.forme_active.nom_fichier, MainForm.forme_active.nom_dossier);
                }
                /*parent.l_image.progressBar.Show();
                parent.l_image.progressBar.Value = 1;*/
            
                MainForm.forme_active.afficher_image_bim();

                parent.l_image.ajouterfichier(MainForm.forme_active.nom_fichier);

                Util.créer_image_palette(Util.créer_tableu_valeur_pour_palette(MainForm.palette_par_defaut),MainForm.forme_active.nom_dossier );
                MainForm.forme_active.afficher_image_palette();
               
                this.b_ok.Cursor = System.Windows.Forms.Cursors.Default;
                //System.Threading.Thread.Sleep(100);
                this.Refresh();
                //parent.l_image.progressBar.Hide();
                      
                      
            }
            catch (Exception ex)
            {
                string msg = "Impossible d'afficher l'image:\n"+ex.Message ;
                MessageBox.Show(msg, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            
          
        }

        /// <summary>
        /// annuler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void b_annuler_Click(object sender, EventArgs e)
        {
            btn = b_annuler;
            parent.etat3 = false;
            if (MainForm.nb_forme_cree < 1) parent.activer_fonctionalité(false);
            
            this.Dispose();
            
            
        }

        /// <summary>
        /// ouverture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Carateristiques_exam_Load(object sender, EventArgs e)
        {


            Rectangle r = Screen.PrimaryScreen.Bounds;
            this.Left = r.Width / 2 - this.Width / 2;
            this.Top = r.Height / 2 - this.Height / 2;

        }
        

        #endregion

        private void nbr_oct_valeur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((radio_entier.Checked == true) && (nbr_oct_valeur.SelectedIndex == 2))
            {
                string msg = "Un entier ne peut pas être codé sur 4 octets";
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nbr_oct_valeur.SelectedIndex = 1;
            }



            if ((nbr_oct_valeur.SelectedIndex == 0) || (nbr_oct_valeur.SelectedIndex == 2))
            {
                check_swap.Enabled = false;
                check_swap.Checked = false;

            }
            else
            {
                if ((radio_pos_neg.Checked == true) && (radio_entier.Checked == true))
                {
                    check_swap.Enabled = false;
                }
                else
                {
                    check_swap.Enabled = true;
                }
            }
                        
               
        }

        private void radio_reel_Click(object sender, EventArgs e)
        {
            nbr_oct_valeur.SelectedIndex = 2;
            radio_pos_neg.Checked = true;
            box_positif_negatif.Enabled = false;
            check_swap.Enabled = false;
            check_swap.Checked = false;
            nbr_oct_valeur.Enabled = false;

        }

        private void radio_entier_Click(object sender, EventArgs e)
        {
            if((nbr_oct_valeur.SelectedIndex==2)&&(radio_entier.Checked==true))
            {
                nbr_oct_valeur.SelectedIndex=1;
            }
            if (box_positif_negatif.Enabled == false)
            {
                box_positif_negatif.Enabled = true;
            }

            if ((check_swap.Enabled == false)&&(nbr_oct_valeur.SelectedIndex==1))
            {
                check_swap.Enabled = true;
            }
            if (nbr_oct_valeur.Enabled == false)
            {
                nbr_oct_valeur.Enabled = true;
            }
        }

        private void radio_pos_neg_Click(object sender, EventArgs e)
        {
            if ((radio_entier.Checked == true) && (nbr_oct_valeur.SelectedIndex == 1))
            {
                check_swap.Enabled = false;
                check_swap.Checked = false;
            }

        }

        private void radio_positif_Click(object sender, EventArgs e)
        {
            if ((radio_entier.Checked == true) && (nbr_oct_valeur.SelectedIndex == 1) && (check_swap.Enabled == false))
            {
                check_swap.Enabled = true;
            }

        }

        

        
        
    }
}
