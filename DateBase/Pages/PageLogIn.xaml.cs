using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;


// Логин: admin
// Пароль: Admin_12
namespace DateBase
{
    /// <summary>
    /// Логика взаимодействия для PageLogIn.xaml
    /// </summary>
    public partial class PageLogIn : Page
    {
        public PageLogIn()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            int gender = 0;

            if (logMen.IsChecked == true)
            {
                gender = 1;
            }
            if (logWomen.IsChecked == true)
            {
                gender = 2;
            }
            if (logSurname.Text == "")
            {
                if (logName.Text == "")
                {
                    if (logPatr.Text == "")
                    {
                        if (logBirthday.IsEnabled == false)
                        {
                            if (logLogin.Text == "")
                            {
                                if (logPassword.Password == "")
                                {
                                    if (logMen.IsChecked == false && logWomen.IsChecked == false)
                                    {
                                        MessageBox.Show("Не выбран пол!");
                                    }
                                    MessageBox.Show("Поле Пароль не заполнено!");
                                }
                                MessageBox.Show("Поле Логин не заполнено!");
                            }
                            MessageBox.Show("Поле Дата рождения не заполнено!");
                        }
                        MessageBox.Show("Поле Отчество не заполнено!");
                    }
                    MessageBox.Show("Поле Имя не заполнено!");
                }
                MessageBox.Show("Поле Фамилия не заполнено!");
            }
            else
            {
                Regex r1 = new Regex("(?=.*[A-Z])");
                Regex r2 = new Regex("[a-z].*[a-z].*[a-z]");
                Regex r3 = new Regex("\\d.*\\d");
                Regex r4 = new Regex("[!@#$%^&*()_+=]");
                Regex r5 = new Regex("(.+){8,}");
                Regex r6 = new Regex("^[8]{1}[0-9]{10}$");

                if (r1.IsMatch(logPassword.Password) == true)
                {
                    if (r2.IsMatch(logPassword.Password) == true)
                    {
                        if (r3.IsMatch(logPassword.Password) == true)
                        {
                            if (r4.IsMatch(logPassword.Password) == true)
                            {
                                if (r5.IsMatch(logPassword.Password) == true)
                                {
                                    if (r6.IsMatch(logContact.Text) == true)
                                    {
                                        int passw = logPassword.Password.GetHashCode();
                                        Employe employe = DBase.ZE.Employe.FirstOrDefault(x => x.login == logLogin.Text);
                                        if (employe == null)
                                        {
                                            Employe employes = new Employe() { surname = logSurname.Text, name = logName.Text, patronymic = logPatr.Text, login = logLogin.Text, password = logPassword.Password.GetHashCode(), id_role = 2, contact = logContact.Text, birthday = (DateTime)logBirthday.SelectedDate, id_gender = gender };
                                            DBase.ZE.Employe.Add(employes);
                                            DBase.ZE.SaveChanges();
                                            MessageBox.Show("Пользователь успешно зарегистрирован!");
                                            BlankPage.EMP = employe;
                                            ClassFrame.newFrame.Navigate(new BlankPage());
                                        }
                                        else
                                        {
                                            MessageBox.Show("Данный логин уже зарегистрирован в системе!");
                                        }
                                    }
                                    else { MessageBox.Show("Номер телефона введен некорректно!"); }
                                }
                                else { MessageBox.Show("В пароле должно быть не менее 8 символов!"); }
                            }
                            else { MessageBox.Show("В пароле должно быть не менее 1 спец. символа!"); }
                        }
                        else { MessageBox.Show("В пароле должно быть не менее 2 цифр!"); }
                    }
                    else { MessageBox.Show("В пароле должно быть не менее 3 строчных латинских символов!"); }
                }
                else { MessageBox.Show("В пароле должно быть не менее 1 заглавного латинского символа!"); }

            }
        }

        private void logMen_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
