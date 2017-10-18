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
    class Dicom
    {
        public enum type_examen { statique, tomographique, dynamique, synchronisé };
        public static short nb_ligne;
        public static short nb_colon;
        public static int nb_image=1;
        public static type_examen type_ex;
        public static bool entier;
        public static bool positif;
        public static bool debut;
        public static int taille;
        public static double angle_pi;
        public static int nbr_oct_valeur;
        public static bool swap;
        public static int tail_entet;
        public static int m;
        public static int big_endian;
        public static int s;
        public static int n;


        public static  void info_DCM(string nom_fich)
        {

            int size = (int)new System.IO.FileInfo(nom_fich).Length;

            int size1 = size ;
            byte[] Bbuf = new byte[size1];
            char[] radh = new char[size1/2 ];
            string[] radh1 = new string[size1 / 2];
            ASCIIEncoding ascii = new ASCIIEncoding();
            Stream Soriginalstream = new FileStream(nom_fich, FileMode.Open, FileAccess.Read);
            //Soriginalstream.Seek(132, SeekOrigin.Begin);
            Soriginalstream.Read(Bbuf, 0, size1);
            Soriginalstream.Close();
            

            char[] encodingName = ascii.GetChars(Bbuf, 0, size1/2);
            int i = 0;
            string  tag1=null;
            string tag2=null;
            char[] vr=new char [3];
            string  [] vl=new string[2];
            string[] valeur = new string[100];

            for (i = 0; i < size1 / 2; i++)
            {
                Int16 value = BitConverter.ToInt16(Bbuf, 2 * i);
                string hex = String.Format("{0:X4}", value);

                radh1[i] = hex;
                radh[i] = encodingName[i];
                
            }
            i = 0;
            do
            {
                tag1 = radh1[i];
                tag2 = radh1[i + 1];

                i += 1;
                
            } 
            while ((tag1 != "7FE0") || (tag2 != "0010"));

            tail_entet = ((i+1) * 2)+6;//((i+1)* 2) + 132+6;

            # region commentaire

            /*for (i = 0; i < size1 / 2; i++)
            {
                
                if ((radh1[i] == "7FE0") && (radh1[i + 1] == "0010"))
                {
                    int x = BitConverter.ToInt16(Bbuf, (i + 3) * 2);
                    char[] tag11 = new char[x];

                    for (int n = 0; n < 2; n++)
                    {
                        tag11[n] = radh[n + ((i + 4) * 2)];
                    }
                    if ((tag11[0] == 'O') && (tag11[1] == 'W'))
                    {
                        tail_entet += 4;
                    }
                    if ((tag11[0] == 'O') && (tag11[1] == 'B'))
                    {

                        tail_entet += 4;
                    }
                }
            }*/
            
            /*if ( (radh1[0] == "2E30"))//||(radh1[0]==
            {
                //int v = 1;
                for (i = 0; i < size1 / 2; i++)//do
                {
                    int x = 0;
                    tag1 = radh1[i + 8];
                    tag2 = radh1[i + 9/* 1];
                    if ((radh1[i + 8] == "7FE0") && (radh1[i + 9/* 1] == "0010"))
                    {
                        break;//Environment.FailFast;//   return ;
                    }
                    vr[0] = (radh[(i + 10/* 2) * 2]);
                    vr[1] = (radh[(i + 10/* 2) * 2 + 1]);
                    if (((vr[0] == 'O') && (vr[1] == 'B')) || ((vr[0] == 'O') && (vr[1] == 'W')) || ((vr[0] == 'O') && (vr[1] == 'F')) || ((vr[0] == 'S') && (vr[1] == 'Q')) || ((vr[0] == 'U') && (vr[1] == 'T')) || ((vr[0] == 'U') && (vr[1] == 'N')))
                    {
                        vr[2] = radh[(i + 12/* 4) * 2];
                        vl[0] = radh1[i + 12/*4];
                        vl[1] = radh1[i + 13/* 5];
                        x = BitConverter.ToInt16(Bbuf, (i + 12/* 4) * 2) / 2;
                        int y = BitConverter.ToInt16(Bbuf, (i + 13/* 5) * 2) / 2;
                        if ((x == 0) || (y == 0))
                        { x += 1; }
                        for (int j = 0; j < x + y; j++)
                        { valeur[j] = radh1[i + j + 14/* 6]; }

                        i += x + y + 4;

                    }
                    else
                        if (((vr[0] == 'A') && (vr[1] == 'E')) || ((vr[0] == 'A') && (vr[1] == 'S')) || ((vr[0] == 'A') && (vr[1] == 'T')) || ((vr[0] == 'C') && (vr[1] == 'S')) || ((vr[0] == 'D') && (vr[1] == 'A')) || ((vr[0] == 'D') && (vr[1] == 'S')) || ((vr[0] == 'D') && (vr[1] == 'T')) || ((vr[0] == 'F') && (vr[1] == 'L')) || ((vr[0] == 'F') && (vr[1] == 'D')) || ((vr[0] == 'I') && (vr[1] == 'S')) || ((vr[0] == 'L') && (vr[1] == 'O')) || ((vr[0] == 'L') && (vr[1] == 'T')) || ((vr[0] == 'P') && (vr[1] == 'N')) || ((vr[0] == 'S') && (vr[1] == 'H')) || ((vr[0] == 'S') && (vr[1] == 'L')) || ((vr[0] == 'S') && (vr[1] == 'S')) || ((vr[0] == 'S') && (vr[1] == 'T')) || ((vr[0] == 'T') && (vr[1] == 'M')) || ((vr[0] == 'U') && (vr[1] == 'I')) || ((vr[0] == 'U') && (vr[1] == 'L')) || ((vr[0] == 'U') && (vr[1] == 'S')) || ((vr[0] == 'O') && (vr[1] == 'T')))
                        {
                            vl[0] = radh1[i + 11/* 3];
                            x = BitConverter.ToInt16(Bbuf, (i +11/*3) * 2) / 2;

                            if (x == 0)
                            { x += 1; }

                            for (int j = 0; j < x; j++)
                            { valeur[j] = radh1[i + j + 12/*4]; }
                            i += 3 + x + 1;
                        }
                        else// (((vr[0] == '0') && (vr[1] != '0')))
                        {
                            vl[0] = radh1[i + 10/* 2];
                            vl[1] = radh1[i + 11/* 3];
                             x= BitConverter.ToInt16(Bbuf, (i + 10/* 2) * 2) / 2;
                           int  y = BitConverter.ToInt16(Bbuf, (i + 11/* 3) * 2) / 2;
                            if (x == 0 || y == 0)
                            { x += 1; }
                            for (int j = 0; j < x + y; j++)
                            { valeur[j] = radh1[i + j + 12/* 4]; }
                            i += x + y + 2;

                        }
                    char[] tag = new char[100];
                    if ((tag1 == "0028") && (tag2 == "0004"))
                    {
                        //int x = 0;
                        for (int n = 0; n < x + 5; n++)
                        {
                            tag[n] = radh[n + ((i +3) * 2)];
                        }
                        if ((tag[0] == 'M') && (tag[1] == 'O') && (tag[2] == 'N') && (tag[3] == 'O') && (tag[4] == 'C') && (tag[5] == 'H') && (tag[6] == 'R') && (tag[7] == 'O') && (tag[8] == 'M') && (tag[9] == 'E') && (tag[10] == '2'))
                        { m = 0; }
                        if ((tag[0] == 'M') && (tag[1] == 'O') && (tag[2] == 'N') && (tag[3] == 'O') && (tag[4] == 'C') && (tag[5] == 'H') && (tag[6] == 'R') && (tag[7] == 'O') && (tag[8] == 'M') && (tag[9] == 'E') && (tag[10] == '1'))
                        {
                            m = 1;


                        }
                        if ((tag[0] == 'R') && (tag[1] == 'G') && (tag[2] == 'B')) { m = 2; }
                    }
                    tail_entet = i * 2;// +1;
                }
            }
            else
                if (radh1[0] == "0002")
                {
                    for (i = 0; i < size1 / 2; i++)
                    {
                        int x = 0;
                        tag1 = radh1[i];
                        tag2 = radh1[i + 1];
                        if ((radh1[i] == "7FE0") && (radh1[i + 1] == "0010"))
                        {
                            break;//Environment.FailFast;//   return ;
                        }
                        vr[0] = (radh[(i + 2) * 2]);
                        vr[1] = (radh[(i + 2) * 2 + 1]);
                        if (((vr[0] == 'O') && (vr[1] == 'B')) || ((vr[0] == 'S') && (vr[1] == 'H')) || ((vr[0] == 'O') && (vr[1] == 'W')) || ((vr[0] == 'O') && (vr[1] == 'F')) || ((vr[0] == 'S') && (vr[1] == 'Q')) || ((vr[0] == 'U') && (vr[1] == 'T')) || ((vr[0] == 'U') && (vr[1] == 'N')))
                        {
                            vr[2] = radh[(i + 4) * 2];
                            vl[0] = radh1[i + 4];
                            vl[1] = radh1[i + 5];
                            x = BitConverter.ToInt16(Bbuf, (i + 4) * 2) / 2;
                            int y = BitConverter.ToInt16(Bbuf, (i + 5) * 2) / 2;
                            if ((x == 0) || (y == 0))
                            { x += 1; }
                            for (int j = 0; j < x + y; j++)
                            { valeur[j] = radh1[i + j + 6]; }

                            i += x + y + 4;

                        }
                        else
                            if (((vr[0] == 'A') && (vr[1] == 'E')) || ((vr[0] == 'A') && (vr[1] == 'S')) || ((vr[0] == 'A') && (vr[1] == 'T')) || ((vr[0] == 'C') && (vr[1] == 'S')) || ((vr[0] == 'D') && (vr[1] == 'A')) || ((vr[0] == 'D') && (vr[1] == 'S')) || ((vr[0] == 'D') && (vr[1] == 'T')) || ((vr[0] == 'F') && (vr[1] == 'L')) || ((vr[0] == 'F') && (vr[1] == 'D')) || ((vr[0] == 'I') && (vr[1] == 'S')) || ((vr[0] == 'L') && (vr[1] == 'O')) || ((vr[0] == 'L') && (vr[1] == 'T')) || ((vr[0] == 'P') && (vr[1] == 'N'))  || ((vr[0] == 'S') && (vr[1] == 'L')) || ((vr[0] == 'S') && (vr[1] == 'S')) || ((vr[0] == 'S') && (vr[1] == 'T')) || ((vr[0] == 'T') && (vr[1] == 'M')) || ((vr[0] == 'U') && (vr[1] == 'I')) || ((vr[0] == 'U') && (vr[1] == 'L')) || ((vr[0] == 'U') && (vr[1] == 'S')) || ((vr[0] == 'O') && (vr[1] == 'T')))
                            {
                                vl[0] = radh1[i + 3];
                                x = BitConverter.ToInt16(Bbuf, (i + 3) * 2) / 2;

                                if (x == 0)
                                { x += 1; }

                                for (int j = 0; j < x; j++)
                                { valeur[j] = radh1[i + j + 4]; }
                                i += 3 + x;
                            }
                            else// (((vr[0] == '0') && (vr[1] != '0')))
                            {
                                vl[0] = radh1[i + 2];
                                vl[1] = radh1[i + 3];
                                x = BitConverter.ToInt16(Bbuf, (i + 2) * 2) / 2;
                                int y  = BitConverter.ToInt16(Bbuf, (i + 3) * 2) / 2;
                                if (x == 0 || y == 0)
                                { x += 1; }
                                for (int j = 0; j < x + y; j++)
                                { valeur[j] = radh1[i + j + 4]; }
                                i += x + y + 2;

                            }
                        char[] tag = new char[100];
                        if ((tag1 == "0028") && (tag2 == "0004"))
                        {
                            //int x = 0;
                            for (int n = 0; n < x + 5; n++)
                            {
                                tag[n] = radh[n + ((i -1) * 2)];
                            }
                            if ((tag[0] == 'M') && (tag[1] == 'O') && (tag[2] == 'N') && (tag[3] == 'O') && (tag[4] == 'C') && (tag[5] == 'H') && (tag[6] == 'R') && (tag[7] == 'O') && (tag[8] == 'M') && (tag[9] == 'E') && (tag[10] == '2'))
                            { m = 0; }
                            if ((tag[0] == 'M') && (tag[1] == 'O') && (tag[2] == 'N') && (tag[3] == 'O') && (tag[4] == 'C') && (tag[5] == 'H') && (tag[6] == 'R') && (tag[7] == 'O') && (tag[8] == 'M') && (tag[9] == 'E') && (tag[10] == '1'))
                            {
                                m = 1;


                            }
                            if ((tag[0] == 'P') && (tag[1] == 'A') && (tag[2] == 'L') && (tag[3] == 'E') && (tag[4] == 'T') && (tag[5] == 'T') && (tag[6] == 'E') && (tag[7] == ' ') && (tag[8] == 'C') && (tag[9] == 'O') && (tag[10] == 'L') && (tag[11] == 'O') && (tag[12] == 'R'))
                            {
                                m = 3;


                            }
                            if ((tag[0] == 'R') && (tag[1] == 'G') && (tag[2] == 'B')) { m = 2; }
                        }
                        if ((tag1 == "0002") && (tag2 == "0010"))
                        {
                            //int x = 0;
                            for (int n = 0; n < x*2 + 5; n++)
                            {
                                tag[n] = radh[n + ((i - 10) * 2)];
                            }
                            if ((tag[0] == '1') && (tag[1] == '.') && (tag[2] == '2') && (tag[3] == '.') && (tag[4] == '8') && (tag[5] == '4') && (tag[6] == '0') && (tag[7] == '.') && (tag[8] == '1') && (tag[9] == '0') && (tag[10] == '0') && (tag[11] == '0') && (tag[12] == '8') && (tag[13] == '.') && (tag[14] == '1') && (tag[15] == '.') && (tag[16] == '2') && (tag[17] == '.') && (tag[18] == '4') && (tag[19] == '.') && (((tag[20] == '5') && (tag[21] == '7')) || ((tag[20] == '5') && (tag[21] == '0')) || ((tag[20] == '5') && (tag[21] == '1')) || ((tag[20] == '5') && (tag[21] == '2')) || ((tag[20] == '5') && (tag[21] == '3')) || ((tag[20] == '5') && (tag[21] == '4')) || ((tag[20] == '5') && (tag[21] == '5')) || ((tag[20] == '5'))))
                            { m = 4; }
                        
                            
                        }
                        tail_entet = i * 2;// +1;
                    }
                }
                else
                    if ((radh1[0] == "0036")||(radh1[0]=="0033"))
            {
                for (i = 0; i < size1 / 2; i++)//do
                {
                    int x = 0;
                    tag1 = radh1[i + 3];
                    tag2 = radh1[i + 4/* 1*];
                    if ((radh1[i + 3] == "7FE0") && (radh1[i +4/* 1] == "0010"))
                    {
                        break;//Environment.FailFast;//   return ;
                    }
                    vr[0] = (radh[(i + 5/* 2) * 2]);
                    vr[1] = (radh[(i + 5/* 2) * 2 + 1]);
                    if (((vr[0] == 'O') && (vr[1] == 'B')) || ((vr[0] == 'O') && (vr[1] == 'W')) || ((vr[0] == 'O') && (vr[1] == 'F')) || ((vr[0] == 'S') && (vr[1] == 'Q')) || ((vr[0] == 'U') && (vr[1] == 'T')) || ((vr[0] == 'U') && (vr[1] == 'N')))
                    {
                        vr[2] = radh[(i + 7/* 4) * 2];
                        vl[0] = radh1[i + 7/*4];
                        vl[1] = radh1[i + 8/* 5];
                        x = BitConverter.ToInt16(Bbuf, (i + 7/* 4) * 2) / 2;
                        int y = BitConverter.ToInt16(Bbuf, (i +8/* 5) * 2) / 2;
                        if ((x == 0) || (y == 0))
                        { x += 1; }
                        for (int j = 0; j < x + y; j++)
                        { valeur[j] = radh1[i + j + 9/* 6]; }

                        i += x + y + 4;

                    }
                    else
                        if (((vr[0] == 'A') && (vr[1] == 'E')) || ((vr[0] == 'A') && (vr[1] == 'S')) || ((vr[0] == 'A') && (vr[1] == 'T')) || ((vr[0] == 'C') && (vr[1] == 'S')) || ((vr[0] == 'D') && (vr[1] == 'A')) || ((vr[0] == 'D') && (vr[1] == 'S')) || ((vr[0] == 'D') && (vr[1] == 'T')) || ((vr[0] == 'F') && (vr[1] == 'L')) || ((vr[0] == 'F') && (vr[1] == 'D')) || ((vr[0] == 'I') && (vr[1] == 'S')) || ((vr[0] == 'L') && (vr[1] == 'O')) || ((vr[0] == 'L') && (vr[1] == 'T')) || ((vr[0] == 'P') && (vr[1] == 'N')) || ((vr[0] == 'S') && (vr[1] == 'H')) || ((vr[0] == 'S') && (vr[1] == 'L')) || ((vr[0] == 'S') && (vr[1] == 'S')) || ((vr[0] == 'S') && (vr[1] == 'T')) || ((vr[0] == 'T') && (vr[1] == 'M')) || ((vr[0] == 'U') && (vr[1] == 'I')) || ((vr[0] == 'U') && (vr[1] == 'L')) || ((vr[0] == 'U') && (vr[1] == 'S')) || ((vr[0] == 'O') && (vr[1] == 'T')))
                        {
                            vl[0] = radh1[i + 6/* 3];
                            x = BitConverter.ToInt16(Bbuf, (i + 6/*3) * 2) / 2;

                            if (x == 0)
                            { x += 1; }

                            for (int j = 0; j < x; j++)
                            { valeur[j] = radh1[i + j + 7/*4]; }
                            i += 3 + x + 1;
                        }
                        else// (((vr[0] == '0') && (vr[1] != '0')))
                        {
                            vl[0] = radh1[i + 5/* 2];
                            vl[1] = radh1[i + 4/* 3];
                             x= BitConverter.ToInt16(Bbuf, (i +5/* 2) * 2) / 2;
                            int y = BitConverter.ToInt16(Bbuf, (i + 6/* 3) * 2) / 2;
                            if (x == 0 || y == 0)
                            { x += 1; }
                            for (int j = 0; j < x + y; j++)
                            { valeur[j] = radh1[i + j + 7/* 4]; }
                            i += x + y + 2;

                        }
                    char[] tag = new char[100];
                    if ((tag1 == "0028") && (tag2 == "0004"))
                    {
                        //int x = 0;
                        for (int n = 0; n < x + 5; n++)
                        {
                            tag[n] = radh[n + ((i + 3) * 2)];
                        }
                        if ((tag[0] == 'M') && (tag[1] == 'O') && (tag[2] == 'N') && (tag[3] == 'O') && (tag[4] == 'C') && (tag[5] == 'H') && (tag[6] == 'R') && (tag[7] == 'O') && (tag[8] == 'M') && (tag[9] == 'E') && (tag[10] == '2'))
                        { m = 0; }
                        if ((tag[0] == 'M') && (tag[1] == 'O') && (tag[2] == 'N') && (tag[3] == 'O') && (tag[4] == 'C') && (tag[5] == 'H') && (tag[6] == 'R') && (tag[7] == 'O') && (tag[8] == 'M') && (tag[9] == 'E') && (tag[10] == '1'))
                        {
                            m = 1;


                        }
                        if ((tag[0] == 'R') && (tag[1] == 'G') && (tag[2] == 'B')) { m = 2; }
                    }
                    tail_entet = i * 2;// +1;
                }
            }
                    else
                        if (radh1[0] == "0008")
                        {
                            for (i = 0; i < size1 / 2; i++)
                            {
                                int x = 0;
                                tag1 = radh1[i + 2];
                                tag2 = radh1[i + 3/* 1];
                                if ((radh1[i + 2] == "7FE0") && (radh1[i + 3/* 1] == "0010"))
                                {
                                    break;//Environment.FailFast;//   return ;
                                }
                                vr[0] = (radh[(i + 4/* 2) * 2]);
                                vr[1] = (radh[(i + 4/*2) * 2 + 1]);
                                if (((vr[0] == 'O') && (vr[1] == 'B')) || ((vr[0] == 'O') && (vr[1] == 'W')) || ((vr[0] == 'O') && (vr[1] == 'F')) || ((vr[0] == 'S') && (vr[1] == 'Q')) || ((vr[0] == 'U') && (vr[1] == 'T')) || ((vr[0] == 'U') && (vr[1] == 'N')))
                                {
                                    vr[2] = radh[(i + 6/* 4) * 2];
                                    vl[0] = radh1[i + 6/*4];
                                    vl[1] = radh1[i + 7/* 5];
                                    x = BitConverter.ToInt16(Bbuf, (i + 6/* 4) * 2) / 2;
                                    int y = BitConverter.ToInt16(Bbuf, (i + 7/* 5) * 2) / 2;
                                    if ((x == 0) || (y == 0))
                                    { x += 1; }
                                    for (int j = 0; j < x + y; j++)
                                    { valeur[j] = radh1[i + j + 8/* 6]; }

                                    i += x + y + 4;

                                }
                                else
                                    if (((vr[0] == 'A') && (vr[1] == 'E')) || ((vr[0] == 'A') && (vr[1] == 'S')) || ((vr[0] == 'A') && (vr[1] == 'T')) || ((vr[0] == 'C') && (vr[1] == 'S')) || ((vr[0] == 'D') && (vr[1] == 'A')) || ((vr[0] == 'D') && (vr[1] == 'S')) || ((vr[0] == 'D') && (vr[1] == 'T')) || ((vr[0] == 'F') && (vr[1] == 'L')) || ((vr[0] == 'F') && (vr[1] == 'D')) || ((vr[0] == 'I') && (vr[1] == 'S')) || ((vr[0] == 'L') && (vr[1] == 'O')) || ((vr[0] == 'L') && (vr[1] == 'T')) || ((vr[0] == 'P') && (vr[1] == 'N')) || ((vr[0] == 'S') && (vr[1] == 'H')) || ((vr[0] == 'S') && (vr[1] == 'L')) || ((vr[0] == 'S') && (vr[1] == 'S')) || ((vr[0] == 'S') && (vr[1] == 'T')) || ((vr[0] == 'T') && (vr[1] == 'M')) || ((vr[0] == 'U') && (vr[1] == 'I')) || ((vr[0] == 'U') && (vr[1] == 'L')) || ((vr[0] == 'U') && (vr[1] == 'S')) || ((vr[0] == 'O') && (vr[1] == 'T')))
                                    {
                                        vl[0] = radh1[i + 5/*3];
                                        x = BitConverter.ToInt16(Bbuf, (i + 5/* 3) * 2) / 2;

                                        if (x == 0)
                                        { x += 1; }

                                        for (int j = 0; j < x; j++)
                                        { valeur[j] = radh1[i + j + 6/* 4]; }
                                        i += 3 + x + 1;
                                    }
                                    else// (((vr[0] == '0') && (vr[1] != '0')))
                                    {
                                        vl[0] = radh1[i + 4/*2];
                                        vl[1] = radh1[i + 5/* 3];
                                        x = BitConverter.ToInt16(Bbuf, (i + 4/*2) * 2) / 2;
                                        int y = BitConverter.ToInt16(Bbuf, (i + 5/* 3) * 2) / 2;
                                        if (x == 0 || y == 0)
                                        { x += 1; }
                                        for (int j = 0; j < x + y; j++)
                                        { valeur[j] = radh1[i + j + 6/* 4]; }
                                        i += x + y + 2;

                                    }
                                char[] tag = new char[100];
                                if ((tag1 == "0028") && (tag2 == "0004"))
                                {
                                    //int x = 0;
                                    for (int n = 0; n < x + 5; n++)
                                    {
                                        tag[n] = radh[n + ((i + 3) * 2)];
                                    }
                                    if ((tag[0] == 'M') && (tag[1] == 'O') && (tag[2] == 'N') && (tag[3] == 'O') && (tag[4] == 'C') && (tag[5] == 'H') && (tag[6] == 'R') && (tag[7] == 'O') && (tag[8] == 'M') && (tag[9] == 'E') && (tag[10] == '2'))
                                    { m = 0; }
                                    if ((tag[0] == 'M') && (tag[1] == 'O') && (tag[2] == 'N') && (tag[3] == 'O') && (tag[4] == 'C') && (tag[5] == 'H') && (tag[6] == 'R') && (tag[7] == 'O') && (tag[8] == 'M') && (tag[9] == 'E') && (tag[10] == '1'))
                                    {
                                        m = 1;


                                    }
                                    if ((tag[0] == 'R') && (tag[1] == 'G') && (tag[2] == 'B')) { m = 2; }
                                }
                                tail_entet = i * 2;// +1;
                            }
                        }

                        else
                        {
                            
                            do
                            {
                                int x = 0;
                                tag1 = radh1[i + 61];
                                tag2 = radh1[i + 62/* 1];

                                vr[0] = (radh[(i + 63/*2) * 2]);
                                vr[1] = (radh[(i + 63/* 2) * 2 + 1]);
                                if (((vr[0] == 'O') && (vr[1] == 'B')) || ((vr[0] == 'O') && (vr[1] == 'W')) || ((vr[0] == 'O') && (vr[1] == 'F')) || ((vr[0] == 'S') && (vr[1] == 'Q')) || ((vr[0] == 'U') && (vr[1] == 'T')) || ((vr[0] == 'U') && (vr[1] == 'N')))
                                {
                                    vr[2] = radh[(i + 65/* 4) * 2];
                                    vl[0] = radh1[i + 65/* 4];
                                    vl[1] = radh1[i + 66/* 5];
                                    x = BitConverter.ToInt16(Bbuf, (i + 65/* 4) * 2) / 2;
                                    int y = BitConverter.ToInt16(Bbuf, (i + 66/* 5) * 2) / 2;
                                    if ((x == 0) || (y == 0))
                                    { x += 1; }
                                    for (int j = 0; j < x + y; j++)
                                    { valeur[j] = radh1[i + j + 67/* 6]; }

                                    i += x + y + 4;

                                }
                                else
                                    if (((vr[0] == 'A') && (vr[1] == 'E')) || ((vr[0] == 'A') && (vr[1] == 'S')) || ((vr[0] == 'A') && (vr[1] == 'T')) || ((vr[0] == 'C') && (vr[1] == 'S')) || ((vr[0] == 'D') && (vr[1] == 'A')) || ((vr[0] == 'D') && (vr[1] == 'S')) || ((vr[0] == 'D') && (vr[1] == 'T')) || ((vr[0] == 'F') && (vr[1] == 'L')) || ((vr[0] == 'F') && (vr[1] == 'D')) || ((vr[0] == 'I') && (vr[1] == 'S')) || ((vr[0] == 'L') && (vr[1] == 'O')) || ((vr[0] == 'L') && (vr[1] == 'T')) || ((vr[0] == 'P') && (vr[1] == 'N')) || ((vr[0] == 'S') && (vr[1] == 'H')) || ((vr[0] == 'S') && (vr[1] == 'L')) || ((vr[0] == 'S') && (vr[1] == 'S')) || ((vr[0] == 'S') && (vr[1] == 'T')) || ((vr[0] == 'T') && (vr[1] == 'M')) || ((vr[0] == 'U') && (vr[1] == 'I')) || ((vr[0] == 'U') && (vr[1] == 'L')) || ((vr[0] == 'U') && (vr[1] == 'S')) || ((vr[0] == 'O') && (vr[1] == 'T')) || ((vr[0] == 'D') && (vr[1] == 'V')))
                                    {
                                        vl[0] = radh1[i + 64/* 3];
                                        x = BitConverter.ToInt16(Bbuf, (i + 64/*3) * 2) / 2;

                                        if (x == 0)
                                        { x += 1; }

                                        for (int j = 0; j < x; j++)
                                        { valeur[j] = radh1[i + j + 65/* 4]; }
                                        i += 3+ x;
                                    }
                                    else// (((vr[0] == '0') && (vr[1] != '0')))
                                    {
                                        vl[0] = radh1[i + 63/* 2];
                                        vl[1] = radh1[i + 64/* 3];
                                        x = BitConverter.ToInt16(Bbuf, (i + 63/* 2) * 2) / 2;
                                        int y = BitConverter.ToInt16(Bbuf, (i + 64/* 3) * 2) / 2;
                                       /* if (x == 0 || y == 0)
                                        { x += 1; }
                                        for (int j = 0; j < x + y; j++)
                                        { valeur[j] = radh1[i + j + 65/* 4]; }
                                        i += x + y + 4;

                                    }
                                char[] tag = new char[100];
                                if ((tag1 == "0028") && (tag2 == "0004"))
                                {
                                    i += 61; //int x = 0;i
                                    for (int n = 0; n < x + 5; n++)
                                    {
                                        tag[n] = radh[n + ((i - 7) * 2)];
                                    }
                                    if ((tag[0] == 'M') && (tag[1] == 'O') && (tag[2] == 'N') && (tag[3] == 'O') && (tag[4] == 'C') && (tag[5] == 'H') && (tag[6] == 'R') && (tag[7] == 'O') && (tag[8] == 'M') && (tag[9] == 'E') && (tag[10] == '2'))
                                    { m = 0; }
                                    if ((tag[0] == 'M') && (tag[1] == 'O') && (tag[2] == 'N') && (tag[3] == 'O') && (tag[4] == 'C') && (tag[5] == 'H') && (tag[6] == 'R') && (tag[7] == 'O') && (tag[8] == 'M') && (tag[9] == 'E') && (tag[10] == '1'))
                                    {
                                        m = 1;


                                    }
                                    if ((tag[0] == 'P') && (tag[1] == 'A') && (tag[2] == 'L') && (tag[3] == 'E') && (tag[4] == 'T') && (tag[5] == 'T') && (tag[6] == 'E') && (tag[7] == ' ') && (tag[8] == 'C') && (tag[9] == 'O') && (tag[10] == 'L') && (tag[11] == 'O') && (tag[12] == 'R'))
                                    {
                                        m = 3;


                                    }
                                    if ((tag[0] == 'R') && (tag[1] == 'G') && (tag[2] == 'B')) { m = 2; }
                                }
                                if ((tag1 == "0002") && (tag2 == "0010"))
                                {
                                    //int x = 0;
                                    for (int n = 0; n < x * 2 + 5; n++)
                                    {
                                        tag[n] = radh[n + ((i - 10) * 2)];
                                    }
                                    if ((tag[0] == '1') && (tag[1] == '.') && (tag[2] == '2') && (tag[3] == '.') && (tag[4] == '8') && (tag[5] == '4') && (tag[6] == '0') && (tag[7] == '.') && (tag[8] == '1') && (tag[9] == '0') && (tag[10] == '0') && (tag[11] == '0') && (tag[12] == '8') && (tag[13] == '.') && (tag[14] == '1') && (tag[15] == '.') && (tag[16] == '2') && (tag[17] == '.') && (tag[18] == '4') && (tag[19] == '.') && (((tag[20] == '5') && (tag[21] == '7')) || ((tag[20] == '5') && (tag[21] == '0')) || ((tag[20] == '5') && (tag[21] == '1')) || ((tag[20] == '5') && (tag[21] == '2')) || ((tag[20] == '5') && (tag[21] == '3')) || ((tag[20] == '5') && (tag[21] == '4')) || ((tag[20] == '5') && (tag[21] == '5')) || ((tag[20] == '5'))))
                                    { m = 4; }


                                }
                                tail_entet = i * 2;// +1;

                            } while ((tag1 != "7FEO") || (tag2 != "0010"));
                        }*/
#endregion

            char[] tag = new char[22];
            m = 0;
            for ( i = 0; i < size1 / 2; i++)
            {
                               
                if ((radh1[i] == "0028") && (radh1[i + 1] == "0004"))
                {
                    //i += 61; //int x = 0;i
                    for (int n = 0; n < 22; n++)
                    {
                        tag[n] = radh[n + ((i +4) * 2)];
                    }
                    if ((tag[0] == 'M') && (tag[1] == 'O') && (tag[2] == 'N') && (tag[3] == 'O') && (tag[4] == 'C') && (tag[5] == 'H') && (tag[6] == 'R') && (tag[7] == 'O') && (tag[8] == 'M') && (tag[9] == 'E') && (tag[10] == '2'))
                    { m = 0;
                    break;
                    }
                    if ((tag[0] == 'M') && (tag[1] == 'O') && (tag[2] == 'N') && (tag[3] == 'O') && (tag[4] == 'C') && (tag[5] == 'H') && (tag[6] == 'R') && (tag[7] == 'O') && (tag[8] == 'M') && (tag[9] == 'E') && (tag[10] == '1'))
                    {
                        m = 1;
                        break;

                    }
                    if ((tag[0] == 'P') && (tag[1] == 'A') && (tag[2] == 'L') && (tag[3] == 'E') && (tag[4] == 'T') && (tag[5] == 'T') && (tag[6] == 'E') && (tag[7] == ' ') && (tag[8] == 'C') && (tag[9] == 'O') && (tag[10] == 'L') && (tag[11] == 'O') && (tag[12] == 'R'))
                    {
                        m = 3;
                        break;


                    }
                    if ((tag[0] == 'R') && (tag[1] == 'G') && (tag[2] == 'B')) 
                    { m = 2;
                    break;
                    }
                }
                
                }
            for ( i = 0; i < size1 / 2; i++)
            {
                if ((radh1[i] == "0002") && (radh1[i + 1] == "0010"))
                {
                    //int x = 0;
                    for (int n = 0; n < 22/*x * 2 + 5*/; n++)
                    {
                        tag[n] = radh[n + ((i +4) * 2)];
                    }
                    if ((tag[0] == '1') && (tag[1] == '.') && (tag[2] == '2') && (tag[3] == '.') && (tag[4] == '8') && (tag[5] == '4') && (tag[6] == '0') && (tag[7] == '.') && (tag[8] == '1') && (tag[9] == '0') && (tag[10] == '0') && (tag[11] == '0') && (tag[12] == '8') && (tag[13] == '.') && (tag[14] == '1') && (tag[15] == '.') && (tag[16] == '2') && (tag[17] == '.') && (tag[18] == '4') && (tag[19] == '.') && (((tag[20] == '5') && (tag[21] == '7')) || ((tag[20] == '5') && (tag[21] == '0')) || ((tag[20] == '5') && (tag[21] == '1')) || ((tag[20] == '5') && (tag[21] == '2')) || ((tag[20] == '5') && (tag[21] == '3')) || ((tag[20] == '5') && (tag[21] == '4')) || ((tag[20] == '5') && (tag[21] == '5')) || ((tag[20] == '5'))))
                    { m = 4;
                        break; }
                    else
                        break;


                }
            }
           
            for (i = 0; i < size1 / 2; i++)
            {
                if ((radh1[i] == "0008") && (radh1[i + 1] == "0008"))
                {
                    
                    char[] ts = new char[10];
                    for (int n = 0; n < 10; n++)
                    {
                        ts[n] = radh[n + ((i + 12) * 2)+1];
                    }
                    if ((ts[0] == 'T') && (ts[1] == 'O') && (ts[2] == 'M') && (ts[3] == 'O'))
                    {
                        n = 5;
                        break;
                    }
                    else
                        if ((ts[0] == 'D') && (ts[1] == 'Y') && (ts[2] == 'N') && (ts[3] == 'A') && (ts[4] == 'M') && (ts[5] == 'I') && (ts[6] == 'C'))
                        {
                            n = 6;
                            break;
                        }
                        else
                            if ((ts[0] == 'G') && (ts[1] == 'A') && (ts[2] == 'T') && (ts[3] == 'E') && (ts[4] == 'D') && (ts[5] == ' ') && (ts[6] == 'T') && (ts[7] == 'O') && (ts[8] == 'M') && (ts[9] == 'O'))
                            {
                                n = 7;
                                break;
                            }
                            else n = 0;
                        break;


                }
            }
            int f = 0;
            for ( f = 0; f < size1 / 2; f++)
            {
                if ((radh1[f] == "0028") && (radh1[f+1] == "0011"))
                {

                    nb_colon = BitConverter.ToInt16(Bbuf, (f + 4) * 2);

                    break;//f = size1 / 2;
                }
            }

           long nb_imageS =0;
           
            

            for ( f = 0; f < size1 / 2; f++)
            {
                if ((radh1[f] == "0028") && (radh1[f + 1] == "0010"))
                {

                    nb_ligne = BitConverter.ToInt16(Bbuf, (f + 4) * 2);
                    break;//f = size1 / 2;
                }
            }

            /*for ( f = 0; f < size1 / 2; f++)
            {
                if ((radh1[f] == "0028") && (radh1[f + 1] == "0101"))
                {

                    int ba =BitConverter.ToInt16(Bbuf, (f + 4) * 2);
                    break;//f = size1 / 2;
                }
            }*/

            for (f = 0; f < size1 / 2; f++)
            {
                if ((radh1[f] == "0028") && (radh1[f + 1] == "0100"))
                {

                    nbr_oct_valeur = BitConverter.ToInt16(Bbuf, (f + 4) * 2) ;
                    nbr_oct_valeur = nbr_oct_valeur / 8;
                    break;//f = size1 / 2;
                }
            }
            
            for (f = 0; f < tail_entet / 2; f++)
            {
                if ((radh1[f] == "0028") && (radh1[f + 1] == "0008"))
                {
                    int x = BitConverter.ToInt16(Bbuf, (f + 3) * 2);

                    /*int c = -1;
                   
                    do
                    {
                        c+=1;
                    }
                    while((radh[c + ((f + 4) * 2)]!=' ')&&(c<x+1));
                    
                    c-=1;*/

                    if (radh[x + ((f + 3) * 2)] == ' ') x--;

                    //string[] st = new string[x];
                    string st = null;
                    for (int n = 0; n < x; n++)
                    {
                        st += Convert.ToString(radh[n + ((f + 4) * 2)]);
                    }
                    nb_image = Convert.ToInt16(st);


                    /*if (x == 2)
                     {
                         for (i = 0; i <c; i++)
                         {
                             nb_image += Convert.ToInt16(st[i]) * (int)(Math.Pow(10, c - i-1));


                         }
                     }
                     else
                     {
                         for (i = 0; i <=c; i++)
                         {
                             nb_image += Convert.ToInt16(st[i]) * (int)(Math.Pow(10, c - i+1));


                         }
                     }*/

                    break;// f = size1 / 2;
                }
                else
                { nb_image = 1; }
            }

            for (f = 0; f < size1 / 2; f++)
            {
                if ((radh1[f] == "0028") && (radh1[f + 1] == "0102"))
                {

                    big_endian = BitConverter.ToInt16(Bbuf, (f + 4) * 2) ;
                    break;// f = size1 / 2;
                }
            }
            if ((big_endian >7)) s = 1; 

          
            //nb_image=(short)((size-(tail_entet/*+132*/))/(nb_colon*nb_ligne*nbr_oct_valeur));
            //if (nb_image == 0) { nb_image = 1; }
            /* for (i = 0; i < size1 / 2; i++)
           {
               if ((radh1[i] == "0018") && (radh1[i + 1] == "1140"))
               {

                   int nb_image = BitConverter.ToInt16(Bbuf, (i + 4) * 2);
                   i = size1 / 2;
               }
           }*/
            

        }
    }
}
