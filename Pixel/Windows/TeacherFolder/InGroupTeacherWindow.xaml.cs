using Pixel.ClassFolder;
using Pixel.FolderData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для InGroupTeacherWindow.xaml
    /// </summary>
    public partial class InGroupTeacherWindow : Window
    {
        public InGroupTeacherWindow(Groups Groups)
        {
            InitializeComponent();
            KidDG.ItemsSource = DBEntities.GetContext().PersonalData.Where(k => k.IdGroups == Groups.IdGroups).ToList();

        }
        private void RollUpBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
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

        private void MoreBtn_Click(object sender, RoutedEventArgs e)
        {
            if (KidDG.SelectedItem == null)
            {
                ClassMB.MBerror("Не выбран пользователь");
            }
            else
            {
                PersonalData personalData = KidDG.SelectedItem as PersonalData;
                ClassGlobal.KidEdit = personalData.IdPersonalData;

                EditKidTeacherWindow editKidTeacherWindow = new EditKidTeacherWindow(KidDG.SelectedItem as PersonalData);
                editKidTeacherWindow.Show();
                this.Close();
            }

        }

        private void DelBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (KidDG.SelectedItem == null)
            {
                ClassMB.MBerror("Выберите пользователя для удаления");
            }
            else
            {
                try
                {
                    PersonalData personalData = KidDG.SelectedItem as PersonalData ;
                    User user = DBEntities.GetContext().User.FirstOrDefault( u => u.IdPersonalDataUser == personalData.IdPersonalData);
                    var atte = DBEntities.GetContext().Attempts.Where( a => a.IdUser == user.IdUser).ToList();
                    if (ClassMB.QuestionMessage($"Удалить выбранного пользователя?"))
                    {
                        DBEntities.GetContext().Attempts.RemoveRange(atte);
                        DBEntities.GetContext().SaveChanges();
                        DBEntities.GetContext().User.Remove(user);
                        DBEntities.GetContext().SaveChanges();
                        DBEntities.GetContext().PersonalData.Remove(personalData);
                        DBEntities.GetContext().SaveChanges();
                    }

                    GroupsWindow groupsWindow = new GroupsWindow();
                    groupsWindow.Show();
                    this.Close();                         
        } 
                catch (Exception ex)
                {
                    ClassMB.MBerror(ex);
                }
            }
        }
    }
}
