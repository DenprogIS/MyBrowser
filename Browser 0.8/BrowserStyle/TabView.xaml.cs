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
            da.Duration = TimeSpan.FromSeconds(0.5);
            swirl.BeginAnimation(SwirlEffect.TwistAmountProperty, da);
        }
    }
}
