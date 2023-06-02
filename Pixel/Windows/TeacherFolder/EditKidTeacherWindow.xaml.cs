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

        private void EditBtn_Click(object sender, RoutedEventArgs e)
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

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitProfile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
