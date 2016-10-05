using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtMerchandiseShippingMethodsDetailsPage
    {
        IWebElement NameContent { get; }
        void VerifyElements();
        void VerifyElementContent();
    }

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class MtMerchandiseShippingMethodsDetailsPage : BaseTest, IMtMerchandiseShippingMethodsDetailsPage, IBaseSmokeTest
    {
        private readonly IMtCommonToMerchandiseDetailsPage _commonPage; // i like as it reduces noise an makes allows better readability by grouping common paths stacked in single lines without anything in between.
        private const string IdLabelSelector = "body > div.container > div.row > div.span9.view-container > fieldset > div > label:nth-child(1)";
        private const string IdContentSelector = "body > div.container > div.row > div.span9.view-container > fieldset > div > span:nth-child(2)";
        private const string NameLabelSelector = "body > div.container > div.row > div.span9.view-container > fieldset > div > label:nth-child(3)";
        private const string NameContentSelector = "body > div.container > div.row > div.span9.view-container > fieldset > div > span:nth-child(4)";
        

        public MtMerchandiseShippingMethodsDetailsPage() : this(new MtCommonToMerchandiseDetailsPage()) { }
        public MtMerchandiseShippingMethodsDetailsPage(IMtCommonToMerchandiseDetailsPage commonPage)
        {
            PageFactory.InitElements(Driver, this);
            _commonPage = commonPage;
        }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul > li.active")]
        private IWebElement BreadCrumbShippingMethodsDetails { get; set; }

        [FindsBy(How = How.CssSelector, Using = IdLabelSelector)]
        private IWebElement IdLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = IdContentSelector)]
        private IWebElement IdContent { get; set; }

        [FindsBy(How = How.CssSelector, Using = NameLabelSelector)]
        private IWebElement NameLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = NameContentSelector)]
        public IWebElement NameContent { get; set; }

        public void VerifyElements()
        {
            BreadCrumbShippingMethodsDetails.Verify();
            IdLabel.Verify();
            IdContent.Verify();
            NameLabel.Verify();
            NameContent.Verify();
            _commonPage.VerifyElements();
            Console.WriteLine("Verify Elements on " + GetType().Name);
        }
        public void VerifyElementContent()
        {
            BreadCrumbShippingMethodsDetails.VerifyTextIsInThisElement("Shipping Method Details");
            IdLabel.VerifyTextIsInThisElement("Id");
            IdContent.VerifyContentOfThisElementIsIntegerType();
            NameLabel.VerifyTextIsInThisElement("Name");
            NameContent.VerifyContentNotEmpty();
            Console.WriteLine("Verified Header elements have expected values on " + GetType().Name);
        }

        public void RunActions()
        {
            throw new NotImplementedException();
        }
    }
}
