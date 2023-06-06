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
    /// Логика взаимодействия для ResultKidWindow.xaml
    /// </summary>
    public partial class ResultKidWindow : Window
    {
        public ResultKidWindow()
        {
            InitializeComponent();
            DgList.ItemsSource = DBEntities.GetContext().Attempts
                .Where(u => u.IdUser == ClassGlobal.UserId).ToList();
            //DgList.ItemsSource = DBEntities.GetContext().Attempts
            //   .ToList().OrderBy(x => x.IdAttempts);
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

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuKidWindow menuKidWindow = new MenuKidWindow();
            menuKidWindow.Show();
            this.Close();
        }

        private void Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClassMB.MBExit();
        }

        private void RollUpBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
