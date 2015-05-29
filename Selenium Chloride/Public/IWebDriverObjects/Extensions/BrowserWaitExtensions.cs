using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium_Chloride.Internal.Constants;
using System.Threading;
using OpenQA.Selenium;

namespace Selenium_Chloride
{
    /// <summary>
    /// Extensions to allow the browser to wait
    /// </summary>
    public static class BrowserWaitExtensions
    {
        /// <summary>
        /// Browser wait for page title to load
        /// </summary>
        /// <param name="pageTitle">Page title waiting for</param>
        public static void WaitForTitle(this IBrowser browser, string pageTitle)
        {
            var start = DateTime.Now;

            while (DateTime.Now.Subtract(start).Seconds < Common.BrowserTimeout.Seconds)
            {
                try
                {
                    if (pageTitle == browser.IWebDriver.Title)
                        return;
                    Thread.Sleep(200);
                } catch (NoSuchElementException) { }
            }
            throw new BrowserTimeoutException("Timeout");
        }

        /// <summary>
        /// Wait for a page element to become present
        /// </summary>
        /// <param name="element">Page element waiting for</param>
        public static void WaitForElementPresent(this IBrowser browser, PageElement element)
        {
            var start = DateTime.Now;

            while (DateTime.Now.Subtract(start).Seconds < Common.BrowserTimeout.Seconds)
            {
                try
                {
                    IWebElement temp = browser.Find(element, false);
                    return;
                } catch (NoSuchElementException) { Thread.Sleep(200); }
            }
            throw new BrowserTimeoutException("Timeout: Element not found.");
        }

        /// <summary>
        /// Wait for a page element to disappear
        /// </summary>
        /// <param name="element">Page element waiting on to disappear</param>
        public static void WaitForElementNotPresent(this IBrowser browser, PageElement element)
        {
            var start = DateTime.Now;

            while (DateTime.Now.Subtract(start).Seconds < Common.BrowserTimeout.Seconds)
            {
                try
                {
                    IWebElement temp = browser.Find(element, false);
                    Thread.Sleep(200);
                } catch (NoSuchElementException) { return; }
            }
            throw new BrowserTimeoutException("Timeout: Element continues to stay present.");
        }
    }
}
