using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Linq;
namespace one_click_fix
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_B_Click(object sender, RoutedEventArgs e)
        {
            start_B.Visibility = Visibility.Hidden;

            Microsoft.Win32.OpenFileDialog openImageDialog = new Microsoft.Win32.OpenFileDialog();
            openImageDialog.Filter = "Файл изображения (.jpg)|*.jpg";
            Nullable<bool> result = openImageDialog.ShowDialog();
            if (result == true)
            {

                string filename = openImageDialog.FileName;
                mainImage_I.Visibility = Visibility.Visible;


                BitmapImage originalImage = new BitmapImage(new Uri(openImageDialog.FileName));

                int stride = originalImage.PixelWidth * 4;
                int size = originalImage.PixelHeight * stride;

                byte[] originalImagePixels = new byte[size];
                byte[] previewImagePixels = new byte[size];

                originalImage.CopyPixels(originalImagePixels, stride, 0);

                for(int x = 0; x< (int)originalImage.Height; x++)
                {
                    for (int y = 0; y < (int)originalImage.Height; y++)
                    {
                        int index = y * stride + 4 * x;
                        byte red = originalImagePixels[index];
                        byte green = originalImagePixels[index + 1];
                        byte blue = originalImagePixels[index + 2];
                        byte alpha = originalImagePixels[index + 3];
                    }


                }
            }
        }



        class mask
        {
            BitmapImage applyFilter(BitmapImage image)
            {
                Enumerable.Range(0, (int)image.Width).AsParallel().ForAll(x =>
                {
                    for (int y = 0; y < (int)image.Height; y++)
                    {
                        /*        color = ;
                                color1 = dsp.GetPixel(x, y);

                                float brght = color.GetBrightness();
                                float brght1 = color1.GetBrightness();

                                byte r1 = color1.R;
                                byte g1 = color1.G;
                                byte b1 = color1.B;

                                r = (byte)((r * 0.35 + ((brght) * r + (1 - brght) * 100) * 0.65));
                                b = (byte)((b * 0.7 + ((1 - brght) * b + (brght) * 255) * 0.3));

                                dst.SetPixel(x, y, Color.FromArgb((byte)(r * (1 - brght1) + r1 * brght1), (byte)(g * (1 - brght1) + g1 * brght1), (byte)(b * (1 - brght1) + b1 * brght1)));
                            */
                    }
                });

                return image;
            }
        }
    }
}