using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentaDeVideos.Clases
{
    class CargarImagenesSlider
    {
        private int iContadorImagen=1;
        private PictureBox picImagen;

        public CargarImagenesSlider(PictureBox picImagenesSlider)
        {
            this.picImagen = picImagenesSlider;
        }
        
        public void ImagenesSlider_Cargar(int iMaximoImagenes,int iImagenesInicio,string sCarpeta, string sImagenFuente)
        {
            if (iContadorImagen == iMaximoImagenes)
            {
                iContadorImagen = iImagenesInicio;
            }
            picImagen.ImageLocation = string.Format(sCarpeta+@"\"+sImagenFuente, iContadorImagen);
            iContadorImagen++;
        }
    }
}
