﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using Browser.Properties;
using BrowserStyle;
using NUnit.Framework.Api;

namespace Browser
{
    public partial class tabViewForm : Form
    {
        public int tabNamber;

        public tabViewForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            TabView tabView = new TabView();
            tabView.PreviewMouseDown += TabView_PreviewMouseDown;
            elementHost1.Child = tabView;
            bool finalTab = true;

            int count = 0;

            foreach (Control control in Controls)
            {
                if (control is PictureBox)
                {
                    control.MouseDown += Control_MouseDown;
                    count++;
                    try
                    {
                        (control as PictureBox).Image =
                            new Bitmap(
                                @"C:\Users\user\Documents\Visual Studio 2015\Projects\Browser\Browser\bin\Debug\screens\screenBrowser" +
                                Convert.ToString(count) + ".jpg");
                        control.BringToFront();
                    }
                    catch (Exception ex)
                    {
                        if (finalTab)
                        {
                            (control as PictureBox).Image = Resources.thisTabPicture;
                            control.BringToFront();
                            finalTab = false;
                        }
                    }
                }
            }
        }

        private void Control_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var pictureBox = sender as PictureBox;
            if (pictureBox != null) tabNamber = Convert.ToInt32(pictureBox.Name.Replace("pictureBox",""));
            Close();
        }

        private void TabView_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (Control control in Controls)
            {
                if ((control is PictureBox) && ((control as PictureBox).Image!=null))
                    (control as PictureBox).Image.Dispose();
            }
            Close();
        }
    }
}
