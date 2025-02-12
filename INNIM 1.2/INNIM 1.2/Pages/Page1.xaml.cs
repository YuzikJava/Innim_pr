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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            try
            {
                ZP.ItemsSource = Connect.context.zakazi_programista.ToList();
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
                ZP.ItemsSource = Connect.context.zakazi_programista.ToList().OrderBy(x => x.nomer_zakaza);
                ZP.ItemsSource = Connect.context.zakazi_programista.ToList().OrderBy(x => x.status);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Window1 window = new Window1();
        private void EditP1_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.user == true)
            {
                if (!window.IsActive)
                {
                    Window1 window = new Window1();
                    Nav.frame2.Navigate(new PageE1((sender as Button).DataContext as zakazi_programista));
                    window.Show();
                }
            }
            else
                MessageBox.Show("Отказано в доступе", "Ошибка");
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.user == true) {
                if (!window.IsActive)
                {
                    Window1 window = new Window1();
                    Nav.frame2.Navigate(new PageE1(null));
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
                var deljuus = ZP.SelectedItems.Cast<zakazi_programista>().ToList();
                if (MessageBox.Show($"Удалить {deljuus.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    Connect.context.zakazi_programista.RemoveRange(deljuus);
                try
                {
                    Connect.context.SaveChanges();
                    ZP.ItemsSource = Connect.context.zakazi_programista.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                MessageBox.Show("Отказано в доступе", "Ошибка");
        }
        private void OpenExcel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application()
            {
                Visible = true,
                SheetsInNewWorkbook = 1
            };
            Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing); app.DisplayAlerts = false;
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            sheet.Cells[1, 1] = "Номер заказа";
            sheet.Cells[1, 2] = "ID Заказа";
            sheet.Cells[1, 3] = "ID Программиста";
            sheet.Cells[1, 4] = "Дата принятия";
            sheet.Cells[1, 5] = "Статус";
            var currentRow = 2;
            var prod = Connect.context.zakazi_programista.ToList();
            foreach (var item in prod)
            {
                sheet.Cells[currentRow, 1] = item.nomer_zakaza;
                sheet.Cells[currentRow, 2] = item.id_zakaza;
                sheet.Cells[currentRow, 3] = item.id_programmista;
                sheet.Cells[currentRow, 4] = item.date_prinatia;
                sheet.Cells[currentRow, 5] = item.status; 
                currentRow++;
            }
            Microsoft.Office.Interop.Excel.Range range2 = sheet.get_Range("A1", "F20");
            range2.Cells.Font.Name = "Arial";
            range2.Cells.Font.Size = 10;
        }

        private void tbs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string searchTerm = tbs.SelectedValue.ToString();
            var results = Connect.context.zakazi_programista.Where(item => item.status.ToString().Contains(searchTerm)).ToList();
            ZP.ItemsSource = results;
        }
    }
}