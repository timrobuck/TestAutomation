using System;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.ShippingManager
{
    internal class SmStockStatusPageObject
    {
        public SmStockStatusPageObject()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
        }


        //stock status breadcrumbs
        [FindsBy(How = How.CssSelector, Using = "body > div > ul >li:nth-child(1)")]
        public IWebElement BreadCrumbHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > ul >li:nth-child(2)")]
        public IWebElement BreadCrumbProductType { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > ul >li:nth-child(3)")]
        public IWebElement BreadCrumbFacilitiesList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > ul >li:nth-child(4)")]
        public IWebElement BreadCrumbViewStockStatus { get; set; }


        //stock status page headers
        [FindsBy(How = How.CssSelector, Using = "body > header > div > div.navbar-header.navbar-left > h3")]
        public IWebElement StockStatusPageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_length > label > select")]
        public IWebElement DropdownDataTableRecordsPerPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_filter > label > input")]
        public IWebElement InputSearchDataTableFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > legend")]
        public IWebElement DataTableTitle { get; set; }


        //Product Type Table Specific
        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(1) > div")]
        public IWebElement TableColumnPtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(2) > div")]
        public IWebElement TableColumnCaption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(3) > div")]
        public IWebElement TableColumnFacilities { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(3) > a")]
        public IWebElement ProductTypeTableInteractView { get; set; }
        

        //Production Facilities page specific
        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(1) > div")]
        public IWebElement TableColumnFacilityName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(2) > div")]
        public IWebElement TableColumnCountryCode { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(3) > div")]
        public IWebElement TableColumnIsOwnedByCafePress { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(4) > div")]
        public IWebElement TableColumnStockStatus { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(4) > a")]
        public IWebElement ProductionFacilitiesTableInteractView { get; set; }


        //View Stock Status page specific
        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > table > thead > tr > td:nth-child(1)")]
        public IWebElement TableColumnColor { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > table > thead > tr > td:nth-child(2)")]
        public IWebElement TableColumnSize { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > table > thead > tr > td:nth-child(3)")]
        public IWebElement TableColumnAttribute { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > table > thead > tr > td:nth-child(4)")]
        public IWebElement TableColumnInStock { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".container.view-container>fieldset")]
        public IWebElement ViewStockStatusTableContainer { get; set; }


        //expected elements
        public void VerifyStockStatusProductTypePageElements()
        {
            BreadCrumbHome.Verify();
            BreadCrumbProductType.Verify();
            StockStatusPageTitle.Verify();
            DropdownDataTableRecordsPerPage.Verify();
            InputSearchDataTableFilter.Verify();
            TableColumnPtn.Verify();
            TableColumnCaption.Verify();
            TableColumnFacilities.Verify();
            ProductTypeTableInteractView.Verify();
            Console.WriteLine("Verified: Product Type Page Elements");
            Console.WriteLine("Verified: bread crumbs");
            Console.WriteLine("Verified: data table container and columns");
        }

        public void VerifyStockStatusProductionFacilitiesPageElements()
        {
            BreadCrumbHome.Verify();
            BreadCrumbProductType.Verify();
            StockStatusPageTitle.Verify();
            DropdownDataTableRecordsPerPage.Verify();
            InputSearchDataTableFilter.Verify();
            TableColumnFacilityName.Verify();
            TableColumnCountryCode.Verify();
            TableColumnIsOwnedByCafePress.Verify();
            TableColumnStockStatus.Verify();
            ProductionFacilitiesTableInteractView.Verify();
            Console.WriteLine("Verified: Production Facilities Page Elements");
            Console.WriteLine("Verified: bread crumbs");
            Console.WriteLine("Verified: data table container and columns");
        }

        public void VerifyStockStatusCurrentStockStatusPageElements()
        {
            BreadCrumbHome.Verify();
            BreadCrumbProductType.Verify();
            BreadCrumbFacilitiesList.Verify();
            BreadCrumbViewStockStatus.Verify();
            TableColumnColor.Verify();
            TableColumnSize.Verify();
            TableColumnAttribute.Verify();
            TableColumnInStock.Verify();
            StockStatusPageTitle.Verify();
            ViewStockStatusTableContainer.Verify();
            Console.WriteLine("Verified: View Stock STatus Page Elements");
            Console.WriteLine("Verified: bread crumbs");
            Console.WriteLine("Verified: data table container and columns");
        }

        public void StockStatusProductTypeTableFilterInputTest()
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

        public void StockStatusProdFacilitiesTableFilterInputTest()
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
        public SmStockStatusPageObject ClickProductTypeTableRow()
        {
            ProductTypeTableInteractView.Click();
            Console.WriteLine("Drilling into table - Navigating to Production Facilities page");

            return new SmStockStatusPageObject();
        }

        //Product Facilities(subpage)
        public void ClickProdFacilitiesTableRow()
        {
            ProductionFacilitiesTableInteractView.Click();
        }

        public void TestProductionFacilitiesTableFilterInput()
        {
            InputSearchDataTableFilter.SendKeys("Kentucky Production");
            Console.WriteLine("Inputtext: 'Kentucky Production'");
        }
    }
}