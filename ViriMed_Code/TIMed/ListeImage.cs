using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Threading;



namespace TIMed
{
    public partial class ListeImage : UserControl
    {

        private ImageList imglist;
        private int nbfichierajouter;
        private MainForm parent;
        private const int largeur = 120;
        private const int hauteur = 120;
        private string nvnomfichier;
        private string currentFileName;


        #region constructeur

        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="parent"></param>

        public ListeImage(MainForm parent)
        {
            InitializeComponent();
            this.Dock = DockStyle.Bottom;

            imglist = new ImageList();
            imglist.ImageSize = new System.Drawing.Size(largeur, hauteur);
            imglist.ColorDepth = ColorDepth.Depth16Bit;

            containerImage.LargeImageList = imglist;
            containerImage.Alignment = ListViewAlignment.Left;
            containerImage.HideSelection = false;
            this.parent = parent;
            

        }
        #endregion

        #region methode
        /// <summary>
        /// retourner le nom du fichier courant
        /// </summary>
        public string CurrentFileName
        {
            get { return currentFileName; }
        }


        /// <summary>
        /// ajouter une image dans le container
        /// </summary>
        /// <param name="nomfichier"></param>
        public void ajouterfichier(string nomfichier)
        {
            nbfichierajouter = 0;
            if (!imglist.Images.ContainsKey(nomfichier))
            {
                nvnomfichier = nomfichier;
                nbfichierajouter++;
            }
            if (nbfichierajouter == 0)
                return;

           

            this.ajouter_image();

            mettre_a_jour_le_container();

        }

        /// <summary>
        /// suite_ajouter
        /// </summary>
        void ajouter_image()
        {
            if (MainForm.forme_active.b_image.Image != null)
            {

                imglist.Images.Add(nvnomfichier, MainForm.forme_active.b_image.Image);
            }

        }
        /// <summary>
        /// mettre à jour le container
        /// </summary>
        private void mettre_a_jour_le_container()
        {

            containerImage.BeginUpdate();
            containerImage.Items.Add(nvnomfichier, Path.GetFileName(nvnomfichier), nvnomfichier);

           
            containerImage.EndUpdate();

            UpdateOpenFilesCount();

            //Current file is the 1st of the ones the user just opened
            currentFileName = containerImage.Items[nvnomfichier].Name;
            containerImage.Items[currentFileName].Selected = true;
            containerImage.Items[currentFileName].Focused = true;
           
        }
        /// <summary>
        /// mettre à jour le nombre de fichiers
        /// </summary>
        private void UpdateOpenFilesCount()
        {
            if (containerImage.Items.Count <= 1)
                this.l_info.Text = containerImage.Items.Count + " fichier";
            else this.l_info.Text = containerImage.Items.Count + " fichiers";
        }
        /// <summary>
        /// si on ferme un ficher
        /// </summary>
        /// <param name="nom_fichier"></param>
        public void fermer_fichier(string nom_fichier)
        {

            containerImage.BeginUpdate();
            int ind = containerImage.Items.Count - 1;

            
            if (ind >= 0)
            {
                containerImage.Items[ind].Selected = true; // Restores the selected index (different file)
                currentFileName = containerImage.Items[ind].Name;
                //MainForm.forme_active.Dispose();
                imglist.Images.RemoveByKey(nom_fichier);
                containerImage.Items.RemoveByKey(nom_fichier);
            }
            
            containerImage.EndUpdate();

            UpdateOpenFilesCount();


        }
        /// <summary>
        /// copier
        /// </summary>
        public void CopySelectedFilesToClipboard()
        {
            System.Collections.Specialized.StringCollection stc;
            stc = new System.Collections.Specialized.StringCollection();
            foreach (ListViewItem lvi in containerImage.SelectedItems)
            {
                stc.Add(lvi.Name);
            }

            try
            {
                Clipboard.SetFileDropList(stc);
            
            }
            catch (Exception ex)
            {
                string msg = "Impossible de copier le/les fichier(s) sélectionné(s)!";
                MessageBox.Show(msg, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        /// <summary>
        /// selectionner tout
        /// </summary>
        public void SelectAllFiles()
        {
            if (containerImage.Items.Count == 0)
                return;

            foreach (ListViewItem lvi in containerImage.Items)
            {
                lvi.Focused = true;
                lvi.Selected = true;
            }
            currentFileName = containerImage.Items[0].Name;

        }
        /// <summary>
        /// si on appuie avec le bouton droite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void containerImage_MouseUp(object sender, MouseEventArgs e)
        {
            ListViewItem lvi  = containerImage.HitTest(e.X, e.Y).Item;
            if (e.Button == MouseButtons.Right)
            {
                if (lvi == null)
                    return;
                // shows context menu for selected item(s)
                affichercontextimage(e.X, e.Y);

            }
        }
        /// <summary>
        /// afficher fonctionalité avec le bouton droite
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void affichercontextimage(int x, int y)
        {
            // if several items selected, copy as picture menu item not available
            if ((containerImage.SelectedIndices.Count > 1)||(Util.extensiontraitée(currentFileName)==false))
                this.copierEnTantQueImageToolStripMenuItem.Enabled = false;
            else copierEnTantQueImageToolStripMenuItem.Enabled = true;
            

            contextimage.Show(this, x, y);
        }
        /// <summary>
        /// fermer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       /* private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parent.fermer_Click(sender, e);


        }*/
        /// <summary>
        /// copier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parent.copierToolStripMenuItem_Click(sender, e);
        }

        #endregion

        private void copierEnTantQueImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                Clipboard.SetImage(Image.FromFile(currentFileName));
            
            }
            catch (Exception ex)
            {
                string msg = "Impossible de copier le/les fichier(s)!";
                MessageBox.Show(msg, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
 

    }
}

