using System;
using System.Collections.Generic;
using System.Linq;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtMerchandiseShippingMethodsPage
    {
        void VerifyElements();
        void RunActions();
    }
    public class MtMerchandiseShippingMethodsPage:BaseTest, IBaseSmokeTest, IMtMerchandiseShippingMethodsPage
    {
        private readonly IMtCommonToMerchandisePages _common;
        private readonly IMtMerchandiseShippingMethodsDetailsPage _detail;
        private static string PageName { get; } = "ShippingMethods";

        public MtMerchandiseShippingMethodsPage(): this(new MtCommonToMerchandisePages(PageName),new MtMerchandiseShippingMethodsDetailsPage()) {}

        public MtMerchandiseShippingMethodsPage(IMtCommonToMerchandisePages common, IMtMerchandiseShippingMethodsDetailsPage detail)
        {
            PageFactory.InitElements(Driver, this);
            _common = common;
            _detail = detail;

        }
        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(1) > div")]
        public IWebElement ColumnHeaderId { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(2) > div")]
        public IWebElement ColumnHeaderName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(3) > div")]
        public IWebElement ColumnHeaderDeliveryTime { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(4) > div")]
        public IWebElement ColumnHeaderIsExpidited { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(5) > div")]
        public IWebElement ColumnHeaderDetails { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(5) > a")]
        public IWebElement GotoDetailPageOnFirstRow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(2)")]
        public IWebElement FirstRowContent { get; set; }

        [FindsBy(How = How.CssSelector, Using= "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(2)")]
        public IWebElement Row1Column2Content { get; set; }
        
        public void VerifyElements()
        {
            VerifyElementsUniqueToPage(); Console.WriteLine("Verified " + PageName + " page elements");
            VarifyElementsCommonToPage();
        }

        public void VerifyElementHasValue()
        {
            ColumnHeaderId.VerifyTextIsInThisElement("Id");
            ColumnHeaderName.VerifyTextIsInThisElement("Name");
            ColumnHeaderDeliveryTime.VerifyTextIsInThisElement("Delivery Time");
            ColumnHeaderIsExpidited.VerifyTextIsInThisElement("Is Expedited?");
            ColumnHeaderDetails.VerifyTextIsInThisElement("Details");
            Console.WriteLine("Verified " + PageName + "  page Header elements have expected values");
        }

        public void RunActions()
        {
            _common.RunCommonActions();
        }

        public IMtMerchandiseShippingMethodsDetailsPage GotoDetailsPage()
        {
            GotoDetailPageOnFirstRow.Click();
            Console.WriteLine("Verified Navigation to Details Page");
            return _detail;
        }

        private void VerifyElementsUniqueToPage()
        {
            foreach (var element in new List<IWebElement> { ColumnHeaderDetails, ColumnHeaderName, ColumnHeaderId }.ToList())
            {
                element.Verify();
            }
        }

        private void VarifyElementsCommonToPage()
        {
            _common.VerifyCommonElements();
        }
    }
}