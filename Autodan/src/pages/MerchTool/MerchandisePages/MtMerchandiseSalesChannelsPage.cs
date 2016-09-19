using System;
using System.Collections.Generic;
using System.Linq;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public class MtMerchandiseSalesChannelsPage : BaseTest
    {
        private string PageName { get; } = "SalesChannel";
        public MtMerchandiseSalesChannelsPage()
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(1) > div")]
        public IWebElement ColumnHeaderId { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(2) > div")]
        public IWebElement ColumnHeaderName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(3) > div")]
        public IWebElement ColumnHeaderDetails { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(3) > a")]
        public IWebElement GotoDetailPageOnFirstRow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(2)")]
        public IWebElement FirstRowContent { get; set; }

        public void VerifyElements()
        {
            VerifyElementsUniqueToPage();
            VarifyElementsCommonToPage();
        }

        public void ValidateElementHasValue()
        {
            ColumnHeaderId.ValidateTextIsInThisElement("Id");
            ColumnHeaderName.ValidateTextIsInThisElement("Name");
            ColumnHeaderDetails.ValidateTextIsInThisElement("Details");
            Console.WriteLine("Verified SalesChannels page Header elements have expected values");

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
            return new MtCommonMerchandiseDetailsPage(firstRowContentText);
        }

        private void VerifyElementsUniqueToPage()
        {
            foreach (var element in new List<IWebElement> { ColumnHeaderDetails, ColumnHeaderName, ColumnHeaderId }.ToList())
            {
                element.Verify();
            }
            Console.WriteLine("Verified SalesChannels page elements");
        }

        private void VarifyElementsCommonToPage()
        {
            var page = new MtCommonToMerchandisePages(PageName);
            page.VerifyCommonElements();
        }
    }
}
