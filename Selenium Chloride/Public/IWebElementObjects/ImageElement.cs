using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium_Chloride
{
    /// <summary>
    /// Image element
    /// </summary>
    public class ImageElement : PageElement
    {
        public ImageElement(IBrowser browser, string name) : base(browser, name)  { }

        public string Src { get { return IWebElement.GetAttribute("src"); } }
    }
}