using System.Drawing;
using System.Linq;
using SimpleImageProcessing;

namespace one_click_fix
{
    static class Mask
    {
        static public Bitmap BlackAndWhite(Bitmap mask)
        {
            int w = mask.Width;
            int h = mask.Height;
            ImagerBitmap currentMask = new ImagerBitmap(mask);

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

        public static Bitmap Nashville(Bitmap mask)
        {
            int w = mask.Width;
            int h = mask.Height;
            ImagerBitmap currentMask = new ImagerBitmap(mask);

            Enumerable.Range(0, w).AsParallel().ForAll(x =>
            {
                for (int y = 0; y < h; y++)
                {                
                    Color color = currentMask.GetPixel(x, y);
                    color = Color.FromArgb(255, color.R, color.G, (int)(color.B*(1- color.GetBrightness())));
                    currentMask.SetPixel(x, y, color);
                }
            });

            currentMask.UnlockBitmap();
            return currentMask.Bitmap;
        }
    }
}
