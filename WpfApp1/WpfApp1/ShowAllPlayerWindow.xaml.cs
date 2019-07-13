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
using CourseWork;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ShowAllPlayerWindow.xaml
    /// </summary>
    public partial class ShowAllPlayerWindow : Window
    {
        public ShowAllPlayerWindow()
        {
            InitializeComponent();
            ShowAllPlayers();
        }
        public void ShowAllPlayers()
        {
            PlayerContext db = new PlayerContext();
            var list = db.Deserialize();
            PlayerShowList.Content = list.Count.ToString() + " elements" + "\n";
            foreach(var i in list)
            {
                PlayerShowList.Content += "#" + Convert.ToString(list.IndexOf(i)) + "\n" + i.Show_player_info();
            }
        }
    }
}
