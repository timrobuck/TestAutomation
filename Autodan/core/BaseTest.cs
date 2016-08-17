using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodan.core
{
    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        ClassName
    }

    public class BaseTest
    {
        public static IWebDriver driver;
        
        public void Setup(String browserName)
        {
            if (browserName.Equals("ie"))
                driver = new InternetExplorerDriver();
            else if (browserName.Equals("chrome"))
                driver = new ChromeDriver();
            else if (browserName.Equals("firefox"))
                driver = new FirefoxDriver();
            else
                driver = new ChromeDriver();
            Console.WriteLine("Created browser instance");

            driver.Manage().Window.Maximize();
            Console.WriteLine("Instance window maximized");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("http://tools.cafepress.com/Shipping/");
            Console.WriteLine("Navigated to URL: tools.cafepress.com/Shipping/");
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
