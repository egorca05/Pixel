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

namespace Pixel.Windows.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для GroupsDirectorWindow.xaml
    /// </summary>
    public partial class GroupsDirectorWindow : Window
    {
        public GroupsDirectorWindow()
        {
            InitializeComponent();
            GroupsDG.ItemsSource = DBEntities.GetContext().Groups.ToList().OrderBy(g => g.IdGroups);
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuDirectorWindow menuDirectorWindow = new MenuDirectorWindow();
            menuDirectorWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassMB.MBExit();
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
    }
}
