using System;
using System.Collections.Generic;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.MerchadisePages
{
    public class MtCommonToMerchandisePages:BaseTest
    {
        private readonly string _comsummingPageName;

        public  MtCommonToMerchandisePages(string consummingPageName)
        {
            PageFactory.InitElements(Driver, this);
            _comsummingPageName = consummingPageName;
        }

        //common to ProductTypes, Colors, Sizes, ProductCategories, SalesChannels, ShipBoxCategories, ShippingMethods
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(1)")]
        public IWebElement BreadCrumbHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(2)")]
        public IWebElement BreadCrumbForThisPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td.sorting_1")]
        public IWebElement TableFirstRow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(2)")]
        public IWebElement TableSelectFromList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > div > a")]
        public IWebElement BtnExportToCsv { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > legend")]
        public IWebElement LegendForTable { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_length > label")]
        public IWebElement LabelShow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_length > label > select")]
        public IWebElement SelectNumberOfEntries { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_length > label > select > option:nth-child(3)")]
        public IWebElement OptionSelected50 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_filter > label")]
        public IWebElement LabelFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_filter > label > input")]
        public IWebElement InputFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_wrapper")]
        public IWebElement Table { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(3)")]
        public IWebElement TableHeaders { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_info")]
        public IWebElement ShowingEntries { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_paginate")]
        public IWebElement BtnSetPagination { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(1) > div > span")]
        public IWebElement SortAscendingDescendingByTableColumnHeaderIdClickTheTriangle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td.sorting_1")]
        public IWebElement GetTableIdValueFromFirstRow { get; set; }

        public void VerifyCommonElements()
        {
            var pageElements = new List<IWebElement>
            {
                BreadCrumbHome,
                TableSelectFromList,
                BtnExportToCsv,
                LegendForTable,
                LabelShow,
                SelectNumberOfEntries,
                OptionSelected50,
                LabelFilter,
                InputFilter,
                Table,
                TableHeaders,
                ShowingEntries,
                BtnSetPagination
            };
            foreach (var element in pageElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified CommonToMerchanise elements for " + _comsummingPageName);
        }


        public void RunCommonActions()
        {
            ExportToCsvButton();
            SelectNumberOfLines();
            SortAscendingDescendingByTableColumnHeaderClick();
        }
        private void ExportToCsvButton()
        {
            BtnExportToCsv.Click();
            //todo: the code do the download and varify this is not trivial due to various browser specificities. Get back to this after more research and testing. 
            Console.WriteLine("Verified that the button to download a CSV file was clicked. " + _comsummingPageName);
        }

        private void SelectNumberOfLines()
        {
            SelectNumberOfEntries.SelectDropdown("50");
            SelectNumberOfEntries.SelectDropdown("10");
            Console.WriteLine(ShowingEntries.Text.Contains("10")
                ? "Verify that the item count changes and corresponds to label shown on bottom of page."
                : "Failure to Verify that the item count changes and corresponds to label show on bottom of page. " + _comsummingPageName);
        }

        private bool SortAscendingDescendingByTableColumnHeaderClick()
        {
            var beforeSortValue = GetTableIdValueFromFirstRow.Text;
            SortAscendingDescendingByTableColumnHeaderIdClickTheTriangle.Click();
            var afterSortValue = GetTableIdValueFromFirstRow.Text;
            if (beforeSortValue == afterSortValue) return false;
            Console.WriteLine("Verified records will sort desc and asc off colunn header " + _comsummingPageName);
            return true;
        }
    }
}
