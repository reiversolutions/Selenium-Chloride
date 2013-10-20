using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium_Chloride
{
    /// <summary>
    /// Text element
    /// </summary>
    public class TextElement : PageElement
    {
        public TextElement(IBrowser browser, string name) : base(browser, name) { }
    }
}