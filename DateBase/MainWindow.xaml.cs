using System.Windows;

namespace DateBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        //{           
        //    Employe UsersObject = new Employe() { name = tbname.Text, surname = tbsurname.Text, patronymic = tbpatronymic.Text, login = tblog.Text, password = tbpas.Text, id_gender = g, birthday = dtdr.DisplayDate, id_role = tbrole.Text, contact = tbcon.Text };
        //    DBase.ZE.Employe.Add(UsersObject);
        //    DBase.ZE.SaveChanges();
        //    MessageBox.Show("Пользователь добавлен");
        //}

        public MainWindow()
        {
            InitializeComponent();
            ClassFrame.newFrame = frmMain;
            DBase.ZE = new ZhulinaEntities();

        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.newFrame.Navigate(new PageAuth());
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.newFrame.Navigate(new PageLogIn());
        }
    }
}
