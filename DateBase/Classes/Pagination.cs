﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DateBase
{
    class Pagination : INotifyPropertyChanged  // класс, который наследуется от интерфейса INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private static int Countitems = 5;
        public int[] NPage { get; set; } = new int[Countitems];
        public string[] Visible { get; set; } = new string[Countitems];
        public string[] Gray { get; set; } = new string[Countitems];

        private int Countpages; //Количество страниц
        public int CountPages
        {
            get => Countpages;
            set
            {
                Countpages = value;
                for (int i = 1; i < Countitems; i++)
                {
                    if (CountPages <= i)
                    {
                        Visible[i] = "Hidden";
                    }
                    else
                    {
                        Visible[i] = "Visible";
                    }
                }
            }
        }

        private int Countpage; //Количество записей на странице
        public int CountPage
        {
            get => Countpage;
            set
            {
                
                if (value==0)
                {
                    MessageBox.Show("Вы ввели не адекватное значение, непонятно зачем, повторите ввод");
                    return;
                }
                Countpage = value;
                if (CountList % value == 0)
                {
                    CountPages = CountList / value;
                }
                else
                {
                    CountPages = CountList / value + 1;
                }
            }
        }

        private int Countlist; //Количество записей в списке
        public int CountList
        {
            get => Countlist;
            set
            {
                Countlist = value;
                if (value % CountPage == 0)
                {
                    CountPages = value / CountPage;
                }
                else
                {
                    CountPages = 1 + value / CountPage;
                }
            }
        }
        private int Сurrentpage; //Текущая страница
        public int CurrentPage
        {
            get => Сurrentpage;
            set
            {
                Сurrentpage = value;
                if (Сurrentpage < 1)
                {
                    Сurrentpage = 1;
                }
                if (Сurrentpage >= CountPages)
                {
                    Сurrentpage = CountPages;
                }

                for (int i = 0; i < Countitems; i++)
                {
                    if (Сurrentpage < (1 + Countitems / 2) || CountPages < Countitems)
                    {
                        NPage[i] = i + 1; //Eсли страница в начале списка
                    }
                    else if (Сurrentpage > CountPages - (Countitems / 2 + 1))
                    {
                        NPage[i] = CountPages - (Countitems - 1) + i; //Eсли страница в конце списка
                    }
                    else
                    {
                        NPage[i] = Сurrentpage + i - (Countitems / 2); //Eсли страница в середине списка
                    }
                }

                for (int i = 0; i < Countitems; i++)
                {
                    if (NPage[i] == Сurrentpage) Gray[i] = "Gray";
                    else Gray[i] = "Black";
                }

                PropertyChanged(this, new PropertyChangedEventArgs("NPage"));
                PropertyChanged(this, new PropertyChangedEventArgs("Visible"));
                PropertyChanged(this, new PropertyChangedEventArgs("Gray"));
            }
        }
        public Pagination()
        {
            for (int i = 0; i < Countitems; i++)
            {
                if (i == 0)
                {
                    Visible[i] = "Visible";
                    Gray[i] = "Gray";
                }
                else
                {
                    Visible[i] = "Hidden";
                    Gray[i] = "Black";
                }

                NPage[i] = i + 1;
            }

            Сurrentpage = 1;
            Countlist = 1;
        }
    }
}
