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
            ClassFrame.mnFrame = frmMain;
            ClassFrame.mnFrame.Navigate(new BlankPage());
            DBase.ZE = new ZhulinaEntities();

        }
    }
}
