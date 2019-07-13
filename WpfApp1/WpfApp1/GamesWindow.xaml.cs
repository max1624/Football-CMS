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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для GamesWindow.xaml
    /// </summary>
    public partial class GamesWindow : Window
    {
        public GamesWindow()
        {
            InitializeComponent();
        }

        private void AddGameWindow_Click(object sender, RoutedEventArgs e)
        {
            AddGameWindow addGameWindow = new AddGameWindow()
            {
                Owner = this
            };
            addGameWindow.Show();
        }

        private void GamesInformation_Click(object sender, RoutedEventArgs e)
        {
            GamesInformationWindow gamesInformationWindow = new GamesInformationWindow()
            {
                Owner = this
            };
            gamesInformationWindow.Show();
        }

        private void EditGame_Click(object sender, RoutedEventArgs e)
        {
            EditGameWindow editGameWindow = new EditGameWindow()
            {
                Owner = this
            };
            editGameWindow.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteGameWindow deleteGameWindow = new DeleteGameWindow()
            {
                Owner = this
            };
            deleteGameWindow.Show();
        }

        private void Sorting(object sender, RoutedEventArgs e)
        {

        }
    }
}
