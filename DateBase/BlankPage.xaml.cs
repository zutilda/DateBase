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
    /// Логика взаимодействия для BlankPage.xaml
    /// </summary>
    public partial class BlankPage : Page
    {
        public BlankPage()
        {
            InitializeComponent();
            MessageBox.Show("Вход в программу успешно выполнен!\nДобро пожаловать, администратор!");
        }

        private void btnGetList_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.newFrame.Navigate(new PageAdmin());
        }
    }
}