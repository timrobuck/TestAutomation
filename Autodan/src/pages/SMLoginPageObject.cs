﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Autodan
{
    class SMLoginPageObject
    {
        public SMLoginPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > form > button")]
        public IWebElement loginBtn { get; set; }


        public SMDashboardPageObject Login(string userName, string password)
        {
            //username
            txtUserName.SendKeys(userName);
            //password
            txtPassword.SendKeys(password);
            //click btn
            loginBtn.Submit();

            //return page object
            return new SMDashboardPageObject();

        }
    }
}
