using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace Autodan.pages.MerchTool.MtCommonSitePages
{
    public class MtLoginPageObject
    {
        public MtLoginPageObject()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
        }

        //MerchTool Loginpage elements
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.header > h1")]
        public IWebElement PageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#UserName")]
        public IWebElement InputUserName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#Password")]
        public IWebElement InputPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > form > fieldset > input")]
        public IWebElement BtnLogin { get; set; }


        //loginpage actions
        //login to merchtool and passes common page object
        public MtHomePageObject Login()
        {
            InputUserName.EnterText("CORP_Webdriver");
            InputPassword.EnterText("ANapPqH<");
            BtnLogin.Click();

            Console.WriteLine("Varified input creds and logged into merchtool");
            return new MtHomePageObject();
        }

        //expected elements
        public void VerifyLoginPageElements()
        {
            var pageElements = new List<IWebElement>
            {
                PageTitle,
                InputUserName,
                InputPassword,
                BtnLogin
            };

            foreach (var element in pageElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified: login page elements");
        }
    }
}
