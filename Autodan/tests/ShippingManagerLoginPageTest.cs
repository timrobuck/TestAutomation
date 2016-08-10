using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using System;
using Autodan.src.pages;
using Autodan.adcore.selenium;
using Autodan.adcore.common;



namespace ShippingManager
{
    [TestClass]
    public class ShippingManagerLoginPageTest
    {
        [TestInitialize]
        public void Initialize()
        {
            adCommon.Setup();
            adCommon.OpenShippingManager();
        }

        [TestMethod]
        public void ExecuteTest()
        {
            ShippingManagerLoginPageElements loginpage = new ShippingManagerLoginPageElements();

            loginpage.CafepressImageLogo.Click();
            adCommon.TearDown();
        }
    }
}