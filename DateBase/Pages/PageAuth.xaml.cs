using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DateBase
{
    /// <summary>
    /// Логика взаимодействия для PageAuth.xaml
    /// </summary>
    public partial class PageAuth : Page
    {
        public PageAuth()
        {
            InitializeComponent();
        }

        private void btnEntr_Click(object sender, RoutedEventArgs e)
        {

            int passw = autoPassword.Password.GetHashCode();
            Employe employe = DBase.ZE.Employe.FirstOrDefault(z => z.login == autoLogin.Text && z.password == passw);
            if (employe == null)
            {
                MessageBox.Show("Неправильно введен логин или пароль!");
            }
            else
            {
                switch (employe.id_role)
                {
                    case 1:
                        MessageBox.Show("Вход в программу успешно выполнен!\nДобро пожаловать, администратор!");
                        BlankPage.EMP = employe;
                        ClassFrame.newFrame.Navigate(new BlankPage());
                        break;
                    case 2:
                        MessageBox.Show("Вход в программу успешно выполнен!\nДобро пожаловать, пользователь!");
                        BlankPage.EMP = employe;
                        ClassFrame.newFrame.Navigate(new BlankPage());
                        break;

                    default:
                        MessageBox.Show("Вход не выполнен! Повторите попытку");
                        break;
                }
            }
        }
    }
}
