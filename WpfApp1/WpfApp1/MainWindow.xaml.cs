using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CourseWork;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static PlayerContext db = new PlayerContext();

        private void PlayerButton(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1
            {
                Owner = this
            };
            window1.Show();
        }

        private void GamesButton(object sender, RoutedEventArgs e)
        {
            GamesWindow gamesWindow = new GamesWindow()
            {
                Owner = this
            };
            gamesWindow.Show();

        }

        private void StadiumButton(object sender, RoutedEventArgs e)
        {
            StadiumsWindow stadiumsWindow = new StadiumsWindow()
            {
                Owner = this
            };
            stadiumsWindow.Show();
        }

        private void SearchButton(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow()
            {
                Owner = this
            };
            searchWindow.Show();
        }


    }
}
