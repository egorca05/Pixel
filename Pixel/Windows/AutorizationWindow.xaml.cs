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
using Pixel.Windows;
using Pixel.Windows.KidFolder;

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

        private void LoginBt_Click(object sender, RoutedEventArgs e)
        {
            Window kidwindow = new KidFolder.MenuKidWindow();
            kidwindow.Show();
            this.Close();
        }
    }
}
