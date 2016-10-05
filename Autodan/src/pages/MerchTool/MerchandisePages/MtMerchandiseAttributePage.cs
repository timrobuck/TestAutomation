using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtMerchandiseAttributeOptionsPage
    {
        void VerifyElements();
        void RunActions();
    }

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class MtMerchandiseAttributeOptionsPage : BaseTest, IBaseSmokeTest
    {
        public MtMerchandiseAttributeOptionsPage()
        {
            PageFactory.InitElements(Driver, this);
        }
        //AttributeOption subpage elements
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(1)")]
        private IWebElement BreadCrumbHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(2)")]
        private IWebElement BreadCrumbAttributeList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > legend")]
        private IWebElement LegendCafepressAttributeOptions { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span2 > ul > li.active > a")]
        private IWebElement TableAttributeOption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > table > thead > tr > td:nth-child(1)")]
        private IWebElement TableHeaders { get; set; }

        public void VerifyElements()
        {
            var pageElements = new List<IWebElement>
            {
                BreadCrumbHome,
                BreadCrumbAttributeList,
                LegendCafepressAttributeOptions,
                TableAttributeOption,
                TableHeaders
            };

            foreach (var element in pageElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified AttributeOptions page elements");
        }

        public void RunActions()
        {
            throw new NotImplementedException();
        }
    }
}


