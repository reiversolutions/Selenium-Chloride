using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Selenium_Chloride
{
    public class SelectElement : PageElement
    {
        public SelectElement(IBrowser browser, string name) : base(browser, name) { }
    }
}
