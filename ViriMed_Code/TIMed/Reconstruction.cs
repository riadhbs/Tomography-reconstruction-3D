using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TIMed
{
    public partial class Reconstruction : Form
    {
        public static int capteur = 0;
        MainForm parent;
        public static int prograss_max = 0;
        
        public Reconstruction(MainForm parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void b_reconst_Click(object sender, EventArgs e)
        {

            int n =(int)( Math.Log(MainForm.forme_active.caracteristique_exam.nb_image) / Math.Log(2));
            parent.desactiver_activer_osem(n, true);
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
            if ((MainForm.forme_active.caracteristique_exam==null)||(MainForm.forme_active.caracteristique_exam.type_ex != Examen.type_examen.tomographique))
            {
                this.Dispose();
                string msg = "Cet examen n'est pas tomographique!";
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            label2.Show();
            label2.Update();
            label2.Refresh();
                        
            int nb_colon = MainForm.forme_active.caracteristique_exam.nb_colon;
            int nb_ligne =  MainForm.forme_active.caracteristique_exam.nb_ligne;
            int nb_image = MainForm.forme_active.caracteristique_exam.nb_image;
                        
            int nb_iteration =(int) nombre_itéra.Value;
            this.b_reconst.Cursor = System.Windows.Forms.Cursors.WaitCursor;
           
            
            Examen exam = new Examen(nb_colon, nb_colon, nb_ligne, Examen.type_examen.None, MainForm.forme_active.caracteristique_exam.entier,
                MainForm.forme_active.caracteristique_exam.positif, MainForm.forme_active.caracteristique_exam.debut,
                MainForm.forme_active.caracteristique_exam.taille, MainForm.forme_active.caracteristique_exam.angle_pi_test,
                MainForm.forme_active.caracteristique_exam.nbr_oct_valeur, MainForm.forme_active.caracteristique_exam.swap,
                MainForm.forme_active.caracteristique_exam.rvb);
           
            
            int nb_total = exam.nb_colon*exam.nb_colon*exam.nb_ligne;

            ImageBox childform = new ImageBox(exam,parent,MainForm.forme_active.nom_fichier);
            MainForm.nb_forme_cree++;
            childform.MdiParent = parent;
            
            MainForm.btofront = false;
            childform.Show();
            MainForm.btofront = true;
            
            int size =nb_ligne*nb_image * nb_colon*4;
            string s = Util.conversion_fich_non_connu_to_bim(childform.nom_fichier);
            Stream buff_proj = new FileStream(s, FileMode.Open, FileAccess.Read);
            //buff_proj.Seek(size, SeekOrigin.Begin);
            byte[] temp = new byte[size];
            buff_proj.Read(temp, 0, temp.Length);
            MemoryStream w = new MemoryStream(temp,false);
            BinaryReader br = new BinaryReader(w);
           
            float[] t_proj = new float[size/4];
            for (int i = 0; i < t_proj.Length; i++)
            {
              t_proj[i]= br.ReadSingle();
            }
            buff_proj.Close();
            br.Close();
            w.Dispose();
            
           
            string nom_fic_bim = childform.nom_dossier + Path.GetFileNameWithoutExtension(childform.nom_fichier) + ".bim";
            progressBar1.Show();
            prograss_max = (int)(nombre_itéra.Value* 2);
            progressBar1.Maximum = prograss_max;
            float[] tomo = new float[nb_total];
            if (capteur==1)
            {
                childform.Text += " (MLEM/Itération n° : " + (int)nombre_itéra.Value + ")";
                for (int i = 0; i < nb_total; i++)
                {
                    tomo[i] = 1;
                }

                for (int i = 0; i < nb_iteration; i++)
                {
                    mlem_iteration(t_proj, ref tomo, nb_image, nb_colon, nb_ligne, exam.angle_pi, nom_fic_bim);
                }
            }
            if (capteur==2)
            {
                childform.Text += " (ASIRT/Itération n° : " + (int)nombre_itéra.Value + ")";
                float[] tab_s = new float[nb_colon*nb_image];
                remplissage_tab_s(nb_colon, nb_image, exam.angle_pi,ref tab_s);
                 
                for (int i = 0; i < nb_iteration; i++)
                {
                    asirt_iteration(t_proj, ref tomo, nb_image, nb_colon, nb_ligne, exam.angle_pi, nom_fic_bim,tab_s);
                }

            }
            if (capteur == 3)
            {
                childform.Text += " (OSEM_1/Itération n° : " + (int)nombre_itéra.Value + ")";
                for (int i = 0; i < nb_total; i++)
                {
                    tomo[i] = 1;
                }

                for (int i = 0; i < nb_iteration; i++)
                {
                    osem_iteration(1,t_proj, ref tomo, nb_image, nb_colon, nb_ligne, exam.angle_pi, nom_fic_bim);
                }

            }
            if (capteur == 4)
            {
                childform.Text += " (OSEM_2/Itération n° : " + (int)nombre_itéra.Value + ")";
                for (int i = 0; i < nb_total; i++)
                {
                    tomo[i] = 1;
                }
                progressBar1.Maximum *= 2;
                for (int i = 0; i < nb_iteration; i++)
                {
                    
                    osem_iteration(2,t_proj, ref tomo, nb_image, nb_colon, nb_ligne, exam.angle_pi, nom_fic_bim);
                }

            }
            if (capteur == 5)
            {
                childform.Text += " (OSEM_4/Itération n° : " + (int)nombre_itéra.Value + ")";
                for (int i = 0; i < nb_total; i++)
                {
                    tomo[i] = 1;
                }
                progressBar1.Maximum *= 4;
                for (int i = 0; i < nb_iteration; i++)
                {
                    
                    osem_iteration(4,t_proj, ref tomo, nb_image, nb_colon, nb_ligne, exam.angle_pi, nom_fic_bim);
                }

            }
            if (capteur == 6)
            {
                childform.Text += " (OSEM_8/Itération n° : " + (int)nombre_itéra.Value + ")";
                for (int i = 0; i < nb_total; i++)
                {
                    tomo[i] = 1;
                }
                progressBar1.Maximum *= 8;
                for (int i = 0; i < nb_iteration; i++)
                {
                    
                    osem_iteration(8,t_proj, ref tomo, nb_image, nb_colon, nb_ligne, exam.angle_pi, nom_fic_bim);
                }

            }
            if (capteur == 7)
            {
                childform.Text += " (OSEM_16/Itération n° : " + (int)nombre_itéra.Value + ")";
                for (int i = 0; i < nb_total; i++)
                {
                    tomo[i] = 1;
                }
                progressBar1.Maximum *= 16;
                for (int i = 0; i < nb_iteration; i++)
                {
                   
                    osem_iteration(16, t_proj, ref tomo, nb_image, nb_colon, nb_ligne, exam.angle_pi, nom_fic_bim);
                }

            }
            if (capteur == 8)
            {
                childform.Text += " (OSEM_32/Itération n° : " + (int)nombre_itéra.Value + ")";
                for (int i = 0; i < nb_total; i++)
                {
                    tomo[i] = 1;
                }
                progressBar1.Maximum *= 32;
                for (int i = 0; i < nb_iteration; i++)
                {
                    
                    osem_iteration(32, t_proj, ref tomo, nb_image, nb_colon, nb_ligne, exam.angle_pi, nom_fic_bim);
                }

            }
            if (capteur == 9)
            {
                childform.Text += " (OSEM_64/Itération n° : " + (int)nombre_itéra.Value + ")";
                for (int i = 0; i < nb_total; i++)
                {
                    tomo[i] = 1;
                }
                progressBar1.Maximum *= 64;
                for (int i = 0; i < nb_iteration; i++)
                {
                    
                    osem_iteration(64, t_proj, ref tomo, nb_image, nb_colon, nb_ligne, exam.angle_pi, nom_fic_bim);
                }

            }
            if (capteur == 10)
            {
                childform.Text += " (OSEM_128/Itération n° : " + (int)nombre_itéra.Value + ")";
                for (int i = 0; i < nb_total; i++)
                {
                    tomo[i] = 1;
                }
                progressBar1.Maximum *= 128;
                for (int i = 0; i < nb_iteration; i++)
                {
                    
                    osem_iteration(128, t_proj, ref tomo, nb_image, nb_colon, nb_ligne, exam.angle_pi, nom_fic_bim);
                }

            }


            Stream buff_tomo = new FileStream(s, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(buff_tomo);

            for (int i = 0; i < tomo.Length; i++)
            {
                bw.Write((float)tomo[i]);
            }

            buff_tomo.Close();
            bw.Close();
            
            Util.créer_image(Util.créer_tableu_valeur_pour_palette(MainForm.palette_par_defaut), MainForm.forme_active.caracteristique_exam.nb_ligne, MainForm.forme_active.caracteristique_exam.nb_colon,
              s, MainForm.forme_active.nom_dossier);
            MainForm.forme_active.afficher_image_bim();
            Util.créer_image_palette(Util.créer_tableu_valeur_pour_palette(MainForm.palette_par_defaut), MainForm.forme_active.nom_dossier);
            MainForm.forme_active.afficher_image_palette();
                       
            System.Threading.Thread.Sleep(100);
            this.Refresh();
            this.b_reconst.Cursor = System.Windows.Forms.Cursors.Default;

            label2.Hide();
            progressBar1.Value = 0;
            progressBar1.Hide();
            this.Hide();
            this.Dispose();

        }

        private void Reconstruction_Load(object sender, EventArgs e)
        {
            Rectangle r = Screen.PrimaryScreen.Bounds;
            this.Left = r.Width / 2 - this.Width / 2;
            this.Top = r.Height / 2 - this.Height / 2;

        }
        #region reconstruction

        public static float proj_pt(float x, float y, double cost, double sint)
        {

            float nb_ligne = MainForm.forme_active.caracteristique_exam.nb_ligne;
            float nb_colon = MainForm.forme_active.caracteristique_exam.nb_colon;

            return (float)((y - nb_ligne / 2) * sint - (x - nb_colon / 2) * cost + nb_colon / 2);
        }

        public static float surface_disque(float z)
        {

            return (float)((1 / Math.PI) * (Math.Asin(2 * z) + (Math.Sin(2 * Math.Asin(2 * z)) / 2)));

        }

        public static void proj_pixel(int i, int j, double cost, double sint, out int k1, out int k2, out float d1, out float d2)
        {
            float z = proj_pt((float)(i + 0.5), (float)(j + 0.5), cost, sint);

            if (z >= 0) k1 = (int)z;
            else k1 = (int)z - 1;
            if (z - k1 - 0.5 > 0)
            {
                k2 = k1 + 1;
                d2 = (float)(surface_disque(k1 + 1 - z) + 0.5);


            }
            else
            {

                k2 = k1 - 1;
                d2 = (float)(surface_disque(z - k1) + 0.5);


            }


            d1 = 1 - d2;

        }



        public  void proj_examen(float[] t_tomo, ref float[] t_proj, int nb_image, int nb_colon, int nb_ligne, double angle_rot)
        {
            progressBar1.Value += 1;
            int k1, k2;
            float d1, d2;
            double cost = 0;
            double sint = 0;


            double pas_teta = (double)(angle_rot / nb_image);

            int nbc = nb_colon * nb_colon;

            for (int a = 0; a < nb_image; a++)
            {
                cost = Math.Cos(a * pas_teta); sint = Math.Sin(a * pas_teta);

                for (int i = 0; i < nb_colon; i++)
                {
                    for (int j = 0; j < nb_colon; j++)
                    {
                        
                       
                        proj_pixel(i, j, cost, sint, out k1, out k2, out d1, out d2);

                        if ((k1 >= 0) && (k1 < nb_colon))
                        {
                            for (int nt = 0; nt < nb_ligne; nt++)
                            {
                                t_proj[a * nb_colon * nb_ligne + nt * nb_colon + k1] += (d2 * t_tomo[nt * nbc + j * nb_colon + i]);

                            }
                        }

                        if ((k2 >= 0) && (k2 < nb_colon))
                        {
                            for (int nt = 0; nt < nb_ligne; nt++)
                            {
                                t_proj[a * nb_colon * nb_ligne + nt * nb_colon + k2] += (d1 * t_tomo[nt * nbc + j * nb_colon + i]);

                            }
                        }

                    }
                }
            }

        }

        public  void remplissage_tab_s(int nb_colon, int nb_image, double angle_rot, ref float[] tab_s)
        {

            int k1, k2;
            float d1, d2;
            double cost = 0;
            double sint = 0;


            double pas_teta = (double)(angle_rot / nb_image);

            int nbc = nb_colon * nb_colon;

            for (int a = 0; a < nb_image; a++)
            {
                cost = Math.Cos(a * pas_teta); sint = Math.Sin(a * pas_teta);

                for (int i = 0; i < nb_colon; i++)
                {
                    for (int j = 0; j < nb_colon; j++)
                    {

                        proj_pixel(i, j, cost, sint, out k1, out k2, out d1, out d2);

                        if ((k1 >= 0) && (k1 < nb_colon))
                        {


                            tab_s[a * nb_colon + k1] += d2;


                        }

                        if ((k2 >= 0) && (k2 < nb_colon))
                        {
                            tab_s[a * nb_colon + k2] += d1;
                        }

                    }
                }
            }

        }


        public  void retro_proj_mlem_examen(ref float[] t_tomo, float[] t_proj, int nb_image, int nb_colon, int nb_ligne, double angle_rot)
        {
            progressBar1.Value += 1;
            int k1, k2;
            float d1, d2;
            double cost = 0;
            double sint = 0;

            double pas_teta = (double)(angle_rot / nb_image);

            int nbc = nb_colon * nb_colon;

            for (int a = 0; a < nb_image; a++)
            {
                cost = Math.Cos(a * pas_teta); sint = Math.Sin(a * pas_teta);
                for (int i = 0; i < nb_colon; i++)
                {
                    for (int j = 0; j < nb_colon; j++)
                    {
                        
                        proj_pixel(i, j, cost, sint, out k1, out k2, out d1, out d2);
                       

                        if ((k1 >= 0) && (k1 < nb_colon))
                        {
                            for (int nt = 0; nt < nb_ligne; nt++)
                            {
                                t_tomo[nt * nbc + j * nb_colon + i] += (d2 * t_proj[a * nb_colon * nb_ligne + nt * nb_colon + k1]);

                            }
                        }

                        if ((k2 >= 0) && (k2 < nb_colon))
                        {
                            for (int nt = 0; nt < nb_ligne; nt++)
                            {
                                t_tomo[nt * nbc + j * nb_colon + i] += (d1 * t_proj[a * nb_colon * nb_ligne + nt * nb_colon + k2]);

                            }
                        }

                    }
                }
            }
            //return t_tomo;
        }

        public  void retro_proj_asirt_examen(ref float[] t_tomo, float[] t_proj, int nb_image, int nb_colon, int nb_ligne, double angle_rot, float[] tab_s)
        {
            progressBar1.Value += 1;
            int k1, k2;
            float d1, d2;
            double cost = 0;
            double sint = 0;

            double pas_teta = (double)(angle_rot / nb_image);

            int nbc = nb_colon * nb_colon;

            for (int a = 0; a < nb_image; a++)
            {
                cost = Math.Cos(a * pas_teta); sint = Math.Sin(a * pas_teta);
                for (int i = 0; i < nb_colon; i++)
                {
                    for (int j = 0; j < nb_colon; j++)
                    {
                       

                        proj_pixel(i, j, cost, sint, out k1, out k2, out d1, out d2);


                        if ((k1 >= 0) && (k1 < nb_colon))
                        {
                            for (int nt = 0; nt < nb_ligne; nt++)
                            {
                                t_tomo[nt * nbc + j * nb_colon + i] += (d2 / tab_s[a * nb_colon + k1] * t_proj[a * nb_colon * nb_ligne + nt * nb_colon + k1]);

                            }
                        }

                        if ((k2 >= 0) && (k2 < nb_colon))
                        {
                            for (int nt = 0; nt < nb_ligne; nt++)
                            {
                                t_tomo[nt * nbc + j * nb_colon + i] += (d1 / tab_s[a * nb_colon + k2] * t_proj[a * nb_colon * nb_ligne + nt * nb_colon + k2]);

                            }
                        }

                    }
                }
            }
            //return t_tomo;
        }


        public  float surface_k(float z2, float z1)
        {
            int nc = MainForm.forme_active.caracteristique_exam.nb_colon;
            int r = nc / 2;
            double arcsin1 = Math.Asin(z1 / r);
            double arcsin2 = Math.Asin(z2 / r);
            return (float)(r * r * (arcsin2 - arcsin1 + (Math.Sin(2 * arcsin2) - Math.Sin(2 * arcsin1)) / 2));
        }


        public  void pre_osem_projection_exam(int set, int indice, float[] t_tomo, ref float[] t_proj, int nb_image, int nb_colon, int nb_ligne, double angle_rot)
        {
            progressBar1.Value += 1;
            int k1, k2;
            float d1, d2;
            double cost = 0;
            double sint = 0;


            double pas_teta = (double)(angle_rot / nb_image);

            int nbc = nb_colon * nb_colon;
            int indice_a = 0;
            for (int a = 0; a < nb_image / set; a++)
            {
                indice_a = set * a + indice;
                cost = Math.Cos(indice_a * pas_teta); sint = Math.Sin(indice_a * pas_teta);

                for (int i = 0; i < nb_colon; i++)
                {
                    for (int j = 0; j < nb_colon; j++)
                    {
                        
                        proj_pixel(i, j, cost, sint, out k1, out k2, out d1, out d2);

                        if ((k1 >= 0) && (k1 < nb_colon))
                        {
                            for (int nt = 0; nt < nb_ligne; nt++)
                            {
                                t_proj[indice_a * nb_colon * nb_ligne + nt * nb_colon + k1] += (d2 * t_tomo[nt * nbc + j * nb_colon + i]);

                            }
                        }

                        if ((k2 >= 0) && (k2 < nb_colon))
                        {
                            for (int nt = 0; nt < nb_ligne; nt++)
                            {
                                t_proj[indice_a * nb_colon * nb_ligne + nt * nb_colon + k2] += (d1 * t_tomo[nt * nbc + j * nb_colon + i]);

                            }
                        }

                    }
                }
            }
        }

        public  void pre_osem_retro_projection_exam(int set, int indice, ref float[] t_tomo, float[] t_proj, int nb_image, int nb_colon, int nb_ligne, double angle_rot)
        {
            progressBar1.Value += 1;
            int k1, k2;
            float d1, d2;
            double cost = 0;
            double sint = 0;

            double pas_teta = (double)(angle_rot / nb_image);

            int nbc = nb_colon * nb_colon;
            int indice_a = 0;
            for (int a = 0; a < nb_image / set; a++)
            {
                indice_a = set * a + indice;
                cost = Math.Cos(indice_a * pas_teta); sint = Math.Sin(indice_a * pas_teta);
                for (int i = 0; i < nb_colon; i++)
                {
                    for (int j = 0; j < nb_colon; j++)
                    {

                        
                        proj_pixel(i, j, cost, sint, out k1, out k2, out d1, out d2);


                        if ((k1 >= 0) && (k1 < nb_colon))
                        {
                            for (int nt = 0; nt < nb_ligne; nt++)
                            {
                                t_tomo[nt * nbc + j * nb_colon + i] += (d2 * t_proj[indice_a * nb_colon * nb_ligne + nt * nb_colon + k1]);

                            }
                        }

                        if ((k2 >= 0) && (k2 < nb_colon))
                        {
                            for (int nt = 0; nt < nb_ligne; nt++)
                            {
                                t_tomo[nt * nbc + j * nb_colon + i] += (d1 * t_proj[indice_a * nb_colon * nb_ligne + nt * nb_colon + k2]);

                            }
                        }

                    }
                }
            }

        }

        public  void pre_osem_iteration(int set, int indice, float[] t_p, ref float[] t_tomo, int nb_image, int nb_colon, int nb_ligne, double angle_rot)
        {
            float[] ep = new float[t_p.Length];
            float[] et = new float[t_tomo.Length];
            int nb_total = nb_colon * nb_ligne * nb_image;
            int nb_total2 = nb_colon * nb_colon * nb_ligne;


            
            pre_osem_projection_exam(set, indice, t_tomo, ref ep, nb_image, nb_colon, nb_ligne, angle_rot);



            //////////////////////////////////////////
            //                                      //
            //   construire le fichier sinog.bim    //
            //                                      //
            //                                      //
            //////////////////////////////////////////


            for (int i = 0; i < t_p.Length; i++)
            {
                if (ep[i] != 0)
                {
                    if (t_p[i] != 0)
                    {
                        ep[i] = (float)(t_p[i] / ep[i]);
                    }
                    else
                    {
                        ep[i] = 0;
                    }
                }

            }


            
            pre_osem_retro_projection_exam(set, indice, ref et, ep, nb_image, nb_colon, nb_ligne, angle_rot);


            for (int i = 0; i < t_tomo.Length; i++)
            {
                t_tomo[i] = (float)(t_tomo[i] * et[i]);
            }



            //////////////////////////////////////////
            //                                      //
            //   construire le fichier tomo.bim     //
            //                                      //
            //                                      //
            //////////////////////////////////////////
        }


        public  void osem_iteration(int set, float[] t_p, ref float[] t_tomo, int nb_image, int nb_colon, int nb_ligne, double angle_rot, string tomo_bim)
        {
            for (int indice = 0; indice < set; indice++)
            {
                
                pre_osem_iteration(set, indice, t_p, ref t_tomo, nb_image, nb_colon, nb_ligne, angle_rot);
            }
        }


        public  void mlem_iteration(float[] t_p, ref float[] t_tomo, int nb_image, int nb_colon, int nb_ligne, double angle_rot, string tomo_bim)
        {
            float[] ep = new float[t_p.Length];
            float[] et = new float[t_tomo.Length];
            int nb_total = nb_colon * nb_ligne * nb_image;
            int nb_total2 = nb_colon * nb_colon * nb_ligne;


            proj_examen(t_tomo, ref ep, nb_image, nb_colon, nb_ligne, angle_rot);


            //////////////////////////////////////////
            //                                      //
            //   construire le fichier sinog.bim    //
            //                                      //
            //                                      //
            //////////////////////////////////////////


            for (int i = 0; i < t_p.Length; i++)
            {
                if (t_p[i] != 0)
                {
                    ep[i] = (float)(t_p[i] / ep[i]);
                }
                else
                {
                    ep[i] = 0;
                }

            }

            retro_proj_mlem_examen(ref et, ep, nb_image, nb_colon, nb_ligne, angle_rot);

            for (int i = 0; i < t_tomo.Length; i++)
            {
                t_tomo[i] = (float)(t_tomo[i] * et[i]);
            }


            //////////////////////////////////////////
            //                                      //
            //   construire le fichier tomo.bim     //
            //                                      //
            //                                      //
            //////////////////////////////////////////


        }



        public  void asirt_iteration(float[] t_p, ref float[] t_tomo, int nb_image, int nb_colon, int nb_ligne, double angle_rot, string tomo_bim, float[] tab_s)
        {
            float[] ep = new float[t_p.Length];
            float[] et = new float[t_tomo.Length];
            int nb_total = nb_colon * nb_ligne * nb_image;
            int nb_total2 = nb_colon * nb_colon * nb_ligne;


            proj_examen(t_tomo, ref ep, nb_image, nb_colon, nb_ligne, angle_rot);


            //////////////////////////////////////////
            //                                      //
            //   construire le fichier sinog.bim    //
            //                                      //
            //                                      //
            //////////////////////////////////////////


            for (int i = 0; i < t_p.Length; i++)
            {

                ep[i] = (float)(t_p[i] - ep[i]);


            }

            retro_proj_asirt_examen(ref et, ep, nb_image, nb_colon, nb_ligne, angle_rot, tab_s);

            for (int i = 0; i < t_tomo.Length; i++)
            {
                t_tomo[i] = (float)(t_tomo[i] + et[i] / nb_image);
                if (t_tomo[i] < 0) t_tomo[i] = 0;
            }


            //////////////////////////////////////////
            //                                      //
            //   construire le fichier tomo.bim     //
            //                                      //
            //                                      //
            //////////////////////////////////////////
            

        }
               

        #endregion
        
    }
}
