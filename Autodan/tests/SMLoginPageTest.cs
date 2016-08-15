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
        static void Main(string[] args)
        {
        }

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
        public void LoginPageTest()
        {
            //navigate to login page of Shipping Manager app
            SMLoginPageObject loginPage = new SMLoginPageObject();

            //verify login page elements
            loginPage.VerifyLoginPageElements();

            //login to app + returns dashboard page object
            loginPage.Login();
        }

        [TearDown]
        public void Cleanup()
        {
            PropertiesCollection.driver.Close();
            Console.WriteLine("Test completed; collapsing instance");
        }
    }
}
