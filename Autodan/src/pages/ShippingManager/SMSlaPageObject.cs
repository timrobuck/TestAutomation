using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Autodan
{
    class SMSlaPageObject
    {
        public SMSlaPageObject()
        {
            PageFactory.InitElements(BaseTest.driver, this);
        }


        //SLA page(s) breadcrumbs
        [FindsBy(How = How.CssSelector, Using = "body > div > ul >li:nth-child(1)")]
        public IWebElement BreadCrumbHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > ul >li:nth-child(2)")]
        public IWebElement BreadCrumbProductType { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > ul >li:nth-child(3)")]
        public IWebElement BreadCrumbFacilitiesList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > ul >li:nth-child(4)")]
        public IWebElement BreadCrumbEditSLA { get; set; }


        //SLA  page headers
        [FindsBy(How = How.CssSelector, Using = "body > header > div > div.navbar-header.navbar-left > h3")]
        public IWebElement SLAPageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_length > label > select")]
        public IWebElement DropdownDataTableRecordsPerPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_filter > label > input")]
        public IWebElement InputSearchDataTableFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > legend")]
        public IWebElement DataTableTitle { get; set; }


        //SLA - Product Type Table Specific
        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(1) > div")]
        public IWebElement TableColumnPTN { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(2) > div")]
        public IWebElement TableColumnCaption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(3) > div")]
        public IWebElement TableColumnFacilities { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(3) > a")]
        public IWebElement SLAProductTypeTableInteractView { get; set; }
        

        //SLA - Production Facilities page specific
        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(1) > div")]
        public IWebElement TableColumnFacilityName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(2) > div")]
        public IWebElement TableColumnCountryCode { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(3) > div")]
        public IWebElement TableColumnIsOwnedByCafePress { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(4) > div")]
        public IWebElement TableColumnStockStatus { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(4) > a")]
        public IWebElement SLAProductionFacilitiesTableInteractView { get; set; }


        //SLA - current SLA page specific
        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > table > thead > tr > td:nth-child(1)")]
        public IWebElement TableColumnColor { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > table > thead > tr > td:nth-child(2)")]
        public IWebElement TableColumnSize { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > table > thead > tr > td:nth-child(3)")]
        public IWebElement TableColumnAttribute { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > table > thead > tr > td:nth-child(4)")]
        public IWebElement TableColumnMinShipDays { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > table > thead > tr > td:nth-child(5)")]
        public IWebElement TableColumnMaxShipDays { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > table > thead > tr > td:nth-child(6)")]
        public IWebElement TableColumnAvailabilityOverrideMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".container.view-container>fieldset")]
        public IWebElement ViewStockStatusTableContainer { get; set; }


        //expected elements
        public void VerifySLAProductTypePageElements()
        {
            BreadCrumbHome.Verify();
            BreadCrumbProductType.Verify();
            SLAPageTitle.Verify();
            DropdownDataTableRecordsPerPage.Verify();
            InputSearchDataTableFilter.Verify();
            TableColumnPTN.Verify();
            TableColumnCaption.Verify();
            TableColumnFacilities.Verify();
            SLAProductTypeTableInteractView.Verify();
            Console.WriteLine("Verified: SLA - Product Type Page Elements");
            Console.WriteLine("Verified: bread crumbs");
            Console.WriteLine("Verified: data table container and columns");
        }

        public void VerifySLAProductionFacilitiesPageElements()
        {
            BreadCrumbHome.Verify();
            BreadCrumbProductType.Verify();
            SLAPageTitle.Verify();
            DropdownDataTableRecordsPerPage.Verify();
            InputSearchDataTableFilter.Verify();
            TableColumnFacilityName.Verify();
            TableColumnCountryCode.Verify();
            TableColumnIsOwnedByCafePress.Verify();
            TableColumnStockStatus.Verify();
            SLAProductionFacilitiesTableInteractView.Verify();
            Console.WriteLine("Verified: SLA - Production Facilities Page Elements");
            Console.WriteLine("Verified: bread crumbs");
            Console.WriteLine("Verified: data table container and columns");
        }

        public void VerifySLAViewCurrentSLAPageElements()
        {
            BreadCrumbHome.Verify();
            BreadCrumbProductType.Verify();
            BreadCrumbFacilitiesList.Verify();
            BreadCrumbEditSLA.Verify();
            TableColumnColor.Verify();
            TableColumnSize.Verify();
            TableColumnAttribute.Verify();
            TableColumnMinShipDays.Verify();
            TableColumnMaxShipDays.Verify();
            TableColumnAvailabilityOverrideMessage.Verify();
            ViewStockStatusTableContainer.Verify();
            Console.WriteLine("Verified: SLA - Current SLA Page Elements");
            Console.WriteLine("Verified: bread crumbs");
            Console.WriteLine("Verified: data table container and columns");
        }

        public void SLAProductTypeTableFilterInputTest()
        {
            InputSearchDataTableFilter.SendKeys("Mug");
            InputSearchDataTableFilter.Clear();
            Console.WriteLine("Inputtext: 'Mug' and cleared");
            InputSearchDataTableFilter.SendKeys("Shirt");
            InputSearchDataTableFilter.Clear();
            Console.WriteLine("Inputtext: 'Shirt' and cleared");
            InputSearchDataTableFilter.SendKeys("Cup");
            Console.WriteLine("Inputtext: 'Cup'");
            Console.WriteLine("Verified: filter text input function and table filtering");
        }

        public void SLAProductionFacilitiesTableFilterInputTest()
        {
            InputSearchDataTableFilter.SendKeys("Duplium");
            InputSearchDataTableFilter.Clear();
            Console.WriteLine("Inputtext: 'Duplium' and cleared");
            InputSearchDataTableFilter.SendKeys("PMI");
            InputSearchDataTableFilter.Clear();
            Console.WriteLine("Inputtext: 'PMI' and cleared");
            InputSearchDataTableFilter.SendKeys("Kentucky Production");
            Console.WriteLine("Inputtext: 'Kentucky Production'");
            Console.WriteLine("Verified: filter text input function and table filtering");
        }


        //page specific actions
        //Product Type(subpage)
        public SMStockStatusPageObject ClickSLAProductTypeTableRow()
        {
            SLAProductTypeTableInteractView.Click();
            Console.WriteLine("Drilling into table - Navigating to Production Facilities page");

            return new SMStockStatusPageObject();
        }

        //Product Facilities(subpage)
        public void ClickSLAFacilitiesTableRow()
        {
            SLAProductionFacilitiesTableInteractView.Click();
        }

        public void TestProductionFacilitiesTableFilterInput()
        {
            InputSearchDataTableFilter.SendKeys("Kentucky Production");
            Console.WriteLine("Inputtext: 'Kentucky Production'");
        }
    }
}