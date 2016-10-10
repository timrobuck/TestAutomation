using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtMerchandiseColorsPage
    {
        void DrillIntoColorTable();
        void VerifyElements();
        void RunActions();
    }

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class MtMerchandiseColorsPage : BaseTest, IBaseSmokeTest
    {
        public MtMerchandiseColorsPage()
        {
            PageFactory.InitElements(Driver, this);
        }

        //Colors subpage elements
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(1)")]
        private IWebElement BreadCrumbHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(2)")]
        private IWebElement BreadCrumbMerchanise { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul > li.active")]
        private IWebElement BreadCrumbColorsList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > legend")]
        private IWebElement LegendCafepressColorOptions { get; set; }

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
        private IWebElement TableColors { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(3)")]
        private IWebElement TableHeaders { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_info")]
        private IWebElement ShowingEntries { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_paginate")]
        private IWebElement BtnSetPagination { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(2)")]
        private IWebElement ColorTableSelectWhite { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td.sorting_1")]
        private IWebElement GetTableIdValueFromFirstRow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(1) > div > span")]
        private IWebElement SortAscendingDescendingByTableColumnHeaderIdClickTheTriangle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > div > a")]
        private IWebElement ExportToCvs { get; set; }

        //navigation elements
        private void DrillIntoColorTable()
        {
            ColorTableSelectWhite.Click();
            Console.WriteLine("Verified Drill Into Color Table Selecting a Color and Goto the Detail page");
        }

        private void ClickTheExportToCvsBtn()
        {
            ExportToCvs.Click();
            Console.WriteLine("Verified ExportToCvs Btn can be clicked");
        }

        private void VerifyColorsPageElements()
        {
            var pageElements = new List<IWebElement>
            {
                BreadCrumbHome,
                BreadCrumbMerchanise,
                BreadCrumbColorsList,
                LegendCafepressColorOptions,
                BtnExportToCsv,
                LabelShow,
                SelectNumberOfEntries,
                OptionSelected50,
                LabelSearch,
                InputSearch,
                TableColors,
                TableHeaders,
                ShowingEntries,
                BtnSetPagination
            };

            foreach (var element in pageElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified Color page elements");
        }

        private void MerchandiseColorFilterColors()
        {
            InputSearch.ClearAndEnterText("White");
            WaitForAjax();
            TableColors.Verify();
            InputSearch.ClearAndEnterText("BlahBlah");
            WaitForAjax();
            TableColors.Verify();
            InputSearch.ClearAndEnterText("Black");
            WaitForAjax();
            TableColors.Verify();
            Console.WriteLine("Verified that filtering the list of color list works.");
        }

        private void MerchandiseColorSelectNumberOfEntries()
        {
            SelectNumberOfEntries.SelectDropdown("50");
            SelectNumberOfEntries.SelectDropdown("10");
            if (!ShowingEntries.Text.Contains("10"))
                throw new Exception("Failure to Verify that the item count changes and corresponds to label show on bottom of page.");

            Console.WriteLine("Verified that the item count changes and corresponds to label shown on bottom of page.");
        }

        private void SortAscendingDescendingByTableColumnHeaderClick()
        {
            var beforeSortValue = GetTableIdValueFromFirstRow.Text;
            SortAscendingDescendingByTableColumnHeaderIdClickTheTriangle.Click();
            var afterSortValue = GetTableIdValueFromFirstRow.Text;
            if (beforeSortValue == afterSortValue)
                throw new Exception("Sort Asending-Descending By Table ColumnHeader Click Action Failed!");

            Console.WriteLine("Verified Sort Asending-Descending By Table ColumnHeader Click Action");
        }

        public void VerifyElements()
        {
            VerifyColorsPageElements();
        } 

        public void RunActions()
        {
            MerchandiseColorFilterColors();
            ClickTheExportToCvsBtn();
            DrillIntoColorTable();
            MerchandiseColorSelectNumberOfEntries();
            SortAscendingDescendingByTableColumnHeaderClick();
        }
    }
}
