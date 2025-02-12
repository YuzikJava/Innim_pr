using INNIM_1._2.AppData;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using INNIM_1._2.Pages;

namespace INNIM_1._2.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Nav.frame = frame;
            if (LoginPage.admin == false)
            {
                BtnBackup.Visibility = Visibility.Hidden;
            }
        }
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new Page1());
            Btn1.IsEnabled = false;
            Btn2.IsEnabled = true;
            Btn3.IsEnabled = true;
            Btn4.IsEnabled = true;
            if (LoginPage.admin == true)
                BtnBackup.IsEnabled = true;
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new Page2());
            Btn1.IsEnabled = true;
            Btn2.IsEnabled = false;
            Btn3.IsEnabled = true;
            Btn4.IsEnabled = true;
            if (LoginPage.admin == true)
                BtnBackup.IsEnabled = true;
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new Page3());
            Btn1.IsEnabled = true;
            Btn2.IsEnabled = true;
            Btn3.IsEnabled = false;
            Btn4.IsEnabled = true;
            if (LoginPage.admin == true)
                BtnBackup.IsEnabled = true;
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new Page4());
            Btn1.IsEnabled = true;
            Btn2.IsEnabled = true;
            Btn3.IsEnabled = true;
            Btn4.IsEnabled = false;
            if (LoginPage.admin == true)
                BtnBackup.IsEnabled = true;
        }



        private void BtnBackup_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Backup files(*.bak)|*.bak";
            dialog.DefaultExt = ".bak";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                Connect.context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction,
                    $@"BACKUP DATABASE [{Directory.GetCurrentDirectory()}\DB.mdf] TO  " +
                    $@"DISK = N'{dialog.FileName}' WITH NOFORMAT, NOINIT,  " +
                    $@"NAME = N'{dialog.FileName}', SKIP, NOREWIND, NOUNLOAD,  STATS = 10");
            }
            else
                MessageBox.Show("Файл не выбран");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (LoginPage.admin == true)
                BtnBackup.Visibility = Visibility.Visible;
            else
                BtnBackup.Visibility = Visibility.Hidden;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Nav.Mframe.Navigate(new LoginPage());
            WindowManager.CloseAllWindows();
        }
    }
}