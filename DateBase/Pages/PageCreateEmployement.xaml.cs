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
    /// Логика взаимодействия для PageCreateEmployement.xaml
    /// </summary>
    public partial class PageCreateEmployement : Page
    {
        public static Party party 
        { 
            get
            {
                return party;
            }
            set
            {
                party = value;
            }
        } 
        public PageCreateEmployement()
        {
            InitializeComponent();
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
            


        }
    }
}
