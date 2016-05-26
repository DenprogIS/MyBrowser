using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Awesomium.Core;
using Awesomium.Windows.Forms;

namespace Browser
{
    class WebBrowser
    {
        private static int count;
        private WebControl webControl = new WebControl();

        public WebBrowser()
        {
            webControl.Name = "Browser" + Convert.ToString(count);
            count++;
            webControl.Width = 813;
            webControl.Height = 487;
            webControl.Location = new Point(2, 32);
            webControl.ViewType=WebViewType.Offscreen;
            webControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            webControl.Source = new Uri("http://google.com");
        }

        public WebControl getWebControl()
        {
            return webControl;
        }
    }
}
