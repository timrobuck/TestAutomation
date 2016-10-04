using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Autodan.pages.MerchTool.SmartProductEnginePages
{
    public class MtAdministativeFunctionPage
    {
        private string PageName { get; } = "Administative Functions Page";
        public MtAdministativeFunctionPage()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > ul > li.active")]
        private IWebElement BreadCrumbSmartProductEngineElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset > legend")]
        private IWebElement LegendElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset > ul > li:nth-child(1) > a")]
        private IWebElement NavigateManageMemberExclusionsClickableElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset > ul > li:nth-child(2) > a")]
        private IWebElement NavigateManagePtnExclusionsClickableElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset > ul > li:nth-child(3) > a")]
        private IWebElement NavigateManagePtnCategoriesClickableElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset > ul > li:nth-child(4) > a")]
        private IWebElement NavigateManagePtnFitAndFillConfigurationsClickableElement { get; set; }

        public void VerifyElements()
        {
            VerifyElementsUniqueToPage();
            Console.WriteLine("Verified " + PageName + " page elements exist");
        }
        private void VerifyElementsUniqueToPage()
        {
            foreach (var element in new List<IWebElement>
            { BreadCrumbSmartProductEngineElement,
                LegendElement,
                NavigateManageMemberExclusionsClickableElement,
                NavigateManagePtnCategoriesClickableElement,
                NavigateManagePtnExclusionsClickableElement,
                NavigateManagePtnFitAndFillConfigurationsClickableElement
            }.ToList())
                element.Verify();
        }
        public void VerifyElementHasExpectedValue()
        {
            BreadCrumbSmartProductEngineElement.VerifyTextIsInThisElement("Smart Product Engine");
            LegendElement.VerifyTextIsInThisElement("Smart Product Administrative Functions");
            NavigateManageMemberExclusionsClickableElement.VerifyTextIsInThisElement("Manage Member Exclusions");
            NavigateManagePtnExclusionsClickableElement.VerifyTextIsInThisElement("Manage PTN Exclusions");
            NavigateManagePtnCategoriesClickableElement.VerifyTextIsInThisElement("Manage PTN Categories");
            NavigateManagePtnFitAndFillConfigurationsClickableElement.VerifyTextIsInThisElement("Manage PTN Fit and Fill Configurations");
            Console.WriteLine("Verified " + PageName + " elements have expected values");
        }

        public MtSpeMemberExclusionPage GotoMemberExclusionPages()
        {
            NavigateManageMemberExclusionsClickableElement.Click();
            return new MtSpeMemberExclusionPage();
        }
        public MtSpePtnExclusionPage GoToPtnExclusionPage()
        {
            NavigateManagePtnExclusionsClickableElement.Click();
            return new MtSpePtnExclusionPage();
        }
        public MtSpeCategoriesPage GotoCategoriesPage()
        {
            NavigateManagePtnCategoriesClickableElement.Click();
            return new MtSpeCategoriesPage();
        }
        public MtSpeEditFitNCropPage GotoMtSpeEditFitNCropPage()
        {
            NavigateManagePtnFitAndFillConfigurationsClickableElement.Click();
            return new MtSpeEditFitNCropPage();
        }
    }
}

