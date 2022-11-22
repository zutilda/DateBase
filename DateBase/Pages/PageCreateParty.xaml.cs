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
        Sites ST;
        Clients CL;
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

                PT.id_type = Convert.ToInt32(cmbType.SelectedValue.ToString());
                PT.id_sites = Convert.ToInt32(cmbLocation.SelectedValue.ToString());
                PT.date = Convert.ToDateTime(dpDate.SelectedDate);
                PT.id_client = Convert.ToInt32(cmbClient.SelectedValue.ToString());

                if (flagUpdate == false)
                {
                    DBase.ZE.Party.Add(PT);
                }
               
                DBase.ZE.SaveChanges();
                MessageBox.Show("Информация о мероприятии добавлена ");
            }
            catch
            {
                MessageBox.Show("Запись не сохранена, попробуйте снова");
            }
        }

        private void btnService_Click(object sender, RoutedEventArgs e)
        {

            if (PT != null)
            {
                DBase.ZE.Party.Add(PT);
                DBase.ZE.SaveChanges();
                PageCreateEmployement.party = PT;
                ClassFrame.newFrame.Navigate(new PageCreateEmployement());

            }
            else
            {
                MessageBox.Show("Вы не добавили информацию о мероприятии!");
            }

        }

        private void btnSaveLoc_Click(object sender, RoutedEventArgs e)
        {           
            try
            {
                if (flagUpdate == false)
                {
                    ST = new Sites();
                }

                ST.name_sites = tbLoc.Text.ToString();
                ST.adress = tbAdres.Text.ToString();
                ST.rent = Convert.ToDouble(tbRent.Text.ToString());                

                if (flagUpdate == false)
                {
                    DBase.ZE.Sites.Add(ST);
                }

                DBase.ZE.SaveChanges();
                MessageBox.Show("Информация о месте проведения добавлена ");
                ClassFrame.newFrame.Navigate(new PageCreateParty());
            }
            catch
            {
                MessageBox.Show("Запись не сохранена, попробуйте снова");
            }
            AddLocation.Visibility = Visibility.Collapsed;
        }

        private void btnSaveClient_Click(object sender, RoutedEventArgs e)
        {           
            try
            {
                if (flagUpdate == false)
                {
                    CL = new Clients();
                }
                
                CL.surname = tbSurname.Text.ToString();
                CL.name = tbName.Text.ToString();
                CL.patronymic = tbPart.Text.ToString();
                CL.contacts = tbContact.Text.ToString();

                if (flagUpdate == false)
                {
                    DBase.ZE.Clients.Add(CL);
                }

                DBase.ZE.SaveChanges();
                MessageBox.Show("Информация о клиенте добавлена");
                ClassFrame.newFrame.Navigate(new PageCreateParty());
            }
            catch
            {
                MessageBox.Show("Запись не сохранена, попробуйте снова");
            }
            AddClient.Visibility = Visibility.Collapsed;
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            AddClient.Visibility = Visibility.Visible;
        }

        private void btnAddLoc_Click(object sender, RoutedEventArgs e)
        {
            AddLocation.Visibility = Visibility.Visible;
        }
    }
}
