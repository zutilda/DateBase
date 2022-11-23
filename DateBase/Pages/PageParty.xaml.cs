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
    /// Логика взаимодействия для PageParty.xaml
    /// </summary>
    public partial class PageParty : Page
    {
        public PageParty()
        {
            InitializeComponent();
            ListParty.ItemsSource = DBase.ZE.Party.ToList();
            PageCreateParty.flagUpdate = false;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.newFrame.Navigate(new BlankPage());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.newFrame.Navigate(new PageCreateParty());
        }

        private void btnDelite_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.Uid);

            Party saling = DBase.ZE.Party.FirstOrDefault(x => x.id_party == id);
            List<Employment> employment = DBase.ZE.Employment.Where(x => x.id_party == id).ToList();

            DBase.ZE.Party.Remove(saling);

            foreach (Employment item in employment)
            {
                DBase.ZE.Employment.Remove(item);
            }


            DBase.ZE.SaveChanges();
            MessageBox.Show("Информация удалена");

            ListParty.ItemsSource = DBase.ZE.Party.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.Uid);
            ClassFrame.newFrame.Navigate(new PageCreateParty(DBase.ZE.Party.FirstOrDefault(x => x.id_party == id)));
        }
    }

   
}
