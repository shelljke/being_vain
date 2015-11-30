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
        protected byte[] originalImagePixels;
        protected byte[] previewImagePixels;
        protected BitmapImage originalImage;
        mask maskPixels = new mask();
        combine updater = new combine();
        byte[] currentMask;

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

                originalImage = new BitmapImage(uri);
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
                int previewlSize = previewImage.PixelHeight * previewImage.PixelWidth * 4;

                originalImagePixels = new byte[originalSize];
                previewImagePixels = new byte[previewlSize];
                

                originalImage.CopyPixels(originalImagePixels, originalStride, 0);
                previewImage.CopyPixels(previewImagePixels, previewStride, 0);

                

                blackAndWhite_I.Visibility = Visibility.Visible;
                currentMask = maskPixels.blackAndWhite(previewImagePixels, previewImage.PixelWidth, previewImage.PixelHeight);
               // blackAndWhite_I.Source= BitmapSource.Create((int)previewImage.Width, (int)previewImage.Height, 96, 96, PixelFormats.Bgr32, null, previewImagePixels2, (int)previewImage.Width * 4);
                blackAndWhite_I.Source = updater.applyFilter(previewImagePixels, previewImagePixels, 0.5, (int)previewImage.Width, (int)previewImage.Height);
            }
        }

        private void blackAndWhite_I_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
                    currentMask = maskPixels.blackAndWhite(originalImagePixels,originalImage.PixelWidth, originalImage.PixelHeight);
            mainImage_I.Source = updater.applyFilter(currentMask, originalImagePixels, 1, (int)originalImage.Width, (int)originalImage.Height);
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mainImage_I.Source = updater.applyFilter(currentMask, originalImagePixels, slider.Value, (int)originalImage.Width, (int)originalImage.Height);
        }
    }
}
