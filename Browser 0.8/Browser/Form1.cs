﻿using BrowserStyle;
using System.Windows.Forms;
using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Windows.Input;
using Browser.Properties;
using Awesomium.Core;
using Awesomium.Windows.Forms;
using NUnit.Framework;

namespace Browser
{
    public partial class Form1 : Form
    {
        private Keys g_lastKey;
        private int g_currentBrowserID=-1; //only two function can write this var (newWebBrowser and setCurrentWebBrowser)
        private readonly ArrayList g_webBrowsersList = new ArrayList();

        public Form1()
        {
            InitializeComponent();
            DoStartingActions(); 
            InitializeHotKey();
            ElementHostChildsSet();
            SetRadioButtonStartingStation();
            SubscribeDifferentEvents();
            //MouseWheel += Form1_MouseWheel;
            
            //InitializeKeyHook();
            /*MouseHook.LocalHook = false;
            MouseHook.MouseDown += MouseHook_MouseDown;
            MouseHook.InstallHook();*/
        }

        private void Form1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int tmpValue = getCurrentWebBrowser().Zoom;
            if (e.Delta > 0)
            {
                int MAX_ZOOM=500;
                if (e.Delta + tmpValue < MAX_ZOOM)
                    tmpValue += e.Delta;
                else
                    tmpValue = MAX_ZOOM;
            }
            else
            {
                int MIN_ZOOM=25;
                if (tmpValue - e.Delta > MIN_ZOOM)
                    tmpValue -= e.Delta;
                else
                    tmpValue = MIN_ZOOM;
            }
            getCurrentWebBrowser().Zoom = tmpValue;
        }

        private void DoStartingActions()
        {
            newWebBrowser();
            elementHostHeadpiece.Visible = false;
        }

        private void SubscribeDifferentEvents()
        {
            FormClosing += Form1_FormClosing;
            SubscrinbeBrowserEvents();
        }

        private void SubscrinbeBrowserEvents()
        {
            getCurrentWebBrowser().ShowCreatedWebView += WebBrowserShowCreatedWebView;
            getCurrentWebBrowser().LoadingFrame += WebBrowserLoadingFrame;
        }

        private WebControl getCurrentWebBrowser()
        {
            var webBrowser = g_webBrowsersList[g_currentBrowserID] as WebBrowser;
            if (webBrowser != null)
                return webBrowser.getWebControl();
            return null;
        }

        private void newWebBrowser()
        {
            g_currentBrowserID++;
            WebBrowser webBrowser = new WebBrowser(Width,Height);
            g_webBrowsersList.Add(webBrowser);
            foreach (Control control in Controls)
            {
                if (control is WebControl)
                    control.Visible = false;
            }
            Controls.Add(webBrowser.getWebControl());
            elementHostHeadpiece.BringToFront();
            SubscrinbeBrowserEvents();
        }

        private void setCurrentWebBrowser(int browserID)
        {
            g_currentBrowserID = browserID;

            foreach (Control control in Controls)
            {
                if (control is WebControl)
                    control.Visible = false;
            }

            for (int i = 0; i < Controls.Count; i++)
            {
                if ((Controls[i] is WebControl) && (Controls[i].Name == "Browser" + Convert.ToString(g_currentBrowserID)))
                {
                        Controls[i].Visible = true;
                }
            }
        }

        private void WebBrowserLoadingFrame(object sender, LoadingFrameEventArgs e)
        {
            elementHostHeadpiece.Visible = true;
            headpiceHideTimer.Enabled = true;
        }

        private void LoadUrl(string url)
        {
           getCurrentWebBrowser().Source = new Uri(url);
            omniBox.Text = "";
            omniBox.Text = url;
        }

        private void SetRadioButtonStartingStation()
        {
            radioButtonGoogleOrYandex.Checked = true;
        }

        private void InitializeKeyHook()
        {
            Hook.LocalHook = false;
            Hook.InstallHook();
            Hook.OnHookKeyPressEventHandler += Hook_OnHookKeyPressEventHandler;
        }

        private void InitializeHotKey()
        {
            KeyPreview = true;
            KeyDown += Form1_KeyDown;
        }

        private void WebBrowserShowCreatedWebView(object sender, ShowCreatedWebViewEventArgs e)
        {
            string targetUrl = getCurrentWebBrowser().TargetURL.ToString();
            LoadUrl(targetUrl);
        }

