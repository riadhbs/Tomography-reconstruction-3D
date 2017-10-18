using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;


namespace TIMed
{
    class Util
    {

        #region methode



        /// <summary>
        /// 1:jpg/bmp/s... 2:bim 3:non_connu
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static int type_fichier(string filename)
        {
            string extension = Path.GetExtension(filename).ToLower();
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                case ".gif":
                case ".tif":
                case ".tiff":
                case ".png": return 1;
                    
                case ".s": return 4;
                    
                case ".bim": return 2;

                case ".dcm":
                case ".dic":
                case ".dc3":return 6;
                    
                case ".bmp": if (Util.Test_BMP(filename) == true) return 5;
                            else return 1;
                    
            }
            return 3;
        }
        /// <summary>
        /// convertir de bim to byte
        /// </summary>
        /// <param name="nomfic_bim"></param>
        /// <returns></returns>

        public static byte[] bim_to_byte(string nomfic_bim,string dossier)
        {
            Stream originalstream = null;
            Stream Boriginalstream = null;
            try
            {

                float min_bim = 0; float max_bim = 0;

                originalstream = new FileStream(nomfic_bim, FileMode.Open, FileAccess.Read);
                string fichir_byte = dossier + "fichier.byte";
                Boriginalstream = new FileStream(fichir_byte, FileMode.CreateNew, FileAccess.Write);

                int size = (int)new FileInfo(nomfic_bim).Length;
                byte[] Bbuf = new byte[size];
                originalstream.Read(Bbuf, 0, size);
                float[] Fbuf = new float[size / 4];


                min_bim = max_bim = Fbuf[0] = BitConverter.ToSingle(Bbuf, 0);


                for (int i = 1; i < size / 4; i++)
                {


                    Fbuf[i] = BitConverter.ToSingle(Bbuf, 4 * i);
                    if (max_bim < Fbuf[i]) max_bim = Fbuf[i];
                    if (min_bim > Fbuf[i]) min_bim = Fbuf[i];

                }
                

                MainForm.forme_active.min_bim = min_bim;
                MainForm.forme_active.max_bim = max_bim;

                for (int i = 0; i < size / 4; i++)
                {
                    Bbuf[i] = (byte)((Fbuf[i] - min_bim) * 255 / (max_bim - min_bim));
                }

                Boriginalstream.Write(Bbuf, 0, size / 4);
                originalstream.Close();
                Boriginalstream.Close();
            
                return Bbuf;
            }
            catch (Exception ex)
            {
                string msg = "Problème lors de la création de l'image!";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                originalstream.Close();
                Boriginalstream.Close();
                
            }
            

            return null;
        }

        /// <summary>
        /// creer tableur de valeur pour palette
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>

