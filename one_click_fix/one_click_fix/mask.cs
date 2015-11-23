using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace one_click_fix
{
    partial class mask
    {
        public byte[] blackAndWhite(byte[] imagePixels, BitmapImage image)
        {

            for (int x = 0; x < (int)image.Width; x++)
            {
                for (int y = 0; y < (int)image.Height; y++)
                {
                    int index = y * image.PixelWidth * 4 + 4 * x;
                    imagePixels[index ] = imagePixels[index + 1] = imagePixels[index + 2];
                }

            }
            return imagePixels;
        }
    }

}
