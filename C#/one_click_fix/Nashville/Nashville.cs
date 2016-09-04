using System.Drawing;
using System.Linq;
using Common;

namespace Nashville
{
    public class Nashville : IFilter
    {
        public Bitmap ApplyFilter(Bitmap mask)
        {
            int w = mask.Width;
            int h = mask.Height;
            ImagerBitmap currentMask = new ImagerBitmap(mask.Clone() as Bitmap);

            Enumerable.Range(0, w).AsParallel().ForAll(x =>
            {
                for (int y = 0; y < h; y++)
                {
                    Color color = currentMask.GetPixel(x, y);
                    float red = color.R;
                    float green = color.G;
                    float blue = color.B;

                    red = 224f/255f*red + 31;
                    green = 236f/255f*green;
                    blue = 59f/255f*blue + 102;
                    color = Color.FromArgb(255, (int)red, (int)green, (int)blue);
                    currentMask.SetPixel(x, y, color);
                }
            });

            currentMask.UnlockBitmap();
            return currentMask.Bitmap;
        }
    }
}