        public static byte[] créer_tableu_valeur_pour_palette(string p)
        {
            try
            {
                Stream originalstream = new FileStream(p, FileMode.Open, FileAccess.Read);
                byte[] Bbuf = new byte[1024];
                originalstream.Read(Bbuf, 0, 1024);
                originalstream.Close();
                return Bbuf;
            }
            catch (Exception ex)
            {
                string msg = "Problème lors de la création de l'image!" + ex.Message;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;

        }

        /// <summary>
        /// créer une image d'examen
        /// </summary>
        /// <param name="hauteur"></param>
        /// <param name="largeur"></param>
        /// <param name="nom_palette"></param>
        /// <param name="fichier_bim"></param>
        /// <param name="chemin"></param>
        public static void créer_image(byte[]tab_pal,int hauteur, int largeur, string fichier_bim, string chemin)
        {
                               
            int stride = largeur;


            try
            {


                byte[] pixel = null;
                if (MainForm.forme_active.bmp256 == true)
                {
                    pixel = Util.conversion_BMP_byte(fichier_bim);
                }
                else
                {

                    pixel = bim_to_byte(fichier_bim, chemin);
                }



                System.Windows.Media.Imaging.BitmapSource image = System.Windows.Media.Imaging.BitmapSource.Create(
                   largeur,
                   hauteur,
                   96,
                   96,
                   System.Windows.Media.PixelFormats.Indexed8,
                   créer_palette(tab_pal),
                   pixel,
                   stride);

                enregistrer_fichier_sur_le_disque(image, chemin, Path.GetFileNameWithoutExtension(fichier_bim));
            }
            catch (Exception ex)
            {
                string msg = "Problème lors de la création de l'image!";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        
        /// <summary>
        /// enregisrer l'image de l'examen sur le disque
        /// </summary>
        /// <param name="image"></param>
        /// <param name="chemin"></param>
        /// <param name="nom_fic"></param>
        public static void enregistrer_fichier_sur_le_disque(System.Windows.Media.Imaging.BitmapSource image, string chemin, string nom_fic)
        {
            FileStream stream = new FileStream(chemin + nom_fic + ".bmp", FileMode.Create);
            System.Windows.Media.Imaging.BmpBitmapEncoder encoder = new System.Windows.Media.Imaging.BmpBitmapEncoder();
            System.Windows.Controls.TextBlock myTextBlock = new System.Windows.Controls.TextBlock();
            myTextBlock.Text = "Codec Author is: 15_22" ;
            encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(image));
            encoder.Save(stream);
            stream.Close();
        }

        /// <summary>
        /// creer l'image de la palette
        /// </summary>
        /// <param name="nom_pal"></param>
        /// <param name="chemin"></param>
        public static void créer_image_palette(byte[] tab_pal, string chemin)
        {
            byte[] tableau_palette = new byte[5120];

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    tableau_palette[i * 20 + j] = (byte)i;
                }
            }

            System.Windows.Media.Imaging.BitmapSource image = System.Windows.Media.Imaging.BitmapSource.Create(
               20,
               256,
               96,
               96,
               System.Windows.Media.PixelFormats.Indexed8,
               seuiller_tableau_palette(tab_pal),
               tableau_palette,
               20);
            try
            {

                enregistrer_fichier_sur_le_disque(image, chemin, Path.GetFileNameWithoutExtension(MainForm.forme_active.nom_palette));
            }
            catch (Exception ex)
            {
                string msg = "Problème lors de la création de l'image!";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /// <summary>
        /// true si extension traité
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>


        public static bool extensiontraitée(string filename)
        {
            string extension = Path.GetExtension(filename).ToLower();
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                case ".gif":
                case ".tif":
                case ".tiff":
                case ".bmp":
                case ".png": return true;

            }
            return false;


        }

        /// <summary>
        /// créer multi _image
        /// </summary>
        /// <param name="tab_pal"></param>
        /// <param name="nb_image_fich"></param>
        /// <param name="image_debut"></param>
        /// <param name="nb_ligne"></param>
        /// <param name="nb_colon"></param>
        /// <param name="h"></param>
        /// <param name="w"></param>
        /// <param name="chemin"></param>
        /// <param name="fichier_bim"></param>

        public static void créer_multi_image(byte[] tab_pal, int nb_image_fich, int image_debut, int nb_ligne, int nb_colon, int h, int w, string chemin, string fichier_bim)
        {
            
            int nic = w / nb_colon;
            int nil = h / nb_ligne;
            if (nic == 0)
            {
                nil = 1;
                /*string msg = "Paramètres invalides!\n";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);*/

            }
            if (nil == 0)
            {
               nil = 1;
                /*string msg = "Paramètres invalides!\n";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);*/

            }

            
            int l, c;

            byte[] pixel = tableau_byte(nb_image_fich, image_debut,nb_ligne, nb_colon, chemin, nic, nil,out l,out c);
            if (l == 0)
            {
                l = 1;
                /*string msg = "Paramètres invalides!\n";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
                
            }
            if(c==0)
            {
                c = 1;
                /*string msg = "Paramètres invalides!\n";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
                
            }

            System.Windows.Media.Imaging.BitmapSource image = System.Windows.Media.Imaging.BitmapSource.Create(
               l * nb_colon,
               c * nb_ligne,
               96,
               96,
               System.Windows.Media.PixelFormats.Indexed8,
               seuiller_tableau_palette(tab_pal),
               pixel,
               l * nb_colon);
            try
            {

                enregistrer_fichier_sur_le_disque(image, chemin, Path.GetFileNameWithoutExtension(fichier_bim));
            }
            catch (Exception ex)
            {
                string msg = "Problème lors de la création de l'image!" + ex.Message;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        /// <summary>
        /// créer mono image
        /// </summary>
        /// <param name="tab_pal"></param>
        /// <param name="nb_ligne"></param>
        /// <param name="nb_colon"></param>
        /// <param name="fichier_bim"></param>
        /// <param name="chemin"></param>
        public static void mono_image(byte[] tab_pal, int nb_ligne, int nb_colon, string fichier_bim, string chemin)
        {
            byte[] pixel = tableau_byte_mono(nb_ligne, nb_colon, chemin);
            System.Windows.Media.Imaging.BitmapSource image = System.Windows.Media.Imaging.BitmapSource.Create(
               nb_colon,
               nb_ligne,
               96,
               96,
               System.Windows.Media.PixelFormats.Indexed8,
               seuiller_tableau_palette(tab_pal),
               pixel,
               nb_colon);
            try
            {

                enregistrer_fichier_sur_le_disque(image, chemin, Path.GetFileNameWithoutExtension(fichier_bim));
            }
            catch (Exception ex)
            {
                string msg = "Problème lors de la création de l'image!" + ex.Message;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        public static byte[] tableau_byte_mono(int nb_ligne, int nb_colon, string chemin)
        {
            string fichier_byte = chemin + "\\fichier.byte";
            Stream byte_originalstream = new FileStream(fichier_byte, FileMode.Open, FileAccess.Read);
            int size = nb_colon * nb_ligne;
            byte[] tab_pal = new byte[size];
            byte_originalstream.Read(tab_pal, 0, size);
            byte_originalstream.Close();

            return tab_pal;

        }

        /// <summary>
        /// multi
        /// </summary>
        /// <param name="nb_image_fich"></param>
        /// <param name="image_debut"></param>
        /// <param name="nb_ligne"></param>
        /// <param name="nb_colon"></param>
        /// <param name="chemin"></param>
        /// <param name="nic"></param>
        /// <param name="nil"></param>
        /// <returns></returns>


        public static byte[] tableau_byte(int nb_image_fich, int image_debut, int nb_ligne, int nb_colon, string chemin, int nic, int nil,out int l,out int c)
        {

            string fichier_byte = chemin + "\\fichier.byte";
            Stream byte_originalstream = new FileStream(fichier_byte, FileMode.Open, FileAccess.Read);

            int nb_image_total = nic * nil;

            int size = nb_image_total * nb_ligne * nb_colon;
            if (nb_image_fich > nb_image_total) size = nb_image_fich * nb_ligne * nb_colon;
            byte[] tab = new byte[size];
            byte_originalstream.Read(tab, 0, size);

            int debut = (image_debut - 1) * nb_ligne * nb_colon;

            byte[] Bbuf = new byte[nb_image_total * nb_ligne * nb_colon];
            int var = nb_image_total * nb_ligne * nb_colon;
            if ((nb_image_total * nb_ligne * nb_colon + debut) > size) var = size - debut;
            MemoryStream aux = new MemoryStream(tab, debut, var);
             aux.Read(Bbuf, 0, nb_image_total * nb_ligne * nb_colon);
             

            int pas_j = 0;
            int pas_y = 0;
            int pas_i = 0;
            int numero_image = 0;
            byte[] pixel;

            int nbim = nb_image_fich  -(image_debut-1) ;
            if ((nic * nil) > nbim)
            {
                if (nbim >= nic)
                {
                    c = nbim / nic;
                    if ((nbim % nic) != 0) c++;
                    l = nic;
                }
                else
                {
                    l = nbim;
                    c = 1;
                }
               
            }
            else
            {
                c = nil;
                l = nic;
            }
 
            pixel = new byte[l*c * nb_ligne * nb_colon];
            int indice = 0;
            for (int j = 1; j <= c; j++)
            {
                pas_j = nb_ligne * nb_colon * l * (j - 1);


                for (int y = 1; y <= nb_ligne; y++)
                {
                    pas_y = l * nb_colon * (y - 1);

                    for (int i = 1; i <= l; i++)
                    {
                        pas_i = nb_colon * (i - 1);
                        numero_image = l * (j - 1) + i;

                        for (int x = 1; x <= nb_colon; x++)
                        {
                            indice=pas_j + pas_i + pas_y + (x - 1);
                            

                            pixel[indice] = Bbuf[(numero_image - 1) * nb_ligne * nb_colon + nb_colon * (y - 1) + (x - 1)];
                        }
                    }
                }
            }
            aux.Close();
            aux.Dispose();
            byte_originalstream.Close();
            byte_originalstream.Dispose();

            return pixel;

        }

        public static void palette_negatif(string nom_pal)
        {

            byte[] pal2 = new byte[1024];
            Stream originalstream = new FileStream(nom_pal, FileMode.Open, FileAccess.Read);
            byte[] pal1 = new byte[1024];
            originalstream.Read(pal1, 0, 1024);
            originalstream.Close();

            for (int i = 0; i < 256; i++)
            {
                for (int c = 0; c < 4; c++)
                {
                    pal2[i * 4 + c] = pal1[(255 - i) * 4 + c];
                }
            }

            Stream s = new FileStream(Application.StartupPath+"15_22.pal", FileMode.Create, FileAccess.Write);
            s.Write(pal2,0,1024);
            s.Close();

            //return pal2;

        }

        public static int[] table_indice_positif()
        {

            int s_max = MainForm.forme_active.seuil_max;
            int s_min = MainForm.forme_active.seuil_min;

            int[] tab_indice = new int[256];
            for (int i = 0; i <= s_min - 1; i++)
            {
                tab_indice[i] = 0;
            }
            for (int i = s_min; i <= s_max; i++)
            {
                tab_indice[i] = (int)(((i - s_min) * 255) / (s_max - s_min));

            }

            for (int i = s_max + 1; i < 256; i++)
            {
                tab_indice[i] = 255;

            }
            return tab_indice;

        }

        public static int[] table_indice_negatif()
        {

            int s_max = MainForm.forme_active.seuil_max;
            int s_min = MainForm.forme_active.seuil_min;

            int[] tab_indice = new int[256];
            for (int i = 0; i <= s_min - 1; i++)
            {
                tab_indice[i] = 255;
            }
            for (int i = s_min; i <= s_max; i++)
            {
                tab_indice[i] = (int)(255-(((i - s_min) * 255) / (s_max - s_min)));

            }

            for (int i = s_max + 1; i < 256; i++)
            {
                tab_indice[i] = 0;

            }
            return tab_indice;
        }

        public static int[] seuillage_ou_gamma_tableau()
        {
            float gamma = (float)(MainForm.forme_active.gamma / 10000);
            int[] tab_indice = null;
            if (MainForm.forme_active.negatif == false)
            {
                tab_indice = table_indice_positif();
            }
            else
            {
                tab_indice = table_indice_negatif();
            }

            if (gamma != 0)
            {
                int[] tab = tab_indice;
                tab_indice = tableau_gamma(tab);
            }
            return tab_indice;

        }


        public static System.Windows.Media.Imaging.BitmapPalette seuiller_tableau_palette(byte[] tab_pal)
        {
            int r = 0;
            float gamma = (float)(MainForm.forme_active.gamma / 10000);
            List<System.Windows.Media.Color> colors = new List<System.Windows.Media.Color>();
            int[] tab_indice = table_indice_positif();
            if (gamma != 0)
            {
                int[] tab = tab_indice;
                tab_indice = tableau_gamma(tab);
            }

            for (int i = 0; i <= 255; i++)
            {
                r = tab_indice[i];
                colors.Add(System.Windows.Media.Color.FromArgb(0, tab_pal[r * 4 + 2], tab_pal[r * 4 + 1], tab_pal[r * 4]));
            }


            System.Windows.Media.Imaging.BitmapPalette myPalette = new System.Windows.Media.Imaging.BitmapPalette(colors);
            return myPalette;

        }

        /// <summary>
        /// gamma
        /// </summary>
        /// <param name="tab_indice"></param>
        /// <returns></returns>

        public static int[] tableau_gamma(int[] tab_indice)
        {

            float gamma = (float)(MainForm.forme_active.gamma / 10000);
            float r = 0;
            int s_min = MainForm.forme_active.seuil_min;
            int s_max = MainForm.forme_active.seuil_max;
            if (MainForm.forme_active.negatif == false)
            {

                if (gamma > 0)
                {
                    r = (float)(255 / (1 - Math.Exp(-1 *gamma * 255)));
                    for (int i = s_min + 1; i <= s_max - 1; i++)
                    {
                        tab_indice[i] = positive(tab_indice[i], r);
                    }
                }

                else
                {
                    r = (float)(255 / (1 - Math.Exp(gamma * 255)));
                    for (int i = s_min + 1; i <= s_max - 1; i++)
                    {
                        tab_indice[i] = negatif(tab_indice[i], r);
                    }
                }
            }
            else
            {
                if (gamma > 0)
                {
                    r = (float)(255 / (1 - Math.Exp(-1 * gamma * 255)));
                    for (int i = s_min + 1; i <= s_max - 1; i++)
                    {
                        tab_indice[i] = 255 - positive(255 - tab_indice[i], r);
                    }
                }

                else
                {
                    r = (float)(255 / (1 - Math.Exp(gamma * 255)));
                    for (int i = s_min + 1; i <= s_max - 1; i++)
                    {
                        tab_indice[i] = 255 - negatif(255 - tab_indice[i], r);
                    }
                }
            }

            return tab_indice;

        }

        public static int positive(int x, float r)
        {
            float gamma = (float)(MainForm.forme_active.gamma / 10000);
            byte xx = (byte)x;
            byte y = (byte)(r * (1 - Math.Exp(-1 * gamma * xx)));

            return y;
        }

        public static int negatif(int x, float r)
        {
            float gamma = (float)(MainForm.forme_active.gamma / 10000);
            byte xx = (byte)x;
            byte y = (byte)(255 - r * (1 - Math.Exp(gamma * (255 - xx))));

            return y;
        }

        public static void afficher_numéro()
        {
            Point p;
            int taille = 8;//* MainForm.forme_active.zoom;
            Font drawFont = new Font("Arial", taille);
            SolidBrush drawBrush = new SolidBrush(Color.Red);
            int nb_colon = MainForm.forme_active.caracteristique_exam.nb_colon;
            int nb_ligne = MainForm.forme_active.caracteristique_exam.nb_ligne;
            int nic = MainForm.forme_active.b_image.Image.Width / nb_colon;
            int nil = MainForm.forme_active.b_image.Image.Height / nb_ligne;
            int num_image = 1;

            Size s = MainForm.forme_active.b_image.Image.Size; //new Size(nb_colon*nic, nb_ligne*nil);
            Bitmap bit = new Bitmap(MainForm.forme_active.b_image.Image, s);
            Graphics g = Graphics.FromImage(bit);

            int nombre = 0;
            for (int j = 0; j < nil; j++)
            {
                for (int i = 0; i < nic; i++)
                {
                    nombre++;
                    if (nombre > MainForm.forme_active.caracteristique_exam.nb_image - MainForm.forme_active.image_debut + 1)
                    {
                        i = nic;
                        j = nil;
                    }
                    p = new Point(i * nb_colon, j * nb_ligne);
                    //MainForm.forme_active.b_image.CreateGraphics().DrawString(""+(MainForm.forme_active.image_debut-1+num_image++), drawFont, drawBrush, p);
                    g.DrawString("" + (MainForm.forme_active.image_debut - 1 + num_image++), drawFont, drawBrush, p);

                }
            }
            MainForm.forme_active.b_image.Image = bit;
            g.Dispose();
        }
        
        /// <summary>
        /// creer une palette =>bitmappalette
        /// </summary>
        /// <param name="nom_palette"></param>
        /// <returns></returns>

        public static System.Windows.Media.Imaging.BitmapPalette créer_palette(byte[]tab_pal)
        {

            byte[] tab_palette = tab_pal;
            List<System.Windows.Media.Color> colors = new List<System.Windows.Media.Color>();
            for (int i = 0; i < 256; i++)
            {

                colors.Add(System.Windows.Media.Color.FromArgb(0, tab_palette[4 * i + 2], tab_palette[4 * i + 1], tab_palette[4 * i]));

            }

            System.Windows.Media.Imaging.BitmapPalette myPalette = new System.Windows.Media.Imaging.BitmapPalette(colors);
            return myPalette;
        }

       
        /// <summary>
        /// convertir de bitmapsource to bitmap
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>

        public static Bitmap bitmapsource_to_bitmap(System.Windows.Media.Imaging.BitmapSource bs)
        {


            int width = bs.PixelWidth;
            int height = bs.PixelHeight;
            int stride = width * ((bs.Format.BitsPerPixel + 7) / 8);

            byte[] bits = new byte[height * width];

            bs.CopyPixels(bits, stride, 0);
            System.Drawing.Bitmap bitmap;
            unsafe
            {
                fixed (byte* pBits = bits)
                {
                    IntPtr ptr = new IntPtr(pBits);

                    bitmap = new System.Drawing.Bitmap(
                       width,
                       height,
                       stride,
                       System.Drawing.Imaging.PixelFormat.Format8bppIndexed,
                       ptr);

                }
            }

            return bitmap;
        }
       
             

        #endregion


        #region util

        public static void créer_image_seuillée(string nom_pal, int nb_ligne, int nb_colon, string fichier_bim, string chemin)
        {

            byte[] pixel = tableau_byte_mono(nb_ligne, nb_colon, chemin);
            System.Windows.Media.Imaging.BitmapSource image = System.Windows.Media.Imaging.BitmapSource.Create(
               nb_colon,
               nb_ligne,
               96,
               96,
               System.Windows.Media.PixelFormats.Indexed8,
               seuiller_tableau_palette(créer_tableu_valeur_pour_palette(nom_pal)),
               pixel,
               nb_colon);
            try
            {

                enregistrer_fichier_sur_le_disque(image, chemin, Path.GetFileNameWithoutExtension(fichier_bim));
            }
            catch (Exception ex)
            {
                string msg = "Problème lors de la création de l'image!" + ex.Message;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void créer_image_palette_seuillée(string nom_pal, string chemin)
        {
            byte[] tableau_palette = new byte[5120];

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    tableau_palette[i * 20 + j] = (byte)i;
                }
            }

            System.Windows.Media.Imaging.BitmapSource image = System.Windows.Media.Imaging.BitmapSource.Create(
               20,
               256,
               96,
               96,
               System.Windows.Media.PixelFormats.Indexed8,
               seuiller_tableau_palette(créer_tableu_valeur_pour_palette(nom_pal)),
               tableau_palette,
               20);
            try
            {

                enregistrer_fichier_sur_le_disque(image, chemin, Path.GetFileNameWithoutExtension(MainForm.forme_active.nom_palette));
            }
            catch (Exception ex)
            {
                string msg = "Problème lors de la création de l'image!" + ex.Message;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       

        public static bool estunfichierconnnu(string filename)
        {
            string extension = Path.GetExtension(filename).ToLower();
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                case ".bmp":
                case ".gif":
                case ".tif":
                case ".tiff":
                case ".png":
                case ".bim":
                case ".s": return true;

            }

            return false;
        }

        public static void construire_palette_negative(string nom_pal, string nom_paln)
        {
            Stream originalstream = new FileStream(nom_pal, FileMode.Open, FileAccess.Read);
            byte[] Bbuf = new byte[1024];
            byte[] newbuf = new byte[1024];
            originalstream.Read(Bbuf, 0, 1024);

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    newbuf[1023 - (4 * i + j)] = Bbuf[4 * i + (3 - j)];
                }

            }
            Stream Boriginalstream = new FileStream(nom_paln, FileMode.CreateNew, FileAccess.Write);
            Boriginalstream.Write(newbuf, 0, 1024);
            Boriginalstream.Close();
            originalstream.Close();

        }

        public static void nom_palette_normal()
        {
            string aux = MainForm.forme_active.nom_palette;
            string aux2 = null;
            for (int i = 0; i < MainForm.forme_active.nom_palette.Length - 5; i++)
            {

                aux2 += aux[i];

            }
            aux2 += ".pal";
            MainForm.forme_active.nom_palette = aux2;


        }

        public static void nom_palette_negatif()
        {
            string aux = MainForm.forme_active.nom_palette;
            string aux2 = null;
            for (int i = 0; i < MainForm.forme_active.nom_palette.Length - 4; i++)
            {

                aux2 += aux[i];

            }
            aux2 += "n.pal";
            MainForm.forme_active.nom_palette = aux2;




        }




        #endregion


        #region ex
        
      

        ////////////////////////////////////////////////////////////////////////////////////


        public static byte[] conversion_BMP_byte(string nom_fic)
        {
            string fichier_bim = MainForm.chemin + (MainForm.num_forme_creer - 1) + "\\" + Path.GetFileNameWithoutExtension(nom_fic) + ".bim";
            Stream originalstream = new FileStream(fichier_bim, FileMode.Open, FileAccess.Read);
            float min_bim = 0; float max_bim = 0;

            string fichier_byte = MainForm.chemin + (MainForm.num_forme_creer - 1) + "\\fichier.byte";
            Stream Boriginalstream = new FileStream(fichier_byte, FileMode.CreateNew, FileAccess.Write);

            int size = (int)new FileInfo(fichier_bim).Length;
            byte[] Bbuf = new byte[size];
            originalstream.Read(Bbuf, 0, size);
            float[] Fbuf = new float[size ];


            min_bim = max_bim = Fbuf[0];


            for (int i = 1; i < size ; i++)
            {


                Fbuf[i] = (float)Bbuf[i];
                if (max_bim < Fbuf[i]) max_bim = Fbuf[i];
                if (min_bim > Fbuf[i]) min_bim = Fbuf[i];

            }
            MainForm.forme_active.min_bim = min_bim;
            MainForm.forme_active.max_bim = max_bim;

            for (int i = 0; i < size ; i++)
            {
                Bbuf[i] = (byte)((Fbuf[i] - min_bim) * 255 / (max_bim - min_bim));
            }

            Boriginalstream.Write(Bbuf, 0, size );
            originalstream.Close();
            Boriginalstream.Close();
            return Bbuf;
        }
        
        public static string convrsion_BMP_to_bim(string nom_fic)
        {
            int size = nb_colon_bmp(nom_fic) * nb_ligne_bmp(nom_fic);
            byte[] Bbuf = new byte[size];
            Stream originalstream = new FileStream(nom_fic, FileMode.Open, FileAccess.Read);
            string fichir_bim = MainForm.chemin + (MainForm.num_forme_creer - 1) + "\\" + Path.GetFileNameWithoutExtension(nom_fic) + ".bim";
            Stream Boriginalstream = new FileStream(fichir_bim, FileMode.CreateNew, FileAccess.Write);

            int stride = nb_colon_bmp(nom_fic);
            int sz = (int)new FileInfo(fichir_bim).Length;
            byte[] pixel1 = new byte[sz];
            byte[] pixel = new byte[sz];


            int taille = MainForm.forme_active.caracteristique_exam.taille;

            originalstream.Seek(taille, SeekOrigin.Begin);
            originalstream.Read(Bbuf, 0, size);
            originalstream.Close();
            sbyte[] SBbuf = new sbyte[size];
            for (int i = 0; i < size; i++)
            {
                SBbuf[i] = (sbyte)Bbuf[i];
            }


            //int size1 = size / 2;
            float[] FFbuf = new float[size];
            for (int i = 0; i < size; i++)
            {
                FFbuf[i] = (float)SBbuf[i];
            }
            byte[] BSBbuf = new byte[size];
            for (int i = 0; i < size; i++)
            {
                BSBbuf[i] = (byte)FFbuf[i];
            }
            /*string fichir_byte = MainForm.chemin + (MainForm.num_forme_creer - 1) + "\\" + Path.GetFileNameWithoutExtension(nom_fic) + ".byte";
                    Stream BBoriginalstream = new FileStream(fichir_byte, FileMode.CreateNew, FileAccess.Write);*/


            Boriginalstream.Write(BSBbuf, 0, size);
            //BBoriginalstream.Write(BSBbuf,0,size);

            Boriginalstream.Close();
            return fichir_bim;
        }

        public static int nb_colon_bmp(string nomfic)
        {
            byte[] Bbuf = new byte[10];
            int sz = (int)(new System.IO.FileInfo(nomfic).Length);
            Stream originalstream = new FileStream(nomfic, FileMode.Open, FileAccess.Read);
            originalstream.Seek(18, SeekOrigin.Begin);
            originalstream.Read(Bbuf, 0, 2);
            int nb_colon = BitConverter.ToInt16(Bbuf, 0);

            originalstream.Close();

            return nb_colon;

        }

        public static int nb_ligne_bmp(string nomfic)
        {
            byte[] Bbuf = new byte[10];
            int sz = (int)(new System.IO.FileInfo(nomfic).Length);
            Stream originalstream = new FileStream(nomfic, FileMode.Open, FileAccess.Read);
            originalstream.Seek(22, SeekOrigin.Begin);
            originalstream.Read(Bbuf, 0, 2);

            int nb_ligne = BitConverter.ToInt16(Bbuf, 0);

            originalstream.Close();

            return nb_ligne;

        }
        
        public static bool Test_BMP(string nom_fic)
        {
            byte[] buf = new Byte[10];
            bool r = true;
            Stream original = new FileStream(nom_fic, FileMode.Open, FileAccess.Read);
            original.Read(buf, 0, 1);
            int x = BitConverter.ToInt16(buf, 0);
            if (x != 66) r = false;
            //original.Close();
            original.Seek(1, SeekOrigin.Begin);
            original.Read(buf, 0, 1);
            x = BitConverter.ToInt16(buf, 0);
            if (x != 77) r = false;
            //original.Close();
            original.Seek(10, SeekOrigin.Begin);
            original.Read(buf, 0, 1);
            x = BitConverter.ToInt16(buf, 0);
            if (x != 54) r = false;
            //original.Close();
            original.Seek(11, SeekOrigin.Begin);
            original.Read(buf, 0, 1);
            x = BitConverter.ToInt16(buf, 0);
            if (x != 4) r = false;
            //original.Close();
            original.Seek(14, SeekOrigin.Begin);
            original.Read(buf, 0, 1);
            x = BitConverter.ToInt16(buf, 0);
            if (x != 40) r = false;
            //original.Close();
            original.Seek(26, SeekOrigin.Begin);
            original.Read(buf, 0, 1);
            x = BitConverter.ToInt16(buf, 0);
            if (x != 1) r = false;
            //original.Close();
            original.Seek(28, SeekOrigin.Begin);
            original.Read(buf, 0, 1);
            x = BitConverter.ToInt16(buf, 0);
            if (x != 8) r = false;
            //original.Close();
            original.Seek(47, SeekOrigin.Begin);
            original.Read(buf, 0, 1);
            x = BitConverter.ToInt16(buf, 0);
            if (x != 1) r = false;
            //original.Close();
            original.Seek(51, SeekOrigin.Begin);
            original.Read(buf, 0, 1);
            x = BitConverter.ToInt16(buf, 0);
            if (x != 1) r = false;
            original.Close();
            return r;
        }

        ////////////////////////////////////////////////////////////////

        public static string conversion_fich_non_connu_to_bim(string nom_fichier)
        {
            string fichir_bim = MainForm.chemin + (MainForm.num_forme_creer - 1) + "\\" + Path.GetFileNameWithoutExtension(nom_fichier) + ".bim";
            Stream Boriginalstream = new FileStream(fichir_bim, FileMode.CreateNew, FileAccess.Write);
            int size = MainForm.forme_active.caracteristique_exam.nbr_oct_valeur * MainForm.forme_active.caracteristique_exam.nb_image * MainForm.forme_active.caracteristique_exam.nb_colon * MainForm.forme_active.caracteristique_exam.nb_ligne;
            if ((MainForm.forme_active.caracteristique_exam.nbr_oct_valeur == 2) && (MainForm.forme_active.caracteristique_exam.entier == true) &&
                (MainForm.forme_active.caracteristique_exam.positif == true) && (MainForm.forme_active.caracteristique_exam.swap == true))
            {

                byte[] Bbuf = new byte[size];
                
                Stream originalstream = new FileStream(nom_fichier, FileMode.Open, FileAccess.Read);


                if (MainForm.forme_active.caracteristique_exam.debut == true)
                {

                    int taille = MainForm.forme_active.caracteristique_exam.taille;

                    originalstream.Seek(taille, SeekOrigin.Begin);
                    originalstream.Read(Bbuf, 0, size);
                    originalstream.Close();
                    ushort[] Tbuf = new ushort[size / 2];

                    for (int i = 0; i < size / 2; i++)
                    {
                        Tbuf[i] = (ushort)(256 * Bbuf[2 * i] + Bbuf[2 * i + 1]);
                    }
                   


                    float[] FFbuf = new float[size / 2];
                    for (int i = 0; i < size / 2; i++)
                    {
                        FFbuf[i] = (float)(Tbuf[i]);
                    }
                    
                    BinaryWriter bw = new BinaryWriter(Boriginalstream);
                    for (int i = 0; i < size / 2; i++)
                    {
                        bw.Write((float)FFbuf[i]);
                    }
                    bw.Close();
                    Boriginalstream.Close();


                }
                if (MainForm.forme_active.caracteristique_exam.debut == false)
                {

                   originalstream.Read(Bbuf, 0, size);
                    originalstream.Close();

                    ushort[] BBbuf = new ushort[size / 2];

                    for (int i = 0; i < size / 2; i++)
                    {
                        BBbuf[i] = (ushort)(256 * Bbuf[2 * i] + Bbuf[2 * i + 1]);
                    }
                    
                    int size1 = size / 2;
                    float[] FFbuf = new float[size1];
                    for (int i = 0; i < size1; i++)
                    {
                        FFbuf[i] = (float)BBbuf[i];
                    }
                    BinaryWriter bw = new BinaryWriter(Boriginalstream);
                    for (int i = 0; i < size1; i++)
                    {
                        bw.Write((float)FFbuf[i]);
                    }
                    bw.Close();
                    Boriginalstream.Close();


                }

            }
            if ((MainForm.forme_active.caracteristique_exam.nbr_oct_valeur == 2) && (MainForm.forme_active.caracteristique_exam.entier == true) &&
                (MainForm.forme_active.caracteristique_exam.positif == true) && (MainForm.forme_active.caracteristique_exam.swap == false))
            {

                byte[] Bbuf = new byte[size];
                ushort[] Fbuf = new ushort[size / 2];


                Stream originalstream = new FileStream(nom_fichier, FileMode.Open, FileAccess.Read);


                if (MainForm.forme_active.caracteristique_exam.debut == true)
                {

                    int taille = MainForm.forme_active.caracteristique_exam.taille;

                    originalstream.Seek(taille, SeekOrigin.Begin);
                    originalstream.Read(Bbuf, 0, size);
                    originalstream.Close();

                    for (int i = 0; i < size / 2; i++)
                    {
                        Fbuf[i] = BitConverter.ToUInt16(Bbuf, 2 * i);
                    }

                    int size1 = size / 2;
                    float[] FFbuf = new float[size1];
                    for (int i = 0; i < size1; i++)
                    {
                        FFbuf[i] = (float)Fbuf[i];
                    }


                    BinaryWriter bw = new BinaryWriter(Boriginalstream);
                    for (int i = 0; i < size1; i++)
                    {
                        bw.Write((float)FFbuf[i]);
                    }
                    bw.Close();
                    Boriginalstream.Close();


                }
                if (MainForm.forme_active.caracteristique_exam.debut == false)
                {

                    int taille = MainForm.forme_active.caracteristique_exam.taille;

                    originalstream.Read(Bbuf, 0, size);
                    originalstream.Close();


                    for (int i = 0; i < size / 2; i++)
                    {
                        Fbuf[i] = BitConverter.ToUInt16(Bbuf, 2 * i);
                    }

                    int size1 = size / 2;
                    float[] FFbuf = new float[size1];
                    for (int i = 0; i < size1; i++)
                    {
                        FFbuf[i] = (float)Fbuf[i];
                    }
                    BinaryWriter bw = new BinaryWriter(Boriginalstream);
                    for (int i = 0; i < size1; i++)
                    {
                        bw.Write((float)FFbuf[i]);
                    }
                    bw.Close();
                    Boriginalstream.Close();


                }

            }
            if ((MainForm.forme_active.caracteristique_exam.nbr_oct_valeur == 2) && (MainForm.forme_active.caracteristique_exam.entier == true) &&
           (MainForm.forme_active.caracteristique_exam.positif == false))
            {


                byte[] Bbuf = new byte[size];
                short[] Fbuf = new short[size / 2];
                Stream originalstream = new FileStream(nom_fichier, FileMode.Open, FileAccess.Read);


                if (MainForm.forme_active.caracteristique_exam.debut == true)
                {

                    int taille = MainForm.forme_active.caracteristique_exam.taille;


                    originalstream.Seek(taille, SeekOrigin.Begin);
                    originalstream.Read(Bbuf, 0, size);
                    originalstream.Close();

                    byte[] BBbuf = new byte[size / 2];
                    for (int i = 0; i < size / 2; i++)
                    {
                        Fbuf[i] = BitConverter.ToInt16(Bbuf, 2 * i);
                    }

                    int size1 = size / 2;
                    float[] FFbuf = new float[size1];
                    for (int i = 0; i < size1; i++)
                    {
                        FFbuf[i] = (float)Fbuf[i];
                    }

                    BinaryWriter bw = new BinaryWriter(Boriginalstream);
                    for (int i = 0; i < size1; i++)
                    {
                        bw.Write((float)FFbuf[i]);
                    }

                    bw.Close();
                    Boriginalstream.Close();


                }
                if (MainForm.forme_active.caracteristique_exam.debut == false)
                {

                    originalstream.Read(Bbuf, 0, size);
                    originalstream.Close();

                    byte[] BBbuf = new byte[size / 2];
                    for (int i = 0; i < size / 2; i++)
                    {
                        Fbuf[i] = BitConverter.ToInt16(Bbuf, 2 * i);
                    }

                    int size1 = size / 2;
                    float[] FFbuf = new float[size1];
                    for (int i = 0; i < size1; i++)
                    {
                        FFbuf[i] = (float)Fbuf[i];
                    }

                    BinaryWriter bw = new BinaryWriter(Boriginalstream);
                    for (int i = 0; i < size1; i++)
                    {
                        bw.Write((float)FFbuf[i]);
                    }

                    bw.Close();
                    Boriginalstream.Close();


                }

            }

            if ((MainForm.forme_active.caracteristique_exam.nbr_oct_valeur == 4) && (MainForm.forme_active.caracteristique_exam.entier == false) &&
                (MainForm.forme_active.caracteristique_exam.positif == false))
            {
                byte[] Bbuf = new byte[size];


                Stream originalstream = new FileStream(nom_fichier, FileMode.Open, FileAccess.Read);


                if (MainForm.forme_active.caracteristique_exam.debut == true)
                {

                    int taille = MainForm.forme_active.caracteristique_exam.taille;



                    originalstream.Seek(taille, SeekOrigin.Begin);
                    originalstream.Read(Bbuf, 0, size);
                    originalstream.Close();


                    Boriginalstream.Write(Bbuf, 0, size);
                    Boriginalstream.Close();



                }
                if (MainForm.forme_active.caracteristique_exam.debut == false)
                {

                    
                    originalstream.Read(Bbuf, 0, size);
                    originalstream.Close();

                    Boriginalstream.Write(Bbuf, 0, size);
                    Boriginalstream.Close();

                }


            }
            if ((MainForm.forme_active.caracteristique_exam.nbr_oct_valeur == 1) && (MainForm.forme_active.caracteristique_exam.entier == true) &&
               (MainForm.forme_active.caracteristique_exam.positif == true))
            {


                byte[] Bbuf = new byte[size];


                Stream originalstream = new FileStream(nom_fichier, FileMode.Open, FileAccess.Read);


                if (MainForm.forme_active.caracteristique_exam.debut == true)
                {

                    int taille = MainForm.forme_active.caracteristique_exam.taille;

                    originalstream.Seek(taille, SeekOrigin.Begin);
                    originalstream.Read(Bbuf, 0, size);
                    originalstream.Close();
                    float[] fbuf = new float[size];
                    for (int i = 0; i < size; i++)
                    {
                        fbuf[i] = (float)Bbuf[i];
                    }


                    BinaryWriter bw = new BinaryWriter(Boriginalstream);
                    for (int i = 0; i < size; i++)
                    {
                        bw.Write((float)fbuf[i]);
                    }

                    bw.Close();
                    Boriginalstream.Close();


                }
                if (MainForm.forme_active.caracteristique_exam.debut == false)
                {

                    originalstream.Read(Bbuf, 0, size);
                    originalstream.Close();
                    float[] fbuf = new float[size];
                    for (int i = 0; i < size; i++)
                    {
                        fbuf[i] = (float)Bbuf[i];
                    }


                    BinaryWriter bw = new BinaryWriter(Boriginalstream);
                    for (int i = 0; i < size; i++)
                    {
                        bw.Write(fbuf[i]);
                    }
                    bw.Close();
                    Boriginalstream.Close();


                }


            }
            if ((MainForm.forme_active.caracteristique_exam.nbr_oct_valeur == 1) && (MainForm.forme_active.caracteristique_exam.entier == true) &&
             (MainForm.forme_active.caracteristique_exam.positif == false))
            {
                byte[] Bbuf = new byte[size];
                Stream originalstream = new FileStream(nom_fichier, FileMode.Open, FileAccess.Read);

                if (MainForm.forme_active.caracteristique_exam.debut == true)
                {
                   

                    int taille = MainForm.forme_active.caracteristique_exam.taille;

                    originalstream.Seek(taille, SeekOrigin.Begin);
                    originalstream.Read(Bbuf, 0, size);
                    originalstream.Close();
                    sbyte[] SBbuf = new sbyte[size];
                    for (int i = 0; i < size; i++)
                    {
                        SBbuf[i] = (sbyte)Bbuf[i];
                    }


                    float[] FFbuf = new float[size];
                    for (int i = 0; i < size; i++)
                    {
                        FFbuf[i] = (float)SBbuf[i];
                    }

                    BinaryWriter bw = new BinaryWriter(Boriginalstream);
                    for (int i = 0; i < size; i++)
                    {
                        bw.Write((float)FFbuf[i]);
                    }
                    bw.Close();
                    Boriginalstream.Close();


                }
                if (MainForm.forme_active.caracteristique_exam.debut == false)
                {
                   
                    originalstream.Read(Bbuf, 0, size);
                    originalstream.Close();
                    sbyte[] SBbuf = new sbyte[size];
                    for (int i = 0; i < size; i++)
                    {
                        SBbuf[i] = (sbyte)Bbuf[i];
                    }


                    float[] FFbuf = new float[size];
                    for (int i = 0; i < size; i++)
                    {
                        FFbuf[i] = (float)SBbuf[i];
                    }

                    BinaryWriter bw = new BinaryWriter(Boriginalstream);
                    for (int i = 0; i < size; i++)
                    {
                        bw.Write((float)FFbuf[i]);
                    }
                    bw.Close();
                    Boriginalstream.Close();


                }

            }
            return fichir_bim;

        }


        ///////////////////////////////////////////////////////////////////////////////

        public static int nb_ligne_s(string nomfic)
        {
            byte[] Bbuf = new byte[2];
            int sz = (int)(new System.IO.FileInfo(nomfic).Length);
            Stream originalstream = new FileStream(nomfic, FileMode.Open, FileAccess.Read);
            originalstream.Seek(sz - 429, SeekOrigin.Begin);
            originalstream.Read(Bbuf, 0, 1);
            int nb_img = BitConverter.ToInt16(Bbuf, 0);

            originalstream.Close();
            int nb_pixel = (sz - 512) / nb_img / 2;
            int nb_ligne = (int)Math.Sqrt((double)nb_pixel);

            return nb_ligne;

        }

        public static int nb_image_s(string nomfic)
        {
            byte[] Bbuf = new byte[2];
            int sz = (int)(new System.IO.FileInfo(nomfic).Length);
            Stream originalstream = new FileStream(nomfic, FileMode.Open, FileAccess.Read);
            originalstream.Seek(sz - 429, SeekOrigin.Begin);
            originalstream.Read(Bbuf, 0, 1);
            int nb_img = BitConverter.ToInt16(Bbuf, 0);
            originalstream.Close();
            return nb_img;
            

        }

        public static Examen.type_examen type_exam_s(string nomfic)
        {
            byte[] Bbuf = new byte[2];
            
            int sz = (int)(new System.IO.FileInfo(nomfic).Length);
            Stream originalstream = new FileStream(nomfic, FileMode.Open, FileAccess.Read);
            originalstream.Seek(sz - 451, SeekOrigin.Begin);
            originalstream.Read(Bbuf, 0, 1);
            originalstream.Close();
            char s = BitConverter.ToChar(Bbuf,0);
            Examen.type_examen type = Examen.type_examen.statique;
            if (s == 'T')
                type = Examen.type_examen.tomographique;
            if (s == 'D')
                type = Examen.type_examen.dynamique;
            if (s == 'S')
                type = Examen.type_examen.statique;
            if (s == 'F')
                type = Examen.type_examen.synchronisé;

            return type;
            
        }


        public static string conversion_S_to_bim(string nom_fichier)
        {
            string fichir_bim = MainForm.chemin + (MainForm.num_forme_creer - 1) + "\\" + Path.GetFileNameWithoutExtension(nom_fichier) + ".bim";
            Stream Boriginalstream = new FileStream(fichir_bim, FileMode.CreateNew, FileAccess.Write);

            int sz = (int)(new System.IO.FileInfo(nom_fichier).Length);
            byte[] Bbuf = new byte[10];

            Stream originalstream = new FileStream(nom_fichier, FileMode.Open, FileAccess.Read);
            Stream Soriginalstream = new FileStream(nom_fichier, FileMode.Open, FileAccess.Read);

            int nb_img = nb_image_s(nom_fichier);

                
            int nb_ligne = nb_ligne_s(nom_fichier);
           
            int siz = nb_img * nb_ligne * nb_ligne * 2;
            byte[] BBbuf = new byte[siz];
            Soriginalstream.Read(BBbuf, 0, siz);
            Soriginalstream.Close();
            //swap
            ushort[] Tbuf = new ushort[siz/2];

            for (int i = 0; i < siz/2-1; i++)
            {
                Tbuf[i] = (ushort)(256*BBbuf[2 * i] + BBbuf[2 * i + 1]);
            }
            //

            
            float[] FFbuf = new float[siz/2];
            for (int i = 0; i < siz/2-1; i++)
            {
                FFbuf[i] = (float)(Tbuf[i]);
            }
           
            

            BinaryWriter bw = new BinaryWriter(Boriginalstream);
            for (int i = 0; i < siz / 2 - 1; i++)
            {
                bw.Write((float)FFbuf[i]);
            }
          
            Boriginalstream.Close();
            originalstream.Close();


            return fichir_bim;
        }

             
        
        #endregion
        /*

        #region reconstruction

       /* public static float proj_pt(float x,float y,double angl_rot)
        {
            
            float nb_ligne=MainForm.forme_active.caracteristique_exam.nb_ligne;
            float nb_colon=MainForm.forme_active.caracteristique_exam.nb_colon;

            return (float)((y-nb_ligne/2)*Math.Sin(angl_rot)-(x-nb_colon/2)*Math.Cos(angl_rot)+nb_colon/2);
        }

        public static void proj_pixel(int i,int j,double teta,out int  k1,out int k2,out float d1,out float d2)
        {
            float z=proj_pt((float)(i+0.5),(float)(j+0.5),teta);
            k1=(int)z;
            d1=(float)(z-k1-0.5);
            if(d1>0)
            {
                k2=k1+1;
                d2=(float)((k2+0.5)-z);
            }
            else
            {
                k2=k1-1;
                d2=(float)(z-(k2+0.5));
                d1=Math.Abs(d1);
            }

        }

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

        public static void proj_pixel(int i, int j, double cost,double sint, out int k1, out int k2, out float d1, out float d2)
        {
            float z = proj_pt((float)(i + 0.5), (float)(j + 0.5), cost,sint);

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

        /*public static void proj_pixel_asirt(int i, int j, double cost, double sint, out int k1, out int k2, out float d1, out float d2,float[]tab_s)
        {
            int nb_colon=MainForm.forme_active.caracteristique_exam.nb_colon;
            float z = proj_pt((float)(i + 0.5), (float)(j + 0.5), cost, sint);

            if (z >= 0) k1 = (int)z;
            else k1 = (int)z - 1;
            if (z - k1 - 0.5 > 0)
            {
                k2 = k1 + 1;
                if ((k1 >= 0) && (k1 < nb_colon))
                {
                    d2 = (float)(surface_disque(k1 + 1 - z) + 0.5);

                    d2 /= (float)(tab_s[k1]);
                }
                else
                {
                    d2 = k1 = 0;
                }
                    


            }
            else
            {
                k2 = k1 - 1;
                if ((k1 >= 0) && (k1 < nb_colon))
                {


                    
                    d2 = (float)(surface_disque(z - k1) + 0.5);
                    d2 /= (float)(tab_s[k1]);
                }
                else
                {
                    d2 = k1 = 0;
                }

            }
            if ((k2 >= 0) && (k2 < nb_colon))
            {
                d1 = 1 - d2;
                d1 /= (float)(tab_s[k2]);
            }
            else
            {
                d1 = k2 = 0;
            }

        }

        public static void proj_examen(float[]t_tomo,ref float[]t_proj,int nb_image,int nb_colon,int nb_ligne,double angle_rot )
        {
            
            int k1,k2;
            float d1,d2;
            double cost = 0;
            double sint = 0;
            
                                    
            double pas_teta =(double)( angle_rot / nb_image);
            
            int nbc=nb_colon*nb_colon;

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

        public static void remplissage_tab_s(int nb_colon, int nb_image, double angle_rot,ref float[]tab_s)
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

                            
                                tab_s[a * nb_colon  + k1] += d2 ;

                            
                        }

                        if ((k2 >= 0) && (k2 < nb_colon))
                        {
                            tab_s[a * nb_colon + k2] += d1;
                        }

                    }
                }
            }

        }


        public static void retro_proj_mlem_examen(ref float[] t_tomo, float[] t_proj, int nb_image, int nb_colon, int nb_ligne, double angle_rot)
        {
            int k1, k2;
            float d1, d2;
            double cost = 0;
            double sint = 0;

           double pas_teta =(double) (angle_rot / nb_image);

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

        public static void retro_proj_asirt_examen(ref float[] t_tomo, float[] t_proj, int nb_image, int nb_colon, int nb_ligne, double angle_rot,float[]tab_s)
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
                            for (int nt = 0; nt < nb_ligne; nt++)
                            {
                                t_tomo[nt * nbc + j * nb_colon + i] += (d2/tab_s[a*nb_colon+k1] * t_proj[a * nb_colon * nb_ligne + nt * nb_colon + k1]);

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


        public static float surface_k(float z2, float z1)
        {
            int nc = MainForm.forme_active.caracteristique_exam.nb_colon;
            int r = nc / 2;
            double arcsin1 = Math.Asin(z1 / r);
            double arcsin2=Math.Asin(z2 / r);
            return (float)(r * r * (arcsin2 -arcsin1  + (Math.Sin(2 * arcsin2) - Math.Sin(2 * arcsin1)) / 2));
        }

        /*public static void retro_proj_asirt_examen(ref float[] t_tomo, float[] t_proj, int nb_image, int nb_colon, int nb_ligne, double angle_rot,float[]tab_s)
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
                        float d =(float) Math.Sqrt(Math.Pow((i +0.5- nb_colon / 2), 2) + Math.Pow((j+0.5 - nb_colon / 2), 2));
                        if (d <= nb_colon/2)
                        {

                            proj_pixel_asirt(i, j, cost, sint, out k1, out k2, out d1, out d2, tab_s);


                            for (int nt = 0; nt < nb_ligne; nt++)
                            {
                                t_tomo[nt * nbc + j * nb_colon + i] += (d2 * t_proj[a * nb_colon * nb_ligne + nt * nb_colon + k1]);
                                t_tomo[nt * nbc + j * nb_colon + i] += (d1 * t_proj[a * nb_colon * nb_ligne + nt * nb_colon + k2]);

                            }
                        }
                        else
                        {
                            for (int nt = 0; nt < nb_ligne; nt++)
                            {
                                t_tomo[nt * nbc + j * nb_colon + i] =0;
                                t_tomo[nt * nbc + j * nb_colon + i] =0;

                            }
                        }

                        
                        
                    }
                }
            }
            //return t_tomo;
        }

        public static void pre_osem_projection_exam(int set, int indice, float[] t_tomo, ref float[] t_proj, int nb_image, int nb_colon, int nb_ligne, double angle_rot)
        {

            int k1, k2;
            float d1, d2;
            double cost = 0;
            double sint = 0;


            double pas_teta = (double)(angle_rot / nb_image);

            int nbc = nb_colon * nb_colon;
            int indice_a = 0;
            for (int a = 0; a < nb_image/set; a++)
            {
                indice_a=set * a + indice;
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

        public static void pre_osem_retro_projection_exam(int set, int indice, ref float[] t_tomo, float[] t_proj, int nb_image, int nb_colon, int nb_ligne, double angle_rot)
        {
            int k1, k2;
            float d1, d2;
            double cost = 0;
            double sint = 0;

            double pas_teta = (double)(angle_rot / nb_image);

            int nbc = nb_colon * nb_colon;
            int indice_a = 0;
            for (int a = 0; a < nb_image/set; a++)
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

        public static void pre_osem_iteration(int set,int indice, float[] t_p, ref float[] t_tomo, int nb_image, int nb_colon, int nb_ligne, double angle_rot)
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

        public static void osem_iteration(int set, float[] t_p, ref float[] t_tomo, int nb_image, int nb_colon, int nb_ligne, double angle_rot, string tomo_bim)
        {
            for (int indice = 0; indice < set; indice++)
            {
                pre_osem_iteration(set, indice, t_p, ref t_tomo, nb_image, nb_colon, nb_ligne, angle_rot);
            }
        }

        public static void mlem_iteration(float[] t_p, ref float[] t_tomo, int nb_image, int nb_colon, int nb_ligne, double angle_rot, string tomo_bim)
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



        public static void asirt_iteration(float[] t_p, ref float[] t_tomo, int nb_image, int nb_colon, int nb_ligne, double angle_rot, string tomo_bim,float[]tab_s)
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

            retro_proj_asirt_examen(ref et, ep, nb_image, nb_colon, nb_ligne, angle_rot,tab_s);

            for (int i = 0; i < t_tomo.Length; i++)
            {
                t_tomo[i] = (float)(t_tomo[i] + et[i]/nb_image);
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

        */

        public static byte[] creer_palette_x(float x)
        {
            byte[] pal_x = new byte[1024];
            byte[] pal_defaut = new byte[1024];
            byte r, v, b;

            Stream defaut = new FileStream(MainForm.forme_active.nom_palete_x, FileMode.Open, FileAccess.Read);
            defaut.Read(pal_defaut, 0, 1024);
            defaut.Close();

            int i = 0;
            int i_min = 0;
            int i_max = 0;
            int i_c = 0;

            do
            {
                i_min = (int)(((x * 255) / 100) * i);
                i_max = (int)(((x * (i + 1) * 255) / 100) - 1);
                i_c = (int)(((x * 255) / (2 * 100)) * (2 * i + 1));
                if (i_c > 255) i_c = 255;
                if (i_max > 255) i_max = 255;
                r = pal_defaut[4 * i_c];
                v = pal_defaut[4 * i_c + 1];
                b = pal_defaut[4 * i_c + 2];
                for (int j = i_min; j <= i_max; j++)
                {
                    pal_x[4 * j] = r;
                    pal_x[4 * j + 1] = v;
                    pal_x[4 * j + 2] = b;
                }
                i++;


            }
            while (i_max < 255);
            MainForm.forme_active.nom_palette = MainForm.forme_active.nom_dossier + "palette_x.pal";
            Stream defaut1 = new FileStream(MainForm.forme_active.nom_palette, FileMode.Create, FileAccess.Write);
            defaut1.Write(pal_x, 0, 1024);
            defaut1.Close();
            return pal_x;


        }


        public static bool type_dicom(string nom_fich)
        {
            byte[] Bbuf = new byte[4];
            Stream Soriginalstream = new FileStream(nom_fich, FileMode.Open, FileAccess.Read);
            Soriginalstream.Seek(128, SeekOrigin.Begin);
            Soriginalstream.Read(Bbuf, 0, 4);
            Soriginalstream.Close();

            ASCIIEncoding ascii = new ASCIIEncoding();
            char[] encodingName = ascii.GetChars(Bbuf, 0, 4);

            if ((encodingName[0] == 'D') && (encodingName[1] == 'I') && (encodingName[2] == 'C') && (encodingName[3] == 'M'))
                return true;

            return false;
           

        }


        public static string convrsion_DCM_bim(string nom_fich)
        {
            string fichir_bim = MainForm.chemin + (MainForm.num_forme_creer - 1) + "\\" + Path.GetFileNameWithoutExtension(nom_fich) + ".bim";
            Stream Boriginalstream = new FileStream(fichir_bim, FileMode.CreateNew, FileAccess.Write);
            int size = (int)new System.IO.FileInfo(nom_fich).Length;
            Stream originalstream = new FileStream(nom_fich, FileMode.Open, FileAccess.Read);
            //Dicom.info_DCM(nom_fich);
            int tail_entet = Dicom.tail_entet;//size - (Dicom.nb_colon * Dicom.nb_ligne * Dicom.nbr_oct_valeur*Dicom.nb_image);//* Dicom.nb_image);
            int taille = /*size - tail_entet;*/Dicom.nb_colon * Dicom.nb_ligne * Dicom.nbr_oct_valeur * Dicom.nb_image;

            byte[] Bbuf = new byte[taille];
            BinaryWriter bw = null;

            int v = 0;
            try
            {
            originalstream.Seek(tail_entet, SeekOrigin.Begin);
            originalstream.Read(Bbuf, 0, taille);
            originalstream.Close();
            /*
            
                for (int j = 0; j < taille; j++)
                {
                    if (Bbuf[j] < 0)
                    {
                        v = 1;
                        j = taille;
                    }
                    else v = 2;
                }*/
                if /*(*/(Dicom.nbr_oct_valeur == 2) //&& (v == 2))
                {
                    //////////////////////////////////////////////////////////
                   /* originalstream.Seek(taille, SeekOrigin.Begin);
                    originalstream.Read(Bbuf, 0, size);
                    originalstream.Close();

                    for (int i = 0; i < size / 2; i++)
                    {
                        Fbuf[i] = BitConverter.ToUInt16(Bbuf, 2 * i);
                    }

                    int size1 = size / 2;
                    float[] FFbuf = new float[size1];
                    for (int i = 0; i < size1; i++)
                    {
                        FFbuf[i] = (float)Fbuf[i];
                    }


                    BinaryWriter bw = new BinaryWriter(Boriginalstream);
                    for (int i = 0; i < size1; i++)
                    {
                        bw.Write((float)FFbuf[i]);
                    }
                    bw.Close();
                    Boriginalstream.Close();*/
                    ///////////////////////////////////////////////////////////////
                    ushort[] Fbuf = new ushort[taille/2];
                    for (int i = 0; i < taille/2 ; i++)
                    {
                        Fbuf[i] = BitConverter.ToUInt16(Bbuf, 2 * i);
                    }

                    int size1 = taille / 2;
                    float[] FFbuf = new float[size1];
                    for (int i = 0; i < size1; i++)
                    {
                        FFbuf[i] = (float)Fbuf[i];
                    }

                    bw = new BinaryWriter(Boriginalstream);
                    for (int i = 0; i < size1; i++)
                    {
                        bw.Write((float)FFbuf[i]);
                    }

                    


                }
                if (Dicom.nbr_oct_valeur == 1) 
                {


                    float[] FFbuf = new float[taille];
                    for (int i = 0; i < taille; i++)
                    {
                        FFbuf[i] = (float)Bbuf[i];
                    }

                    bw = new BinaryWriter(Boriginalstream);
                    for (int i = 0; i < taille; i++)
                    {
                        bw.Write((float)FFbuf[i]);
                    }
                    

                }
                bw.Close();
                Boriginalstream.Close();

                return fichir_bim;
            }
            
            catch(Exception ee)
            {
                MessageBox.Show("Fichier invalide!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Boriginalstream.Close();
                
                originalstream.Close();
                return null;
            }
            

            
        }

        public static void inverser_fichier_bim(string ss)
        {
            Stream s = new FileStream(ss, FileMode.Open,FileAccess.Read );
            Stream s_new = new FileStream(ss + "new", FileMode.Create, FileAccess.Write);

            byte[] tab = new byte[64 * 64 * 32 * 4];
                       
            s.Seek(tab.Length, SeekOrigin.Begin);
            s.Read(tab, 0, tab.Length);
            s_new.Write(tab, 0, tab.Length);
            s.Seek(0, SeekOrigin.Begin);
            s.Read(tab, 0, tab.Length);
            s_new.Write(tab, 0, tab.Length);
            s.Close();
            s_new.Close();


        }



    }

}

