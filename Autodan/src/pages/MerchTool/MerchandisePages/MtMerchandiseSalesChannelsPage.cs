using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtMerchandiseSalesChannelsPage
    {
        void VerifyElements();
        void VerifyElementContent();
        void RunActions();
        IMtMerchandiseSalesChannelDetailsPage GotoDetailsPage();
    }

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class MtMerchandiseSalesChannelsPage : BaseTest, IBaseSmokeTest
    {
        private readonly IMtCommonToMerchandisePages _commonPage;
        private readonly IMtMerchandiseSalesChannelDetailsPage _detailsPage;
        private readonly string _className;

        public MtMerchandiseSalesChannelsPage() :this(new MtCommonToMerchandisePages(" SalesChannels "), new MtMerchandiseSalesChannelDetailsPage()) { }
        public MtMerchandiseSalesChannelsPage(IMtCommonToMerchandisePages commonPage, IMtMerchandiseSalesChannelDetailsPage detailsPage)
        {
            PageFactory.InitElements(Driver, this);
            _commonPage = commonPage;
            _detailsPage = detailsPage;
            _className = GetType().ToString();
        }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(1) > div")]
        private IWebElement ColumnHeaderId { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(2) > div")]
        private IWebElement ColumnHeaderName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > thead > tr > td:nth-child(3) > div")]
        private IWebElement ColumnHeaderDetails { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(3) > a")]
        private IWebElement NavigationElementToDetailPageFromRow1Col2Details { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0 > tbody > tr:nth-child(1) > td:nth-child(2)")]
        public IWebElement Row1Column2Content { get; set; }

        public void VerifyElements()
        {
            VerifyElementsUniqueToPage();
            VarifyElementsCommonToPage();
        }

        public void VerifyElementContent()
        {
            ColumnHeaderId.VerifyTextIsInThisElement("Id");
            ColumnHeaderName.VerifyTextIsInThisElement("Name");
            ColumnHeaderDetails.VerifyTextIsInThisElement("Details");
            Console.WriteLine("Verified page header elements have expected values on " + _className);
        }

        public void RunActions()
        {
            _commonPage.RunCommonActions();
        }

        public IMtMerchandiseSalesChannelDetailsPage GotoDetailsPage()
        {
            NavigationElementToDetailPageFromRow1Col2Details.Click();
            Console.WriteLine("Verified Navigation to details page from " + _className);
            return _detailsPage;
        }

        private void VerifyElementsUniqueToPage()
        {
            ColumnHeaderId.Verify();
            ColumnHeaderName.Verify();
            ColumnHeaderDetails.Verify();
            Console.WriteLine(" Verified page elements on " +  _className);
        }

        private void VarifyElementsCommonToPage()
        {
            _commonPage.VerifyCommonElements();
            Console.WriteLine("Verified common elements on "+ _className);
        }
    }
}
