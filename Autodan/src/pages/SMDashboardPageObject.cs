using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public IWebElement btnLogOut { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > header > div > nav > ul > li.active > a")]
        public IWebElement btnHome { get; set; }

        [FindsBy(How = How.Name, Using = "body > header > div > nav > ul > li:nth-child(2) > a")]
        public IWebElement btnStockStatus { get; set; }

        [FindsBy(How = How.Name, Using = "body > header > div > nav > ul > li:nth-child(3) > a")]
        public IWebElement btnSla { get; set; }

        //dashboard page links
        [FindsBy(How = How.CssSelector, Using = "body > div > div.home-button.stock-status")]
        public IWebElement btnStockStatusBlock { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div.home-button.sla")]
        public IWebElement btnServiceLevelAgreementBlock { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div.home-button.facilities")]
        public IWebElement btnFacilitesBlock { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div.home-button.reports")]
        public IWebElement btnReportsBlock { get; set; }


        ////public void FillUserForm(string initial, string firstName, string middleName)
        ////{
        ////    txtInitial.EnterText(initial);

        ////    txtFirstName.EnterText(firstName);
        ////    txtMiddleName.EnterText(middleName);
        ////    btnSave.Clicks();

            //SeleniumSetMethods.EnterText(txtInitial, initial);
            //SeleniumSetMethods.EnterText(txtFirstName, firstName);
            //SeleniumSetMethods.EnterText(txtMiddleName, middleName);
            //SeleniumSetMethods.Click(btnSave);

            //txtInitial.SendKeys(initial);
            //txtFirstName.SendKeys(firstName);
            //txtMiddleName.SendKeys(middleName);
            //btnSave.Click();
        }
    }
