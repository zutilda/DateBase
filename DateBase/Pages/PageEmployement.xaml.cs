using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.UI.MobileControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace DateBase
{
    /// <summary>
    /// Логика взаимодействия для PageEmployement.xaml
    /// </summary>
    /// 
    public partial class PageEmployement : Page
    {
        List<Employment> list = new List<Employment>();

        Pagination Pagination = new Pagination();
        public PageEmployement()
        {
            InitializeComponent();
            list= DBase.ZE.Employment.ToList();
            ListImployement.ItemsSource = list;
            Pagination.CountPage = DBase.ZE.Party.ToList().Count;
            DataContext = Pagination;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.newFrame.Navigate(new BlankPage());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.newFrame.Navigate(new PageCreateEmployement());
        }

        private void cmbEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchEmploe();
        }

        private void tbEmployee_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchEmploe();
        }

        private void SearchEmploe()
        {
            
            switch (cmbEmployee.SelectedIndex)
            {
                case 1:
                    list = DBase.ZE.Employment.Where(x => x.Employe.surname.Contains(tbEmployee.Text)).ToList();
                    break;
                case 2:
                    list = DBase.ZE.Employment.Where(x => x.Employe.name.Contains(tbEmployee.Text)).ToList();
                    break;
                case 3:
                    list = DBase.ZE.Employment.Where(x => x.Employe.patronymic.Contains(tbEmployee.Text)).ToList();
                    break;

                default:
                    list = DBase.ZE.Employment.ToList();
                    break;
            }
            ListImployement.ItemsSource = list;
            PaginationList();
        }


        private void tboxPageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            PaginationList();
        }

        private void EditingCurrentPage_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;

            switch (tb.Uid)
            {
                case "first":
                    Pagination.CurrentPage = 1;
                    break;
                case "last":
                    Pagination.CurrentPage = list.Count;
                    break;
                case "back":
                    Pagination.CurrentPage--;
                    break;
                case "next":
                    Pagination.CurrentPage++;
                    break;
                default:
                    Pagination.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }
            ListImployement.ItemsSource = list.Skip(Pagination.CurrentPage * Pagination.CountPage - Pagination.CountPage).Take(Pagination.CountPage).ToList();

        }


        private void PaginationList()
        {
            try
            {
                Pagination.CountPage = Convert.ToInt32(tboxPageCount.Text);
            }
            catch
            {
                Pagination.CountPage = list.Count;
            }

            Pagination.CountList = list.Count;
            ListImployement.ItemsSource = list.Skip(0).Take(Pagination.CountPage).ToList();
            Pagination.CurrentPage = 1;
        }


    }
}
