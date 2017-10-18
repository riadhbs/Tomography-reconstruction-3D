using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace TIMed
{
    public class Examen
    {


        
        public enum type_examen { statique, tomographique, dynamique, synchronisé,None };
        public int nb_ligne=0;
        public int nb_colon=0;
        public int nb_image=1;
        public type_examen type_ex;
        public bool entier = false;
        public bool positif = true;
        public bool debut = true;
        public int taille = 0;
        public double angle_pi = 0;
        public bool angle_pi_test = true;
        public int nbr_oct_valeur = 0;
        public bool swap = false;
        public bool rvb = false;
        
       /// <summary>
       /// constructeur
       /// </summary>
       /// <param name="nb_ligne"></param>
       /// <param name="nb_colon"></param>
       /// <param name="nb_image"></param>
       /// <param name="type_ex"></param>
       /// <param name="entier"></param>
       /// <param name="positif"></param>
       /// <param name="debut"></param>
       /// <param name="taille"></param>
       /// <param name="angle_pi"></param>
 

        public Examen(int nb_ligne, int nb_colon, int nb_image, type_examen type_ex,bool entier,
            bool positif,bool debut,int taille,bool angle_pi_test,int nbr,bool sw,bool rvb)
        {
            this.nb_ligne = nb_ligne;
            this.nb_colon = nb_colon;
            this.nb_image = nb_image;
            this.type_ex = type_ex;
            this.entier = entier;
            this.positif = positif;
            this.debut = debut;
            this.taille = taille;
            this.angle_pi_test = angle_pi_test;
            switch(this.angle_pi_test)
            {
                case true: this.angle_pi=Math.PI;
                    break;
                case false: this.angle_pi=Math.PI*2;
                    break;
            }
             
            nbr_oct_valeur = nbr;
            swap = sw;
            this.rvb = rvb;
            
        }
        

                       
    }
}
