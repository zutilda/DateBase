namespace DateBase
{
    public partial class Employment
    {
        public string InformOneEmploe
        {
            get
            {
                string str = "";

                str += "Сотрудник "
                    + Employe.name
                    + " "
                    + Employe.surname
                    + " "
                    + Employe.patronymic
                    + " "
                    + Position.name_position
                    + " "
                    + Services.name_services
                    + "\nСтоимость "
                    + price
                    + "\n";

                return str;
            }
        }
    }
}
