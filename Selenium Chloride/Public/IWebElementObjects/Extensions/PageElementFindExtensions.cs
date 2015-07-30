using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Selenium_Chloride
{
    public static class PageElementFindExtensions
    {
        /// <summary>
        /// Find a IWebElement from the current PageElement
        /// </summary>
        /// <param name="element">this Page Elemtn</param>
        /// <param name="locator">By object</param>
        /// <returns>IWebElement</returns>
        public static IWebElement Find(this PageElement element, By locator)
        {
            try
            {
                return element.IWebElement.FindElement(locator);
            } catch (NoSuchElementException)
            {
                throw new PageElementNotFoundException();
            }
        }

        /// <summary>
        /// Find multiple IWebElement from the current PageElement
        /// </summary>
        /// <param name="element">this Page Elemtn</param>
        /// <param name="locator">By object</param>
        /// <returns>List of IWebElement</returns>
        public static IEnumerable<IWebElement> FindMultiple(this PageElement element, By locator)
        {
            try
            {
                return element.IWebElement.FindElements(locator);
            }
            catch (NoSuchElementException)
            {
                throw new PageElementNotFoundException();
            }
        }
    }
}
