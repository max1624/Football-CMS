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
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public PlayerContext db_player = new PlayerContext();
        public List<Player> players_list;
        public GameContext db_game = new GameContext();
        public List<Game> games_list;
        public StadiumContext db_stadium = new StadiumContext();
        public List<Stadium> stadiums_list;
        public SearchWindow()
        {
            InitializeComponent();
            SearchContent.Text = "Пошук...";
            players_list = db_player.Deserialize();
            games_list = db_game.Deserialize();
            stadiums_list = db_stadium.Deserialize();
        }


        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (SearchContent.Text != "")
            {
                foreach(var game in games_list)
                {
                    if (SearchContent.Text == game.GetGameDate())
                    {
                        ShowInfo.Content = game.Show_game_info();
                    }
                }
                foreach (var player in players_list)
                {
                    if (SearchContent.Text == player.GetFirstName() || SearchContent .Text == player.GetSecondName())
                    {
                        ShowInfo.Content = player.Show_player_info();
                    }
                }
                foreach(var stadium in stadiums_list)
                {
                    if (SearchContent.Text == stadium.GetName())
                    {
                        ShowInfo.Content = stadium.Show_stadium_info();
                    }
                }
            }
            else
            {
                MessageBox.Show("Заповніть всі поля!");
            }
        }

        private void TExtChanged(object sender, RoutedEventArgs e)
        {
            SearchContent.Text = "";
        }
    }
}
