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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            try
            {
                Z.ItemsSource = Connect.context.zakazi.ToList();
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
                Z.ItemsSource = Connect.context.zakazi.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Window1 window = new Window1();
        private void EditP4_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.user == true)
            {
                if (!window.IsActive)
                {
                    Window1 window = new Window1();
                    Nav.frame2.Navigate(new PageE2((sender as Button).DataContext as zakazi));
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
                var delsps = Z.SelectedItems.Cast<zakazi>().ToList();
                foreach (var delsp in delsps)
                    if (Connect.context.zakazi_programista.Any(x => x.id_zakaza == delsp.id_zakaza))
                    {
                        MessageBox.Show("Данные используются в таблице Заказы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                if (MessageBox.Show($"Удалить {delsps.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    Connect.context.zakazi.RemoveRange(delsps);
                try
                {
                    Connect.context.SaveChanges();
                    Z.ItemsSource = Connect.context.zakazi.ToList();
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
                    Nav.frame2.Navigate(new PageE2(null));
                    window.Show();
                }
            }
            else
                MessageBox.Show("Отказано в доступе", "Ошибка");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            decimal totalCost = 0;
            foreach (var row in Z.Items)
            {
                totalCost += (decimal)row.GetType().GetProperty("cost").GetValue(row);
            }
            MessageBox.Show($"Общая стоимость выплат: {totalCost:C}", "Расчет стоимости");
        }
    }
}