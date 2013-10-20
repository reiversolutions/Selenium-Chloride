using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Interactions;

namespace Selenium_Chloride
{
    /// <summary>
    /// Extensions for pointer input
    /// </summary>
    public static class BrowserPointerExtensions
    {
        /// <summary>
        /// Hover the pointer over an element
        /// </summary>
        /// <param name="element">Page element</param>
        public static void Hover(this IBrowser browser, PageElement element)
        {
            var action = new Actions(browser.IWebDriver);

            action.MoveToElement(browser.Find(element)).Build().Perform();
        }
    }
}