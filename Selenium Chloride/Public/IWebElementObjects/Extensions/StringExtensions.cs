using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium_Chloride.Public.IWebElementObjects.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Takes a list of class names on an element and 
        /// converts them to a css selector
        /// </summary>
        /// <param name="classNames">Classes on an element</param>
        /// <returns>Css selector</returns>
        public static string ClassListToCssSelector(this string classNames)
        {
            return "." + classNames.Replace(' ', '.');
        }
    }
}
