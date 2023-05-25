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
using Pixel.Windows.DirectorFolder;

namespace Pixel.Windows.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для MenuDirectorWindow.xaml
    /// </summary>
    public partial class MenuDirectorWindow : Window
    {
        public MenuDirectorWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassMB.MBExit();
        }

        private void TeacherBtn_Click(object sender, RoutedEventArgs e)
        {
            ListTeachersDirectorWindow listTeachersDirectorWindow = new ListTeachersDirectorWindow();
            listTeachersDirectorWindow.Show();
            this.Close();
        }

        private void GroupsBtn_Click(object sender, RoutedEventArgs e)
        {
            GroupsDirectorWindow groupsDirectorWindow = new GroupsDirectorWindow();
            groupsDirectorWindow.Show();
            this.Close();
        }

        private void ResultBtn_Click(object sender, RoutedEventArgs e)
        {
            ResultTestDirectorWindow resultTestDirectorWindow = new ResultTestDirectorWindow();
            resultTestDirectorWindow.Show();
            this.Close();
        }

        private void ExitProfile_Click(object sender, RoutedEventArgs e)
        {
            AutorizationWindow autorizationWindow = new AutorizationWindow();
            autorizationWindow.Show();
            this.Close();
        }
    }
}
