using Awesomium.Windows.Forms;
using Awesomium.Core;
using System;

namespace Browser
{
    public static class webBrowserExtension
    {
        private static int id;
        public static void doScreenshot(this WebControl webBrowser, string filePath)
        {
            using (WebView vw = WebCore.CreateWebView(1024, 768))
            {
                vw.Source = new Uri(Convert.ToString(webBrowser.Source));

                while (vw.IsLoading)
                {
                    WebCore.Update();
                }

             ((BitmapSurface)vw.Surface).SaveToJPEG(filePath + ".jpg");
                vw.Dispose();
            }
        }
    }
}
