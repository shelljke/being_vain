using System.Drawing;

namespace one_click_fix
{
    static class Mask
    {
        static public Bitmap BlackAndWhite(Bitmap currentImage)
        {
            Bitmap currentMask = (Bitmap) currentImage.Clone();          
            for (int x = 0; x < currentImage.Width; x++)
            {
                for (int y = 0; y < currentImage.Height; y++)
                {
                    Color color = currentMask.GetPixel(x,y);
                    color = Color.FromArgb(255, color.G, color.G, color.G);
                    currentMask.SetPixel(x,y, color);
                }
            }
            return currentMask;
        }

        //static public byte[] Nashville(Bitmap currentImage)
        //{
        //    currentMask = currentImage.Pixels.ToArray();
        //    float brightness;
        //    for (int x = 0; x < currentImage.Width; x++)
        //    {
        //        for (int y = 0; y < currentImage.Height; y++)
        //        {
        //            int index = y * currentImage.Width * 4 + 4 * x;
        //            brightness = (float)(currentImage.Pixels[index + 0] + currentImage.Pixels[index + 1] + currentImage.Pixels[index + 2]) / 765;
        //            currentMask[index] = (byte)(255 - (255 * brightness));
        //        }
        //    }
        //    return currentMask;
        //}
    }
}
