using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CourseWork;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для EditGameWindow.xaml
    /// </summary>
    public partial class EditGameWindow : Window
    {
        public List<Game> game_list = new List<Game>();
        public GameContext db_game = new GameContext();
        public PlayerContext db_players = new PlayerContext();
        public List<Player> players_list = new List<Player>();
        List<Player> game_players;
        public string gamedate;
        public int gameindex = -1;
        public CheckBox[] checkBoxes;
        public bool daybool, monthbool, yearbool;


        public EditGameWindow()
        {
            InitializeComponent();
            game_list = db_game.Deserialize();
        }



        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            if (Day.Text != "" && Month.Text != "" && Year.Text != "" && Place.Text != "" && CountOfVisitors.Text != "")
            {
                Int32.TryParse(Month.Text, out int month);
                Int32.TryParse(Day.Text, out int day);
                Int32.TryParse(Year.Text, out int year);
                string date = SearchDay.Text + "." + SearchMonth.Text + "." + SearchYear.Text;

                if (date == gamedate)
                {
                    game_list.ElementAt(gameindex).SetGameDate(day, month, year);
                    game_list.ElementAt(gameindex).SetDay(day);
                    game_list.ElementAt(gameindex).SetMonth(month);
                    game_list.ElementAt(gameindex).SetYear(year);
                    game_list.ElementAt(gameindex).SetCountOfVisitors(CountOfVisitors.Text);
                    game_list.ElementAt(gameindex).SetPlace(Place.Text);
                    players_list = db_players.Deserialize();
                    game_players = new List<Player>();
                    foreach (var box in checkBoxes)
                    {
                        if (box.IsChecked == true)
                        {
                            foreach (var player in players_list)
                            {
                                if (box.Content.ToString() == player.GetFirstName())
                                {
                                    game_players.Add(player);
                                    flag = true;
                                    game_list.ElementAt(gameindex).SetPlayers(game_players);
                                }
                            }
                        }
                    }
                    if ((day > DateTime.Now.Day && month > DateTime.Now.Month && year > DateTime.Now.Year) ||
                        (day >= DateTime.Now.Day && month >= DateTime.Now.Month && year > DateTime.Now.Year) ||
                        (day >= DateTime.Now.Day && month > DateTime.Now.Month && year >= DateTime.Now.Year) ||
                        (day > DateTime.Now.Day && month >= DateTime.Now.Month && year >= DateTime.Now.Year) ||
                        (day > DateTime.Now.Day && month > DateTime.Now.Month && year >= DateTime.Now.Year) ||
                        (day > DateTime.Now.Day && month >= DateTime.Now.Month && year > DateTime.Now.Year) ||
                        (day >= DateTime.Now.Day && month > DateTime.Now.Month && year > DateTime.Now.Year))
                    {
                        game_list.ElementAt(gameindex).SetResult(0);
                        Win.IsEnabled = false;
                        Lose.IsEnabled = false;

                    }
                    if (Win.IsEnabled == true && Lose.IsEnabled == true && Win.IsChecked == true)
                    {
                        game_list.ElementAt(gameindex).SetResult(1);
                    }
                    if (Win.IsEnabled == true && Lose.IsEnabled == true && Lose.IsChecked == true)
                    {
                        game_list.ElementAt(gameindex).SetResult(-1);
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Заповніть все поля!");
            }
            if (flag == true)
            {
                db_game.Serialize(game_list);
                MessageBox.Show("Збережено!");
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (SearchDay.Text != "" && SearchMonth.Text != "" && SearchYear.Text != "")
            {
                bool finded = false;
                Int32.TryParse(SearchMonth.Text, out int month);
                Int32.TryParse(SearchDay.Text, out int day);
                Int32.TryParse(SearchYear.Text, out int year);
                gamedate = SearchDay.Text + "." + SearchMonth.Text + "." + SearchYear.Text;
                foreach (var game in game_list)
                {
                    if (game.GetGameDate() == gamedate)
                    {
                        gameindex = game_list.IndexOf(game);
                        Day.Text = game.GetDay().ToString();
                        Month.Text = game.GetMonth().ToString();
                        Year.Text = game.GetYear().ToString();
                        Place.Text = game.GetPlace();
                        CountOfVisitors.Text = game.GetCoutOfVisitors();
                        List<Player> all_players_list = db_players.Deserialize();
                        game_players = game.GetPlayers();
                        int quantity = all_players_list.Count;
                        checkBoxes = Createboxes(quantity, all_players_list, game_players);
                        AddToWrapPanel(checkBoxes);
                        finded = true;
                        if (game.GetResult() == 1)
                        {
                            MessageBox.Show(game.GetResult().ToString());
                            Win.IsChecked = true;
                            Win.IsEnabled = true;
                            Lose.IsEnabled = true;
                        }
                        if (game.GetResult() == -1)
                        {
                            MessageBox.Show(game.GetResult().ToString());
                            Lose.IsChecked = true;
                            Win.IsEnabled = true;
                            Lose.IsEnabled = true;
                        }
                    }
                }
                if (finded == false)
                {
                    MessageBox.Show("Не знайдено!");
                }
            }
            else
            {
                MessageBox.Show("Заповніть все поля!");
            }
        }
        private CheckBox[] Createboxes(int quantity, List<Player> all_players_list, List<Player> game_players)
        {
            CheckBox[] checkBoxes = new CheckBox[quantity];
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                checkBoxes[i] = new CheckBox();
                checkBoxes[i].Width = 90d;
                checkBoxes[i].Margin = new Thickness(1d);
                checkBoxes[i].Content = all_players_list[i].GetFirstName().ToString();
                foreach(var players in game_players)
                {
                    if (players.GetFirstName() == all_players_list[i].GetFirstName()
                        && players.GetSecondName() == all_players_list[i].GetSecondName())
                    {
                        checkBoxes[i].IsChecked = true;
                    }
                }
            }
            return checkBoxes;
        }
        private void AddToWrapPanel(CheckBox[] checkBoxes)
        {
            for (int i = 0; i < checkBoxes.Length; i++)
                PlayerPanel.Children.Add(checkBoxes[i]);
        }

        private void Day_TextChanged(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(Month.Text, out int month);
            Int32.TryParse(Day.Text, out int day);
            Int32.TryParse(Year.Text, out int year);
            if (DateTime.Now.Month >= month)
            {
                monthbool = true;
            }
            else
            {
                Win.IsEnabled = false;
                Lose.IsEnabled = false;
            }
            if (DateTime.Now.Year >= year)
            {
                yearbool = true;
            }
            else
            {
                Win.IsEnabled = false;
                Lose.IsEnabled = false;
            }
            if (DateTime.Now.Day > day)
            {
                daybool = true;
                if (daybool == true && monthbool == true && yearbool == true)
                {
                    Win.IsEnabled = true;
                    Lose.IsEnabled = true;

                }
                else
                {
                    Win.IsEnabled = true;
                    Lose.IsEnabled = true;
                }
            }
            else
            {
                Win.IsEnabled = true;
                Lose.IsEnabled = true;
            }

        }



        private void Month_TextChanged(object sender, TextChangedEventArgs e)
        {

            Int32.TryParse(Month.Text, out int month);
            Int32.TryParse(Day.Text, out int day);
            Int32.TryParse(Year.Text, out int year);
            if (DateTime.Now.Year >= year)
            {
                yearbool = true;
            }
            else
            {
                Win.IsEnabled = false;
                Lose.IsEnabled = false;
            }
            if (DateTime.Now.Day >= day)
            {
                daybool = true;
            }
            else
            {
                Win.IsEnabled = false;
                Lose.IsEnabled = false;
            }
            if (DateTime.Now.Month > month)
            {
                monthbool = true;
                if (daybool == true && monthbool == true && yearbool == true)
                {
                    Win.IsEnabled = true;
                    Lose.IsEnabled = true;

                }
                else
                {
                    Win.IsEnabled = false;
                    Lose.IsEnabled = false;
                }
            }
            else
            {
                Win.IsEnabled = true;
                Lose.IsEnabled = true;
            }
        }

        private void Year_TextChanged(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(Month.Text, out int month);
            Int32.TryParse(Day.Text, out int day);
            Int32.TryParse(Year.Text, out int year);
            if (DateTime.Now.Day >= day)
            {
                daybool = true;
            }
            else
            {
                Win.IsEnabled = false;
                Lose.IsEnabled = false;
            }
            if (DateTime.Now.Month > month)
            {
                monthbool = true;
            }
            else
            {
                Win.IsEnabled = false;
                Lose.IsEnabled = false;
            }
            if (DateTime.Now.Year > year)
            {
                yearbool = true;
                if (daybool == true && monthbool == true && yearbool == true)
                {
                    Win.IsEnabled = true;
                    Lose.IsEnabled = true;

                }
                else
                {
                    Win.IsEnabled = false;
                    Lose.IsEnabled = false;
                }
            }
            else
            {
                Win.IsEnabled = false;
                Lose.IsEnabled = false;
            }
        }
    }
}
