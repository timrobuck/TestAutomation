using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtMerchProductTypesByPtnPage
    {
        void DrillIntoProductTypeTable();
        void ViewTableByAspectRatio();
        void MerchProductTypesTableFilterTest();
        IMtMerchProductTypesByPtnPage NavigateToProductTypesByPtnPage();
        IMtMerchProductTypesByAspectRatioPage NavigateToProductTypesByAspectRatioPage();
        IMtMerchandiseProductTypeDetailPage NavigateToProductTypeDetailsPageByClickOnRow();
        void NavigateToProductTypeDetailsPageBySearchInput(int ptn);
    }

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class MtMerchProductTypesByPtnPage : BaseTest, IBaseSmokeTest, IMtMerchProductTypesByPtnPage
    {
        private readonly IMtMerchandiseProductTypeDetailPage _detailsPage;
        private readonly IMtMerchProductTypesByAspectRatioPage _aspectRationPage;

        public MtMerchProductTypesByPtnPage() :this(new MtMerchProductTypesByAspectRatioPage(), new  MtMerchandiseProductTypeDetailPage()) { }
        public MtMerchProductTypesByPtnPage(IMtMerchProductTypesByAspectRatioPage aspectRatioPage,IMtMerchandiseProductTypeDetailPage detailsPage)
        {
            _detailsPage = detailsPage;
            _aspectRationPage = aspectRatioPage;
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

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > table > tbody > tr:nth-child(1)")]
        private IWebElement RowGotoDetailsForThisPageHiddenEvent { get; set; }

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
                RowGotoDetailsForThisPageHiddenEvent
            };

            foreach (var element in pageElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified ProductType page for " + pageElements.Count + " elements");
        }

        public void RunActions()
        {
            throw new NotImplementedException();
        }

        public IMtMerchProductTypesByPtnPage NavigateToProductTypesByPtnPage()
        {
            BtnTableByPtn.Click();
            Console.WriteLine("Navigated to ProductTypes page by clicking on the ByPTN tab");
            return this;
        }
        public IMtMerchProductTypesByAspectRatioPage NavigateToProductTypesByAspectRatioPage()
        {
            BtnTableByAspectRatio.Click();
            Console.WriteLine("Navigated to AspectRatioPage by clicking on the ByApectRatio tab");
            return _aspectRationPage;
        }

        public IMtMerchandiseProductTypeDetailPage NavigateToProductTypeDetailsPageByClickOnRow()
        {
            RowGotoDetailsForThisPageHiddenEvent.Click();
            Console.WriteLine("Navigated to detail page by selecting the first row item ");
            return _detailsPage;
        }

        public void NavigateToProductTypeDetailsPageBySearchInput(int ptn)
        {
            InputSearchProductTypes.ClearAndEnterText(ptn.ToString());
            BtnSearchMagGlass.Click();
            WaitForAjax();
            Console.WriteLine("Navigated to detail page using the search input for ptn =" + ptn);
        }
    }
}
