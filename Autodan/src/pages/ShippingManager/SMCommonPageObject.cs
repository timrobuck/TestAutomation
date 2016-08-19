using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Autodan
{
    class SMCommonPageObject
    {

        public SMCommonPageObject()
        {
            PageFactory.InitElements(BaseTest.driver, this);
        }


        //common+shared navigation elements
        [FindsBy(How = How.CssSelector, Using = "#logout > a")]
        public IWebElement NavBtnLogOut { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > header > div > nav > ul > li:nth-child(1) > a")]
        public IWebElement NavBtnHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > header > div > nav > ul > li:nth-child(2) > a")]
        public IWebElement NavBtnStockStatus { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > header > div > nav > ul > li:nth-child(3) > a")]
        public IWebElement NavBtnSla { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > header > div > div.navbar-header.navbar-left > h3")]
        public IWebElement SMTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_wrapper")]
        public IWebElement DataTableContainer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_info")]
        public IWebElement DataTableInfo { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".dataTables_paginate.fg-buttonset.ui-buttonset.fg-buttonset-multi.ui-buttonset-multi.paging_bootstrap")]
        public IWebElement DataTablePager { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > p")]
        public IWebElement pageFooterCopyRight { get; set; }


        //dashboard page elements
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


        //expected elements
        public void VerifyPersistentNav()
        {
            NavBtnLogOut.Verify();
            NavBtnHome.Verify();
            NavBtnStockStatus.Verify();
            NavBtnSla.Verify();
            Console.WriteLine("Verified: persistent navigation elements");
        }

        public void VerifyDataTableOnPage()
        {
            DataTableContainer.Verify();
            DataTableInfo.Verify();
            DataTablePager.Verify();
            Console.WriteLine("Verified: presence of data table on page");
            Console.WriteLine("Verified: data table pager");
            Console.WriteLine("Verified: data table info footer");
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
            Console.WriteLine("Verified: dashboard page elements");
            Console.WriteLine("Verified: page navigation elements");
        }


        //common+shared actions
        //dashboard navigation
        public SMStockStatusPageObject NavigateToStockStatus()
        {
            BtnStockStatusBlock.Click();
            Console.WriteLine("Navigating to Stock Status - Product Type");

            //returns page object
            return new SMStockStatusPageObject();
        }

        public SMSlaPageObject NavigateToSLA()
        {
            BtnServiceLevelAgreementBlock.Click();
            Console.WriteLine("Navigating to SLA - Product Type");

            //returns page object
            return new SMSlaPageObject();
        }

        public SMReportsPageObject NavigateToReports()
        {
            BtnReportsBlock.Click();
            Console.WriteLine("Navigating to Reports - View Reports");

            //returns page object
            return new SMReportsPageObject();
        }

        public SMFacilitiesPageObject NavigateToFacilities()
        {
            BtnFacilitesBlock.Click();
            Console.WriteLine("Navigating to SLA - Select a Facility");

            //return page object
            return new SMFacilitiesPageObject();
        }
    }
}