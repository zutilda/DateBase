using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
