using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    public class Settings : INotifyPropertyChanged
    {
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }
        private WeatherMode _mode = WeatherMode.Rain;
        private int _strength = 0;
        private int _weigth = 0;
        private int _wind = 0;
        public WeatherMode Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;
                NotifyPropertyChanged(nameof(Mode));
            }
        }
        public int Strength
        {
            get { return _strength; }
            set
            {
                _strength = value;
                NotifyPropertyChanged(nameof(Strength));
            }
        }
        public int Weight
        {
            get { return _weigth; }
            set
            {
                _weigth = value;
                NotifyPropertyChanged(nameof(Weight));
            }
        }
        public int Wind
        {
            get { return _wind; }
            set
            {
                _wind = value;
                NotifyPropertyChanged(nameof(Wind));
            }
        }
        public bool IsRunning { get; set; } = true;
        public Settings(WeatherMode mode = WeatherMode.Rain, int wind = 1, int strength = 50, int weight = 50, int screenHeight = 1200, int screenWidth = 1920)
        {
            Mode = mode;
            Strength = strength;
            Weight = weight;
            Wind = wind;
            ScreenHeight = screenHeight;
            ScreenWidth = screenWidth;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public enum WeatherMode
    {
        Rain,
        Snow,
        Hail
    }
}
