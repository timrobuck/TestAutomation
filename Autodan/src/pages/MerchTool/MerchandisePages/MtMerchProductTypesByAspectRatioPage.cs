using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtMerchProductTypesByAspectRatioPage
    {
        void VerifyElements();
        void VerifyElementContent();
        void RunActions();
    }

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class MtMerchProductTypesByAspectRatioPage : BaseTest, IBaseSmokeTest, IMtMerchProductTypesByAspectRatioPage
    {
        private readonly IMtCommonToMerchandisePages _commonPage;
        private readonly string _className;

        public MtMerchProductTypesByAspectRatioPage() : this(new MtCommonToMerchandisePages(" ProductTypesByAspectRationPage ")) { }
        public MtMerchProductTypesByAspectRatioPage(IMtCommonToMerchandisePages commonPage)
        {
            PageFactory.InitElements(Driver, this);
            _commonPage = commonPage;
            _className = GetType().ToString();
        }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.merch-nav.nav.nav-tabs > li:nth-child(1) > a")]
        private IWebElement TabByPtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.merch-nav.nav.nav-tabs > li.active > a")]
        private IWebElement TabByAspectRatio { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(1) > div")]
        private IWebElement ColumnHeader1 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(2) > div")]
        private IWebElement ColumnHeader2 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(3) > div")]
        private IWebElement ColumnHeader3 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(4) > div")]
        private IWebElement ColumnHeader4 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(5) > div")]
        private IWebElement ColumnHeader5 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(6) > div")]
        private IWebElement ColumnHeader6 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(7) > div")]
        private IWebElement ColumnHeader7 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(8) > div")]
        private IWebElement ColumnHeader8 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(2)")]
        public IWebElement Row1Column2Content { get; set; }

        public void VerifyElements()
        {
            VerifyElementsUniqueToPage();
            VarifyElementsCommonToPage();
        }

        public void VerifyElementContent()
        {
            ColumnHeader1.VerifyTextIsInThisElement("PTN");
            ColumnHeader2.VerifyTextIsInThisElement("Name");
            ColumnHeader3.VerifyTextIsInThisElement("Orientation");
            ColumnHeader4.VerifyTextIsInThisElement("Perspective");
            ColumnHeader5.VerifyTextIsInThisElement("Media Region");
            ColumnHeader6.VerifyTextIsInThisElement("Aspect Ratio");
            ColumnHeader7.VerifyTextIsInThisElement("Width");
            ColumnHeader8.VerifyTextIsInThisElement("Height");
            Console.WriteLine("Verified page header elements have expected values on " + _className);
        }

        public void RunActions()
        {
            _commonPage.RunCommonActions();
            VerifyThatNavigationTabsWork();
        }

        private void VerifyThatNavigationTabsWork()
        {
            GotoProductTypesByPtnPage();
            //todo: create an IsAt call then verify
            GotoProductTypesByAspectRatioPage();
            Console.WriteLine("Verified that navigation tabs work.");
        }

        public IMtMerchProductTypesByPtnPage GotoProductTypesByPtnPage()
        {
            TabByPtn.Click();
            return new MtMerchProductTypesByPtnPage();
        }
        public IMtMerchProductTypesByPtnPage GotoProductTypesByAspectRatioPage()
        {
            TabByAspectRatio.Click();
            return new MtMerchProductTypesByPtnPage();
        }
       
        private void VerifyElementsUniqueToPage()
        {
            var pageElements = new List<IWebElement>
            {
                ColumnHeader1,
                ColumnHeader2,
                ColumnHeader3,
                ColumnHeader4,
                ColumnHeader5,
                ColumnHeader6,
                ColumnHeader7,
                ColumnHeader8
            };

            foreach(var e in pageElements)
                e.Verify();
        
            Console.WriteLine(" Verified page elements on " + _className);
        }

        private void VarifyElementsCommonToPage()
        {
            _commonPage.VerifyCommonElements();
            Console.WriteLine("Verified common elements on " + _className);
        }
    }
}
