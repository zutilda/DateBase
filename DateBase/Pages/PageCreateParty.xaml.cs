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
    /// Логика взаимодействия для PageCreateParty.xaml
    /// </summary>
    public partial class PageCreateParty : Page
    {
        Party PT;  
        bool flagUpdate = false; 

        public void uploadFields()  // метод для заполнения списков
        {
            cmbType.ItemsSource = DBase.ZE.Type_party.ToList();
            cmbType.SelectedValuePath = "id_type";
            cmbType.DisplayMemberPath = "name_type";

            cmbLocation.ItemsSource = DBase.ZE.Sites.ToList();
            cmbLocation.SelectedValuePath = "id_sites";
            cmbLocation.DisplayMemberPath = "name_sites";

            cmbClient.ItemsSource = DBase.ZE.Clients.ToList();
            cmbClient.SelectedValuePath = "id_client";
            cmbClient.DisplayMemberPath = "surname";
        }
        public PageCreateParty()
        {
            InitializeComponent();
            uploadFields();
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.newFrame.Navigate(new PageParty());
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (flagUpdate == false)
                {
                    PT = new Party();
                }

                PT.id_type = cmbType.SelectedIndex + 1;
                PT.id_sites = cmbLocation.SelectedIndex + 1;
                PT.date = Convert.ToDateTime(dpDate.SelectedDate);
                PT.id_client = cmbClient.SelectedIndex + 1;                

                if (flagUpdate == false)
                {
                    DBase.ZE.Party.Add(PT);
                }
               
                DBase.ZE.SaveChanges();
                MessageBox.Show("Информация о мероприятии добавлена добавлена");
            }
            catch
            {
                MessageBox.Show("Запись не сохранена, попробуйте снова");
            }
        }

        private void btnService_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
