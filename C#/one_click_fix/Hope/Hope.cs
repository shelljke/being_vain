using System.Drawing;
using System.Linq;
using Common;

namespace Nashville
{
    public class Hope : IFilter
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

                    if (color.GetBrightness() <= 0.35)
                    {
                        red = 0;
                        green = 50;
                        blue = 77;
                    }

                    if (color.GetBrightness() > 0.35 & color.GetBrightness() <= 0.55)
                    {
                        red = 215;
                        green = 26;
                        blue = 33;
                    }
                    if (color.GetBrightness() > 0.55)
                    {
                        red = 252;
                        green = 228;
                        blue = 168;
                    }

                    color = Color.FromArgb(255, (int)red, (int)green, (int)blue);
                    currentMask.SetPixel(x, y, color);
                }
            });

            currentMask.UnlockBitmap();
            return currentMask.Bitmap;
        }
    }
}
