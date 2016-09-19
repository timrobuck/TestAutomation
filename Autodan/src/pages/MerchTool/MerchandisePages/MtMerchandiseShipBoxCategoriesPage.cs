using System;
using System.Collections.Generic;
using System.Linq;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public class MtMerchandiseShipBoxCategoriesPage : BaseTest
    {
        private readonly string _className;
        private readonly string _pageName = "ShipBox Categories";

        public MtMerchandiseShipBoxCategoriesPage()
        {
            PageFactory.InitElements(Driver, this);
            _className = GetType().ToString();
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
            Console.WriteLine("Verified " + _pageName + "  page Header elements have expected values");
        }

        public void RunActions()
        {
            var page = new MtCommonToMerchandisePages(_className);
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
            Console.WriteLine("Verified " + _className + " page elements");
        }

        private void VarifyElementsCommonToPage()
        {
            var page = new MtCommonToMerchandisePages(_className);
            page.VerifyCommonElements();
        }
    }
}
