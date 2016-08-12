using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Autodan
{
    class SMStockStatusProductionFacilitiesPageObject
    {
        public SMStockStatusProductionFacilitiesPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        //StockStatus - Product Type subpage
        //breadcrumbs
        [FindsBy(How = How.CssSelector, Using = "body > div > ul > li:nth-child(1) > a")]
        public IWebElement BreadCrumbHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > ul > li:nth-child(2) > a")]
        public IWebElement BreadCrumbProductType { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > ul > li.active")]
        public IWebElement BreadCrumbFacilitiesList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > legend")]
        public IWebElement PageTitleProductionFacilities { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_length > label > select")]
        public IWebElement DropdownDataTableRecordsPerPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_filter > label > input")]
        public IWebElement InputSearchDataTableFilter { get; set; }

        //Product Type Table Specific
        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(1) > div")]
        public IWebElement TableColumnFacilityName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(2) > div")]
        public IWebElement TableColumnCountryCode { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(3) > div")]
        public IWebElement TableColumnIsOwnedByCafePress { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(4) > div")]
        public IWebElement TableColumnStockStatus { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(4) > a")]
        public IWebElement TableInteractView { get; set; }

        public void VerifyStockStatusProductionFacilitiesPageElements()
        {
            BreadCrumbHome.Verify();
            BreadCrumbProductType.Verify();
            PageTitleProductionFacilities.Verify();
            DropdownDataTableRecordsPerPage.Verify();
            InputSearchDataTableFilter.Verify();
            TableColumnFacilityName.Verify();
            TableColumnCountryCode.Verify();
            TableColumnIsOwnedByCafePress.Verify();
            TableColumnStockStatus.Verify();
            TableInteractView.Verify();
            Console.WriteLine("Verified Production Facilities specific Page Elements for CUP");
        }

        public void DrillIntoTable()
        {
            TableInteractView.Click();
        }

        public void TestTableFilterInput()
        {
            InputSearchDataTableFilter.SendKeys("Kentucky Production");
            Console.WriteLine("Inputtext: 'Kentucky Production'");
        }
    }
}