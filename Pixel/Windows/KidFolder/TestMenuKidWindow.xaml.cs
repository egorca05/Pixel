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
using Pixel.ClassFolder;
using Pixel.Windows.KidFolder;

namespace Pixel.Windows.KidFolder
{
    /// <summary>
    /// Логика взаимодействия для TestMenuKidWindow.xaml
    /// </summary>
    public partial class TestMenuKidWindow : Window
    {
        public TestMenuKidWindow()
        {
            InitializeComponent();
        }

        private void ExitProfile_Click(object sender, RoutedEventArgs e)
        {
            bool resultMB = ClassMB.QuestionMessage("Вы действительно хотите выйти из аккаунта?");
            if (resultMB == true)
            {
                AutorizationWindow autorizationWindow = new AutorizationWindow();
                autorizationWindow.Show();
                this.Close();
            }
        }

        private void Test1Btn_Click(object sender, RoutedEventArgs e)
        {
            Test1KidWindow test1KidWindow = new Test1KidWindow();
            test1KidWindow.Show();
            this.Close();
        }

        private void Test2Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Test3Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClassMB.MBExit();
        }
    }
}
