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

namespace Auth.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void ButtonEnter_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxLogin.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            using (var db = new AuthMurashkinMetelkinaEntities())
            {
                var user = db.user.AsNoTracking()
                    .FirstOrDefault(u => u.login == TextBoxLogin.Text && u.password == PasswordBox.Password);

                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден");
                    return;
                }

                MessageBox.Show("Пользователь успешно найден");

                switch (user.role)
                {
                    case "Заказчик":
                        NavigationService?.Navigate(new Menu());
                        break;
                    case "Директор":
                        NavigationService?.Navigate(new Menu());
                        break;
                }

            }





            // todo: доделать
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Page2());
        }
    }
}
