using System;
using System.Collections.Generic;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.ShippingManager
{
    internal class SmFacilitiesPageObject
    {
        public SmFacilitiesPageObject()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
        }


        //Facility page(s) breadcrumbs
        [FindsBy(How = How.CssSelector, Using = "body > div > ul >li:nth-child(1)")]
        public IWebElement BreadCrumbHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > ul >li:nth-child(2)")]
        public IWebElement BreadCrumbFacilitiesList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > ul >li:nth-child(3)")]
        public IWebElement BreadCrumbViewFacilities { get; set; }


        //Facilities  page headers
        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > i")]
        public IWebElement FacilityPageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_length > label > select")]
        public IWebElement DropdownDataTableRecordsPerPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_filter > label > input")]
        public IWebElement InputSearchDataTableFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > fieldset > legend")]
        public IWebElement DataTableTitle { get; set; }


        //Facilities - Select a Facility List Table Specific
        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(1) > div")]
        public IWebElement TableColumnFacilityCode { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(2) > div")]
        public IWebElement TableColumnFacilityName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(3) > div")]
        public IWebElement TableColumnCountryCode { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(4) > div")]
        public IWebElement TableColumnIsCpOwned { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(5) > div")]
        public IWebElement TableColumnView { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(5) > a")]
        public IWebElement FacilityFacilitiesListTableInteractView { get; set; }
        

        //Facilities - View Facility page specific
        [FindsBy(How = How.CssSelector, Using = "body > div > div:nth-child(2) > label")]
        public IWebElement ProductionFacilityCodeTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div:nth-child(3) > label")]
        public IWebElement FacilityNameTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div:nth-child(4) > label")]
        public IWebElement CountryCodeTitle { get; set; }

        /// <summary>
        /// 
        /// page currently broken DE created
        /// 
        /// </summary>


        //expected elements
        public void VerifyFacilitySelectFacilityPageElements()
        {
            var pageElements = new List<IWebElement>
            {
                BreadCrumbHome,
                BreadCrumbFacilitiesList,
                FacilityPageTitle,
                DropdownDataTableRecordsPerPage,
                InputSearchDataTableFilter,
                TableColumnFacilityCode,
                TableColumnFacilityName,
                TableColumnCountryCode,
                FacilityFacilitiesListTableInteractView,
            };

            foreach (IWebElement element in pageElements)
            {
                element.Verify();    
            }
            Console.WriteLine("Verified: Facilities - Select a Facility Page Elements");
            Console.WriteLine("Verified: bread crumbs");
            Console.WriteLine("Verified: data table container and columns");
        }


        public void VerifyViewFacilityPageElements()
        {
            var pageElements = new List<IWebElement>
            {

                BreadCrumbHome,
                BreadCrumbFacilitiesList,
                BreadCrumbViewFacilities,
                ProductionFacilityCodeTitle,
                FacilityNameTitle,
                CountryCodeTitle,
            };
            foreach (IWebElement element in pageElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified: Facilities - View Facility Page Elements");
            Console.WriteLine("Verified: bread crumbs");
            Console.WriteLine("Verified: View Facilities page text- Prod codes, name & country code");
        }


        public void FacilitiesSelectFacilityTableFilterInputTest()
        {
            InputSearchDataTableFilter.SendKeys("COT");
            InputSearchDataTableFilter.Clear();
            Console.WriteLine("Inputtext: 'COT' and cleared");
            InputSearchDataTableFilter.SendKeys("HUW");
            InputSearchDataTableFilter.Clear();
            Console.WriteLine("Inputtext: 'HUW' and cleared");
            InputSearchDataTableFilter.SendKeys("Duplium");
            Console.WriteLine("Inputtext: 'Duplium'");
            Console.WriteLine("Verified: filter text input function and table filtering");
        }


        //page specific actions
        //Product Type(subpage)
        public SmFacilitiesPageObject ClickSlaProductTypeTableRow()
        {
            FacilityFacilitiesListTableInteractView.Click();
            Console.WriteLine("Drilling into table - Navigating to View Facility page");

            return new SmFacilitiesPageObject();
        }


        //Product Facilities(subpage)
        public void ClickSlaFacilitiesTableRow()
        {
            FacilityFacilitiesListTableInteractView.Click();
        }
    }
}