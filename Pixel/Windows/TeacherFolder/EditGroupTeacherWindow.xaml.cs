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

namespace Pixel.Windows.TeacherFolder
{
    /// <summary>
    /// Логика взаимодействия для EditGroupTeacherWindow.xaml
    /// </summary>
    public partial class EditGroupTeacherWindow : Window
    {
        public EditGroupTeacherWindow(Groups Groups)
        {
            InitializeComponent();
            DataContext = Groups;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            GroupsWindow groupsWindow = new GroupsWindow();
            groupsWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassMB.MBExit();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Groups groups = DBEntities.GetContext().Groups.FirstOrDefault(g => g.IdGroups == ClassGlobal.GroupEdit);
            groups.NameGroups = NameTb.Text;
            DBEntities.GetContext().SaveChanges();
            ClassMB.MBinformation("Успешно");

            GroupsWindow groupsWindow = new GroupsWindow();
            groupsWindow.Show();
            this.Close();
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
