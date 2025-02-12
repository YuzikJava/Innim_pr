using INNIM_1._2.AppData;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace INNIM_1._2.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageE3.xaml
    /// </summary>
    public partial class PageE3 : Page
    {
        bool checkNew;
        programmisti p3;
        public PageE3(programmisti s)
        {
            InitializeComponent();
            if (s == null)
            {
                s = new programmisti();
                checkNew = true;
            }
            else
                checkNew = false;
            DataContext = p3 = s;
        }
        Window1 window = new Window1();
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            window.Close();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (checkNew)
            {
                Connect.c.programmisti.Add(p3);
            }
            try
            {
                Connect.c.SaveChanges();
                Window.GetWindow(this)?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}