using System;
using System.Collections.Generic;
using System.Linq;
using Autodan.core;
using Autodan.pages.MerchTool.MerchandisePages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.Resources
{
    public class SiteSectionSpecificPagePage
    {
        private string PageName { get; } = "";//todo:add friendly name for the console lines
        public SiteSectionSpecificPagePage()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
        }

        //todo:Add elements here: suggestion grab a list of element selectors on this page identify on the screenShot
        [FindsBy(How = How.CssSelector, Using = "blah blah")]//todo: remove this line
        public IWebElement BlahId { get; set; }//todo: remove this line

        public void VerifyElements()
        {
            VarifyElementsCommonToPage();
            VerifyElementsUniqueToPage();
            Console.WriteLine("Verified " + PageName + " page elements exist");
        }

        public void VerifyElementHasExpectedValue()
        {
            //todo:Remove this example: BlahId.ValidateTextIsInThisElement("Id"); 
            Console.WriteLine("Verified " + PageName + "  page elements have expected values");
        }

        public void RunActions()
        {
            var page = new MtCommonToMerchandisePages(PageName);
            page.RunCommonActions();

            Action1();//todo:add unique actions(below) then call(here) 
        }

        private void Action1()//todo remove or replace this unique actin example 
        {
            BlahId.Click();
        }

        private void VerifyElementsUniqueToPage()
        {
            foreach (var element in new List<IWebElement> { }.ToList())//todo:add element names into list {Blah1,element2,element3,etc}
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