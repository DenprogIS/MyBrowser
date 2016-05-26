using Microsoft.Expression.Media.Effects;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Collections;

namespace BrowserStyle
{
    /// <summary>
    /// Логика взаимодействия для TabView.xaml
    /// </summary>
    public partial class TabView : UserControl
    {
        public TabView()
        {
            InitializeComponent();
            this.Width = SystemParameters.VirtualScreenWidth;
            this.Height= SystemParameters.VirtualScreenHeight;
            DoubleAnimation da = new DoubleAnimation();
            da.From = 10;
            da.To = 0;
            da.Duration = TimeSpan.FromSeconds(1);
            swirl.BeginAnimation(SwirlEffect.TwistAmountProperty, da);

            /*image1.Source = setSources(1);
            image2.Source = setSources(2);
            image3.Source = setSources(3);
            image4.Source = setSources(4);
            image5.Source = setSources(5);
            image6.Source = setSources(6);
            image7.Source = setSources(7);
            image8.Source = setSources(8);
            image9.Source = setSources(9);
            image10.Source = setSources(10);*/
        }

        private ImageSource setSources(int i)
        {
            try
            {
                return (new BitmapImage(new Uri(@"C:\Users\user\Documents\Visual Studio 2015\Projects\Browser\Browser\bin\Debug\screens\screenBrowser" + Convert.ToString(i) + ".jpg")));
            }catch
            {
                return null;
            }
        }
    }
}
