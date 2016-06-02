using Microsoft.Expression.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace BrowserStyle
{
    /// <summary>
    /// Логика взаимодействия для blinds.xaml
    /// </summary>
    public partial class blinds : UserControl
    { 
        private bool animationStarted;
        public blinds()
        {
            InitializeComponent();
            Width = SystemParameters.VirtualScreenWidth;
            Height = SystemParameters.VirtualScreenHeight;
            rect.Width= SystemParameters.VirtualScreenWidth;
            rect.Height = SystemParameters.VirtualScreenHeight;
        }

        public void StartAnimation()
        {
            animationStarted = true;
            DoubleAnimation da = new DoubleAnimation();
            DoubleAnimation da2 = new DoubleAnimation();
            da.Completed += Da_Completed;
            da.From = 0;
            da2.From = 300;
            da.To = 360;
            da2.To = 660;
            da.Duration = new Duration(TimeSpan.FromSeconds(1));
            da2.Duration = new Duration(TimeSpan.FromSeconds(1));
            arc.BeginAnimation(Arc.StartAngleProperty, da);
            arc.BeginAnimation(Arc.EndAngleProperty, da2);
        }

        private void Da_Completed(object sender, EventArgs e)
        {
            if (animationStarted)
            StartAnimation();
        }

        public void StopAnimation()
        {
            animationStarted = false;
        }
    }
}
