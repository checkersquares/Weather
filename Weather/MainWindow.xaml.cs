using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Weather
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Settings Config { get; set; }
        private WeatherLayer layer;
        public MainWindow()
        {
            InitializeComponent();
            cb_Type.ItemsSource = Enum.GetValues(typeof(WeatherMode));
            DataContext = this;

            Config = new Settings();
            layer = new WeatherLayer(Config);
            layer.Show();
        }

        private void btn_Start_Click(object sender, RoutedEventArgs e)
        {
            layer.Start();
        }

        private void btn_Stop_Click(object sender, RoutedEventArgs e)
        {
            layer.Stop();
        }
    }
}
