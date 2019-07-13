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
    /// Логика взаимодействия для AddPlayerWindow.xaml
    /// </summary>
    public partial class AddPlayerWindow : Window
    {
        public AddPlayerWindow()
        {
            InitializeComponent();
        }
        
        
        private void Add(object sender, RoutedEventArgs e)
        {
            
            if (FirstName.Text != "" && BirthDate.Text != "" && SecondName.Text != "" && PlayerStatus.Text != "" && Salary.Text != "" && HealthStatus.Text != "")
            {

                if (Int32.TryParse(Salary.Text, out int salary))
                {
                    Player NewPlayer = new Player(FirstName.Text, SecondName.Text, BirthDate.Text, PlayerStatus.Text, HealthStatus.Text, Salary.Text);
                    PlayerContext db = new PlayerContext();
                    List<Player> PlayerList = db.Deserialize();
                    PlayerList.Add(NewPlayer);
                    db.Serialize(PlayerList);
                    MessageBox.Show("Об'єкт створений");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Вказане некоректне значення зарплатні!");
                }
            }
            else
            {
                MessageBox.Show("Заповніть усі поля!");
            }
            
        }
    }
}
