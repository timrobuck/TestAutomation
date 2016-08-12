using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NUnit.Core.NUnitFramework;

namespace Autodan
{
    class SMDashboardPageObject
    {

        public SMDashboardPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        //navigation elements
        [FindsBy(How = How.CssSelector, Using = "#logout > a")]
        public IWebElement NavBtnLogOut { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > header > div > nav > ul > li.active > a")]
        public IWebElement NavBtnHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > header > div > nav > ul > li:nth-child(2) > a")]
        public IWebElement NavBtnStockStatus { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > header > div > nav > ul > li:nth-child(3) > a")]
        public IWebElement NavBtnSla { get; set; }

        //dashboard page links
        [FindsBy(How = How.CssSelector, Using = "body > div > div.home-button.stock-status")]
        public IWebElement BtnStockStatusBlock { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div.home-button.sla")]
        public IWebElement BtnServiceLevelAgreementBlock { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div.home-button.facilities")]
        public IWebElement BtnFacilitesBlock { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div.home-button.reports")]
        public IWebElement BtnReportsBlock { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#thisSelectorDoesntExist")]
        public IWebElement TestSelector { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > header > div > div.navbar-header.navbar-left > h3")]
        public IWebElement PageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > p")]
        public IWebElement PageFooter { get; set; }

        public void NavigateToStockStatus()
        {
            BtnStockStatusBlock.Click();
        }

        public SMStockStatusProductTypePageObject NavToStockStatusProductType()
        {
            BtnStockStatusBlock.Click();
            Console.WriteLine("Navigating to Product Type page");

            return new SMStockStatusProductTypePageObject();
        }
        
        public void VerifyDashboardPageElements()
        {
            NavBtnHome.Verify();
            NavBtnLogOut.Verify();
            NavBtnSla.Verify();
            BtnStockStatusBlock.Verify();
            BtnServiceLevelAgreementBlock.Verify();
            BtnFacilitesBlock.Verify();
            BtnReportsBlock.Verify();
            PageTitle.Verify();
            PageFooter.Verify();
            Console.WriteLine("Verified Dashboard Page Elements");
        }
    }
}
