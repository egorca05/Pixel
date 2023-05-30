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
    /// Логика взаимодействия для AddTeacherDirectorWindow.xaml
    /// </summary>
    public partial class AddTeacherDirectorWindow : Window
    {
        public AddTeacherDirectorWindow()
        {
            InitializeComponent();
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
                    DateOfBirth = Convert.ToDateTime(DOBDP.Text),
                    Phone = PhoneTb.Text
                });
                DBEntities.GetContext().SaveChanges();

                DBEntities.GetContext().User.Add(new User()
                {
                    LoginUser = LoginTb.Text,
                    PassworUser = PassworTb.Text,
                    IdPersonalDataUser = data.IdPersonalData,
                    IdRoleUser = 1
                });
                DBEntities.GetContext().SaveChanges();

                ClassMB.MBinformation("Успешно");

                ListTeachersDirectorWindow listTeachersDirectorWindow = new ListTeachersDirectorWindow();
                listTeachersDirectorWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
            ClassMB.MBerror(ex);
            }

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
