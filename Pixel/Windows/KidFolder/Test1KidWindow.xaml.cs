using Pixel.ClassFolder;
using Pixel.FolderData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pixel.Windows.KidFolder
{
    /// <summary>
    /// Логика взаимодействия для Test1KidWindow.xaml
    /// </summary>
    public partial class Test1KidWindow : Window
    {
        public Test1KidWindow()
        {
            InitializeComponent();
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            int TrueAnsver = 0;
            if (AnsOne.IsChecked == true) 
            {
                TrueAnsver ++;
            }
            if (AnsTwo.IsChecked == true)
            {
                TrueAnsver++;
            }
            if (AnsThree.IsChecked == true)
            {
                TrueAnsver++;
            }
            if (AnsFour.IsChecked == true)
            {
                TrueAnsver++;
            }
            if (AnsFive.IsChecked == true)
            {
                TrueAnsver++;
            }
            if (AnsSix.IsChecked == true)
            {
                TrueAnsver++;
            }
            if (AnsSeven.IsChecked == true)
            {
                TrueAnsver++;
            }
            if (AnsEight.IsChecked == true)
            {
                TrueAnsver++;
            }
            if (AnsNine.IsChecked == true)
            {
                TrueAnsver++;
            }
            if (AnsTen.IsChecked == true)
            {
                TrueAnsver++;
            }            
            DBEntities.GetContext().Attempts.Add(new Attempts()
            {
                IdUser = ClassGlobal.UserId,
                IdTest = 1,
                Scores = TrueAnsver,
                Date = DateTime.Today,
            });
            DBEntities.GetContext().SaveChanges();
            ClassMB.MBinformation($"Правильных ответов: {TrueAnsver}");
            MenuKidWindow menuKidWindow = new MenuKidWindow();
            menuKidWindow.Show();
            this.Close(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassMB.MBExit();
        }

        private void RollUpBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            TestMenuKidWindow testMenuKidWindow = new TestMenuKidWindow();
            testMenuKidWindow.Show();
            this.Close();
        }
    }
}
