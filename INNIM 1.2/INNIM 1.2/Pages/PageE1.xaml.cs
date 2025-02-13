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
using System.Data.SqlClient;
using System.Data;

namespace INNIM_1._2.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageE1.xaml
    /// </summary>
    public partial class PageE1 : Page
    {
        bool checkNew;
        zakazi_programista p1;
        public PageE1(zakazi_programista s)
        {
            InitializeComponent();
            if (s == null)
            {
                s = new zakazi_programista();
                checkNew = true;
            }
            else
                checkNew = false;
            DataContext = p1 = s;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkNew)
                {
                    Connect.c.zakazi_programista.Add(p1);
                }
                p1.status = comboBox1.SelectedValue.ToString();
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
