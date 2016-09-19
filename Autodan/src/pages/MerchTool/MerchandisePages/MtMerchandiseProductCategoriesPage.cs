using System;
using System.Collections.Generic;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public class MtMerchandiseProductCategoriesPage : BaseTest
    {
        public MtMerchandiseProductCategoriesPage()
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector,
            Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(2)")]
        public IWebElement BreadCrumbAllProductCategoriesList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td.sorting_1")]
        public IWebElement GetTableIdValueFromFirstRow { get; set; }

        public void VerifyElements()
        {
            VerifyElementsUniqueToPage();
            VarifyElementsCommonToPage();
        }

        private void VerifyElementsUniqueToPage()
        {
            var pageElements = new List<IWebElement>
            {
                BreadCrumbAllProductCategoriesList,
                GetTableIdValueFromFirstRow
                //todo:Varify that string "All Product Categories" returns for this page
            };
            foreach (var element in pageElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified ProductCategories page elements");
        }

        private void VarifyElementsCommonToPage()
        {
            var page = new MtCommonToMerchandisePages("MtMerchandiseProductCategoriesPage");
            page.VerifyCommonElements();
        }

        public void RunActions()
        {
            RunUniqueActions();
            var page = new MtCommonToMerchandisePages("MtMerchandiseProductCategoriesPage");
            page.RunCommonActions();
        }

        private void RunUniqueActions()
        {
            //todo:revisit this page for unique actions
        }
    }
}