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
    /// Логика взаимодействия для AddStadiumWindow.xaml
    /// </summary>
    public partial class AddStadiumWindow : Window
    {
        public StadiumContext db = new StadiumContext();
        public AddStadiumWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "" && CountOfPlaces.Text != "" && Price.Text != "")
            {
                List<Stadium> list = new List<Stadium>();
                list = db.Deserialize();
                Stadium stadium = new Stadium(Name.Text, CountOfPlaces.Text, Price.Text);
                list.Add(stadium);
                db.Serialize(list);
                MessageBox.Show("Об'єкт створений");

            }
        }
    }
}
