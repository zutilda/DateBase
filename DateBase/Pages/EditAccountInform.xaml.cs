using System.Text.RegularExpressions;
using System;
using System.Windows;

namespace DateBase.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditAccountInform.xaml
    /// </summary>
    public partial class EditAccountInform : Window
    {
        Employe Currentuser;
        public EditAccountInform(Employe user)
        {
            InitializeComponent();

            Currentuser = user;

            tboxSurname.Text = user.surname;
            tboxName.Text = user.name;
            tboxPatronymic.Text = user.patronymic;
            dpBirthdate.SelectedDate = user.birthday;
            tboxPhone.Text = user.contact;

            dpBirthdate.DisplayDateStart = new DateTime(DateTime.Now.Year - 70, 1, 1);
            dpBirthdate.DisplayDateEnd = new DateTime(DateTime.Now.Year - 16, DateTime.Now.Month, DateTime.Now.Day);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (checkData())
            {
                Currentuser.surname = tboxSurname.Text;
                Currentuser.name = tboxName.Text;
                Currentuser.patronymic = tboxPatronymic.Text;
                Currentuser.birthday = dpBirthdate.SelectedDate.Value;
                Currentuser.contact = tboxPhone.Text;

                try
                {
                    DBase.ZE.SaveChanges();
                    Close();
                    MessageBox.Show("Данные успешно сохранены", "Персональные данные", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Возникла ошибка! Данные не были обновлены", "Персональные данные", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private bool checkData()
        {
            if (!Regex.IsMatch(tboxSurname.Text, @"^[А-Я][а-я]+$"))
            {
                MessageBox.Show("Фамилия должна начинаться с заглавной буквы и содержать только русские буквы", "Изменение личных данных", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (!Regex.IsMatch(tboxName.Text, @"^[А-Я][а-я]+$"))
            {
                MessageBox.Show("Имя должно начинаться с заглавной буквы и содержать только русские буквы", "Изменение личных данных", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (!Regex.IsMatch(tboxPatronymic.Text, @"^[А-Я][а-я]+$"))
            {
                MessageBox.Show("Отчество должно начинаться с заглавной буквы и содержать только русские буквы", "Изменение личных данных", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (dpBirthdate.SelectedDate.Value == DateTime.Today)
            {
                MessageBox.Show("Выберите дату рождения", "Изменение личных данных", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (!Regex.IsMatch(tboxPhone.Text, @"^\+7 9\d{2} \d{3}-\d{2}-\d{2}$"))
            {
                MessageBox.Show("Номер телефона должен соответствовать следующей маске: \"+7 9XX XXX-XX-XX\", где X - любая цифра", "Изменение личных данных", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }
    }
}