using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium_Chloride
{
    /// <summary>
    /// Browser extensions for dropdown selectors
    /// </summary>
    public static class BrowserSelectExtensions
    {
        /// <summary>
        /// Select from a dropdown by value
        /// </summary>
        /// <param name="element">Select element</param>
        /// <param name="value">Option value</param>
        public static void SelectByValue(this IBrowser browser, SelectElement element, string value)
        {
            // Create selenium select element object 
            var select = new OpenQA.Selenium.Support.UI.SelectElement(browser.Find(element));
            // Select by value
            select.SelectByValue(value);
        }

        /// <summary>
        /// Select from a dropdown by text
        /// </summary>
        /// <param name="element">Select element</param>
        /// <param name="text">Option text</param>
        public static void SelectByText(this IBrowser browser, SelectElement element, string text)
        {
            // Create selenium select element object
            var select = new OpenQA.Selenium.Support.UI.SelectElement(browser.Find(element));
            // Select by value
            select.SelectByText(text);
        }
    }
}
