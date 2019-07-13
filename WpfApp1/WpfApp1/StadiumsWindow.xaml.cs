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
    /// Логика взаимодействия для StadiumsWindow.xaml
    /// </summary>
    public partial class StadiumsWindow : Window
    {
        public StadiumsWindow()
        {
            InitializeComponent();
        }

        private void EditStadium(object sender, RoutedEventArgs e)
        {
            EditStadiumWindow editStadiumWindow = new EditStadiumWindow
            {
                Owner = this
            };
            editStadiumWindow.Show();
        }

        private void ShowAllStadiums(object sender, RoutedEventArgs e)
        {
            ShowAllStadiums showAllStadiums = new ShowAllStadiums()
            {
                Owner = this
            };
            showAllStadiums.Show();
        }

        private void DeleteStadium(object sender, RoutedEventArgs e)
        {
            DeleteStadiumWindow deleteStadiumWindow = new DeleteStadiumWindow()
            {
                Owner = this
            };
            deleteStadiumWindow.Show();
        }

        private void AddStadium(object sender, RoutedEventArgs e)
        {
            AddStadiumWindow addStadiumWindow = new AddStadiumWindow()
            {
                Owner = this
            };
            addStadiumWindow.Show();
        }
    }
}
