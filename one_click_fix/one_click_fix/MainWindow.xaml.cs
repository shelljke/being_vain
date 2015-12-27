using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using Microsoft.Win32;

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

        private void Start_B_Click(object sender, RoutedEventArgs e)
        {
            
            Microsoft.Win32.OpenFileDialog openImageDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Файл изображения (.jpg)|*.jpg"
            };
            bool? result = openImageDialog.ShowDialog();
            if (result == true)
            {
                FilterCollection.Clear();
                string filename = openImageDialog.FileName;

                MainImageI.Visibility = Visibility.Visible;
                FilterList.Visibility = Visibility.Visible;

                SaveB.Visibility = Visibility.Visible;

                OriginalImage = new Bitmap(filename);

                Bitmap previewImage = OriginalImage.Resize(110);
                InitializationPreview(previewImage);

                StartB.Content="Открыть изображение";
                StartB.Margin= new Thickness(0, 10, 10, 0);
                StartB.VerticalAlignment = VerticalAlignment.Top;
                StartB.HorizontalAlignment = HorizontalAlignment.Right;
                MainImageI.Source = OriginalImage.GetSource();
                Image.Source = OriginalImage.GetSource();
            }
        }

        private void SaveB_Click(object sender, RoutedEventArgs e)
        {
            var saveDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "Файл изображения (.jpg)|*.jpg"
            };
            bool? result = saveDialog.ShowDialog();
            if (result == true)
            {
                var fileStream = File.Create(saveDialog.FileName);
                Combine combine = new Combine();

                var filterItem = FilterList.SelectedItem as FilterItem;
                if (filterItem == null) return;
                Bitmap resultImage = combine.ApplyFilter(filterItem.Filter.ApplyFilter(OriginalImage), OriginalImage, filterItem.SliderValue);
                resultImage.Save(fileStream, ImageFormat.Jpeg);
                fileStream.Close();
            }
        }

        void InitializationPreview(Bitmap image)
        {
            var filters =
                Assembly.GetAssembly(typeof (IFilter))  //получаем ссылку на сборку в которой определен тип IFilter, сейчас это ссылка на текущий проект
                    .GetTypes() //получаем все типы
                    .Where(t => t.IsClass && typeof (IFilter).IsAssignableFrom(t)) //фильтруем их, выбираем только те которые являются классом и могут быть приведены к типу IFilter
                    .Select(t => (IFilter) Activator.CreateInstance(t)) //кастим к типу IFilter
                    .ToList(); //преобразуем коллекцию в список типа List<IFilter>
            foreach (var filter in filters)
            {
                FilterCollection.Add(new FilterItem
                {
                    Filter = filter, //сохраняем ссылку на фильтр, чтоб потом можно было его применять при клике
                    PreviewImage = filter.ApplyFilter(image).GetSource(),
                    SliderVisibility = Visibility.Collapsed
                });
            }
            FilterList.ItemsSource = FilterCollection;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = (sender as Slider);
            if (slider == null) return;
            Image.Opacity = slider.Value;
        }

        private void FilterList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filterItem = FilterList.SelectedItem as FilterItem;
            if (filterItem==null) return;
            filterItem.SliderValue = 0.5;
            Image.Source = filterItem.Filter.ApplyFilter(OriginalImage).GetSource();
            SaveB.IsEnabled = true;

            foreach (var item in FilterCollection)
            {
                item.SliderVisibility = Visibility.Collapsed;
            }
            filterItem.SliderVisibility = Visibility.Visible;
        }

      
    }

}
