using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace BrowserStyle
{
    /// <summary>
    /// Логика взаимодействия для blinds.xaml
    /// </summary>
    public partial class blinds : UserControl
    {
        public blinds()
        {
            InitializeComponent();
            Width = SystemParameters.VirtualScreenWidth;
            Height = SystemParameters.VirtualScreenHeight;
            rect.Width= SystemParameters.VirtualScreenWidth;
            rect.Height = SystemParameters.VirtualScreenHeight;
        }
    }
}
