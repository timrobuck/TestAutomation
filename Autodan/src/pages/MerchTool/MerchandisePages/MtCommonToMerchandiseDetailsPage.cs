using System;
using System.Collections.Generic;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtCommonToMerchandiseDetailsPage
    {
        void VerifyPresentation();
        void VerifyElements();
        IWebElement Legend { get; set; }
        IWebElement BreadCrumbDetails { get; set; }
    }

    public class MtCommonToMerchandiseDetailsPage : BaseTest, IMtCommonToMerchandiseDetailsPage
    {
        public MtCommonToMerchandiseDetailsPage()
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul > li.active")]
        public IWebElement BreadCrumbDetails { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > legend")]
        public IWebElement Legend { get; set; }

        public void VerifyElements()
        {
            foreach (var element in new List<IWebElement>
            {
                BreadCrumbDetails,
                Legend
            })
                element.Verify();
        }

        public void VerifyPresentation()
        {
            BreadCrumbDetails.VerifyTextIsInThisElement("Details");
            Legend.VerifyTextIsInThisElement("Details");
            Console.WriteLine("Verified expected content on detail page.");
        }
    }
}