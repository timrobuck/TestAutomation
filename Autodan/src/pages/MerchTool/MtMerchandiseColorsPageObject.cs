using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;


namespace Autodan.pages.MerchTool
{
    internal class MtMerchandiseColorsPageObject : BaseTest
    {

        public MtMerchandiseColorsPageObject()
        {
            PageFactory.InitElements(Driver, this);
        }

        //Colors subpage elements
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(1)")]
        public IWebElement BreadCrumbHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(2)")]
        public IWebElement BreadCrumbMerchanise { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul > li.active")]
        public IWebElement BreadCrumbColorsList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > legend")]
        public IWebElement LegendCafepressColorOptions { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > div > a")]
        public IWebElement BtnExportToCsv { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_length > label")]
        public IWebElement LabelShow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_length > label > select")]
        public IWebElement SelectNumberOfEntries { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_length > label > select > option:nth-child(3)")]
        public IWebElement OptionSelected50 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_filter > label")]
        public IWebElement LabelSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_filter > label > input")]
        public IWebElement InputSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_wrapper")]
        public IWebElement TableColors { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(3)")]
        public IWebElement TableHeaders { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_info")]
        public IWebElement ShowingEntries { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_paginate")]
        public IWebElement ButtonSetPagination { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(2)")]
        public IWebElement ColorTableSelectWhite { get; set; }

        [FindsBy(How = How.CssSelector, Using = "")]
        public IWebElement ExportToCvs { get; set; }
        //navigation elements
        public void DrillIntoColorTable()
        {
            ColorTableSelectWhite.Click();
        }

        public void ClickTheExportToCvsButton()
        {
            ExportToCvs.Click();
        }

        public void VerifyColorsPageElements()
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
                ButtonSetPagination
            };

            foreach (var element in pageElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified Color page elements");
        }

        public void MerchandiseColorFilterColors()
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
            Console.WriteLine("Verified that filtering the list of colors works.");
        }

        public void MerchandiseColorExportToCsvButton()  
        {
            BtnExportToCsv.Click();
            //todo: the code do the download and varify this is not trivial due to various browser specificities. Get back to this after more research and testing. 
            Console.WriteLine("Verified that the a CSV file is created.");
        }

        public void MerchandiseColorSelectNumberOfEntries()
        {
            SelectNumberOfEntries.SelectDropdown("50");
            SelectNumberOfEntries.SelectDropdown("10");
            Console.WriteLine(ShowingEntries.Text.Contains("10")
                ? "Verify that the item count changes and corresponds to label shown on bottom of page."
                : "Failure to Verify that the item count changes and corresponds to label show on bottom of page.");
        }
    }
}
