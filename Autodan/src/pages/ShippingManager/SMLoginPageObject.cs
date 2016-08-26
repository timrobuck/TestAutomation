using System;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.ShippingManager
{
    internal class SmLoginPageObject
    {
        public SmLoginPageObject()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
        }

        //login page elements
        [FindsBy(How = How.CssSelector, Using = "#UserName")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > form > button")]
        public IWebElement BtnLogin { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > header > div > div > h3")]
        public IWebElement PageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".container>p")]
        public IWebElement PageFooter { get; set; }


        //expected elements
        public void VerifyLoginPageElements()
        {
            UserName.Verify();
            Password.Verify();
            BtnLogin.Verify();
            PageTitle.Verify();
            PageFooter.Verify();
            Console.WriteLine("Verified: Login Page Elements");
        }


        //login page actions
        //login to shipping manager and passes common page object
        public SmCommonPageObject Login()
        {
            //username + pw + submit
            UserName.SendKeys("CORP_Webdriver");
            Password.SendKeys("ANapPqH<");
            BtnLogin.Submit();

            Console.WriteLine("input credentials, logged into Shipping Manager");

            //return page object
            return new SmCommonPageObject();
        }
    }
}