        /*private void MouseHook_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int a=0;
        }*/

        private void Hook_OnHookKeyPressEventHandler(LLKHEventArgs e)
        {
            if (((g_lastKey==Keys.LShiftKey) || (g_lastKey == Keys.RShiftKey)) && (e.Keys==Keys.F8))
            {
                this.WindowState = FormWindowState.Maximized;
            }
            g_lastKey = e.Keys;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Application.StartupPath + "\\screens");

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
            //MouseHook.UnInstallHook();
            //Hook.UnInstallHook();
        }

        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (omniBox.Focused)
                Search();   
            }
        }

        private void Search()
        {
            if (!(omniBox.Text.include("http://") || omniBox.Text.include("https://")))
                omniBox.Text = omniBox.Text.Insert(0, "http://");

            if (CheckURL(omniBox.Text))
            {
                LoadUrl(omniBox.Text);
            }
            else
            {
                omniBox.Text = omniBox.Text.RemoveInsertedToBegindText("http://");
                if (radioButtonGoogleOrYandex.Checked)
                    LoadUrl("https://www.google.ru/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=" + omniBox.Text);
                else
                {
                    LoadUrl("https://yandex.ru/search/?lr=11202&text=" + omniBox.Text);
                }
            }
        }

        private void ElementHostChildsSet()
        {
            back_btn backBtn = new back_btn();
            backBtn.PreviewMouseDown += BackBtn_PreviewMouseDown;
            elementHostBackBtn.Child = backBtn;

            forward_btn forwardBtn = new forward_btn();
            forwardBtn.PreviewMouseDown += forwardBtn_PreviewMouseDown;
            elementHostForwardBtn.Child = forwardBtn;
        }

        private void forwardBtn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!getCurrentWebBrowser().CanGoForward())
            MessageBox.Show(Resources.Form1_forwardBtn_PreviewMouseDown_info, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                getCurrentWebBrowser().GoForward();
            }
        }

        private void BackBtn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!getCurrentWebBrowser().CanGoBack())
                MessageBox.Show(Resources.Form1_BackBtn_PreviewMouseDown_info, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                getCurrentWebBrowser().GoBack();
            }
        }

        private bool CheckURL(String url)
        {
            if (String.IsNullOrEmpty(url))
                return false;

            try
            {
                WebRequest request = WebRequest.Create(url);
                HttpWebResponse res = request.GetResponse() as HttpWebResponse;

                if (res.StatusDescription == "OK")
                    return true;
            }
            catch
            {
            }
            return false;  
        }

        private void newTabButton_Click(object sender, EventArgs e)
        {
            getCurrentWebBrowser().doScreenshot(getCurrentWebBrowser().Name);
            newWebBrowser();
            omniBox.Text = "";
        }

        private void omniBox_DoubleClick(object sender, EventArgs e)
        {
            omniBox.SelectAll();
        }

        private void viewTabButton_Click(object sender, EventArgs e)
        {
            getCurrentWebBrowser().doScreenshot(getCurrentWebBrowser().Name);
            tabViewForm form = new tabViewForm();
            form.ShowDialog();
            int selectedTabNumber = form.tabNamber - 1;
            if ((selectedTabNumber >= 0) && (selectedTabNumber != g_currentBrowserID))
                setCurrentWebBrowser(selectedTabNumber);
        }

        private void authorize()
        {
            string appID = "5379869";
            string scopes = "photos";//scopes="friends,audio,message";
            LoadUrl("https://oauth.vk.com/authorize?client_id=" + appID + "&display=popup&redirect_uri=https://oauth.vk.com/blank.html&scope=" + scopes + "&response_type=token&v=5.50");
        }

        private void VKButton_Click(object sender, EventArgs e)
        {
            VKAuthorize form = new VKAuthorize();
            form.ShowDialog();
        }

        private void headpiceHideTimer_Tick(object sender, EventArgs e)
        {
            if (!getCurrentWebBrowser().IsLoading)
            {
                headpiceHideTimer.Enabled = false;
                elementHostHeadpiece.Visible = false;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //getCurrentWebBrowser().Zoom = Convert.ToInt32(numericUpDown1.Value);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}

[TestFixture]
class TestForm1
{
    [Test]
    public void testMethod()
    {
        
    }
}
