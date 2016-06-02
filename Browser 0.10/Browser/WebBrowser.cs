using System;
using System.Drawing;
using System.Windows.Forms;
using Awesomium.Core;
using Awesomium.Windows.Forms;

namespace Browser
{
    class WebBrowser
    {
        private static int count=0;
        private WebControl webControl = new WebControl();

        public WebBrowser(int width, int height)
        {
            width -= 19;
            height -= 68;
            webControl.Name = "Browser" + Convert.ToString(count);
            count++;
            webControl.Width = width;
            webControl.Height = height;
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
