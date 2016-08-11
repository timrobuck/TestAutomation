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
            PropertiesCollection.driver = new ChromeDriver();


            //navigate to application
            PropertiesCollection.driver.Navigate().GoToUrl("http://tools.cafepress.com/Shipping/");
            Console.WriteLine("Created browser instance, opening URL");
        }

        
        [Test]
        public void ExecuteTest()
        {
            //login to app
            SMLoginPageObject loginPage = new SMLoginPageObject();
            SMDashboardPageObject pageEA =  loginPage.Login("actiondan", "password1234");


            //pageEA.FillUserForm("DP", "Dan", "Josh");
        }
        
        [TearDown]
        public void Cleanup()
        {
            PropertiesCollection.driver.Close();
            Console.WriteLine("Test completed; collapsing instance");
        }
    }
}
