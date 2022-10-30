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
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();
            SearchGender.ItemsSource = DBase.ZE.Gender.ToList();
            SearchGender.DisplayMemberPath = "gender1";
            SearchGender.SelectedIndex = 0;
            gridUser.ItemsSource = DBase.ZE.Employe.ToList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (SearchLog.Text != "")
            {
                if (SearchName.Text != "")
                {
                    gridUser.ItemsSource = DBase.ZE.Employe.ToList().Where(x => x.name.Contains(SearchName.Text) && x.login.Contains(SearchLog.Text));
                }
                else
                {
                    gridUser.ItemsSource = DBase.ZE.Employe.ToList().Where(x => x.login.Contains(SearchLog.Text));
                }
            }
            else
            {
                if (SearchName.Text != "")
                {
                    gridUser.ItemsSource = DBase.ZE.Employe.ToList().Where(x => x.name.Contains(SearchName.Text));
                }
                else
                {
                    gridUser.ItemsSource = DBase.ZE.Employe.ToList();
                    return;
                }
            }
        }

        private void btnSearchG_Click(object sender, RoutedEventArgs e)
        {
            gridUser.ItemsSource = DBase.ZE.Employe.ToList().Where(x => x.Gender.gender1 == SearchGender.Text);
        }
        private void desk_Click(object sender, RoutedEventArgs e)
        {
            gridUser.ItemsSource = DBase.ZE.Employe.OrderByDescending(z => z.surname).ToList();
        }

        private void asc_Click(object sender, RoutedEventArgs e)
        {
            gridUser.ItemsSource = DBase.ZE.Employe.OrderBy(z => z.surname).ToList();
        }

        private void btnUpd_Click(object sender, RoutedEventArgs e)
        {
            gridUser.ItemsSource = DBase.ZE.Employe.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.newFrame.Navigate(new BlankPage());
        }        
    }
}
