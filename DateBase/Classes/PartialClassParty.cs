using System;
using System.Linq;
using System.Windows.Media;

namespace DateBase
{
    public partial class Party
    {
        public string FullNameClient
        {
            get
            {
                return Clients.name+" " + Clients.surname+" " + Clients.patronymic + "\nКонтакты: "+ Clients.contacts;
            }
        }

        public string InformEmploe
        {
            get
            {
                string str = "";
                double stoim=0;
                foreach (var item in Employment.Where(x => x.id_party.Equals(id_party)))
                {
                    str += "Сотрудник " + item.Employe.name +" "+ item.Employe.surname +" "+ item.Employe.patronymic+" " + item.Position.name_position + " " + item.Services.name_services+ "\nСтоимость " +item.price + "\n";
                    stoim += item.price;
                }
                str+= "Общая стоимость = "+ stoim;
                return str;
            }
        }

        public SolidColorBrush ColorData
        {
            get
            {
                if (date.Date == DateTime.Now.Date) //сегодня
                {
                    return Brushes.LightCyan;
                }
                else if (date.Date >= DateTime.Now.Date.AddDays(1) && date.Date <= DateTime.Now.Date.AddDays(5))//в ближайшие дни
                {
                    return Brushes.LightBlue;
                }
                else if (date.Date <= DateTime.Now.Date)//прошедшие праздники
                {
                    return Brushes.LightGray;
                }
                else // будущeе, но далекоe
                {
                    return Brushes.LightGreen;
                }
            }
        }
    }
}
