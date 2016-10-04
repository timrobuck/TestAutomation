using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtMerchandiseShipBoxCategoriesPage
    {
        void VerifyElements();
        void VerifyElementContent();
        void RunActions();
        IMtMerchandiseShipBoxCategoriesDetailsPage GotToDetailsPage();
    }

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    internal class MtMerchandiseShipBoxCategoriesPage : BaseTest, IBaseSmokeTest
    {
        private readonly string _className;
        private readonly string _pageName = "ShipBox Categories";
        private readonly IMtCommonToMerchandisePages _common;
        private readonly IMtMerchandiseShipBoxCategoriesDetailsPage _details;

        public MtMerchandiseShipBoxCategoriesPage() : this(new MtCommonToMerchandisePages(" ShipBox Categories Page "), new MtMerchandiseShipBoxCategoriesDetailsPage()){}

        public MtMerchandiseShipBoxCategoriesPage(IMtCommonToMerchandisePages common, IMtMerchandiseShipBoxCategoriesDetailsPage details)
        {
            PageFactory.InitElements(Driver, this);
            _className = GetType().Name;
            _common = common;
            _details = details;
        }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(1) > div")]
        private IWebElement ColumnHeaderId { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(2) > div")]
        private IWebElement ColumnHeaderName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(3) > div")]
        private IWebElement ColumnHeaderDetails { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(3) > a")]
        private IWebElement GotoDetailPageOnFirstRow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(2)")]
        public IWebElement Row1Column2Content { get; set; }

        public void VerifyElements()
        {
            VerifyElementsUniqueToPage();
            VarifyElementsCommonToPage();
        }

        public void VerifyElementContent()
        {
            throw new NotImplementedException();
        }

        public void VerifyElementHasValue()
        {
            ColumnHeaderId.VerifyTextIsInThisElement("Id");
            ColumnHeaderName.VerifyTextIsInThisElement("Name");
            ColumnHeaderDetails.VerifyTextIsInThisElement("Details");
            Console.WriteLine("Verified " + _pageName + "  page Header elements have expected values");
        }

        public void RunActions()
        {
            _common.RunCommonActions();
        }

        public IMtMerchandiseShipBoxCategoriesDetailsPage GotoDetailsPage()
        {
            GotoDetailPageOnFirstRow.Click();
            Console.WriteLine("Verify Navigation to details page.");
            return _details;
        }

        private void VerifyElementsUniqueToPage()
        {
            foreach (var element in new List<IWebElement> { ColumnHeaderDetails, ColumnHeaderName, ColumnHeaderId }.ToList())
            {
                element.Verify();
            }
            Console.WriteLine("Verified " + _className + " page elements");
        }

        private void VarifyElementsCommonToPage()
        {
            var page = new MtCommonToMerchandisePages(_className);
            page.VerifyCommonElements();
        }
    }
}
