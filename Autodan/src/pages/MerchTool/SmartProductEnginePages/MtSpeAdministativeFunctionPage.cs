using Autodan.core;
using Autodan.pages.MerchTool.MerchandisePages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Autodan.pages.MerchTool.SmartProductEnginePages
{
    public class MtSpeAdministativeFunctionPage
    {
        private string PageName { get; } = "";
        public MtSpeAdministativeFunctionPage()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > ul > li.active")]
        private IWebElement BreadCrumbSmartProductEngineElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset > legend")]
        private IWebElement LegendElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset > ul > li:nth-child(1) > a")]
        private IWebElement NavigateManageMemberExclusionsElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset > ul > li:nth-child(2) > a")]
        private IWebElement NavigateManagePtnExclusionsClickElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset > ul > li:nth-child(3) > a")]
        private IWebElement NavigateManagePtnCategoriesClickElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset > ul > li:nth-child(4) > a")]
        private IWebElement NavigateManagePtnFitAndFillConfigurationsElement { get; set; }


        public void VerifyElements()
        {
            VarifyElementsCommonToPage();
            VerifyElementsUniqueToPage();
            Console.WriteLine("Verified " + PageName + " page elements exist");
        }
        private void VerifyElementsUniqueToPage()
        {
            foreach (var element in new List<IWebElement>
            { BreadCrumbSmartProductEngineElement,
                LegendElement,
                NavigateManageMemberExclusionsElement,
                NavigateManagePtnCategoriesClickElement,
                NavigateManagePtnExclusionsClickElement,
                NavigateManagePtnFitAndFillConfigurationsElement
            }.ToList())
                   element.Verify();
        }

        private void VarifyElementsCommonToPage()
        {
            var page = new MtCommonToMerchandisePages(PageName);
            page.VerifyCommonElements();
        }

        public void VerifyElementHasExpectedValue()
        {
            //todo:Remove this example: BlahId.ValidateTextIsInThisElement("Id"); 
            BreadCrumbSmartProductEngineElement.ValidateTextIsInThisElement("Smart Product Engine");
            LegendElement.ValidateTextIsInThisElement("Smart Product Administrative Functions");
            NavigateManageMemberExclusionsElement.ValidateTextIsInThisElement("Manage Member Exclusions");
            NavigateManagePtnCategoriesClickElement.ValidateTextIsInThisElement("Manage PTN Exclusions");
            NavigateManagePtnExclusionsClickElement.ValidateTextIsInThisElement("Manage PTN Categories");
            NavigateManagePtnFitAndFillConfigurationsElement.ValidateTextIsInThisElement("Manage PTN Fit and Fill Configurations");
            Console.WriteLine("Verified " + PageName + " elements have expected values");
        }

        public void RunActions()
        {
            var page = new MtCommonToMerchandisePages(PageName);
            page.RunCommonActions();
        }

        private MtSpeAdministativeFunctionPage GotoManageMemberExclusions()
        {
            NavigateManageMemberExclusionsElement.Click();
            return new MtSpeAdministativeFunctionPage();
        }
    }
}

