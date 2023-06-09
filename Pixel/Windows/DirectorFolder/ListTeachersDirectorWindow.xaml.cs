﻿using Pixel.ClassFolder;
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
    /// Логика взаимодействия для ListTeachersDirectorWindow.xaml
    /// </summary>
    public partial class ListTeachersDirectorWindow : Window
    {
        public ListTeachersDirectorWindow()
        {
            InitializeComponent();
        }

        private void Ref()
        {
            TeacherData.ItemsSource = DBEntities.GetContext().User.ToList()
                .OrderBy(c => c.IdUser);
            //СДЕЛАТЬ ЧТОБЫ БЫЛИ ТОЛЬКО УЧИТЕЛЯ
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuDirectorWindow menuDirectorWindow = new MenuDirectorWindow();
            menuDirectorWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassMB.MBExit();
        }

        private void MoreBtn_Click(object sender, RoutedEventArgs e)
        {
            EditTeacherDirectorWindow editTeacherDirectorWindow = new EditTeacherDirectorWindow();  
            editTeacherDirectorWindow.Show();
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddTeacherDirectorWindow addTeacherDirectorWindow1 = new AddTeacherDirectorWindow();
            addTeacherDirectorWindow1.Show();
            this.Close();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TeacherData.SelectedItem == null)
            {
                ClassMB.MBerror("Выберите адресс для удаления");
            }
            else
            {
                try
                {
                    User user = TeacherData.SelectedItem as User;
                    if (ClassMB.QuestionMessage($"Удалить выбранного пользователя?"))
                    {
                        DBEntities.GetContext().User.Remove(user);
                        DBEntities.GetContext().SaveChanges();
                        Ref();
                    }
                }
                catch (Exception ex)
                {
                    ClassMB.MBerror(ex);
                }
            }
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
