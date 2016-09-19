using System;
using System.Collections.Generic;
using System.Linq;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public class MtMerchandiseShippingMethodsPage:BaseTest
    {
       private string PageName { get; }= "ShippingMethods";
        public MtMerchandiseShippingMethodsPage()
        {
            PageFactory.InitElements(Driver, this);
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

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(3) > a")]
        public IWebElement GotoDetailPageOnFirstRow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(2)")]
        public IWebElement FirstRowContent { get; set; }

        public void VerifyElements()
        {
            VerifyElementsUniqueToPage(); Console.WriteLine("Verified " + PageName + " page elements");
            VarifyElementsCommonToPage();
        }

        public void ValidateElementHasValue()
        {
            ColumnHeaderId.ValidateTextIsInThisElement("Id");
            ColumnHeaderName.ValidateTextIsInThisElement("Name");
            ColumnHeaderDeliveryTime.ValidateTextIsInThisElement("Delivery Time");
            ColumnHeaderIsExpidited.ValidateTextIsInThisElement("Is Expedited?");
            ColumnHeaderDetails.ValidateTextIsInThisElement("Details");
            Console.WriteLine("Verified " + PageName + "  page Header elements have expected values");
        }

        public void RunActions()
        {
            var page = new MtCommonToMerchandisePages(PageName);
            page.RunCommonActions();
        }

        public MtCommonMerchandiseDetailsPage GotoDetailsPage()
        {
            var firstRowContentText = FirstRowContent.Text;
            GotoDetailPageOnFirstRow.Click();
            Console.WriteLine("Verified Navigation to LandingPage");
            return new MtCommonMerchandiseDetailsPage(firstRowContentText);
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
            var page = new MtCommonToMerchandisePages(PageName);
            page.VerifyCommonElements();
        }
    }
}