using Awesomium.Windows.Forms;
using Awesomium.Core;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Browser
{
    public static class webBrowserExtension
    {
        private static int id;
        public static void doScreenshot(this WebControl webBrowser)
        {
            IWebView webView = WebCore.Views.GetByHandle(webBrowser.NativeView);
            if (webView != null)
            {
                var imageSurface = webView.Surface as ImageSurface;
                if (imageSurface != null)
                    imageSurface.Image.Save(Application.StartupPath + "\\screens\\screen" + "1.jpg", ImageFormat.Jpeg);
            }
        }
    }
}
