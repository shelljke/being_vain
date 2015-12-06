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
    /// 

    struct image
    {
        public byte[] pixels;
        public int width;
        public int height;
    }

    public partial class MainWindow : Window
    {
        protected BitmapImage bitmapOriginalImage;

        image originalImage = new image();
        image previewImage = new image();
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

                bitmapOriginalImage = new BitmapImage(uri);
                BitmapImage bitmapPreviewImage = new BitmapImage();

                bitmapPreviewImage.BeginInit();
                bitmapPreviewImage.UriSource = uri;
                if (bitmapOriginalImage.Width < bitmapOriginalImage.Height)
                {
                    bitmapPreviewImage.DecodePixelHeight = 60;
                    double k = bitmapOriginalImage.Height / bitmapPreviewImage.DecodePixelHeight;
                    bitmapPreviewImage.DecodePixelWidth /= (int)k;
                }
                else
                {
                    bitmapPreviewImage.DecodePixelWidth = 110;
                    double k = bitmapOriginalImage.Width / bitmapPreviewImage.DecodePixelWidth;
                    bitmapPreviewImage.DecodePixelHeight /= (int)k;
                }

                bitmapPreviewImage.EndInit();

                int originalStride = bitmapOriginalImage.PixelWidth * 4;
                int originalSize = bitmapOriginalImage.PixelHeight * originalStride;

                int previewStride = bitmapPreviewImage.PixelWidth * 4;
                int previewSize = bitmapPreviewImage.PixelHeight * previewStride;

                originalImage.pixels = new byte[originalSize];
                previewImage.pixels = new byte[previewSize];

                bitmapOriginalImage.CopyPixels(originalImage.pixels, originalStride, 0);
                bitmapPreviewImage.CopyPixels(previewImage.pixels, previewStride, 0);

                originalImage.width = (int)bitmapOriginalImage.Width;
                originalImage.height = (int)bitmapOriginalImage.Height;

                previewImage.width = (int)bitmapPreviewImage.Width;
                previewImage.height = (int)bitmapPreviewImage.Height;

                blackAndWhite_I.Visibility = Visibility.Visible;
                currentMask = mask.blackAndWhite(previewImage);
                blackAndWhite_I.Source = combine.applyFilter(currentMask, previewImage, 0.5);
                mainImage_I.Source = bitmapOriginalImage;
            }
        }

        private void blackAndWhite_I_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            currentMask = mask.blackAndWhite(originalImage);
            mainImage_I.Source = combine.applyFilter(currentMask, originalImage, 0.5);
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mainImage_I.Source = combine.applyFilter(currentMask, originalImage, slider.Value);
        }
    }
}
