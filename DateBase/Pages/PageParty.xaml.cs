using DateBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DateBase
{
    /// <summary>
    /// Логика взаимодействия для PageParty.xaml
    /// </summary>
    public partial class PageParty : Page
    {
        Pagination Pagination = new Pagination();
 
        List<Party> list = new List<Party>();
        public PageParty()
        {
            Party g = new Party();
            InitializeComponent();
            list = DBase.ZE.Party.ToList();
            ListParty.ItemsSource = list;
            PageCreateParty.flagUpdate = false;
            Pagination.CountPage = DBase.ZE.Party.ToList().Count;
            DataContext = Pagination;
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

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CbSort.SelectedIndex)
            {
                case 1:
                    list.Sort((x, y) => x.Clients.surname.CompareTo(y.Clients.surname));
                    break;
                case 2:
                    list.Sort((x, y) => x.Clients.surname.CompareTo(y.Clients.surname));
                    list.Reverse();

                    break;
                case 3:
                    list.Sort((x, y) => x.Clients.name.CompareTo(y.Clients.name));
                    break;
                case 4:
                    list.Sort((x, y) => x.Clients.name.CompareTo(y.Clients.name));
                    list.Reverse();
                    break;
                case 5:
                    list.Sort((x, y) => x.Clients.patronymic.CompareTo(y.Clients.patronymic));

                    break;
                case 6:
                    list.Sort((x, y) => x.Clients.patronymic.CompareTo(y.Clients.patronymic));
                    list.Reverse();
                    break;
            }

            ListParty.ItemsSource = list;
            PaginationList();
        }

        private void cmbClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbClient.SelectedIndex)
            {
                case 1:
                    list = DBase.ZE.Party.Where(x => x.Clients.surname.Contains(tbSearch.Text)).ToList();
                    break;
                case 2:
                    list = DBase.ZE.Party.Where(x => x.Clients.name.Contains(tbSearch.Text)).ToList();
                    break;
                case 3:
                    list = DBase.ZE.Party.Where(x => x.Clients.patronymic.Contains(tbSearch.Text)).ToList();
                    break;
                case 4:
                    list = DBase.ZE.Party.Where(x => x.Sites.name_sites.Contains(tbSearch.Text)).ToList();
                    break;

                default:
                    list = DBase.ZE.Party.ToList();
                    break;
            }
            ListParty.ItemsSource = list;
            PaginationList();
        }

        private void cbPhoto_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)cbPhoto.IsChecked)
            {
                List<Party> list1 = new List<Party>();
                foreach (var item in list)
                {
                    if (item.Sites.Photos.Count != 0)
                    {
                        foreach (var photoItem in item.Sites.Photos)
                        {
                            if (photoItem.path_photo != null && !list1.Contains(item))
                            {
                                list1.Add(item);
                            }
                        }
                    }
                }
                list = list1;
            }
            else
            {
                list = DBase.ZE.Party.ToList();
            }
            
            ListParty.ItemsSource = list;
            PaginationList();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (cmbClient.SelectedIndex)
            {
                case 1:
                    list = DBase.ZE.Party.Where(x => x.Clients.surname.Contains(tbSearch.Text)).ToList();
                    break;
                case 2:
                    list = DBase.ZE.Party.Where(x => x.Clients.name.Contains(tbSearch.Text)).ToList();
                    break;
                case 3:
                    list = DBase.ZE.Party.Where(x => x.Clients.patronymic.Contains(tbSearch.Text)).ToList();
                    break;
                case 4:
                    list = DBase.ZE.Party.Where(x => x.Sites.name_sites.Contains(tbSearch.Text)).ToList();
                    break;

                default:
                    list = DBase.ZE.Party.ToList();
                    break;
            }
            ListParty.ItemsSource = list;
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
            ListParty.ItemsSource = list.Skip(Pagination.CurrentPage * Pagination.CountPage - Pagination.CountPage).Take(Pagination.CountPage).ToList();

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
            ListParty.ItemsSource = list.Skip(0).Take(Pagination.CountPage).ToList();
            Pagination.CurrentPage = 1;
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            Image image = (Image)sender;
            int id = Convert.ToInt32(image.Uid);
            
           Photos photo = DBase.ZE.Photos.FirstOrDefault(x=>x.id_sites == id);
            if (photo==null)
            {
                image.Source= new BitmapImage(new Uri("\\image\\logotip.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
image.Source = Images.GetBitmapImage(photo);
            image.Stretch = Stretch.Uniform;
            }
            
            
        }
    }
}
