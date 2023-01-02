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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DateBase
{
    /// <summary>
    /// Логика взаимодействия для PageMarketing.xaml
    /// </summary>
    public partial class PageMarketing : Page
    {
        public PageMarketing()
        {
            InitializeComponent();

            DoubleAnimation FS = new DoubleAnimation(); //анимация на размер шрифта
            FS.From = 30;
            FS.To = 40;
            FS.Duration = TimeSpan.FromSeconds(5);
            FS.RepeatBehavior = RepeatBehavior.Forever;
            FS.AutoReverse = true;
            tb.BeginAnimation(FontSizeProperty, FS);

            DoubleAnimation LH = new DoubleAnimation(); //анимация на длину картинки
            LH.From = 160;
            LH.To = 200;
            LH.Duration = TimeSpan.FromSeconds(3);
            LH.RepeatBehavior = RepeatBehavior.Forever;
            LH.AutoReverse = true;
            logotip.BeginAnimation(HeightProperty, LH);

            DoubleAnimation LW = new DoubleAnimation(); //анимация на ширину картинки
            LW.From = 200;
            LW.To = 250;
            LW.Duration = TimeSpan.FromSeconds(3);
            LW.RepeatBehavior = RepeatBehavior.Forever;
            LW.AutoReverse = true;
            logotip.BeginAnimation(WidthProperty, LW);


            ThicknessAnimation MA = new ThicknessAnimation(); // анимация границ кнопки
            MA.From = new Thickness(60, 60, 60, 60);
            MA.To = new Thickness(0, 0, 0, 0);
            MA.Duration = TimeSpan.FromSeconds(2);
            MA.RepeatBehavior = RepeatBehavior.Forever;
            MA.AutoReverse = true;
            btn.BeginAnimation(MarginProperty, MA);

            ColorAnimation BA = new ColorAnimation();
            ColorConverter CC = new ColorConverter(); 
            Color Cstart = (Color)CC.ConvertFrom("#483d8b"); // присваивание начального цвета эл-ту
            btn.Background = new SolidColorBrush(Cstart); // закрашивание эл-та сплошным цветом
            BA.From = Cstart; // начальное значение свойства
            BA.To = (Color)CC.ConvertFrom("#FFB064AB"); // конечное значение свойства
            BA.Duration = TimeSpan.FromSeconds(3);
            BA.AutoReverse = true;
            BA.RepeatBehavior = RepeatBehavior.Forever;
            btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, BA);
        }

       
    }
}
