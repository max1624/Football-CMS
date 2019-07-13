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
    /// Логика взаимодействия для EditStadiumWindow.xaml
    /// </summary>
    public partial class EditStadiumWindow : Window
    {
        public EditStadiumWindow()
        {
            InitializeComponent();
        }
        public StadiumContext db = new StadiumContext();
        public List<Stadium> list = new List<Stadium>();
        public int stadiumindex = -1;
        public string stadiumname;
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "" && CountOfPlaces.Text != "" && Price.Text != "" )
            {
                if (stadiumname == StadiumSearch.Text)
                {
                    list.ElementAt(stadiumindex).SetName(Name.Text);
                    list.ElementAt(stadiumindex).SetCountOfPlaces(CountOfPlaces.Text);
                    list.ElementAt(stadiumindex).SetPrice(Price.Text);
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
            if (StadiumSearch.Text != "")
            {
                bool flag = false;
                list = db.Deserialize();

                foreach (var i in list)
                {
                    if (i.GetName() == StadiumSearch.Text)
                    {
                        stadiumname = i.GetName();
                        flag = true;
                        stadiumindex = list.IndexOf(i);
                        Name.Text = i.GetName();
                        CountOfPlaces.Text = i.GetCountOfPlaces();
                        Price.Text = i.GetPrice();
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
                MessageBox.Show("Please, enter stadium`s title");
            }
        }
    }
}
