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
        public IWebElement btnStockStatusBlock { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div.home-button.sla")]
        public IWebElement btnServiceLevelAgreementBlock { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div.home-button.facilities")]
        public IWebElement btnFacilitesBlock { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div.home-button.reports")]
        public IWebElement btnReportsBlock { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#thisSelectorDoesntExist")]
        public IWebElement testSelector { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > header > div > div.navbar-header.navbar-left > h3")]
        public IWebElement pageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > p")]
        public IWebElement pageFooter { get; set; }

        public void NavigateToStockStatus()
        {
            btnStockStatusBlock.Click();
        }
        
        public void VerifyDashboardPageElements()
        {
            NavBtnHome.Verify();
            NavBtnLogOut.Verify();
            NavBtnSla.Verify();
            btnStockStatusBlock.Verify();
            btnServiceLevelAgreementBlock.Verify();
            btnFacilitesBlock.Verify();
            btnReportsBlock.Verify();
            pageTitle.Verify();
            pageFooter.Verify();
            Console.WriteLine("Verified Dashboard Page Elements");
        }
    }
}
