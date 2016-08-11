using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodan
{
    class ShippingManagerLoginPage
    {   
        [SetUp]
        public void Initialize()
        {
            //build browser
            PropertiesCollection.driver = new ChromeDriver();
            Console.WriteLine("Created Chrome instance");
            PropertiesCollection.driver.Manage().Window.Maximize();
            Console.WriteLine("Browser instance window maximized");
            //navigate to application
            PropertiesCollection.driver.Navigate().GoToUrl("http://tools.cafepress.com/Shipping/");
            Console.WriteLine("Created browser instance, opening URL");
        }

        
        [Test]
        public void ExecuteTest()
        {
            //login to app
            SMLoginPageObject loginPage = new SMLoginPageObject();
            SMDashboardPageObject dashboardPage =  loginPage.Login("dpeterson", "ADano!#1519!#");
            Console.WriteLine("Credentials provided, logging into Shipping Manager");
        }
        
        [TearDown]
        public void Cleanup()
        {
            PropertiesCollection.driver.Close();
            Console.WriteLine("Test completed; collapsing instance");
        }
    }
}
