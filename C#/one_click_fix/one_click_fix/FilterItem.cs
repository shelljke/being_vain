using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using one_click_fix.Annotations;
using Common;

namespace one_click_fix
{
    public class FilterItem : INotifyPropertyChanged
    {
        public ImageSource PreviewImage
        {
            get { return previewImage; }
            set
            {
                if (previewImage != value)
                {
                    previewImage = value;
                    OnPropertyChanged();
                }
            }
        }
        private ImageSource previewImage;

        public Visibility SliderVisibility
        {
            get { return sliderVisibility; }
            set
            {
                if (sliderVisibility != value)
                {
                    sliderVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility sliderVisibility;

        public double SliderValue
        {
            get { return sliderValue; }
            set
            {
                if (sliderValue != value)
                {
                    sliderValue = value;
                    OnPropertyChanged();
                }
            }
        }

        private double sliderValue; 
        public IFilter Filter { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged!=null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}