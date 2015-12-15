using System;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace one_click_fix
{
    static class BitmapExtensions
    {
        public static BitmapImage GetSource(this Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                return bitmapimage;
            }
        }

       public static Bitmap Resize(this Bitmap image, int width, int height)
        {
            return new Bitmap(image, width, height);
        }

       public static Bitmap Resize(this Bitmap currentImage, int maxSize)
        {
            double width=currentImage.Width, height=currentImage.Height;
            if (currentImage.Width < currentImage.Height)
            {
                height = maxSize;
                double k = currentImage.Height / height;
                width /= (int)k;
            }
            else
            {
                width = maxSize;
                double k = currentImage.Width / width;
                height /= k;
            }
            return new Bitmap(currentImage, (int)width, (int)height);
        }
         public static Bitmap GetMask(this Bitmap currentImage, Masks mask)
        {
              switch (mask)
              {
                   case Masks.BlackAndWhite:
                   return Mask.BlackAndWhite(currentImage.Clone() as Bitmap);
                    case Masks.Nashville:
                 return Mask.Nashville(currentImage.Clone() as Bitmap);
            }
            throw new Exception("Несуществующая маска");
        }
    }
}