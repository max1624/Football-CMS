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
    /// Логика взаимодействия для AddGameWindow.xaml
    /// </summary>
    public partial class AddGameWindow : Window
    {
        public GameContext db_game = new GameContext();
        public PlayerContext db_players = new PlayerContext();
        public CheckBox[] checkBoxes;
        public List<Game> game_list = new List<Game>();
        public List<Player> players_list = new List<Player>();
        public List<Player> playersListToAdd = new List<Player>();

        public AddGameWindow()
        {
            InitializeComponent();
            players_list = db_players.Deserialize();
            game_list = db_game.Deserialize();
            int quantity = players_list.Count;
            checkBoxes = Createboxes(quantity, players_list);
            AddToWrapPanel(checkBoxes);
        }

        private void AddGame_Click(object sender, RoutedEventArgs e)
        {
            
            if (Day.Text != "" && Month.Text != "" && Year.Text != "" && Place.Text != "" && CountOfVisitors.Text != "" )
            {
                bool flag = false;
                foreach (var box in checkBoxes)
                {
                    if (box.IsChecked == true)
                    {
                        foreach (var player in players_list)
                        {
                            if (box.Content.ToString() == player.GetFirstName())
                            {
                                playersListToAdd.Add(player);
                                flag = true;
                            }
                        }
                    }
                }
                if (flag == true)
                {
                    Int32.TryParse(Month.Text, out int month);
                    Int32.TryParse(Day.Text, out int day);
                    Int32.TryParse(Year.Text, out int year);
                    Game game = new Game(playersListToAdd, day, month, year, Place.Text, CountOfVisitors.Text);
                    game_list.Add(game);
                    db_game.Serialize(game_list);
                    MessageBox.Show("Об'єкт створений");
                }
                else
                {
                    MessageBox.Show("Виберіть гравців!");
                }
            }
            else
            {
                MessageBox.Show("Заповніть всі поля!");
            }

        }

        private CheckBox[] Createboxes(int quantity, List<Player> players_list)
        {
            CheckBox[] checkBoxes = new CheckBox[quantity];
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                checkBoxes[i] = new CheckBox();
                checkBoxes[i].Width = 70d;
                checkBoxes[i].Margin = new Thickness(1d);
                checkBoxes[i].Content = players_list[i].GetFirstName().ToString();
            }
            return checkBoxes;
        }
        private void AddToWrapPanel(CheckBox[] checkBoxes)
        {
            for (int i = 0; i < checkBoxes.Length; i++)
                PlayerPanel.Children.Add(checkBoxes[i]);
        }

    }
}
