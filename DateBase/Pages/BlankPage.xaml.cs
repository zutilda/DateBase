using DateBase.Pages;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DateBase
{
    /// <summary>
    /// Логика взаимодействия для BlankPage.xaml
    /// </summary>
    public partial class BlankPage : Page
    {
        public static Employe EMP;
        private List<Photos> ListPhoto;
        private int IdPhoto;
        public BlankPage()
        {
            InitializeComponent();
            if (EMP.id_role==2)
            {
                btnGetList.Visibility = Visibility.Collapsed;
                btnGetParty.Visibility = Visibility.Collapsed;
                btnGetEmployement.Visibility = Visibility.Collapsed;
            }
            
            tbFullName.Text += EMP.name + " " + EMP.surname + " " + EMP.patronymic + " ";
            tbBirthdate.Text += EMP.birthday.ToString("D");

            tbLogin.Text += EMP.login;
            tbRole.Text += EMP.Role.name_role.ToLower();

            ListPhoto = DBase.ZE.Photos.Where(x => x.id_employee == EMP.id_employe).ToList();
            IdPhoto = ListPhoto.Count - 1;
            Photos photo;

            if (IdPhoto != -1)
            {
                photo = ListPhoto[IdPhoto];
            }
            else
            {
                photo = null;
            }

            imgPhoto.Source = Images.GetBitmapImage(photo);
            imgPhoto.Stretch = Stretch.Uniform;


        }

        private void BtnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                if (Images.AddPhoto(ofd.FileName, true, EMP.id_employe))
                {
                    ClassFrame.newFrame.Navigate(new BlankPage());
                    MessageBox.Show("Фото успешно добавлено", "Личный кабинет", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Возникла ошибка! Обратитесь к администратору", "Личный кабинет", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void BtnDelPhoto_Click(object sender, RoutedEventArgs e)
        {

            if (IdPhoto == -1)
            {
                MessageBox.Show("Нельзя удалить стандартное изображение!", "Личный кабинет", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            Photos photo = ListPhoto[IdPhoto];

            DBase.ZE.Photos.Remove(photo);
            DBase.ZE.SaveChanges();

            ListPhoto = DBase.ZE.Photos.Where(x => x.id_employee == EMP.id_employe).ToList();

            IdPhoto--;

            if (IdPhoto == -1)
            {
                photo = null;
                BtnBackPhoto.Visibility = Visibility.Hidden;
            }
            else
            {
                if (IdPhoto == 0)
                {
                    BtnBackPhoto.Visibility = Visibility.Hidden;
                }

                photo = ListPhoto[IdPhoto];
            }
            imgPhoto.Source = Images.GetBitmapImage(photo);
        }

        private void BtnChangePhoto_Click(object sender, RoutedEventArgs e)
        {
            if (BtnChangePhoto.Content.ToString() == "Изменить")
            {
                BtnChangePhoto.Content = "Сохранить";
                if (IdPhoto != -1)
                {
                    BtnBackPhoto.Visibility = Visibility.Visible;
                }

            }
            else
            {
                BtnChangePhoto.Content = "Изменить";
                BtnBackPhoto.Visibility = Visibility.Hidden;
                BtnNextPhoto.Visibility = Visibility.Hidden;

                if (IdPhoto != -1)
                {
                    Photos photo = ListPhoto[IdPhoto];
                    Photos newPhoto = new Photos()
                    {
                        id_employee = photo.id_employee,
                        binary_photo = photo.binary_photo,
                        path_photo = photo.path_photo
                    };
                    DBase.ZE.Photos.Remove(photo);
                    DBase.ZE.Photos.Add(newPhoto);
                    DBase.ZE.SaveChanges();

                    ClassFrame.newFrame.Navigate(new BlankPage());
                }
            }
        }

        private void BtnBackPhoto_Click(object sender, RoutedEventArgs e)
        {
            IdPhoto--;
            Photos photo = ListPhoto[IdPhoto];

            if (photo != null)
            {
                imgPhoto.Source = Images.GetBitmapImage(photo);
            }

            if (IdPhoto == 0)
            {
                BtnBackPhoto.Visibility = Visibility.Hidden;
            }

            BtnNextPhoto.Visibility = Visibility.Visible;
        }

        private void BtnNextPhoto_Click(object sender, RoutedEventArgs e)
        {
            IdPhoto++;
            Photos photo = ListPhoto[IdPhoto];

            if (photo != null)
            {
                imgPhoto.Source = Images.GetBitmapImage(photo);
            }

            if (IdPhoto == ListPhoto.Count - 1)
            {
                BtnNextPhoto.Visibility = Visibility.Hidden;
            }

            BtnBackPhoto.Visibility = Visibility.Visible;
        }

        private void BtnChangePersonal_Click(object sender, RoutedEventArgs e)
        {
            EditAccountInform acp = new EditAccountInform(EMP);
            acp.ShowDialog();
            ClassFrame.newFrame.Navigate(new BlankPage());
        }

        private void BtnChangeAccount_Click(object sender, RoutedEventArgs e)
        {
            EditAccount ac = new EditAccount(EMP);
            ac.ShowDialog();
        }

        private void BtnAddSomePhotos_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if ((bool)ofd.ShowDialog())
            {
                bool check = false;

                foreach (string path in ofd.FileNames)
                {
                    if (!Images.AddPhoto(path, true, EMP.id_employe))
                    {
                        check = true;
                    }
                }

                ClassFrame.newFrame.Navigate(new BlankPage());

                if (check)
                {
                    MessageBox.Show("Часть фото не удалось загрузить! Обратитесь к администратору", "Личный кабинет", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Фото успешно добавлены", "Личный кабинет", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }


        private void btnGetList_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.newFrame.Navigate(new PageAdmin());
        }

        private void btnGetParty_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.newFrame.Navigate(new PageParty());
        }

        private void btnGetEmployement_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.newFrame.Navigate(new PageEmployement());
        }
    }
}
