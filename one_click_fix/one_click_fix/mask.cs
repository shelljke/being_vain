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
        static public byte[] blackAndWhite(image currentImage)
        {
            byte[] currentMask = currentImage.pixels.ToArray();

            for (int x = 0; x < currentImage.width; x++)
            {
                for (int y = 0; y < currentImage.height; y++)
                {
                    int index = y * currentImage.width * 4 + 4 * x;
                    currentMask[index] = currentMask[index + 1] = currentMask[index + 2];
                }
            }
            return currentMask;
        }
    }

}
