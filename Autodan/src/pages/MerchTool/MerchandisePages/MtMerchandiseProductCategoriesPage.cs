using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtMerchandiseProductCategoriesPage
    {
        void VerifyElements();
        void RunActions();
    }

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class MtMerchandiseProductCategoriesPage : BaseTest, IBaseSmokeTest
    {
        private readonly IMtCommonToMerchandisePages _common;

        public MtMerchandiseProductCategoriesPage() : this(new MtCommonToMerchandisePages("Product Categories Page")) { }
        public MtMerchandiseProductCategoriesPage(IMtCommonToMerchandisePages common)
        {
            _common = common;
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(2)")]
        private IWebElement BreadCrumbAllProductCategoriesList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td.sorting_1")]
        private IWebElement GetTableIdValueFromFirstRow { get; set; }

        public void VerifyElements()
        {
            var pageElements = new List<IWebElement>
            {
                BreadCrumbAllProductCategoriesList,
                GetTableIdValueFromFirstRow
            };
            foreach (var element in pageElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified ProductCategories page elements");
            VarifyElementsCommonToPage();
        }

        private void VarifyElementsCommonToPage()
        {
            _common.VerifyCommonElements();
        }

        public void RunActions()
        {
            _common.RunCommonActions();
        }
    }
}