using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using Common;

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
            const string filtersFoldername = "Filters";
            var directoryInfo = new DirectoryInfo(filtersFoldername); //получаем ссылку на папку
            var filters = new List<IFilter>();
            foreach (var filePath in directoryInfo.GetFiles().Select(f => f.FullName).Where(p => p.EndsWith(".dll"))) //получаем все файлы из папки, и получаем путь к файлам, выбираем только пути с окончанием .dll
            {                                                                                               //т.е. форич будет по списку из путей к каждому файлу в папке фильтерс
                try
                {
                    var fileClass = Assembly.LoadFile(filePath); //загружаем код из файла
                    var loadFilters = fileClass.GetTypes()
                        .Where(t => t.IsClass && typeof(IFilter).IsAssignableFrom(t))
                        .Select(t => (IFilter)Activator.CreateInstance(t))
                        .ToList();
                    filters.AddRange(loadFilters);
                }
                catch { }//ошибка открытия файла, либо файл поврежден, либо к нему нету доступа
            }
            var filtersInThisProject = Assembly.GetCallingAssembly().GetTypes()
                .Where(t => t.IsClass && typeof(IFilter).IsAssignableFrom(t))
                .Select(t => (IFilter)Activator.CreateInstance(t))
                .ToList();
            filters.AddRange(filtersInThisProject);
            foreach (var filter in filters)
            {
                FilterCollection.Add(new FilterItem
                {
                    Filter = filter,
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
