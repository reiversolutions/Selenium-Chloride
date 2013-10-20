using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium_Chloride
{
    /// <summary>
    /// Extensions for text input
    /// </summary>
    public static class BrowserTextExtensions
    {
        /// <summary>
        /// Insert text into field
        /// </summary>
        /// <param name="element">Text element</param>
        /// <param name="text">Input text</param>
        public static void InsertText(this IBrowser browser, TextElement element, string text)
        {
            browser.Find(element).SendKeys(text);
        }

        /// <summary>
        /// Read the text inside the field
        /// </summary>
        /// <param name="element">Text element</param>
        /// <returns>Inner text</returns>
        public static string ReadText(this IBrowser browser, TextElement element)
        {
            return browser.Find(element).Text;
        }
    }
}
