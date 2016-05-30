using System;
using System.Windows.Forms;

namespace Browser
{
    public partial class VKAuthorize : Form
    {
        public VKAuthorize()
        {
            InitializeComponent();
            FormClosing += VKAuthorize_FormClosing;
            authorize();
        }

        private void VKAuthorize_FormClosing(object sender, FormClosingEventArgs e)
        {
            webControl1.Dispose();
        }

        private void authorize()
        {
            string appID = "5379869";
            string scopes = "photos";//scopes="friends,audio,message";
            webControl1.Source = new Uri("https://oauth.vk.com/authorize?client_id=" + appID + "&display=popup&redirect_uri=https://oauth.vk.com/blank.html&scope=" + scopes + "&response_type=token&v=5.50");
        }
    }
}
