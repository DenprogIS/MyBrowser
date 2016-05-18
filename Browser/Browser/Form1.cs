using BrowserStyle;
using System.Windows.Forms;
using System;
using System.Net;
using System.Windows.Input;
using Browser.Properties;
using Awesomium.Core;


namespace Browser
{
    public partial class Form1 : Form
    {
        private Keys g_lastKey;

        public Form1()
        {
            InitializeComponent();
            InitializeHotKey();
            ElementHostChildsSet();
            SetRadioButtonStartingStation();
            InitializeKeyHook();
            SubscribeDifferentEvents();
            /*MouseHook.LocalHook = false;
            MouseHook.MouseDown += MouseHook_MouseDown;
            MouseHook.InstallHook();*/
        }

        private void SubscribeDifferentEvents()
        {
            FormClosing += Form1_FormClosing;
            webBrowser.ShowCreatedWebView += WebBrowser_ShowCreatedWebView;
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

        private void WebBrowser_ShowCreatedWebView(object sender, ShowCreatedWebViewEventArgs e)
        {
            string targetUrl = webBrowser.TargetURL.ToString();
            if (targetUrl.include("http://"))
            {
                    webBrowser.Source = new Uri(targetUrl);
            }
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
            Hook.UnInstallHook();
        }

        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (!omniBox.Text.include("http://"))
                    omniBox.Text = omniBox.Text.Insert(0, "http://");

                if (CheckURL(omniBox.Text))
                {
                    webBrowser.Source = new Uri(omniBox.Text);
                }
                else
                {
                    omniBox.Text = omniBox.Text.RemoveInsertedToBegindText("http://");
                    if (radioButtonGoogleOrYandex.Checked)
                    webBrowser.Source = new Uri("https://www.google.ru/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=" + omniBox.Text);
                    else
                    {
                        webBrowser.Source = new Uri("https://yandex.ru/search/?lr=11202&text=" + omniBox.Text);
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
            if (!webBrowser.CanGoForward())
            MessageBox.Show(Resources.Form1_forwardBtn_PreviewMouseDown_info, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                webBrowser.GoForward();
            }
        }

        private void BackBtn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!webBrowser.CanGoBack())
                MessageBox.Show(Resources.Form1_BackBtn_PreviewMouseDown_info, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                webBrowser.GoBack();
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
    }
}
