using System;
using System.Collections.Generic;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.MerchadisePages
{
    internal class MtMerchProductTypesPageObject : BaseTest
    {
        public MtMerchProductTypesPageObject()
        {
            PageFactory.InitElements(Driver, this);
        }

        //ProductTypes sub-page eles
        //bread
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(1)")]
        public IWebElement BreadCrumbHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(2)")]
        public IWebElement BreadCrumbMerch { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(3)")]
        public IWebElement BreadCrumbMerchDetails { get; set; }

        //table
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.merch-nav.nav.nav-tabs > li:nth-child(1)")]
        public IWebElement BtnTableByPtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.merch-nav.nav.nav-tabs > li:nth-child(2)")]
        public IWebElement BtnTableByAspectRatio { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > div:nth-child(3) > form > div > input")]
        public IWebElement InputSearchProductTypes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > div > form > div > button")]
        public IWebElement BtnSearchMagGlass { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > div:nth-child(3) > h2")]
        public IWebElement TableHeaderProductTypes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container")]
        public IWebElement TableContainerProductTypes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > div.pagination")]
        public IWebElement TablePagerProductTypes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > table > tbody > tr:nth-child(1) > td:nth-child(2)")]
        public IWebElement ProductTypesTableMug { get; set; }


        //navigation options
        public void DrillIntoProductTypeTable()
        {
            ProductTypesTableMug.Click();
        }

        public void ViewTableByAspectRatio()
        {
            BtnTableByAspectRatio.Click();
        }


        //ProductTypes page expected eles
        public void VerifyProductTypesPageElements()
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

            foreach (IWebElement element in pageElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified ProductType page elements");
        }




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
            VerifyProductTypesPageElements();
            Console.WriteLine("Verified search input and re-tested table container");
        }
    }
}
