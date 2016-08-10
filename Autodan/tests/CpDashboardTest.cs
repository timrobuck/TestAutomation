using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using System;
using Autodan.src.pages;
using Autodan.adcore.selenium;
using Autodan.adcore.common;



namespace cpDemo
{
    [TestClass]
    public class AdTest
    {

        [TestInitialize]
        public void Initialize()
        {
            adCommon.Setup();
        }

        [TestMethod]
        public void ExecuteTest()
        {
            CpDashboardPage dashboard = new CpDashboardPage();

            Tester.driver.IsElementDisplayed(By.CssSelector("#eic"));
            Console.WriteLine("Verified presence of First Time Discount container");
            dashboard.FirstTimeDiscountOverlayCloseBtn.Click();
            Console.WriteLine("Closing First Time Discount container");
            
            
        }

        [TestCleanup]
        public void TearDownTest()
        {
            Tester.driver.Quit();
            Console.WriteLine("Test completed - collapsing instance.");
        }

    }
}