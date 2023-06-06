using Pixel.ClassFolder;
using Pixel.FolderData;
using Pixel.Windows.DirectorFolder;
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
    /// Логика взаимодействия для EditKidTeacherWindow.xaml
    /// </summary>
    public partial class EditKidTeacherWindow : Window
    {
        User User { get; set; }
        public EditKidTeacherWindow(PersonalData PersonalData)
        {
            
            InitializeComponent();
            User = DBEntities.GetContext().User.FirstOrDefault(u => u.IdPersonalDataUser == PersonalData.IdPersonalData);
            LoginTb.Text = User.LoginUser;
            PassworTb.Text = User.PassworUser;
            DataContext = PersonalData;
            GroupCB.ItemsSource = DBEntities.GetContext().Groups.ToList().OrderBy(g => g.IdGroups);
            DateOfDP.SelectedDate = PersonalData.DateOfBirth;

        }
        private void RollUpBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
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
            else if (DateOfDP.Text == null)
            {
                ClassMB.MBerror("Не введена дата");
                DateOfDP.Focus();
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
            else if (GroupCB.SelectedValue == null)
            {
                ClassMB.MBerror("Не выбранна группа");
                PassworTb.Focus();
            }
            else
            {
                //User user = DBEntities.GetContext().User
                //    .FirstOrDefault(u => u.IdUser == ClassGlobal.UserEdit);
                User.LoginUser = LoginTb.Text;
                User.PassworUser = PassworTb.Text;
                User.PersonalData.FirstName = FirstNameTb.Text;
                User.PersonalData.LastName = LastNameTb.Text;
                User.PersonalData.MiddleName = MiddleNameTb.Text;
                User.PersonalData.DateOfBirth = Convert.ToDateTime(DateOfDP.Text);
                User.PersonalData.Phone = PhoneTb.Text;
                User.PersonalData.IdGroups = (GroupCB.SelectedItem as Groups).IdGroups;
                DBEntities.GetContext().SaveChanges();

                GroupsWindow groupsWindow = new GroupsWindow();
                groupsWindow.Show();
                this.Close();
            }
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
    }
}
