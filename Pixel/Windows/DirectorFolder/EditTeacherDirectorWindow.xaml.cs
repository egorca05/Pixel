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
using Pixel.FolderData;

namespace Pixel.Windows.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для EditTeacherDirectorWindow.xaml
    /// </summary>
    public partial class EditTeacherDirectorWindow : Window
    {
        User user = new User();
        public EditTeacherDirectorWindow(User User)
        {
            
            InitializeComponent();
            DataContext = User;
            user = DBEntities.GetContext().User.Find(User.IdUser);
            DateOfBirthDP.SelectedDate = user.PersonalData.DateOfBirth;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            ListTeachersDirectorWindow listTeachersDirectorWindow = new ListTeachersDirectorWindow();
            listTeachersDirectorWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassMB.MBExit();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameTb.Text == null)
            {
                ClassMB.MBerror("Не введено имя");
                FirstNameTb.Focus();
            }
            else if (LastNameTb.Text == null)
            {
                ClassMB.MBerror("Не введена фамилия");
                LastNameTb.Focus();
            }
            else if (DateOfBirthDP.Text == null)
            {
                ClassMB.MBerror("Не введена дата");
                DateOfBirthDP.Focus();
            }
            else if (PhoneTb.Text == null)
            {
                ClassMB.MBerror("Не введен номер телефона");
                PhoneTb.Focus();
            }
            else if (LoginTb.Text == null)
            {
                ClassMB.MBerror("Не введен логин");
                LoginTb.Focus();
            }
            else if (PassworTb.Text == null)
            {
                ClassMB.MBerror("Не введен пароль");
                PassworTb.Focus();
            }
            else
            {
                User user = DBEntities.GetContext().User
                .FirstOrDefault(u => u.IdUser == ClassGlobal.UserEdit);
                user.LoginUser = LoginTb.Text;
                user.PassworUser = PassworTb.Text;
                user.PersonalData.FirstName = FirstNameTb.Text;
                user.PersonalData.LastName = LastNameTb.Text;
                user.PersonalData.MiddleName = MiddleNameTb.Text;
                user.PersonalData.DateOfBirth = Convert.ToDateTime(DateOfBirthDP.Text);
                user.PersonalData.Phone = PhoneTb.Text;
                DBEntities.GetContext().SaveChanges();

                ListTeachersDirectorWindow listTeachersDirectorWindow = new ListTeachersDirectorWindow();
                listTeachersDirectorWindow.Show();
                this.Close();

                //PersonalData personalData = DBEntities.GetContext().PersonalData
                //    .FirstOrDefault(p => p.IdPersonalData == ClassGlobal.UserEdit);

                //DBEntities.GetContext().SaveChanges();
            }
        }
        private void RollUpBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
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
