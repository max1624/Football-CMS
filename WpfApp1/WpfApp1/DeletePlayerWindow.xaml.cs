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
    /// Логика взаимодействия для DeletePlayerWindow.xaml
    /// </summary>
    public partial class DeletePlayerWindow : Window
    {
        public PlayerContext db = new PlayerContext();
        public CheckBox[] checkBoxes;
        public List<Player> list = new List<Player>();
        
        public DeletePlayerWindow()
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
                PlayerPanel.Children.Add(checkBoxes[i]);
        }

        private CheckBox[] Createboxes(int quantity, List<Player> list)
        {
            CheckBox[] checkBoxes = new CheckBox[quantity];
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                checkBoxes[i] = new CheckBox();
                checkBoxes[i].Width = 70d;
                checkBoxes[i].Margin = new Thickness(1d);
                checkBoxes[i].Content = list[i].GetFirstName().ToString();
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
                    for(int j = 0; j <list.Count; j++)
                    {

                        if (list[j].GetFirstName().Equals(i.Content.ToString()))
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
            DeletePlayerWindow deletePlayerWindow = new DeletePlayerWindow();
            deletePlayerWindow.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }
    }
}
