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
using Pixel.Windows;
using Pixel.Windows.DirectorFolder;
using Pixel.Windows.KidFolder;
using Pixel.Windows.TeacherFolder;

namespace Pixel.Windows
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        public AutorizationWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassMB.MBExit();
        }
        private void RollUpBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void LoginBt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTb.Text))
            {
                ClassMB.MBerror("Введите логин");
                LoginTb.Focus();
            }
            else if (string.IsNullOrEmpty(PasswordPb.Password))
            {
                ClassMB.MBerror("Введите пароль");
                PasswordPb.Focus();
            }
            else
            {
                try
                {
                    var user = DBEntities.GetContext().User.FirstOrDefault(u => u.LoginUser == LoginTb.Text);
                    if (user == null)
                    {
                        ClassMB.MBerror("Введен не верный логин");
                        LoginTb.Focus();
                        return;
                    }
                    if (user.PassworUser != PasswordPb.Password)
                    {
                        ClassMB.MBerror("введен не верный пароль");
                        PasswordPb.Focus();
                        return;
                    }
                    else
                    {
                        ClassGlobal.UserId = user.IdUser;
                        switch (user.IdRoleUser)
                        {
                            case 1:
                                ClassGlobal.UserId = user.IdUser;
                                MenuTeacherWindow menuTeacherWindow = new MenuTeacherWindow();
                                menuTeacherWindow.Show();
                                this.Close();
                                break;
                            case 2:
                                Window kidwindow = new KidFolder.MenuKidWindow();
                                kidwindow.Show();
                                this.Close();
                                break;
                            case 3:
                                MenuDirectorWindow menuDirectorWindow = new MenuDirectorWindow();
                                menuDirectorWindow.Show();
                                this.Close();
                                break;
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    ClassMB.MBerror(ex);
                }
            }
        }
    }
}
