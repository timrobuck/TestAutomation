using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Autodan
{
    class SMCommonPageObject
    {

        public SMCommonPageObject()
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

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_wrapper")]
        public IWebElement DataTableContainer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_info")]
        public IWebElement DataTableInfo { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".dataTables_paginate.fg-buttonset.ui-buttonset.fg-buttonset-multi.ui-buttonset-multi.paging_bootstrap")]
        public IWebElement DataTablePager { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > p")]
        public IWebElement pageFooterCopyRight { get; set; }

        public void VerifyPersistentNav()
        {
            NavBtnLogOut.Verify();
            NavBtnHome.Verify();
            NavBtnStockStatus.Verify();
            NavBtnSla.Verify();
            Console.WriteLine("Verified persistent navigation elements");
        }

        public void VerifyDataTableOnPage()
        {
            DataTableContainer.Verify();
            DataTableInfo.Verify();
            DataTablePager.Verify();
            Console.WriteLine("Verified presence of data table on page");
        }
    }
}