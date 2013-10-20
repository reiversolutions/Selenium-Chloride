using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium_Chloride
{
    /// <summary>
    /// Radio button element
    /// </summary>
    public class RadioElement : PageElement
    {
        public RadioElement(IBrowser browser, string name) : base(browser, name) { }

        // TODO Create get/set for switching radio buttons
        public bool IsSelected { get; set; }
    }
}