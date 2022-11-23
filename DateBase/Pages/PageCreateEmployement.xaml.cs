using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace DateBase
{
    /// <summary>
    /// Логика взаимодействия для PageCreateEmployement.xaml
    /// </summary>
    public partial class PageCreateEmployement : Page
    {
        public static Party party;
        Employment EM;
        bool flagUpdate = false;
        public void uploadFields()
        {
            InitializeComponent();
            cmbEmploye.ItemsSource = DBase.ZE.Employe.ToList();
            cmbEmploye.SelectedValuePath = "id_employe";
            cmbEmploye.DisplayMemberPath = "surname" + "name";

            cmbPosition.ItemsSource = DBase.ZE.Position.ToList();
            cmbPosition.SelectedValuePath = "id_positions";
            cmbPosition.DisplayMemberPath = "name_sites";

            cmbService.ItemsSource = DBase.ZE.Services.ToList();
            cmbService.SelectedValuePath = "id_services";
            cmbService.DisplayMemberPath = "name_services";
        }
        public PageCreateEmployement()
        {
            InitializeComponent();
            uploadFields();
        }
        public PageCreateEmployement(Employment employment)
        {
            InitializeComponent();
            uploadFields();
            EM = employment;
            flagUpdate = true;
            cmbEmploye.SelectedValue = employment.id_employe;
            cmbPosition.SelectedValue = employment.id_position;
            cmbService.SelectedValue = employment.id_service;
        }
        private void btnParty_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.newFrame.Navigate(new PageParty());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.newFrame.Navigate(new PageCreateParty());
        } 
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (flagUpdate == false)
                {
                    EM = new Employment();
                }

                EM.id_employe = Convert.ToInt32(cmbEmploye.SelectedValue.ToString());
                EM.id_position = Convert.ToInt32(cmbPosition.SelectedValue.ToString());
                EM.id_party = party.id_party;
                EM.id_service = Convert.ToInt32(cmbService.SelectedValue.ToString());
                EM.price = Convert.ToDouble(tbPrice.Text.ToString());

                if (flagUpdate == false)
                {
                    DBase.ZE.Employment.Add(EM);
                }

                DBase.ZE.SaveChanges();
                MessageBox.Show("Информация о занятости сотрудника добавлена ");
            }
            catch
            {
                MessageBox.Show("Запись не сохранена, попробуйте снова");
            }

        }
    }
}
