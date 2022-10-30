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
                        ClassFrame.newFrame.Navigate(new PageAdmin());
                        break;
                    case 2:                        
                        ClassFrame.newFrame.Navigate(new PageUser());
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
