using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace Autodan.core
{
    internal enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        ClassName
    }

    public class BaseTest
    {
        public static IWebDriver Driver;
        
        public void Setup(string browserName)
        {
            if (browserName.Equals("ie"))
                Driver = new InternetExplorerDriver();
            else if (browserName.Equals("chrome"))
                Driver = new ChromeDriver();
            else if (browserName.Equals("firefox"))
                Driver = new FirefoxDriver();
            else
                Driver = new ChromeDriver();
            Console.WriteLine("Created browser instance");

            Driver.Manage().Window.Maximize();
            Console.WriteLine("Instance window maximized");
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            Driver.Navigate().GoToUrl("http://tools.cafepress.com/Shipping/");
            Console.WriteLine("Navigated to URL: tools.cafepress.com/Shipping/");
        }

        [TearDown]
        public void Cleanup()
        {
            Driver.Quit();
        }
    }
}
