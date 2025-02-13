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
    /// Логика взаимодействия для PageE2.xaml
    /// </summary>
    public partial class PageE2 : Page
    {
        bool checkNew;
        zakazi p2;
        public PageE2(zakazi s)
        {
            InitializeComponent();
            if (s == null)
            {
                s = new zakazi();
                checkNew = true;
            }
            else
                checkNew = false;
            DataContext = p2 = s;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkNew)
                {
                    Connect.c.zakazi.Add(p2);
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
