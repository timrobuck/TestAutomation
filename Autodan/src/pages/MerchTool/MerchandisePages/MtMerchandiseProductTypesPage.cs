using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtMerchProductTypesPage
    {
        void DrillIntoProductTypeTable();
        void ViewTableByAspectRatio();
        void MerchProductTypesTableFilterTest();
    }

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class MtMerchProductTypesPage : BaseTest, IBaseSmokeTest
    {
        public MtMerchProductTypesPage()
        {
            PageFactory.InitElements(Driver, this);
        }

        //ProductTypes sub-page 
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(1)")]
        private IWebElement BreadCrumbHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(2)")]
        private IWebElement BreadCrumbMerch { get; set; }

        //table
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.merch-nav.nav.nav-tabs > li:nth-child(1)")]
        private IWebElement BtnTableByPtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.merch-nav.nav.nav-tabs > li:nth-child(2)")]
        private IWebElement BtnTableByAspectRatio { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > div:nth-child(3) > form > div > input")]
        private IWebElement InputSearchProductTypes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > div > form > div > button")]
        private IWebElement BtnSearchMagGlass { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > div:nth-child(3) > h2")]
        private IWebElement TableHeaderProductTypes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container")]
        private IWebElement TableContainerProductTypes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > div.pagination")]
        private IWebElement TablePagerProductTypes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > table > tbody > tr:nth-child(1) > td:nth-child(2)")]
        private IWebElement ProductTypesTableMug { get; set; }


        //navigation options
        public void DrillIntoProductTypeTable()
        {
            ProductTypesTableMug.Click();
            Console.WriteLine("Verified ProductTypeTableMugClick Action");
        }

        public void ViewTableByAspectRatio()
        {
            BtnTableByAspectRatio.Click();
            Console.WriteLine("Verified AspectRationClick Action ");
        }

        //todo: create public method for InputSearchProductTypes by PTN or Name into filter textbox returning a detail page
        //todo: then write fluent method calls for tests.

        public void MerchProductTypesTableFilterTest()
        {
            InputSearchProductTypes.ClearAndEnterText("Mug");
            BtnSearchMagGlass.Click();
            WaitForAjax();
            TableContainerProductTypes.Verify();
            InputSearchProductTypes.ClearAndEnterText("NoTableTest");
            BtnSearchMagGlass.Click();
            WaitForAjax();
            TableContainerProductTypes.Verify();
            InputSearchProductTypes.ClearAndEnterText("Shirt");
            BtnSearchMagGlass.Click();
            WaitForAjax();
            VerifyElements();
            Console.WriteLine("Verified search input and re-tested table container");
        }

        public void VerifyElements()
        {
            var pageElements = new List<IWebElement>
            {
                BreadCrumbHome,
                BreadCrumbMerch,
                BtnTableByPtn,
                BtnTableByAspectRatio,
                InputSearchProductTypes,
                BtnSearchMagGlass,
                TableHeaderProductTypes,
                TableContainerProductTypes,
                TablePagerProductTypes,
                ProductTypesTableMug,
            };

            foreach (var element in pageElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified ProductType page elements");
        }
       
        public void RunActions()
        {
            throw new NotImplementedException();
        }
    }
}
