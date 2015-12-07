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

         image processedImage = new image();
         image previewImage = new image();
        byte[] currentMask;

        public MainWindow()
        {
            InitializeComponent();
            blackAndWhite_I.Visibility = Visibility.Hidden;
            nashville_I.Visibility = Visibility.Hidden;
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
                BitmapImage bitmapImage = new BitmapImage(uri);
                /////////////
                prepareImages.openImage(bitmapImage, out previewImage, out processedImage);

                blackAndWhite_I.Visibility = Visibility.Visible;
                currentMask = mask.blackAndWhite(previewImage);
                blackAndWhite_I.Source = combine.applyFilter(currentMask, previewImage, 0.5);

                nashville_I.Visibility = Visibility.Visible;
                currentMask = mask.nashville(previewImage);
                nashville_I.Source = combine.applyFilter(currentMask, previewImage, 0.5);

                mainImage_I.Source = bitmapOriginalImage;

            }
        }
    
        private void blackAndWhite_I_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            currentMask = mask.blackAndWhite(processedImage);
            mainImage_I.Source = combine.applyFilter(currentMask, processedImage, 0.5);

        }
         private void nashville_I_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            currentMask = mask.nashville(processedImage);
            mainImage_I.Source = combine.applyFilter(currentMask, processedImage, 0.5);
        }
    

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           mainImage_I.Source = combine.applyFilter(currentMask, processedImage, slider.Value);
        }
    }
    class prepareImages
    {
        static BitmapImage bitmapPreviewImage = new BitmapImage();
        static BitmapImage bitmapProcessedImage = new BitmapImage();

      
        static public void openImage(BitmapImage currentImage, out image previewImage, out image processedImage)
        {

            bitmapPreviewImage.BeginInit();
            bitmapPreviewImage.UriSource = currentImage.UriSource ;
            if (currentImage.Width < currentImage.Height)
            {
                bitmapPreviewImage.DecodePixelHeight = 60;
                double k = currentImage.Height / bitmapPreviewImage.DecodePixelHeight;
                bitmapPreviewImage.DecodePixelWidth /= (int)k;
            }
            else
            {
                bitmapPreviewImage.DecodePixelWidth = 110;
                double k = currentImage.Width / bitmapPreviewImage.DecodePixelWidth;
                bitmapPreviewImage.DecodePixelHeight /= (int)k;
            }
            bitmapPreviewImage.EndInit();
            ////////////////////////////////////////
            bitmapProcessedImage.BeginInit();
            bitmapProcessedImage.UriSource = currentImage.UriSource;
            if (currentImage.Width < currentImage.Height)
            {
                bitmapProcessedImage.DecodePixelHeight = 500;
                double k = currentImage.Height / bitmapProcessedImage.DecodePixelHeight;
                bitmapProcessedImage.DecodePixelWidth /= (int)k;
            }
            else
            {
                bitmapProcessedImage.DecodePixelWidth = 700;
                double k = currentImage.Width / bitmapProcessedImage.DecodePixelWidth;
                bitmapProcessedImage.DecodePixelHeight /= (int)k;
            }
            bitmapProcessedImage.EndInit();


            int processedStride = bitmapProcessedImage.PixelWidth * 4;
            int processedSize = bitmapProcessedImage.PixelHeight * processedStride;

            int previewStride = bitmapPreviewImage.PixelWidth * 4;
            int previewSize = bitmapPreviewImage.PixelHeight * previewStride;

            processedImage.pixels = new byte[processedSize];
            previewImage.pixels = new byte[previewSize];

            bitmapProcessedImage.CopyPixels(processedImage.pixels, processedStride, 0);
            bitmapPreviewImage.CopyPixels(previewImage.pixels, previewStride, 0);

            processedImage.width = (int)bitmapProcessedImage.Width;
            processedImage.height = (int)bitmapProcessedImage.Height;

            previewImage.width = (int)bitmapPreviewImage.Width;
            previewImage.height = (int)bitmapPreviewImage.Height;           
        }
    }
}
