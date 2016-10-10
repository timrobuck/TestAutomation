using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtCommonToMerchandisePages
    {
        void VerifyCommonElements();
        void RunCommonActions();
    }

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]//a selenium specificity unhandled by resharper
    public class MtCommonToMerchandisePages : BaseTest, IMtCommonToMerchandisePages
    {
        private readonly string _comsummingPageName;

        public MtCommonToMerchandisePages(string consummingPageName)
        {
            PageFactory.InitElements(Driver, this);
            _comsummingPageName = consummingPageName;
        }

        //common to ProductTypes, Colors, Sizes, ProductCategories, SalesChannels, ShipBoxCategories, ShippingMethods
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(1)")]
        private IWebElement BreadCrumbHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(2)")]
        private IWebElement BreadCrumbForThisPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(2)")]
        private IWebElement TableSelectFromList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > div > a")]
        private IWebElement BtnExportToCsv { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > legend")]
        private IWebElement LegendForTable { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_length > label")]
        private IWebElement LabelShow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_length > label > select")]
        private IWebElement SelectNumberOfEntries { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_length > label > select > option:nth-child(3)")]
        private IWebElement OptionSelected50 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_filter > label")]
        private IWebElement LabelFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_filter > label > input")]
        private IWebElement InputFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_wrapper")]
        private IWebElement Table { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(3)")]
        private IWebElement TableHeaders { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_info")]
        private IWebElement ShowingEntries { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_paginate")]
        private IWebElement BtnSetPagination { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(1) > div > span")]
        private IWebElement SortAscendingDescendingByTableColumnHeaderId { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td.sorting_1")]
        private IWebElement GetTableDataValueFromC1R1 { get; set; }

        public void VerifyCommonElements()
        {
            var pageElements = new List<IWebElement>
            {
                BreadCrumbHome,
                BreadCrumbForThisPage,
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
            Console.WriteLine("Verified common elements on " + _comsummingPageName);
        }

        public void RunCommonActions()
        {
            ActionSelectNumberOfLines();
            ActionSortAscendingDescendingByTableColumnHeaderClick();
        }

        private void ActionSelectNumberOfLines()
        {
            SelectNumberOfEntries.SelectDropdown("50");
            SelectNumberOfEntries.SelectDropdown("10");
            if (!ShowingEntries.Text.Contains("10"))
                throw new Exception("Select Number Of Lines to Show [50 to 10] on table did not work");

            Console.WriteLine("Verified the dropdown to change number of lines visible on table from 50 to 10 on " + _comsummingPageName);
        }

        private void ActionSortAscendingDescendingByTableColumnHeaderClick()
        {
            var beforeSortValue = GetTableDataValueFromC1R1.Text;
            SortAscendingDescendingByTableColumnHeaderId.Click();
            var afterSortValue = GetTableDataValueFromC1R1.Text;
            if (beforeSortValue == afterSortValue)
                throw new Exception("Resorting items does not appear to work. ");

            Console.WriteLine("Verified Resorting records from column header works. ");
        }
    }
}
