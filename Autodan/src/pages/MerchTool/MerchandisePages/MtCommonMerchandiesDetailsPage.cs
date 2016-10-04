using System;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtCommonMerchandiseDetailsPage
    {
        void VerifyElements();
        void VerifyPresentation();
        IWebElement BreadCrumbDetails { get; set; }
        IWebElement Legend { get; set; }
    }

    public class MtCommonMerchandiseDetailsPage : BaseTest, IMtCommonMerchandiseDetailsPage
    {
        public MtCommonMerchandiseDetailsPage()
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