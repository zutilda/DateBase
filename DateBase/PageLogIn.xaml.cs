﻿using System;
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
    /// Логика взаимодействия для PageLogIn.xaml
    /// </summary>
    public partial class PageLogIn : Page
    {
        public PageLogIn()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.newFrame.Navigate(new PageUser());
        }
    }
}
