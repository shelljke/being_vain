using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace one_click_fix
{
  partial class combine 
    {
        private BitmapSource resultImage;
         

        public BitmapSource applyFilter(byte[] mask, byte[] image, double power, int w, int h)
        {
            byte[] resultImagePixels = new byte[w*h*4];
            for (int x = 0; x < (int)w; x++)
            {
                for (int y = 0; y < (int)h; y++)
                {
                    int index = y * w * 4 + 4 * x;
                    resultImagePixels[index] =   (byte)((1 - power) * image[index]   + power * mask[index]);
                    resultImagePixels[index + 1] = (byte)((1 - power) * image[index + 1] + power * mask[index + 1]);
                    resultImagePixels[index+2] = (byte)((1 - power) * image[index+2] + power * mask[index+2]);

                }
            }
            resultImage = BitmapSource.Create(w, h,1, 1, PixelFormats.Bgr32, null, resultImagePixels, w * 4);
            return resultImage;
        }

    }
}
