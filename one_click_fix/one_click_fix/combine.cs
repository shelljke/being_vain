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

        public BitmapSource applyFilter(byte[] mask, byte[] image, int power, int w, int h)
        {

            for (int x = 0; x < (int)w; x++)
            {
                for (int y = 0; y < (int)h; y++)
                {
                    int index = y * w * 4 + 4 * x;
                    image[index] =(byte)( (255 - power) * image[index]+power*mask[index]);
                    image[index+1] = (byte)((255 - power) * image[index+1] + power * mask[index+1]);
                    image[index+2] = (byte)((255 - power) * image[index+2] + power * mask[index+2]);

                }

            }
            BitmapSource bbitmap= BitmapSource.Create(w, h, 96, 96, PixelFormats.Bgr32, null, image, w * 4);
            return bbitmap;
        }

    }
}
