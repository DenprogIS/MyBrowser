using System;
using System.Net;
using System.Windows.Forms;
using Browser.Properties;

namespace Browser
{
    public partial class VKAuthorize : Form
    {
        public string token;
        public string user_id;

        public VKAuthorize()
        {
            InitializeComponent();
            FormClosing += VKAuthorize_FormClosing;
            authorize();
            webControl1.DocumentReady += WebControl1_DocumentReady;
        }

        private string getUserId(string url)
        {
            return url.Substring(url.IndexOf("user_id") + ("user_id").Length + 1);
        }

        private string getToken(string url)
        {
            return url.Substring(url.IndexOf("access_token") + ("access_token").Length + 1, url.IndexOf("&") - (url.IndexOf("access_token") + ("access_token").Length + 1));
        }

        private void WebControl1_DocumentReady(object sender, Awesomium.Core.DocumentReadyEventArgs e)
        {
            if (webControl1.Source.ToString().include("#"))
            {
                token = getToken(webControl1.Source.ToString());
                user_id = getUserId(webControl1.Source.ToString());
                Close();
            }
        }

        private void VKAuthorize_FormClosing(object sender, FormClosingEventArgs e)
        {
            webControl1.Dispose();
        }

        private void authorize()
        {

            string appID = "5379869";//5379869
            string scopes = "messages";//scopes="friends,audio,message";
            string url = "https://oauth.vk.com/authorize?client_id=" + appID +
                             "&display=popup&redirect_uri=https://oauth.vk.com/blank.html&scope=" + scopes +
                             "&response_type=token&v=5.50";
            if (CheckURL(url))
                webControl1.Source = new Uri(url);
            else
            {
                MessageBox.Show(Resources.VKAuthorize_error, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
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
