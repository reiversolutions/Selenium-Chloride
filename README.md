# Selenium Chloride
## A reagent for Selenium

A wrapper for [Selenium Webdriver](http://seleniumhq.org/docs/03_webdriver.jsp)
to make it friendlier to none developers as well as making it easier to 
implement the page object pattern.


-------------------------------------------------------------------------------

## How it works
Selenium Chloride works by short cutting existing methods as well as 
abstracting away information that is not necessary to the developer/tester.

Lets start with a short cut example. Here is clicking on a link with Selenium.

    IWebElement element = driver.FindElement(By.Id("login"));
    element.Click();

With Selenium the developer needs to know what kind of 'By' method to use and 
the actually locator name. With Selenium Chloride we can assume we have a 
variable and do the following;

    browser.Click(login);

The reason we can do this is because of Selenium Chloride's other main feature, 
the page object pattern. Selenium already has a page object pattern but 
Selenium Chloride implements it differently. Selenium Chloride chooses to 
allow changes to the objects to be done outside of code. The advantages to this 
is;

- To maintain the objects no programming experience is necessary.
- Changes to the objects does not mean the code base needs changed.
- Developer is abstracted from how the page elements are retrieved.

### Example poml to page object

###### .poml

    <Pages group="Website pages">
        <Page name="Login">
            <!-- Uses an Id of username to find a text field -->
            <Element name="Username" locator="username" selector="text"  type="id" />

            <!-- Can use html5 data attributes to locate elements -->
            <Element name="Password" locator="password" selector="text" type="data-testId" />

            <Element name="Login" locator="input" selector="link" type="tag" />

            <!-- Can use link reference to locate elements -->
            <Element name="RandomLink" locator="http://www.google.co.uk" selector="button" type="href" />
        </Page>
    </Pages>
    
###### LoginPage.cs

    public class LoginPage : IPage
    {
        private IBrowser _browser { get; set; }

        /*
         * Uses the element name in the .poml file to link to the class
         */
        public TextElement Username { get; set; }
        public TextElement Password { get; set; }
        public ButtonElement Login { get; set; }
        public LinkElement Search { get; set; }

        public LoginPage(IBrowser browser) 
        { 
            _browser = browser;

            Username = _browser.CreateText("Username");
            // or
            Password = new TextElement(_browser, "Password");

            Login = _browser.CreateButton("Login");
            Search = _browser.CreateLink("RandomLink");
        }

        public void LoginToSystem(string username, string password)
        {
            _browser.InsertText(Username , username);
            _browser.InsertText(Password, password);
            _browser.Click(Login);
        }
    }

###### Test.cs

    [TestFixture]
    public class Test
    {
        [TestCase]
        public void Login_Valid_Test()
        {
            // Browser uses config file in order to choose correct driver, this means tests can be configured on a CI basis.
            IBrowser browser = new Browser();
            LoginPage login = new LoginPage(browser);

            login.LoginToSystem("name@example.com", "password");
            
            Assert.AreEqual("Home", browser.Title);
        }
    }

[General Config example](http://www.reiversolutions.co.uk/products/selenium-chloride-config)

## Nuget install

    Install-Package Selenium.Chloride
	
## Api documentation

[www.reiversolutions.co.uk/Products/open/selenium-chloride-api](http://www.reiversolutions.co.uk/products/selenium-chloride-api)

-------------------------------------------------------------------------------

## Page Object Pattern
For further reading on the page object pattern and its advantages read 
[The Automated Tester](http://www.theautomatedtester.co.uk/tutorials/selenium/page-object-pattern.htm).

-------------------------------------------------------------------------------

## Something missing?
If you feel that you are missing something from this framework, please create 
an issue or send a pull request, they are very much welcomed. While your 
feature is being implemented please note you can always reach the underlying 
Selenium functionality.

    IWebDriver driver = browser.IWebDriver

or

    IWebElement element = pageElement.IWebElement

-------------------------------------------------------------------------------

## Core language
 - C#

##### Future language development
 - Java
 - Python

## File format
[Page Object Markup Language](https://github.com/reiversolutions/page-object-markup-language) (.poml)

## License

Released under the Apache License, Version 2.0, January 2004. Full license found
inside docs directory.

######Logo design by Johannes Walter