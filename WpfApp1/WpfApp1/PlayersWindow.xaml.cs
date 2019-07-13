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
using System.Data.Entity;
using CourseWork;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void AddPlayer(object sender, RoutedEventArgs e)
        {
            AddPlayerWindow addPlayerWindow = new AddPlayerWindow
            {
                Owner = this
            };
            addPlayerWindow.Show();
        }

        private void DeletePlayer(object sender, RoutedEventArgs e)
        {
            DeletePlayerWindow deletePlayerWindow = new DeletePlayerWindow
            {
                Owner = this
            };
            deletePlayerWindow.Show();
        }

        private void EditPlayer(object sender, RoutedEventArgs e)
        {
            EditPlayerWindow editPlayerWindow = new EditPlayerWindow
            {
                Owner = this
            };
            editPlayerWindow.Show();
        }

        private void ShowAllPlayers(object sender, RoutedEventArgs e)
        {
            ShowAllPlayerWindow showAllPlayersWindow = new ShowAllPlayerWindow
            {
                Owner = this
            };
            showAllPlayersWindow.Show();
        }
    }
}
