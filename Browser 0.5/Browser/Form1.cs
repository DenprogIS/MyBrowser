using BrowserStyle;
using System.Windows.Forms;
using System;
using System.Collections;
using System.Linq;
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

            //InitializeKeyHook();
            /*MouseHook.LocalHook = false;
            MouseHook.MouseDown += MouseHook_MouseDown;
            MouseHook.InstallHook();*/
        }

        private void DoStartingActions()
        {
            newWebBrowser();
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
            getCurrentWebBrowser().LoadingFrameComplete += WebBrowserLoadingFrameComplete;
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
            WebBrowser webBrowser = new WebBrowser();
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
            headpiceShow();
        }

        private void LoadUrl(string url)
        {
           getCurrentWebBrowser().Source = new Uri(url);
            omniBox.Text = "";
            omniBox.Text = url;
        }

        private void headpiceShow()
        {
            elementHostHeadpiece.Visible = true;
        }

        private void WebBrowserLoadingFrameComplete(object sender, FrameEventArgs e)
        {
            elementHostHeadpiece.Visible = false;
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
            //MouseHook.UnInstallHook();
            //Hook.UnInstallHook();
        }

        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

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
            tabViewForm form = new tabViewForm();
            form.ShowDialog();
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

