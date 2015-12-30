using System.Drawing;
using System.Linq;
using Common;

namespace Nashville
{
    public class Slumber : IFilter
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

                    red = (255f - 48f) / 255f * red + 48;
                    green = (255f - 38f) / 255f * green + 38;
                    blue = (255f - 31f) / 255f * blue + 31;
                    color = Color.FromArgb(255, (int)red, (int)green, (int)blue);
                    currentMask.SetPixel(x, y, color);
                }
            });

            currentMask.UnlockBitmap();
            return currentMask.Bitmap;
        }
    }
}