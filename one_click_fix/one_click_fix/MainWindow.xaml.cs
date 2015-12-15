using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace one_click_fix
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    
    public partial class MainWindow : Window
    {

        public Bitmap OriginalImage;
        public Bitmap CurrentMask;

        public MainWindow()
        {
            InitializeComponent();
            BlackAndWhite_I.Visibility = Visibility.Hidden;
            Nashville_I.Visibility = Visibility.Hidden;
        }

        private void start_B_Click(object sender, RoutedEventArgs e)
        {

            start_B.Visibility = Visibility.Hidden;

            Microsoft.Win32.OpenFileDialog openImageDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Файл изображения (.jpg)|*.jpg"
            };
            bool? result = openImageDialog.ShowDialog();
            if (result == true)
            {
                string filename = openImageDialog.FileName;
                mainImage_I.Visibility = Visibility.Visible;
                Nashville_I.Visibility = Visibility.Visible;
                BlackAndWhite_I.Visibility = Visibility.Visible;

                OriginalImage = new Bitmap(filename);
                Bitmap previewImage = OriginalImage.Resize(110);

                previewImage= previewImage.GetMask(Masks.BlackAndWhite);

                BlackAndWhite_I.Source = previewImage.GetSource();

                mainImage_I.Source = OriginalImage.GetSource();                        
            }
        }
    
        private void BlackAndWhite_I_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CurrentMask = OriginalImage.GetMask(Masks.BlackAndWhite);
            mainImage_I.Source = Combine.ApplyFilter(CurrentMask, OriginalImage, 0.5).GetSource();
            BlackAndWhite_I.Source = OriginalImage.GetSource();
        }
         private void Nashville_I_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           // currentMask = Mask.Nashville(processedImage);
            //mainImage_I.Source = Combine.ApplyFilter(currentMask, processedImage, 0.5);
        }
    

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           //mainImage_I.Source = Combine.ApplyFilter(currentMask, processedImage, slider.Value);
        }
    }
    
}
