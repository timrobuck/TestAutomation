using System;
using System.Collections.Generic;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.MerchadisePages
{
    public  class MtMerchandiseAttributeOptionsPage:BaseTest
    {
        public MtMerchandiseAttributeOptionsPage()
        {
            PageFactory.InitElements(Driver, this);
        }
        //AttributeOption subpage elements
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(1)")]
        public IWebElement BreadCrumbHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul.breadcrumb > li:nth-child(2)")]
        public IWebElement BreadCrumbAttributeList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > legend")]
        public IWebElement LegendCafepressAttributeOptions { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span2 > ul > li.active > a")]
        public IWebElement TableAttributeOption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > table > thead > tr > td:nth-child(1)")]
        public IWebElement TableHeaders { get; set; }

        public void VerifyAttributeOptionPageElements()
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
    }
}


