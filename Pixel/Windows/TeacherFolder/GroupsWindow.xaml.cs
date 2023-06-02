using MaterialDesignThemes.Wpf;
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
    /// Логика взаимодействия для GroupsWindow.xaml
    /// </summary>
    public partial class GroupsWindow : Window
    {
        public GroupsWindow()
        {
            InitializeComponent();
            GriupsDG.ItemsSource = DBEntities.GetContext().Groups.ToList().OrderBy(g => g.IdGroups);
        }

        private void MoreBtn_Click(object sender, RoutedEventArgs e)
        {
            var Group = GriupsDG.SelectedItem as Groups;
            if (Group == null)
            {
                ClassMB.MBerror("Не выбрана группа");
                return;
            }
            InGroupTeacherWindow inGroupTeacherWindow = new InGroupTeacherWindow(Group);
            inGroupTeacherWindow.Show();
            this.Close();

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var Group = GriupsDG.SelectedItem as Groups;
            if (Group == null)
            {
                ClassMB.MBerror("Не выбрана группа");
                return;
            }

            Groups group = GriupsDG.SelectedItem as Groups;
            ClassGlobal.GroupEdit = group.IdGroups;

            EditGroupTeacherWindow editGroupTeacherWindow = new EditGroupTeacherWindow( GriupsDG.SelectedItem as Groups);
            editGroupTeacherWindow.Show();
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddGroupTeacherWindow addGroupTeacherWindow = new AddGroupTeacherWindow();
            addGroupTeacherWindow.Show();
            this.Close();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (GriupsDG.SelectedItem == null)
            {
                ClassMB.MBerror("Не выбранна группа");
                return;
            }
            else
            {
                try
                {
                    Groups groups = GriupsDG.SelectedItem as Groups;
                    if (ClassMB.QuestionMessage($"Удалить выбранную группу?"))
                    {
                        DBEntities.GetContext().Groups.Remove(groups);
                        DBEntities.GetContext().SaveChanges();
                        GriupsDG.ItemsSource = DBEntities.GetContext().Groups.ToList().OrderBy(g => g.IdGroups);
                    }    
                }
                catch (Exception ex)
                {
                    ClassMB.MBerror(ex);
                }
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuTeacherWindow menu = new MenuTeacherWindow();
            menu.Show();
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

        private void AddKidBtn_Click(object sender, RoutedEventArgs e)
        {
            AddKidTeacherWindow addKidTeacherWindow = new AddKidTeacherWindow();
            addKidTeacherWindow.Show();
            this.Close();
        }
    }
}
