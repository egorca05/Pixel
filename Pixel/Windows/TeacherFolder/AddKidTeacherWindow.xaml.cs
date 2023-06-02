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
    /// Логика взаимодействия для AddKidTeacherWindow.xaml
    /// </summary>
    public partial class AddKidTeacherWindow : Window
    {
        public AddKidTeacherWindow()
        {
            InitializeComponent();
            GroupCB.ItemsSource = DBEntities.GetContext().Groups.ToList().OrderBy(g => g.IdGroups);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = DBEntities.GetContext().PersonalData.Add(new PersonalData()
                {
                    LastName = LastNameTb.Text,
                    FirstName = FirstNameTb.Text,
                    MiddleName = MiddleNameTb.Text,
                    DateOfBirth = Convert.ToDateTime(DateOfDP.Text),
                    Phone = PhoneTb.Text,
                    IdGroups = Int32.Parse(GroupCB.SelectedValue.ToString())
                    
                });
                DBEntities.GetContext().SaveChanges();

                DBEntities.GetContext().User.Add(new User()
                {
                    LoginUser = LoginTb.Text,
                    PassworUser = PassworTb.Text,
                    IdPersonalDataUser = data.IdPersonalData,
                    IdRoleUser = 2
                });
                DBEntities.GetContext().SaveChanges();

                ClassMB.MBinformation("Успешно");
            }
            catch (Exception ex)
            {
                ClassMB.MBerror(ex);
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
