using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Autodan
{
    class SMStockStatusProductTypePageObject
    {
        public SMStockStatusProductTypePageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        //StockStatus - Product Type subpage
        //breadcrumbs
        [FindsBy(How = How.CssSelector, Using = "body > div > ul > li:nth-child(1) > a")]
        public IWebElement BreadCrumbHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > ul > li.active")]
        public IWebElement BreadCrumbProductType { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > i")]
        public IWebElement PageTitleProductType { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_length > label > select")]
        public IWebElement DropdownDataTableRecordsPerPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_filter > label > input")]
        public IWebElement InputSearchDataTableFilter { get; set; }

        //Product Type Table Specific
        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(1) > div")]
        public IWebElement TableColumnPTN { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(2) > div")]
        public IWebElement TableColumnCaption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(3) > div")]
        public IWebElement TableColumnFacilities { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(3) > a")]
        public IWebElement TableInteractView { get; set; }

        public void VerifyStockStatusProductTypePageElements()
        {
            BreadCrumbHome.Verify();
            BreadCrumbProductType.Verify();
            PageTitleProductType.Verify();
            DropdownDataTableRecordsPerPage.Verify();
            InputSearchDataTableFilter.Verify();
            TableColumnPTN.Verify();
            TableColumnCaption.Verify();
            TableColumnFacilities.Verify();
            TableInteractView.Verify();
            Console.WriteLine("Verified Product Type Page Elements");
        }

        public SMStockStatusProductionFacilitiesPageObject DrillIntoTable()
        {
            TableInteractView.Click();
            Console.WriteLine("Drilling into table - Navigating to Production Facilities page");

            return new SMStockStatusProductionFacilitiesPageObject();
        }

        public void TestTableFilterInput()
        {
            InputSearchDataTableFilter.SendKeys("Mug");
            InputSearchDataTableFilter.Clear();
            Console.WriteLine("Inputtext: 'Mug' and cleared");
            InputSearchDataTableFilter.SendKeys("Shirt");
            InputSearchDataTableFilter.Clear();
            Console.WriteLine("Inputtext: 'Shirt' and cleared");
            InputSearchDataTableFilter.SendKeys("Cup");
            Console.WriteLine("Inputtext: 'Cup'");
        }
    }
}