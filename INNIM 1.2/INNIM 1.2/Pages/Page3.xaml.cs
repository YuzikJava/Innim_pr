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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
            P.ItemsSource = Connect.context.programmisti.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            P.ItemsSource = Connect.context.programmisti.ToList();
        }
        Window1 window = new Window1();
        private void EditP5_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.user == true)
            {
                if (!window.IsActive)
                {
                    Window1 window = new Window1();
                    Nav.frame2.Navigate(new PageE3((sender as Button).DataContext as programmisti));
                    window.Show();
                }
            }
            else
                MessageBox.Show("Отказано в доступе", "Ошибка");
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.user == true)
            {
                var delsps = P.SelectedItems.Cast<programmisti>().ToList();
                foreach (var delsp in delsps)
                    if (Connect.context.zakazi_programista.Any(x => x.id_programmista == delsp.id_programmista))
                    {
                        MessageBox.Show("Данные используются в таблице Заказы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                if (MessageBox.Show($"Удалить {delsps.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    Connect.context.programmisti.RemoveRange(delsps);
                try
                {
                    Connect.context.SaveChanges();
                    P.ItemsSource = Connect.context.programmisti.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                MessageBox.Show("Отказано в доступе", "Ошибка");
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.user == true)
            {
                Nav.frame2.Navigate(new PageE3(null));
            }
            else
                MessageBox.Show("Отказано в доступе", "Ошибка");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string searchTerm = tbs.Text.Trim().ToLower();
            var results = Connect.context.programmisti.Where(item => item.name_programmista.ToString().Contains(searchTerm)).ToList();

            P.ItemsSource = results;
        }
    }
}