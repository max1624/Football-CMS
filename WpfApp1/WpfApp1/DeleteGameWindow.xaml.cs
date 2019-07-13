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
    public partial class DeleteGameWindow : Window
    {
        public GameContext db = new GameContext();
        public CheckBox[] checkBoxes;
        public List<Game> list = new List<Game>();

        public DeleteGameWindow()
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
                GamePanel.Children.Add(checkBoxes[i]);
        }

        private CheckBox[] Createboxes(int quantity, List<Game> list)
        {
            CheckBox[] checkBoxes = new CheckBox[quantity];
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                checkBoxes[i] = new CheckBox();
                checkBoxes[i].Width = 90d;
                checkBoxes[i].Margin = new Thickness(1d);
                checkBoxes[i].Content = list[i].GetGameDate().ToString();
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

                        if (list[j].GetGameDate().Equals(i.Content.ToString()))
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
            DeleteGameWindow deleteStadiumWindow = new DeleteGameWindow();
            deleteStadiumWindow.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }
    }
}
