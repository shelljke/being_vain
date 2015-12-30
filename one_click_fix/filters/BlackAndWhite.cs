using System.Drawing;
using System.Linq;
using SimpleImageProcessing;

namespace one_click_fix.Filters
{
    public class BlackAndWhite : IFilter
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
                    var color = currentMask.GetPixel(x, y);
                    color = Color.FromArgb(255, color.G, color.G, color.G);
                    currentMask.SetPixel(x, y, color);
                }
            });
            currentMask.UnlockBitmap();
            return currentMask.Bitmap;
        }
    }
}