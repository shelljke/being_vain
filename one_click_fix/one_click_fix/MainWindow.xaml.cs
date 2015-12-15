using System.Windows;
using System.Drawing;

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

                BlackAndWhite_I.Source = previewImage.GetMask(Masks.BlackAndWhite).GetSource();
                Nashville_I.Source = previewImage.GetMask(Masks.Nashville).GetSource();

                mainImage_I.Source = OriginalImage.GetSource();                        
            }
        }
    
        private void BlackAndWhite_I_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CurrentMask = OriginalImage.GetMask(Masks.BlackAndWhite);
            slider.Value = 0.5;
            //mainImage_I.Source = Combine.ApplyFilter(CurrentMask, OriginalImage, 0).GetSource();
            image.Source = CurrentMask.GetSource();

        }
         private void Nashville_I_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CurrentMask = OriginalImage.GetMask(Masks.Nashville);
            slider.Value = 0.5;
            // mainImage_I.Source = Combine.ApplyFilter(CurrentMask, OriginalImage, 0).GetSource();
             image.Source = CurrentMask.GetSource();
        }
    

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            image.Opacity = slider.Value;
        }
    }
    
}
