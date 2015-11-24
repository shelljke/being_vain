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

            }
        }



    }
}
