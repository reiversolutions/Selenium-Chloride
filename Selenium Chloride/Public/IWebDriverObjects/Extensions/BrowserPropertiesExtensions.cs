using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Configuration;

namespace Selenium_Chloride
{
    /// <summary>
    /// Browser properties extensions
    /// </summary>
    public static class BrowserPropertiesExtensions
    {
        /// <summary>
        /// Switch to a window
        /// </summary>
        /// <param name="window">Window index</param>
        public static void SwitchWindow(this IBrowser browser, int window)
        {
            var handles = browser.IWebDriver.WindowHandles;
            if (handles.Count > window)
            {
                browser.IWebDriver.SwitchTo().Window(handles[window]);
            }
        }

        /// <summary>
        /// Resize the current broswer
        /// </summary>
        /// <param name="height">Browser height</param>
        /// <param name="width">Browser width</param>
        public static void ResizeBrowser(this IBrowser browser, int height, int width)
        {
            browser.IWebDriver.Manage().Window.Size = new Size(height, width);
        }

        /// <summary>
        /// Clear the browsers cookies
        /// </summary>
        public static void ClearAllCookies(this IBrowser browser)
        {
            browser.IWebDriver.Manage().Cookies.DeleteAllCookies();
        }

        /// <summary>
        /// Refresh browser
        /// </summary>
        public static void RefreshBrowser(this IBrowser browser)
        {
            browser.IWebDriver.Navigate().Refresh();
            browser.AcceptAlert();
        }

        /// <summary>
        /// Take a print screen and save the file as a .png
        /// </summary>
        public static void PrintScreen(this IBrowser browser, string name)
        {
            string dir = ConfigurationManager.AppSettings["PrintScreenDir"];
            if (dir != null)
            {
                var screenshot = ((ITakesScreenshot) browser.IWebDriver).GetScreenshot();
                byte[] bitmap = screenshot.AsByteArray;

                var time = DateTime.Now.ToString("yy MM dd");

                Directory.CreateDirectory(dir);
                Directory.CreateDirectory(Path.Combine(dir, time));

                var fileName = Path.Combine(dir, time, @"\TEST_" + browser.IWebDriver.Title + "_" + name + "_" + DateTime.Now.ToFileTime().ToString() + ".png");

                using (Image image = Image.FromStream(new MemoryStream(bitmap)))
                {
                    image.Save(fileName, ImageFormat.Png);
                }
            } else
            {
                throw new ConfigException("No screen shot directory specified.");
            }
        }
    }
}
