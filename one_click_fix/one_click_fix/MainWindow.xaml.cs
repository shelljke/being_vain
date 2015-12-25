using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace one_click_fix
{
    public partial class MainWindow : Window
    {

        public Bitmap OriginalImage;
        public Bitmap CurrentMask;
        public ObservableCollection<FilterItem> FilterCollection = new ObservableCollection<FilterItem>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_B_Click(object sender, RoutedEventArgs e)
        {

            StartB.Visibility = Visibility.Hidden;

            Microsoft.Win32.OpenFileDialog openImageDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Файл изображения (.jpg)|*.jpg"
            };
            bool? result = openImageDialog.ShowDialog();
            if (result == true)
            {
                string filename = openImageDialog.FileName;
                MainImageI.Visibility = Visibility.Visible;

                FilterList.Visibility = Visibility.Visible;

                OriginalImage = new Bitmap(filename);

                Bitmap previewImage = OriginalImage.Resize(110);
                InitializationPreview(previewImage);

                MainImageI.Source = OriginalImage.GetSource();
            }
        }

        void InitializationPreview(Bitmap image)
        {
            foreach (Masks mask in Enum.GetValues(typeof(Masks)))
            {
                FilterCollection.Add(new FilterItem
                {MaskName = mask,
                    PreviewImage = image.GetMask(mask).GetSource(),
                    SliderVisibility = Visibility.Collapsed
                });
            }
            FilterList.ItemsSource = FilterCollection;
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = (sender as Slider);
            if (slider == null) return;
            Image.Opacity = slider.Value;
        }

        private void FilterList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filterItem = FilterList.SelectedItem as FilterItem;
            filterItem.SliderValue = 0.5;
            Image.Source = OriginalImage.GetMask(filterItem.MaskName).GetSource();
            foreach (var item in FilterCollection)
            {
                item.SliderVisibility = Visibility.Collapsed;
            }
            filterItem.SliderVisibility = Visibility.Visible;
        }
    }

}
