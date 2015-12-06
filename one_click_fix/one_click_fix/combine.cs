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

        static public BitmapSource applyFilter(byte[] mask, image image, double power)
        {
            int w = image.width;
            int h = image.height;
            BitmapSource resultImage;
            byte[] resultpixels = new byte[w * h * 4];
            for (int x = 0; x < (int)w; x++)
            {
                for (int y = 0; y < (int)h; y++)
                {
                    int index = y * w * 4 + 4 * x;
                    resultpixels[index] =     (byte)((1 - power) * image.pixels[index]   +   power * mask[index]);
                    resultpixels[index + 1] = (byte)((1 - power) * image.pixels[index + 1] + power * mask[index + 1]);
                    resultpixels[index + 2] = (byte)((1 - power) * image.pixels[index + 2] + power * mask[index + 2]);
                }
            }
            resultImage = BitmapSource.Create(w, h, 96, 96, PixelFormats.Bgr32, null, resultpixels, w * 4);
            return resultImage;
        }

    }
}
