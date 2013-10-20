using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium_Chloride
{
    /// <summary>
    /// Link element
    /// </summary>
    public class LinkElement : PageElement
    {
        public LinkElement(IBrowser browser, string name) : base(browser, name) { }

        public string Href { get { return IWebElement.GetAttribute("href"); } }
    }
}