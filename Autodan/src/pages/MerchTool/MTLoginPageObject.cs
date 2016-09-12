using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace Autodan.pages.MerchTool
{
    internal class MtLoginPageObject
    {
        public MtLoginPageObject()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
        }

        //MerchTool Loginpage elements
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.header > h1")]
        public IWebElement PageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#UserName")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > form > fieldset > input")]
        public IWebElement BtnLogin { get; set; }


        //loginpage actions
        //login to merchtool and passes common page object
        public MtCommonPageObject Login()
        {
            UserName.EnterText("CORP_Webdriver");
            Password.EnterText("ANapPqH<");
            BtnLogin.Click();

            Console.WriteLine("input creds, logged into merchtool");

            //return po
            return new MtCommonPageObject();
        }

        //expected elements
        public void VerifyLoginPageElements()
        {
            var pageElements = new List<IWebElement>
            {
                PageTitle,
                UserName,
                Password,
                BtnLogin,
            };

            foreach (IWebElement element in pageElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified: login page elements");
        }
    }
}
