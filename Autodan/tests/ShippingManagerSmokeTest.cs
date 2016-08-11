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
    class ShippingManagerSmokeTest
    {
        
        static void Main(string[] args)
        {
        }
        
        [SetUp]
        public void Initialize()
        {
            //build browser
            PropertiesCollection.driver = new ChromeDriver();
            Console.WriteLine("Created browser instance");
            PropertiesCollection.driver.Manage().Window.Maximize();
            Console.WriteLine("Instance window maximized");
            
            //navigate to application
            PropertiesCollection.driver.Navigate().GoToUrl("http://tools.cafepress.com/Shipping/");
            Console.WriteLine("Navigated to URL: tools.cafepress.com/Shipping/");
        }

        [Test]
        public void LoginPageTest()
        {
            //navigate to login page of Shipping Manager app
            SMLoginPageObject loginPage = new SMLoginPageObject();

            //verify login page elements
            loginPage.VerifyLoginPageElements();

            //login to app + returns dashboard page object
            SMDashboardPageObject dashboard =  loginPage.Login("dpeterson", "ADano!#1519!#"); 
        }

        [Test]
        public void DashboardPageTest()
        {
            //login to app
            SMLoginPageObject loginpage = new SMLoginPageObject();
            SMDashboardPageObject dashboard = loginpage.Login("dpeterson", "ADano!#1519!#");
                    
            //Verify page elements on Dashboard page
            dashboard.VerifyDashboardPageElements();
        }

        [TearDown]
        public void Cleanup()
        {
            PropertiesCollection.driver.Close();
            Console.WriteLine("Test completed; collapsing instance");
        }
    }
}
