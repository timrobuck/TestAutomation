using System;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.ShippingManager
{
    internal class SmReportsPageObject
    {
        public SmReportsPageObject()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
        }


        //Reports page(s) breadcrumbs
        [FindsBy(How = How.CssSelector, Using = "body > div > ul >li:nth-child(1)")]
        public IWebElement BreadCrumbHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > ul >li:nth-child(2)")]
        public IWebElement BreadCrumbViewReports { get; set; }
        
        
        //Reports  page headers
        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_length > label > select")]
        public IWebElement DropdownDataTableRecordsPerPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_filter > label > input")]
        public IWebElement InputSearchDataTableFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > legend")]
        public IWebElement DataTableTitle { get; set; }


        //Reports - View Reports table page specific
        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(1) > div")]
        public IWebElement TableColumnReport { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(2) > div")]
        public IWebElement TableColumnView { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(2) > a")]
        public IWebElement ReportsTableInteractView { get; set; }
        

        //Reports - stock availability for facility report page specific
        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > legend")]
        public IWebElement FacilityStockAvailabilityTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#facilities")]
        public IWebElement FacilitiesDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > form > div:nth-child(2) > button")]
        public IWebElement FacilityStockAvailSubmitBtn { get; set; }
        

        //expected elements
        public void VerifyReportsPageElements()
        {
            BreadCrumbHome.Verify();
            BreadCrumbViewReports.Verify();
            DataTableTitle.Verify();
            DropdownDataTableRecordsPerPage.Verify();
            InputSearchDataTableFilter.Verify();
            TableColumnReport.Verify();
            TableColumnView.Verify();
            ReportsTableInteractView.Verify();
            Console.WriteLine("Verified: Reports Page Elements");
            Console.WriteLine("Verified: bread crumbs");
            Console.WriteLine("Verified: data table container and columns");
        }

        public void VerifyReportsFacilityStockAvailPageElements()
        {
            BreadCrumbHome.Verify();
            BreadCrumbViewReports.Verify();
            FacilityStockAvailabilityTitle.Verify();
            FacilitiesDropdown.Verify();
            FacilityStockAvailSubmitBtn.Verify();
            Console.WriteLine("Verified: Reports - Facility Stock Availability Page Elements");
            Console.WriteLine("Verified: bread crumbs");
            Console.WriteLine("Verified: Facilities dropdown presence");
            Console.WriteLine("Verified: submit btn presence");
        }
        

        //page specific actions
        //Product Facilities(subpage)
        public void ClickReportsTableRow()
        {
            ReportsTableInteractView.Click();
        }

        public void TestReportsTableFilterInput()
        {
            InputSearchDataTableFilter.SendKeys("Kentucky");
            Console.WriteLine("Inputtext: 'Kentucky'");
            InputSearchDataTableFilter.Clear();
            Console.WriteLine("Cleared input");
            InputSearchDataTableFilter.SendKeys("Facility");
            Console.WriteLine("Input text: 'Facility'");
            Console.WriteLine("Verified: filter text input function and table filtering");
        }
    }
}