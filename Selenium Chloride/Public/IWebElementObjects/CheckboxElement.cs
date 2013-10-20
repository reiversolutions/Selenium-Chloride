using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium_Chloride
{
    /// <summary>
    /// Checkbox element
    /// </summary>
    public class CheckboxElement : PageElement
    {
        public CheckboxElement(IBrowser browser, string name) : base(browser, name) { }

        // TODO Create get/set for switching checkbox
        public bool IsSelected { get; set; }
    }
}