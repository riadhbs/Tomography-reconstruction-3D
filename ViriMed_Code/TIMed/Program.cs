using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;



namespace TIMed
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           // Util.inverser_fichier_bim(Application.StartupPath+"\\" + "file");

            //Util.palette_negatif(Application.StartupPath + "\\utilitaire\\BMPpalc.pal");
            if (Directory.Exists(Application.StartupPath + "\\travail") == true)
                Directory.Delete(Application.StartupPath + "\\travail", true);
            string chemin=Application.StartupPath + "\\travail";
            Directory.CreateDirectory(chemin).Attributes=FileAttributes.Hidden;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.Automatic);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
                                   
            try
            {
                Application.Run(new MainForm());
                                               
            }
            catch (Exception ex)
            {
                string msg = "Erreur lors de l'exécution!"+ex.Message;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
