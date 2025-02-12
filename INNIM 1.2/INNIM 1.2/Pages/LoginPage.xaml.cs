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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace INNIM_1._2.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            admin = user = false;
        }

        public static bool admin = false;
        public static bool user = false;

        private Dictionary<string, string> users = new Dictionary<string, string>
        {
            { "admin", "admin" },
            { "user", ""}
        };

        public void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            admin = user = false;
            string login = Log.Text;
            string password = Pass.Password;
            if (users.TryGetValue(login, out var storedPassword))
            {
                if (storedPassword == password)
                {
                    if (login == "admin")
                    {
                        MessageBox.Show($"Вы вошли как Администратор");
                        admin = user = true;
                    }
                    else
                    {
                        MessageBox.Show($"Вы вошли как Пользователь");
                        user = true;
                    }
                    Nav.Mframe.Navigate(new MainPage());
                }
                else
                {
                    MessageBox.Show("Неверный пароль.");
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден.");
            }
            Log.Text = Pass.Password = "";
        }
    }
}
