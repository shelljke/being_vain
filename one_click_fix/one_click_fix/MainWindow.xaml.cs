using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Windows.Media;

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
                blackAndWhite_I.Visibility = Visibility.Visible;

                Uri uri = new Uri(openImageDialog.FileName);

                BitmapImage originalImage = new BitmapImage(uri);
                BitmapImage previewImage = new BitmapImage();


                previewImage.BeginInit();
                    previewImage.UriSource = uri;
                if (originalImage.Width < originalImage.Height)
                {
                    previewImage.DecodePixelHeight = 60;
                    double k = originalImage.Height / previewImage.DecodePixelHeight;
                    previewImage.DecodePixelWidth /= (int)k;
                }
                else
                {
                    previewImage.DecodePixelWidth = 110;
                    double k = originalImage.Width / previewImage.DecodePixelWidth;
                    previewImage.DecodePixelHeight /= (int)k;
                }

                previewImage.EndInit();

                int originalStride = originalImage.PixelWidth * 4;
                int originalSize = originalImage.PixelHeight * originalStride;

                int previewStride = previewImage.PixelWidth * 4;
                int previewlSize = previewImage.PixelHeight * previewStride;

                byte[] originalImagePixels = new byte[originalSize];
                byte[] previewImagePixels = new byte[previewlSize];

                
                originalImage.CopyPixels(originalImagePixels, originalStride, 0);
                previewImage.CopyPixels(previewImagePixels, previewStride, 0);

                for (int x = 0; x < (int)originalImage.Width; x++)
                {
                    for (int y = 0; y < (int)originalImage.Height; y++)
                    {
                        int index = y * originalStride + 4 * x;

                        byte red = originalImagePixels[index];
                        byte green = originalImagePixels[index + 1];
                        byte blue = originalImagePixels[index + 2];
                        byte alpha = originalImagePixels[index + 3];
                        originalImagePixels[index + 1] = (byte)(originalImagePixels[index + 1] * 0.21 + originalImagePixels[index + 2] * 0.79);
                    }

                }



                    BitmapSource bbitmap = BitmapSource.Create(originalImage.PixelWidth, originalImage.PixelHeight,
               96, 96, PixelFormats.Bgr32, null,
               originalImagePixels, originalStride);

                    mainImage_I.Source = bbitmap;

                BitmapSource pbbitmap = BitmapSource.Create(previewImage.PixelWidth, previewImage.PixelHeight,
               96, 96, PixelFormats.Bgr32, null,
               previewImagePixels, previewStride);

                blackAndWhite_I.Source = pbbitmap;

            }
        }



    }
}
