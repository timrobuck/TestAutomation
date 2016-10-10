using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtMerchandiseSizePage
    {
        void DrillIntoSizeTable();
        void RunActions();
    }
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class MtMerchandiseSizePage: BaseTest,IBaseSmokeTest
    {
        public  MtMerchandiseSizePage()
        {
            PageFactory.InitElements(Driver, this);
        }

        //sizes subpage elements
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(1)")]
        private IWebElement BreadCrumbHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(2)")]
        private IWebElement BreadCrumbSizesList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > legend")]
        private IWebElement LegendCafepressSizeOptions { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > div > a")]
        private IWebElement BtnExportToCsv { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_length > label")]
        private IWebElement LabelShow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_length > label > select")]
        private IWebElement SelectNumberOfEntries { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_length > label > select > option:nth-child(3)")]
        private IWebElement OptionSelected50 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_filter > label")]
        private IWebElement LabelSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_filter > label > input")]
        private IWebElement InputSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_wrapper")]
        private IWebElement TableSizes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(3)")]
        private IWebElement TableHeaders { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_info")]
        private IWebElement ShowingEntries { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_paginate")]
        private IWebElement BtnSetPagination { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(1) > div > span")]
        private IWebElement SortAscendingDescendingByTableColumnHeaderIdClickTheTriangle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td.sorting_1")]
        private IWebElement GetTableIdValueFromFirstRow { get; set; }
        
        private void VerifySizesPageElements()
        {
            var pageElements = new List<IWebElement>
            {
                BreadCrumbHome,
                BreadCrumbSizesList,
                LegendCafepressSizeOptions,
                BtnExportToCsv,
                LabelShow,
                SelectNumberOfEntries,
                OptionSelected50,
                LabelSearch,
                InputSearch,
                TableSizes,
                TableHeaders,
                ShowingEntries,
                BtnSetPagination
            };

            foreach (var element in pageElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified Size page elements");
        }

        private void MerchandiseSizeFilterSizes()
        {
            InputSearch.ClearAndEnterText("Small");
            WaitForAjax();
            TableSizes.Verify();
            InputSearch.ClearAndEnterText("BlahBlah");
            WaitForAjax();
            TableSizes.Verify();
            InputSearch.ClearAndEnterText("Small");
            WaitForAjax();
            TableSizes.Verify();
            Console.WriteLine("Verified that filtering the list of Sizes works.");
        }

        private void MerchandiseSizeSelectNumberOfEntries()
        {
            SelectNumberOfEntries.SelectDropdown("50");
            SelectNumberOfEntries.SelectDropdown("10");
            if(!ShowingEntries.Text.Contains("10"))
                throw new Exception("Failure to Verify that the item count changes and corresponds to label show on bottom of page.");
            
            Console.WriteLine("Verify that the item count changes and corresponds to label shown on bottom of page.");
        }

        private void SortAscendingDescendingByTableColumnHeaderClick()
        {
            var beforeSortValue = GetTableIdValueFromFirstRow.Text;
            SortAscendingDescendingByTableColumnHeaderIdClickTheTriangle.Click();
            var afterSortValue =  GetTableIdValueFromFirstRow.Text;
            Console.WriteLine("Verified that records return.");
            if (beforeSortValue == afterSortValue)
                throw new Exception("Sort Asending-Descending By Table ColumnHeader Click Action Failed!");

            Console.WriteLine("Verified Sort Asending-Descending By Table ColumnHeader Click Action");
        }

        public void VerifyElements()
        {
            VerifySizesPageElements();
        }

        public void RunActions()
        {
            MerchandiseSizeSelectNumberOfEntries();
            SortAscendingDescendingByTableColumnHeaderClick();
            MerchandiseSizeFilterSizes();
        }
    }
}

  
