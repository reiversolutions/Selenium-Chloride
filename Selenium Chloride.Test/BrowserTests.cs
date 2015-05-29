using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LINQtoPOML;
using OpenQA.Selenium;

namespace Selenium_Chloride.Test
{
    /// <summary>
    /// Test browser
    /// </summary>
    [TestClass]
    public class BrowserTests
    {
        public Browser Browser { get; set; }

        [TestCleanup]
        public void CleanUp()
        {
            if (Browser != null)
            {
                Browser.IWebDriver.Quit();
            }
        }

        [TestMethod]
        public void Constructor_Default_Test()
        {
            // Assign
            Browser = null;

            // Act
            Browser = new Browser();

            // Assert
            Assert.AreEqual("Reiver Solutions", Browser.IWebDriver.Title);
        }

        [TestMethod]
        public void Constructor_WithString_Test()
        {
            // Assign
            Browser = null;
            string type = "Firefox";

            // Act
            Browser = new Browser(type);

            // Assert
            Assert.AreEqual("Reiver Solutions", Browser.IWebDriver.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigException))]
        public void Constructor_WithInvalidString_Test()
        {
            // Assign
            Browser = null;
            string type = "Driver";

            // Act
            Browser = new Browser(type);
        }

        [TestMethod]
        public void Title_Test()
        {
            // Assign
            Browser = new Browser();
            string result = null;

            // Act
            result = Browser.Title;

            // Assert
            Assert.AreEqual("Reiver Solutions", result);
        }

        [TestMethod]
        public void NavigateTo_Test()
        {
            // Assign
            Browser = new Browser();

            // Act
            Browser.NavigateTo("www.google.co.uk");

            // Assert
            Assert.AreEqual("Google", Browser.Title);
        }
    }
}
