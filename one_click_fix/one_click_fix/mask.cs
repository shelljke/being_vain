using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace one_click_fix
{
     class mask
    {
        public byte[] blackAndWhite(byte[] imagePixels, int w, int h)
        {
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    int index = y * w * 4 + 4 * x;
                    imagePixels[index] = imagePixels[index + 1] = imagePixels[index + 2];
                }
            }
            return imagePixels;
        }
    }

}
