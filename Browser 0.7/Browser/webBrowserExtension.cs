using Awesomium.Windows.Forms;
using Awesomium.Core;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Browser
{
    public static class webBrowserExtension
    {
        public static void doScreenshot(this WebControl webBrowser, string fileName)
        {
            IWebView webView = WebCore.Views.GetByHandle(webBrowser.NativeView);
            if (webView != null)
            {
                var imageSurface = webView.Surface as ImageSurface;
                imageSurface?.Image.Save(Application.StartupPath + "\\screens\\screen" + fileName + ".jpg", ImageFormat.Jpeg);
            }
        }
    }
}
