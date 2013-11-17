using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using LINQtoPOML;

namespace Selenium_Chloride
{
    /// <summary>
    /// Generic page element
    /// </summary>
    public class PageElement
    {
        private IBrowser _browser { get; set; }

        /// <summary>
        /// Create a element
        /// </summary>
        /// <param name="id">Page element poml name</param>
        public PageElement(IBrowser browser, string name)
        {
            _browser = browser;

            // Find PageElement information
            Page file =
                (
                    from f in _browser.Pomls
                    where f.Data.ListOfPages.Any
                    (
                        p => p.ListOfElements.Any
                        (
                            e => e.Name == name
                        )
                    )
                    select f.Data.ListOfPages.Single(s => s.ListOfElements.Any(e => e.Name == name))
                ).Single<Page>();

            if (file != null)
            {
                LINQtoPOML.PageElement element =
                    (
                        from e in file.ListOfElements
                        where e.Name == name
                        select e
                    ).Single<LINQtoPOML.PageElement>();

                Name = element.Name;
                Locator = element.Locator;
                Selector = element.Selector;
                Type = element.Type;
            } else
            {
                throw new PageElementNotFoundException("Could not find id: " + name + " in any .poml file associated with this project.");
            }
        }

        // .poml properties
        /// <summary>
        /// Unique name of the poml element
        /// </summary>
        public string Name { get; internal set; }
        /// <summary>
        /// Locator type used to find element
        /// </summary>
        public string Locator { get; internal set; }
        /// <summary>
        /// Type of element
        /// </summary>
        public string Selector { get; internal set; }
        /// <summary>
        /// Type of 'By' object
        /// </summary>
        public string Type { get; internal set; }

        // IWebElement properties
        /// <summary>
        /// IWebElement that drives element
        /// </summary>
        public IWebElement IWebElement { get { return _browser.Find(this); } }
        /// <summary>
        /// Return the Id of the element
        /// </summary>
        public string Id { get { return IWebElement.GetAttribute("id"); } }
        /// <summary>
        /// Return classes bound to element
        /// </summary>
        public string Class { get { return IWebElement.GetAttribute("class"); } }
        /// <summary>
        /// Return innner html text from this element
        /// </summary>
        public string InnerText { get { return IWebElement.Text; } }
        /// <summary>
        /// Return a css property
        /// </summary>
        /// <param name="property">Property name</param>
        /// <returns>CSS value</returns>
        public string GetCSS(string property) { return IWebElement.GetCssValue(property); }
    }
}