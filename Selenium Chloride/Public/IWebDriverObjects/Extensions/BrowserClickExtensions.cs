using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Selenium_Chloride
{
    /// <summary>
    /// Browser extensions for clicking elements
    /// </summary>
    public static class BrowserClickExtensions
    {
        /// <summary>
        /// Click an element
        /// </summary>
        /// <param name="element">Page element</param>
        public static void Click(this IBrowser browser, PageElement element)
        {
            browser.Find(element).Click();
        }

        /// <summary>
        /// Click and hold an element
        /// </summary>
        /// <param name="element">Page element</param>
        /// <param name="ms">Number of milliseconds to hold down the click</param>
        public static void ClickLong(this IBrowser browser, PageElement element, int ms)
        {
            var action = new Actions(browser.IWebDriver);

            action.ClickAndHold(browser.Find(element)).Build().Perform();
            Thread.Sleep(ms);
            action.Release(browser.Find(element)).Build().Perform();
        }

        /// <summary>
        /// Double click an element
        /// </summary>
        /// <param name="element">Page element</param>
        public static void ClickDouble(this IBrowser browser, PageElement element)
        {
            var action = new Actions(browser.IWebDriver);

            action.DoubleClick(browser.Find(element)).Build().Perform();
        }
    }
}
