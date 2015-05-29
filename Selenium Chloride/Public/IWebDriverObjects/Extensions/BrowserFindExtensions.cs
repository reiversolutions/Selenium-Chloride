using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Selenium_Chloride
{
    /// <summary>
    /// Browser find IWebElement extensions
    /// </summary>
    public static class BrowserFindExtensions
    {
        /// <summary>
        /// Find a page element's IWebElement
        /// </summary>
        /// <param name="element">Page Element to search for</param>
        /// <returns>IWebElement of the page element</returns>
        public static IWebElement Find(this IBrowser browser, PageElement element, bool attemptWait = true)
        {
            try
            {
                switch (element.Type.ToLower())
                {
                    case "id":
                        return browser.IWebDriver.FindElement(By.Id(element.Locator));
                    case "class":
                        return browser.IWebDriver.FindElement(By.ClassName(element.Locator));
                    case "css":
                        return browser.IWebDriver.FindElement(By.CssSelector(element.Locator));
                    case "link":
                        return browser.IWebDriver.FindElement(By.LinkText(element.Locator));
                    case "name":
                        return browser.IWebDriver.FindElement(By.Name(element.Locator));
                    case "partial-link":
                        return browser.IWebDriver.FindElement(By.PartialLinkText(element.Locator));
                    case "tag":
                        return browser.IWebDriver.FindElement(By.TagName(element.Locator));
                    case "href":
                        return browser.IWebDriver.FindElement(By.CssSelector("[href='" + element.Locator + "']"));
                    case "xpath":
                        return browser.IWebDriver.FindElement(By.XPath(element.Locator));
                    default:
                        if (element.Type.Contains("data-"))
                        {
                            return browser.IWebDriver.FindElement(By.CssSelector("[" + element.Type + "='" + element.Locator + "']"));
                        } else
                        {
                            throw new PageElementTypeException("'" + element.Type + "' is not a valid type to find a page element by.");
                        }
                }
            } catch (NoSuchElementException)
            {
                if (attemptWait)
                {
                    try
                    {
                        browser.WaitForElementPresent(element);
                        return browser.Find(element, false);
                    }
                    catch (BrowserTimeoutException bte)
                    {
                        throw new PageElementNotFoundException("Browser timed out trying to find element.", bte);
                    }
                } else
                {
                    throw new PageElementNotFoundException("Browser timed out trying to find element.");
                }
            }
        }
    }
}
