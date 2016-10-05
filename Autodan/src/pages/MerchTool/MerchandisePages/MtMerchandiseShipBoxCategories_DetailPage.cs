using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtMerchandiseShipBoxCategoriesDetailsPage
    {
        void VerifyElements();
        void VerifyElementContent();
        void RunActions();
        IWebElement NameContent { get; set; }
    }

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class MtMerchandiseShipBoxCategoriesDetailsPage : BaseTest, IBaseSmokeTest, IMtMerchandiseShipBoxCategoriesDetailsPage
    {
        private readonly IMtCommonToMerchandiseDetailsPage _common;
        private readonly string _pageName;

        public MtMerchandiseShipBoxCategoriesDetailsPage() : this(new MtCommonToMerchandiseDetailsPage()) { }
        public MtMerchandiseShipBoxCategoriesDetailsPage(IMtCommonToMerchandiseDetailsPage common)
        {
            PageFactory.InitElements(Driver, this);
            _common = common;
            _pageName = GetType().Name;
        }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul > li.active")]
        private IWebElement BreadCrumbShipBoxDetails { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul > li:nth-child(2) > a")]
        private IWebElement BreadCrumbAllShipBoxCategories { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > div > label:nth-child(1)")]
        private IWebElement NameLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset:nth-child(2) > div > span:nth-child(4)")]
        public IWebElement NameContent { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset:nth-child(3) > legend")]
        private IWebElement Legend { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset:nth-child(3) > table > thead > tr > td:nth-child(1)")]
        private IWebElement ColumnHeaderId { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset:nth-child(3) > table > thead > tr > td:nth-child(2)")]
        private IWebElement ColumnHeaderName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset:nth-child(3) > table > thead > tr > td:nth-child(3)")]
        private IWebElement ColumnHeaderDetails { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(1)")]
        private IWebElement Row1Column1 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(2)")]
        private IWebElement Row1Column2 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(3)")]
        private IWebElement Row1Column3 { get; set; }


        public void VerifyElements()
        {
            BreadCrumbShipBoxDetails.Verify();
            BreadCrumbAllShipBoxCategories.Verify();
            Legend.Verify();
            NameLabel.Verify();
            NameContent.Verify();
            ColumnHeaderId.Verify();
            ColumnHeaderName.Verify();
            ColumnHeaderDetails.Verify();
            Row1Column1.Verify();
            Row1Column2.Verify();
            Row1Column3.Verify();
            _common.VerifyElements();
            Console.WriteLine("Verify Elements on " + _pageName);
        }

        public void VerifyElementContent()
        {
            ColumnHeaderId.VerifyTextIsInThisElement("Shipping Method Id");
            ColumnHeaderName.VerifyTextIsInThisElement("Shipping Method Name");
            ColumnHeaderDetails.VerifyTextIsInThisElement("1st Item Charge");
            Row1Column1.VerifyContentOfThisElementIsIntegerType();
            Row1Column2.VerifyContentNotEmpty();
            Row1Column3.VerifyTextIsInThisElement("$");
            Console.WriteLine("Verified Header elements have expected values on " + _pageName);
        }

        public void RunActions()
        {
            throw new NotImplementedException();
        }
    }
}

