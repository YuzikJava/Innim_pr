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
    /// Логика взаимодействия для PageE4.xaml
    /// </summary>
    public partial class PageE4 : Page
    {
        bool checkNew;
        clients p4;
        public PageE4(clients s)
        {
            InitializeComponent();
            if (s == null)
            {
                s = new clients();
                checkNew = true;
            }
            else
                checkNew = false;
            DataContext = p4 = s;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkNew)
                {
                    Connect.c.clients.Add(p4);
                }
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