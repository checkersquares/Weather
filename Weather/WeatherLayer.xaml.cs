using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace Weather
{
    /// <summary>
    /// Interaktionslogik für WeatherLayer.xaml
    /// </summary>
    public partial class WeatherLayer : Window
    {
        private static readonly Random rnd = new Random();
        private int ScreenOffset { get { return (Config.Wind -1) * 10; } }
        private DispatcherTimer timer;
        public Settings Config { get; set; }
        public List<WeatherItem> Drops { get; set; } = new List<WeatherItem>();
        public WeatherLayer(Settings config)
        {
            InitializeComponent();
            Config = config;
            timer = new DispatcherTimer();
            timer.Interval = new System.TimeSpan(0,0,0,0,20);
            timer.Tick += timer_Tick;
        }
        private void BuildDrops()
        {
            Random r = new Random();
            for (int i = 0; i < Config.Strenght * 5; i++)
            {
                Drops.Add(new WeatherItem(Config, r.Next(Config.ScreenWidth), r.Next(Config.ScreenHeight)));
            }
        }
        public void Start()
        {
            grd_weather.Margin = new Thickness(-ScreenOffset,-Config.Weight,0,0);
            BuildDrops();
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
            grd_weather.Children.Clear();
            Drops.Clear();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            foreach (WeatherItem item in Drops)
            {
                if (!grd_weather.Children.Contains(item.Model))
                {
                    grd_weather.Children.Add(item.Model);
                }
                if (item.Y < Config.ScreenHeight)
                {
                    item.Fall();
                }
                else
                {
                    item.Reset(rnd.Next(Config.ScreenWidth + ScreenOffset), rnd.Next(Convert.ToInt32(Math.Round(item.YSpeed))));
                }
            }
        }
    }
}
