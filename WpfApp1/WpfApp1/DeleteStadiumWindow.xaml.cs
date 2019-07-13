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
    /// Логика взаимодействия для DeleteStadiumWindow.xaml
    /// </summary>
    public partial class DeleteStadiumWindow : Window
    {
        public StadiumContext db = new StadiumContext();
        public CheckBox[] checkBoxes;
        public List<Stadium> list = new List<Stadium>();

        public DeleteStadiumWindow()
        {
            InitializeComponent();
            TextBlock name = new TextBlock();
            list = db.Deserialize();
            int quantity = list.Count;
            checkBoxes = Createboxes(quantity, list);
            AddToWrapPanel(checkBoxes);
        }

        private void AddToWrapPanel(CheckBox[] checkBoxes)
        {
            for (int i = 0; i < checkBoxes.Length; i++)
                StadiumPanel.Children.Add(checkBoxes[i]);
        }

        private CheckBox[] Createboxes(int quantity, List<Stadium> list)
        {
            CheckBox[] checkBoxes = new CheckBox[quantity];
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                checkBoxes[i] = new CheckBox();
                checkBoxes[i].Width = 70d;
                checkBoxes[i].Margin = new Thickness(1d);
                checkBoxes[i].Content = list[i].GetName().ToString();
            }
            return checkBoxes;
        }

        private void Delete()
        {
            list = db.Deserialize();
            bool flag = false;
            foreach (var i in checkBoxes)
            {
                if (i.IsChecked == true)
                {
                    for (int j = 0; j < list.Count; j++)
                    {

                        if (list[j].GetName().Equals(i.Content.ToString()))
                        {
                            flag = true;
                            list.Remove(list[j]);
                        }
                    }
                }
            }
            db.Serialize(list);
            if (flag == true)
            {
                MessageBox.Show("Видалено!");
            }
            this.Close();
            DeleteStadiumWindow deleteStadiumWindow = new DeleteStadiumWindow();
            deleteStadiumWindow.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }
    }
}
