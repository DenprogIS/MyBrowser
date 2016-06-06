using BrowserStyle;
using System.Windows.Forms;
using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Input;
using Browser.Properties;
using Awesomium.Core;
using Awesomium.Windows.Forms;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Browser
{
    public partial class Form1 : Form
    {
        private Keys g_lastKey;
        private int g_currentBrowserID=-1; //only two function can write this var (newWebBrowser and setCurrentWebBrowser)
        private readonly ArrayList g_webBrowsersList = new ArrayList();
        private ArrayList g_usersDialogs = new ArrayList();
        private ArrayList g_groupsDialogs = new ArrayList();
        private string g_VKtoken;
        private string g_VKuser_id;

        public Form1()
        {
            InitializeComponent();
            DoStartingActions(); 
            ElementHostChildsSet();
            SetRadioButtonStartingStation();
            SubscribeDifferentEvents();
           
            //InitializeKeyHook();
            /*MouseHook.LocalHook = false;
            MouseHook.MouseDown += MouseHook_MouseDown;
            MouseHook.InstallHook();*/
        }

        private void Form1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            getCurrentWebBrowser().Enabled = false;
            int tmpValue = getCurrentWebBrowser().Zoom;
            int zoomDelta = e.Delta / 25;
            if ((zoomDelta > 0) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                int MAX_ZOOM=500;
                if (zoomDelta + tmpValue < MAX_ZOOM)
                    tmpValue += zoomDelta;
                else
                    tmpValue = MAX_ZOOM;
            }
            else if ((zoomDelta < 0) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                int MIN_ZOOM=25;
                if (tmpValue + zoomDelta > MIN_ZOOM)
                    tmpValue += zoomDelta;
                else
                    tmpValue = MIN_ZOOM;
            }
            getCurrentWebBrowser().Zoom = tmpValue;
            getCurrentWebBrowser().Enabled = true;
        }

        private void DoStartingActions()
        {
            newWebBrowser();
            elementHostHeadpiece.Visible = false;
            listVKDialogs.Visible = false;
            panel1.Visible = false;
        }

        private void SubscribeDifferentEvents()
        {
            FormClosing += Form1_FormClosing;
            KeyPreview = true;
            KeyDown += Form1_KeyDown;
            MouseWheel += Form1_MouseWheel;
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
            if (!headpiceHideTimer.Enabled)
            {
                elementHostHeadpiece.Visible = true;
                (elementHostHeadpiece.Child as BrowserStyle.blinds).StartAnimation();
                headpiceHideTimer.Enabled = true;
            }
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
            Dispose();
        }

        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (omniBox.Focused)
                {
                    e.SuppressKeyPress = true;
                    Search();
                }
                if (numericZoom.Focused)
                {
                    e.SuppressKeyPress = true;
                    getCurrentWebBrowser().Zoom = (int) numericZoom.Value;
                }
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

        private static string GET(string Url)
        {
            WebRequest req = WebRequest.Create(Url);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream, Encoding.UTF8);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }

        private void VKButton_Click(object sender, EventArgs e)
        {
            if (g_VKtoken == null)
            {
                VKAuthorize form = new VKAuthorize();
                if (!form.IsDisposed)
                form.ShowDialog();
                g_VKtoken = form.token;
                g_VKuser_id = form.user_id;
            }
            else
            {
                showDialogsInList();
            }
        }

        private void showDialogsInList()
        {
            listVKDialogs.Items.Clear();
            listVKDialogs.Visible = true;
            int count = 13;
            string dialogsJson = GET("https://api.vk.com/method/messages.getDialogs?count=" + count + "&access_token=" + g_VKtoken);
            JObject dialogsJObject = JObject.Parse(dialogsJson);
            /* {"mid":120603,"date":1464686057,"out":1,"uid":134129083,"read_state":1,      //person
             * "title":" ... ","body":"на завтра задали 4 варианта матана"},                
             * {"mid":120593,"date":1464685597,"out":1,"uid":166820295,"read_state":1       //group
             * ,"title":"Пасека","body":"","fwd_messages":[{"uid":134129083,*/
            string title;
            int id, read_state;
            for (int i = 1; i < count+1; i++)
            {
                title = (string)dialogsJObject["response"][i]["title"];
                id = (int)dialogsJObject["response"][i]["uid"];
                read_state = (int) dialogsJObject["response"][i]["read_state"];
                Tuple<int, int> user = new Tuple<int, int>(id, read_state);
                Tuple<string, int> group = new Tuple<string, int>(title, read_state);
                if (title == " ... ")
                    g_usersDialogs.Add(user);
                else
                {
                    listVKDialogs.Items.Add(group.Item1);
                    g_groupsDialogs.Add(group);
                }
                //if (read_state == 0)

            }
            string userInfo, firstName, lastName;
            for (int i = 0; i < g_usersDialogs.Count; i++)
            {
                userInfo = GET("https://api.vk.com/method/users.get?user_ids=" + (g_usersDialogs[i] as Tuple<int,int>).Item1);
                firstName = (string)(JObject.Parse(userInfo) as JObject)["response"][0]["first_name"];
                lastName = (string)(JObject.Parse(userInfo) as JObject)["response"][0]["last_name"];
                if ((g_usersDialogs[i] as Tuple<int, int>).Item2==1)
                    listVKDialogs.Items.Add(firstName + " " + lastName);
                else
                    listVKDialogs.Items.Add(firstName + " " + lastName + " " + Convert.ToChar(9993));
                listVKDialogs.SelectedIndexChanged -= selectedIndexChange;
                listVKDialogs.SelectedIndexChanged += selectedIndexChange;
            }
        }

        private void headpiceHideTimer_Tick(object sender, EventArgs e)
        {
            if (!getCurrentWebBrowser().IsLoading)
            {
                headpiceHideTimer.Enabled = false;
                (elementHostHeadpiece.Child as BrowserStyle.blinds).StopAnimation();
                elementHostHeadpiece.Visible = false;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void selectedIndexChange(object sender, EventArgs e)
        {
            foreach (var VARIABLE in COLLECTION)
            {
                
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            if (!panel1.Visible)
            {
                panel1.Visible = true;
                listVKDialogs.Visible = false;
            }
            else
                panel1.Visible = false;
        }

        private void numericZoom_ValueChanged(object sender, EventArgs e)
        {
            getCurrentWebBrowser().Zoom = (int)numericZoom.Value;
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            info form = new info();
            form.ShowDialog();
            if (form.linkClicked)
                LoadUrl("http://www.google.com");
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

