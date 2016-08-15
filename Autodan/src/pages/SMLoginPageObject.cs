using OpenQA.Selenium;
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

        //login page elements
        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > form > button")]
        public IWebElement btnLogin { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > header > div > div > h3")]
        public IWebElement pageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".container>p")]
        public IWebElement pageFooter { get; set; }


        //expected elements
        public void VerifyLoginPageElements()
        {
            txtUserName.Verify();
            txtPassword.Verify();
            btnLogin.Verify();
            pageTitle.Verify();
            pageFooter.Verify();
            Console.WriteLine("Verified: Login Page Elements");
        }


        //login page actions
        public SMCommonPageObject Login()
        {
            //username + pw + submit
            txtUserName.SendKeys("dpeterson");
            txtPassword.SendKeys("ADano!#1519!#");
            btnLogin.Submit();

            Console.WriteLine("input credentials, logged into Shipping Manager");

            //return page object
            return new SMCommonPageObject();
        }

        //public SMDashboardPageObject Login(string userName, string password)
        //{
        //    //username
        //    txtUserName.SendKeys(userName);
        //    //password
        //    txtPassword.SendKeys(password);
        //    //click btn
        //    btnLogin.Submit();

        //    Console.WriteLine("Credentials provided, logging into Shipping Manager");

        //    //return page object
        //    return new SMDashboardPageObject();
        //}
    }
}
