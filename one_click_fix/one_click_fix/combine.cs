using System.Drawing;
using System.Linq;
using SimpleImageProcessing;
using Color = System.Drawing.Color;

namespace one_click_fix
{
    class Combine
    {
        public static Bitmap ApplyFilter(Bitmap mask, Bitmap image, double power)
        {
            
            int w = image.Width;
            int h = image.Height;
            ImagerBitmap currentImage = new ImagerBitmap(image.Clone() as Bitmap);
            ImagerBitmap currentMask = new ImagerBitmap(mask.Clone() as Bitmap);

           Enumerable.Range(0, w).AsParallel().ForAll(x =>
            {
                for (int y = 0; y < h; y++)
                {                        
                    Color currentImageColor = currentImage.GetPixel(x, y);
                    Color maskColor = currentMask.GetPixel(x, y);
                    Color resultColor = Color.FromArgb(255,
                        (byte)(currentImageColor.R * (1 - power) + maskColor.R * power),
                        (byte)(currentImageColor.G * (1 - power) + maskColor.G * power),
                        (byte)(currentImageColor.B * (1 - power) + maskColor.B * power));
                    currentImage.SetPixel(x, y, resultColor);
                }
            });
            
            currentImage.UnlockBitmap();
            currentMask.UnlockBitmap();

          return currentImage.Bitmap;
        }
    }

}

