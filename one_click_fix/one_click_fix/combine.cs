
using System.Drawing;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Color = System.Drawing.Color;

namespace one_click_fix
{
    partial class Combine
    {
        static public Bitmap ApplyFilter(Bitmap mask, Bitmap currentImage, double power)
        {
           int w = currentImage.Width;
           int h = currentImage.Height;
            //Enumerable.Range(0, (int)w).AsParallel().WithDegreeOfParallelism(2).ForAll(x =>
            for (int x = 0; x < (int)w; x++)
            {
                for (int y = 0; y < (int) h; y++)
                {
                    Color maskColor = mask.GetPixel(x, y);
                    Color currentImageColor = mask.GetPixel(x, y);
                    Color resultColor = Color.FromArgb(255, 
                        (byte) (currentImageColor.R*(1 - power) + maskColor.R*power),
                        (byte) (currentImageColor.G*(1 - power) + maskColor.G*power),
                        (byte) (currentImageColor.B*(1 - power) + maskColor.B*power));
                    currentImage.SetPixel(x, y, resultColor);
                }
            }
            //});
            return currentImage;
        }

    }
}
