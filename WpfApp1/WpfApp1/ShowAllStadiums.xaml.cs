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
    /// Логика взаимодействия для ShowAllStadiums.xaml
    /// </summary>
    public partial class ShowAllStadiums : Window
    {
        public ShowAllStadiums()
        {
            InitializeComponent();
            ShowAllStadium();
        }
        public void ShowAllStadium()
        {
            StadiumContext db = new StadiumContext();
            var list = db.Deserialize();
            StadiumShowList.Content = list.Count.ToString() + " elements" + "\n";
            foreach (var i in list)
            {
                StadiumShowList.Content += "#" + Convert.ToString(list.IndexOf(i)) + "\n" + i.Show_stadium_info();
            }
        }
    }
}
