using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using Autodan.adcore.selenium;

namespace Autodan.adcore.common

{
    [TestClass]
    class adCommon
    {
        public IWebDriver tester { get; set; }

        [TestInitialize]
        public static void Setup()
        {
            Tester.driver = new FirefoxDriver();
            Tester.driver.Manage().Window.Maximize();
            Console.WriteLine("Created Firefox browser");
        }

        public static void OpenShippingManager()
        {
            Tester.driver.Navigate().GoToUrl("http://tools.cafepress.com/Shipping/");
            Console.WriteLine("Navigating to Shipping Manager");
        }

        [TestMethod]
        public static void Wait(double delay, double interval)
        {
            // Causes the WebDriver to wait for at least a fixed delay
            var now = DateTime.Now;
            var wait = new WebDriverWait(Tester.driver, TimeSpan.FromMilliseconds(delay));
            wait.PollingInterval = TimeSpan.FromMilliseconds(interval);
            wait.Until(wd => (DateTime.Now - now) - TimeSpan.FromMilliseconds(delay) > TimeSpan.Zero);
        }

        [TestCleanup]
        public static void TearDown()
        {
            Tester.driver.Quit();
            Console.WriteLine("Test completed - Collapsing instance");
        }
    }
}