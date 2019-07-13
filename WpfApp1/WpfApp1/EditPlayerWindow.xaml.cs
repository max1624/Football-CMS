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
    /// Логика взаимодействия для EditPlayerWindow.xaml
    /// </summary>
    public partial class EditPlayerWindow : Window
    {
        public EditPlayerWindow()
        {
            InitializeComponent();
        }
        public PlayerContext db = new PlayerContext();
        public List<Player> list = new List<Player>();
        public int playerindex = -1;
        public string playername;
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (FirstName.Text != "" && SecondName.Text != "" && BirthDate.Text != "" && PlayerStatus.Text != "" && HealthStatus.Text != "" && Salary.Text != "")
            {
                if (playername == PlayerSearch.Text)
                {
                    list.ElementAt(playerindex).SetFirstName(FirstName.Text);
                    list.ElementAt(playerindex).SetSecondName(SecondName.Text);
                    list.ElementAt(playerindex).SetBirthDate(BirthDate.Text);
                    list.ElementAt(playerindex).SetPlayerStatus(PlayerStatus.Text);
                    list.ElementAt(playerindex).SetHealthStatus(HealthStatus.Text);
                    list.ElementAt(playerindex).SetSalary(Salary.Text);
                    db.Serialize(list);
                    MessageBox.Show("Збережено!");
                }
            }
            else
            {
                MessageBox.Show("Зпаповніть всі поля!");
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerSearch.Text != "")
            {
                bool flag = false;
                list = db.Deserialize();
                
                foreach(var i in list)
                {
                    if (i.GetFirstName() == PlayerSearch.Text)
                    {
                        playername = i.GetFirstName();
                        flag = true;
                        playerindex = list.IndexOf(i);
                        FirstName.Text = i.GetFirstName();
                        SecondName.Text = i.GetSecondName();
                        BirthDate.Text = i.GetBirthDate();
                        PlayerStatus.Text = i.GetPlayerStatus();
                        HealthStatus.Text = i.GetHealthStatus();
                        Salary.Text = i.GetSalary();
                        break;
                    }
                }
                if (flag == false)
                {
                    MessageBox.Show("There are no matches!");
                }
            }
            else
            {
                MessageBox.Show("Please, enter player`s name");
            }
        }
    }
}
