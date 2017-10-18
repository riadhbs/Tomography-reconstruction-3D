using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace TIMed
{
    public class RichPictureBox : System.Windows.Forms.PictureBox
    {
        public Image original;

        public void Griser()
        {
            if (Image == null) return;

            AppliqueEffet(Image);
            Invalidate();


        }  
        
        public void AppliqueEffet(Image bm)
        {
            Graphics gr = Graphics.FromImage(bm);
            ColorMatrix cm = null;



            cm = new ColorMatrix(new float[][]{new float[]{0.309f,0.309f,0.309f,0,0},
														  new float[]{0.609f,0.609f,0.609f,0,0},
														  new float[]{0.082f,0.082f,0.082f,0,0},
														  new float[]{0,0,0,1,0,0},
														  new float[]{0,0,0,0,1,0},
														  new float[]{0,0,0,0,0,1}});


            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm);

            gr.DrawImage(bm, new Rectangle(0, 0, bm.Width, bm.Height), 0, 0, bm.Width, bm.Height, GraphicsUnit.Pixel, ia);
            gr.Dispose();
        }

    }
}
