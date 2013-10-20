using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using LINQtoPOML;
using System.IO;
using System.Configuration;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Selenium_Chloride.Internal.Constants;

namespace Selenium_Chloride
{
    public class Browser : IBrowser
    {
        /// <summary>
        /// Create a browser
        /// </summary>
        public Browser() : this(Common.Browser.ToLower()) {}

        /// <summary>
        /// Create a browser
        /// </summary>
        /// <param name="browsers">Browser name</param>
        public Browser(string browsers)
        {
            // Set poml context
            Pomls = new PageObjectContext(new DirectoryInfo(Common.PomlFiles)).Get();

            // Set browser
            switch (browsers.ToLower())
            {
                case "chrome":
                    IWebDriver = new ChromeDriver();
                    break;
                case "chrome-de":
                    ChromeOptions option_de = new ChromeOptions();
                    option_de.AddArgument("--lang=de");
                    IWebDriver = new ChromeDriver();
                    break;
                case "chrome-fr":
                    ChromeOptions option_fr = new ChromeOptions();
                    option_fr.AddArgument("--lang=fr");
                    IWebDriver = new ChromeDriver();
                    break;
                case "chrome-es":
                    ChromeOptions option_es = new ChromeOptions();
                    option_es.AddArgument("--lang=es");
                    IWebDriver = new ChromeDriver();
                    break;
                case "firefox":
                    IWebDriver = new FirefoxDriver();
                    break;
                case "firefox-de":
                    FirefoxProfile profile_de = new FirefoxProfile();
                    profile_de.SetPreference("intl.accept_languages", "de");
                    IWebDriver = new FirefoxDriver(profile_de);
                    break;
                case "firefox-fr":
                    FirefoxProfile profile_fr = new FirefoxProfile();
                    profile_fr.SetPreference("intl.accept_languages", "fr");
                    IWebDriver = new FirefoxDriver(profile_fr);
                    break;
                case "firefox-es":
                    FirefoxProfile profile_es = new FirefoxProfile();
                    profile_es.SetPreference("intl.accept_languages", "es");
                    IWebDriver = new FirefoxDriver(profile_es);
                    break;
                case "grid":
                    DesiredCapabilities abilites = new DesiredCapabilities();
                    abilites.SetCapability(CapabilityType.BrowserName, "firefox");
                    IWebDriver = new RemoteWebDriver(new Uri(Common.GridPath), abilites);
                    break;
                case "ie":
                case "internetexplorer":
                case "internet explorer":
                    IWebDriver = new InternetExplorerDriver();
                    break;
                default:
                    throw new ConfigException("Config file has been incorrectly set up. '" +
                        browsers +
                        "' is not a valid browser option");
            }

            // Browse to test site
            NavigateTo(Common.SiteUrl);
        }

        /// <summary>
        /// List of Poml files
        /// </summary>
        public List<PageObjectFile> Pomls { get; internal set; }

        /// <summary>
        /// IWebDriver running the browser object
        /// </summary>
        public IWebDriver IWebDriver { get; internal set; }

        /// <summary>
        /// Web page title
        /// </summary>
        public string Title
        {
            get
            {
                return IWebDriver.Title;
            }
        }

        /// <summary>
        /// Navigate to another page
        /// </summary>
        /// <param name="url">Url address</param>
        public void NavigateTo(string url)
        {
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "http://" + url;
            }

            IWebDriver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Close the current browser
        /// </summary>
        public void Close()
        {
            IWebDriver.Close();
        }

        /// <summary>
        /// Destroy the current web driver
        /// </summary>
        public void Quit()
        {
            IWebDriver.Quit();
        }

        /// <summary>
        /// Creates a Button Element from poml files
        /// </summary>
        /// <param name="name">Element name</param>
        /// <returns>Button Element</returns>
        public ButtonElement CreateButton(string name)
        {
            return new ButtonElement(this, name);
        }

        /// <summary>
        /// Creates a Checkbox Element from poml files
        /// </summary>
        /// <param name="name">Element name</param>
        /// <returns>Checkbox Element</returns>
        public CheckboxElement CreateCheckbox(string name)
        {
            return new CheckboxElement(this, name);
        }

        /// <summary>
        /// Creates a Image Element from poml files
        /// </summary>
        /// <param name="name">Element name</param>
        /// <returns>Image Element</returns>
        public ImageElement CreateImage(string name)
        {
            return new ImageElement(this, name);
        }

        /// <summary>
        /// Creates a Label/Static text Element from poml files
        /// </summary>
        /// <param name="name">Element name</param>
        /// <returns>Label Element</returns>
        public LabelElement CreateLabel(string name)
        {
            return new LabelElement(this, name);
        }

        /// <summary>
        /// Creates a Link Element from poml files
        /// </summary>
        /// <param name="name">Element name</param>
        /// <returns>Link Element</returns>
        public LinkElement CreateLink(string name)
        {
            return new LinkElement(this, name);
        }

        /// <summary>
        /// Creates a General Element from poml files
        /// </summary>
        /// <param name="name">Element name</param>
        /// <returns>Page Element</returns>
        public PageElement CreateElement(string name)
        {
            return new PageElement(this, name);
        }

        /// <summary>
        /// Creates a Radio button Element from poml files
        /// </summary>
        /// <param name="name">Element name</param>
        /// <returns>Radio button Element</returns>
        public RadioElement CreateRadio(string name)
        {
            return new RadioElement(this, name);
        }

        /// <summary>
        /// Creates a Select Element from poml files
        /// </summary>
        /// <param name="name">Element name</param>
        /// <returns>Select Element</returns>
        public SelectElement CreateSlect(string name)
        {
            return new SelectElement(this, name);
        }

        /// <summary>
        /// Creates a Table Element from poml files
        /// </summary>
        /// <param name="name">Element name</param>
        /// <returns>Table Element</returns>
        public TableElement CreateTable(string name)
        {
            return new TableElement(this, name);
        }

        /// <summary>
        /// Creates a Text Element from poml files
        /// </summary>
        /// <param name="name">Element name</param>
        /// <returns>Text Element</returns>
        public TextElement CreateText(string name)
        {
            return new TextElement(this, name);
        }
    }
}