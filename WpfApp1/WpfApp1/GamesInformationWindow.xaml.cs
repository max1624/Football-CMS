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
    /// Логика взаимодействия для GamesInformationWindow.xaml
    /// </summary>
    public partial class GamesInformationWindow : Window
    {
        public GameContext db_game = new GameContext();
        public RadioButton[] buttons;
        public List<Game> game_list = new List<Game>();
        public List<Player> players_list = new List<Player>();
        public GamesInformationWindow()
        {
            InitializeComponent();
            game_list = db_game.Deserialize();
            int quantity = game_list.Count;
            buttons = Createbuttons(quantity, game_list);
            AddToWrapPanel(buttons);
            
        }
        private RadioButton[] Createbuttons(int quantity, List<Game> game_list)
        {
            buttons = new RadioButton[quantity];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new RadioButton();
                buttons[i].Width = 90d;
                buttons[i].Margin = new Thickness(1d);
                buttons[i].Content = game_list[i].GetGameDate().ToString();
            }
            return buttons;
        }
        private void AddToWrapPanel(RadioButton[] buttons)
        {
            for (int i = 0; i < buttons.Length; i++)
                GamesShowList.Children.Add(buttons[i]);
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            foreach(var rButton in buttons)
            {
                if (rButton.IsChecked == true)
                {
                    foreach(var game in game_list)
                    {
                        if (rButton.Content.ToString() == game.GetGameDate())
                        {
                            MessageBox.Show(game.Show_game_info());break;
                        }
                    }
                    
                }
            }
        }

        private void Show_EnableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
