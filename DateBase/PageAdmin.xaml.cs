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
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();
            MessageBox.Show("Вход в программу успешно выполнен!\nДобро пожаловать, администратор!");
        }
        

        private void Hello_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Добро пожаловать на страницу администратора");
        }
    }
}
