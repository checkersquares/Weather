using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;

namespace Weather
{
    public class WeatherItem
    {
        public WeatherMode Mode { get; set; }
        public Rectangle Model { get; set; } = new Rectangle();
        public double X { get; set; }
        public double Y { get; set; }
        public double XSpeed { get; set; }
        public double YSpeed { get; set; }
        public double Angle { get; set; }
        public Settings Config { get; set; }
        public WeatherItem()
        {

        }
        public WeatherItem(Settings config, int x = 0, int y = 0)
        {
            Model.VerticalAlignment = VerticalAlignment.Top;
            Model.HorizontalAlignment = HorizontalAlignment.Left;
            Config = config;
            generateModel();
            Reset(x, y);
            Show();
        }
        private void generateModel()
        {
            switch (Config.Mode)
            {
                case WeatherMode.Rain:
                    Model.Width = 2;
                    Model.Height = 20;
                    Model.Stroke = new SolidColorBrush(Colors.AliceBlue);
                    YSpeed = Config.Weight;
                    XSpeed = Config.Wind * 0.4;
                    break;
                case WeatherMode.Snow:
                    Model.Width = 4;
                    Model.Height = 4;
                    Model.Stroke = new SolidColorBrush(Colors.Snow);
                    YSpeed = Config.Weight * 0.5;
                    XSpeed = Config.Wind * 0.6;
                    break;
                case WeatherMode.Hail:
                    Model.Width = 6;
                    Model.Height = 6;
                    Model.Stroke = new SolidColorBrush(Colors.LightBlue);
                    YSpeed = Config.Weight * 1.2;
                    XSpeed = Config.Wind * 0.3;
                    break;
                default:
                    break;
            }
        }
        public void Reset(int x = -1, int y = -1)
        {
            int ry = new Random().Next(Convert.ToInt32(Math.Round(YSpeed)));
            int rx = new Random().Next(Config.ScreenWidth);
            Y = y < 0 ? ry : y;
            X = x < 0 ? rx : x;
            
            Angle = (Math.Atan2(YSpeed, XSpeed) * 180 / Math.PI) - 90;
            RotateTransform rt = new RotateTransform(Angle);
            Model.RenderTransform = rt;
        }
        public void Fall()
        {
            X += XSpeed;
            Y += YSpeed;
            Show();
        }
        public void Show()
        {
            Model.Margin = new Thickness(X, Y, 0, 0);
        }
    }
}
