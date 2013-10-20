using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Selenium_Chloride
{
    /// <summary>
    /// Browser alert extensions
    /// </summary>
    public static class BrowserAlertExtensions
    {
        /// <summary>
        /// Retrieve alert
        /// </summary>
        /// <returns>An alert</returns>
        public static IAlert SwitchToAlert(this IBrowser browser)
        {
            try
            {
                return browser.IWebDriver.SwitchTo().Alert();
            } catch (NoAlertPresentException)
            {
                return null;
            }
        }

        /// <summary>
        /// Accept an alert
        /// </summary>
        /// <param name="browser"></param>
        public static void AcceptAlert(this IBrowser browser)
        {
            var alert = browser.SwitchToAlert();
            if (alert != null)
            {
                alert.Accept();
            }
        }

        /// <summary>
        /// Cancel an alert
        /// </summary>
        /// <param name="browser"></param>
        public static void CancelAlert(this IBrowser browser)
        {
            var alert = browser.SwitchToAlert();
            if (alert != null)
            {
                alert.Dismiss();
            }
        }
    }
}
