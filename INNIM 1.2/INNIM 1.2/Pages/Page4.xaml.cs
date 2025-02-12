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
    /// Логика взаимодействия для Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();
            try
            {
                C.ItemsSource = Connect.context.clients.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                C.ItemsSource = Connect.context.clients.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        Window1 window = new Window1();
        private void EditP6_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.user == true)
            {
                if (!window.IsActive)
                {
                    Window1 window = new Window1();
                    Nav.frame2.Navigate(new PageE4((sender as Button).DataContext as clients));
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
                var delsscs = C.SelectedItems.Cast<clients>().ToList();
                foreach (var delssc in delsscs)
                    if (Connect.context.clients.Any(x => x.id_client == delssc.id_client))
                    {
                        MessageBox.Show("Данные используются в таблице Заказы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                if (MessageBox.Show($"Удалить {delsscs.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    Connect.context.clients.RemoveRange(delsscs);
                try
                {
                    Connect.context.SaveChanges();
                    C.ItemsSource = Connect.context.clients.ToList();
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
                if (!window.IsActive)
                {
                    Window1 window = new Window1();
                    Nav.frame2.Navigate(new PageE4(null));
                    window.Show();
                }
            }
            else
                MessageBox.Show("Отказано в доступе", "Ошибка");
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string searchTerm = tbs.Text.Trim().ToLower();
            var results = Connect.context.clients.Where(item =>
            item.name_client.ToString().Contains(searchTerm) ||
            item.phone_client.ToString().Contains(searchTerm)).ToList();
            C.ItemsSource = results;
        }
    }
}