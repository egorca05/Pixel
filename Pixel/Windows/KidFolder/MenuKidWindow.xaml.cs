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
    /// Логика взаимодействия для MenuKidWindow.xaml
    /// </summary>
    public partial class MenuKidWindow : Window
    {
        public MenuKidWindow()
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

        private void TestBtn_Click(object sender, RoutedEventArgs e)
        {
            TestMenuKidWindow testMenuKidWindow = new TestMenuKidWindow();
            testMenuKidWindow.Show();
            this.Close();
        }

        private void ResultBtn_Click(object sender, RoutedEventArgs e)
        {
            ResultKidWindow resultKidWindow = new ResultKidWindow();
            resultKidWindow.Show();
            this.Close();
        }

        private void Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClassMB.MBExit();
        }

        private void ExitAppBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
