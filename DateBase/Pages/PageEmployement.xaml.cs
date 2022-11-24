using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DateBase
{
    /// <summary>
    /// Логика взаимодействия для PageEmployement.xaml
    /// </summary>
    public partial class PageEmployement : Page
    {
        public PageEmployement()
        {
            InitializeComponent();
            ListImployement.ItemsSource = DBase.ZE.Party.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.newFrame.Navigate(new BlankPage());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.newFrame.Navigate(new PageCreateEmployement());
        }
    }
}
