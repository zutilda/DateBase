using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace DateBase.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditAccount.xaml
    /// </summary>
    public partial class EditAccount : Window
    {
        Employe CurrentUser;
        public EditAccount(Employe user)
        {
            InitializeComponent();
            CurrentUser = user;

            tboxLogin.Text = user.login;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (checkData())
            {
                CurrentUser.login = tboxLogin.Text;
                CurrentUser.password = pbPassword.Password.GetHashCode();

                try
                {
                    DBase.ZE.SaveChanges();
                    Close();
                    MessageBox.Show("Данные успешно сохранены", "Учётная запись", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Возникла ошибка! Данные не были обновлены", "Учётная запись", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private bool checkData()
        {
            Employe employees = DBase.ZE.Employe.FirstOrDefault(x => x.login == tboxLogin.Text);

            if (tboxLogin.Text.Length == 0)
            {
                MessageBox.Show("Введите логин", "Учётная запись", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (employees != null && CurrentUser.id_employe != employees.id_employe)
            {
                MessageBox.Show("Пользователь с таким логином уже зарегистрирован", "Учётная запись", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (!CheckPassword(pbPassword.Password))
            {
                return false;
            }
            else if (pbPassword.Password != pbRepeatPassword.Password)
            {
                MessageBox.Show("Пароли не совпадают", "Учётная запись", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Валидация пароля
        /// </summary>
        /// <param name="s">Пароль</param>
        /// <returns>Валидация прошла успешно - true, иначе - false</returns>
        private bool CheckPassword(string s)
        {
            if (pbPassword.Password.Length < 8)
            {
                MessageBox.Show("Пароль должен содержать минимум 8 символов", "Учётная запись", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (!Regex.IsMatch(s, "[A-Z]"))
            {
                MessageBox.Show("Пароль должен содержать минимум 1 заглавный латинский символ", "Учётная запись", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (!Regex.IsMatch(s, "[a-z]+.*[a-z]+.*[a-z]+"))
            {
                MessageBox.Show("Пароль должен содержать минимум 3 строчных латинских символов", "Учётная запись", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (!Regex.IsMatch(s, @"\d+.*\d"))
            {
                MessageBox.Show("Пароль должен содержать минимум 2 цифры", "Учётная запись", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (!Regex.IsMatch(s, @"\W"))
            {
                MessageBox.Show("Пароль должен содержать минимум 1 специальный символ", "Учётная запись", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }
    }
}