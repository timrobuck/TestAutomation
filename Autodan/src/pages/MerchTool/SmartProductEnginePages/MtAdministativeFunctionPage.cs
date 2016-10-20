using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Autodan.pages.MerchTool.SmartProductEnginePages
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class MtAdministativeFunctionPage
    {
        private  string PageName { get; } = "Administative Functions Page";
        public MtAdministativeFunctionPage()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > ul > li.active")]
        private IWebElement BreadCrumbSmartProductEngineElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset > legend")]
        private IWebElement LegendElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset > ul > li:nth-child(1) > a")]
        private IWebElement NavigateManageMemberExclusions { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset > ul > li:nth-child(2) > a")]
        private IWebElement NavigateManagePtnExclusions { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset > ul > li:nth-child(3) > a")]
        private IWebElement NavigateManagePtnCategories { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset > ul > li:nth-child(4) > a")]
        private IWebElement NavigateManagePtnFitAndFillConfigurations { get; set; }

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
                NavigateManageMemberExclusions,
                NavigateManagePtnCategories,
                NavigateManagePtnExclusions,
                NavigateManagePtnFitAndFillConfigurations
            }.ToList())
                element.Verify();
        }
        public void VerifyElementHasExpectedValue()
        {
            BreadCrumbSmartProductEngineElement.VerifyTextIsInThisElement("Smart Product Engine");
            LegendElement.VerifyTextIsInThisElement("Smart Product Administrative Functions");
            NavigateManageMemberExclusions.VerifyTextIsInThisElement("Manage Member Exclusions");
            NavigateManagePtnExclusions.VerifyTextIsInThisElement("Manage PTN Exclusions");
            NavigateManagePtnCategories.VerifyTextIsInThisElement("Manage PTN Categories");
            NavigateManagePtnFitAndFillConfigurations.VerifyTextIsInThisElement("Manage PTN Fit and Fill Configurations");
            Console.WriteLine("Verified " + PageName + " elements have expected values");
        }

        public MtSpeMemberExclusionPage GotoMemberExclusionPages()
        {
            NavigateManageMemberExclusions.Click();
            return new MtSpeMemberExclusionPage();
        }
        public MtSpePtnExclusionPage GoToPtnExclusionPage()
        {
            NavigateManagePtnExclusions.Click();
            return new MtSpePtnExclusionPage();
        }
        public MtSpeCategoriesPage GotoCategoriesPage()
        {
            NavigateManagePtnCategories.Click();
            return new MtSpeCategoriesPage();
        }
        public MtSpeEditFitNCropPage GotoMtSpeEditFitNCropPage()
        {
            NavigateManagePtnFitAndFillConfigurations.Click();
            return new MtSpeEditFitNCropPage();
        }
    }
}

