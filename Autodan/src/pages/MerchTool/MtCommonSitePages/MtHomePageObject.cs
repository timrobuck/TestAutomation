using Autodan.core;
using Autodan.pages.MerchTool.MerchandisePages;
using Autodan.pages.MerchTool.SmartProductEnginePages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Autodan.pages.MerchTool.MtCommonSitePages
{

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class MtHomePageObject : BaseTest
    {
        public MtHomePageObject()
        {
            PageFactory.InitElements(Driver, this);
        }

        //common & shared navigation elements
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.header > h1")]
        private IWebElement MerchMgtPageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#logoutForm > a")]
        private IWebElement BtnLogout { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.navbar > div.navbar-inner > ul > li:nth-child(1) > a")]
        private IWebElement BtnNavigateHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.navbar > div.navbar-inner > ul > li:nth-child(2) > a")]
        private IWebElement BtnNavigateMerchandise { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.navbar > div.navbar-inner > ul > li:nth-child(3) > a")]
        private IWebElement BtnNavSmartProductEngine { get; set; }

        //landingpage eles
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > ul.home-buttons > li.merch-list")]
        private IWebElement BtnLandingMerchBlock { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > ul.home-buttons > li.smart-products-engine")]
        private IWebElement BtnLandingSmartProductEngineBlock { get; set; }

        //side navigation options
        //sidenav
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span2 > ul > li:nth-child(1) > a")]
        public IWebElement SideNavProductTypes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span2 > ul > li:nth-child(2) > a")]
        private IWebElement SideNavColors { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span2 > ul > li:nth-child(3) > a")]
        private IWebElement SideNavSizes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span2 > ul > li:nth-child(4) > a")]
        private IWebElement SideNavAttributes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span2 > ul > li:nth-child(5) > a")]
        private IWebElement SideNavProductCategories { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span2 > ul > li:nth-child(6) > a")]
        private IWebElement SideNavSalesChannels { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span2 > ul > li:nth-child(7) > a")]
        private IWebElement SideNavShipBoxCategories { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span2 > ul > li:nth-child(8) > a")]
        private IWebElement SideNavShippingMethods { get; set; }

        //common page actions
        public MtMerchProductTypesByPtnPage NavigateToMerchPage()
        {
            BtnNavigateMerchandise.Click();
            return new MtMerchProductTypesByPtnPage();
        }

        public MtAdministativeFunctionPage NavgateToSmartProductEnginePage()
        {
            BtnNavSmartProductEngine.Click();
            return new MtAdministativeFunctionPage();
        }

        public void Logout()
        {
            BtnLogout.Click();
        }

        //Merchandise - Side nav options
        public MtMerchProductTypesByPtnPage SideNavToProductTypes()
        {
            SideNavProductTypes.Click();
            return new MtMerchProductTypesByPtnPage();
        }

        public MtMerchandiseColorsPage SideNavToColors()
        {
            SideNavColors.Click();
            return new MtMerchandiseColorsPage();
        }

        public MtMerchandiseSizePage SideNavToSizes()
        {
            SideNavSizes.Click();
            return new MtMerchandiseSizePage();
        }

        public MtMerchandiseAttributeOptionsPage SideNavToAttributes()
        {
            SideNavAttributes.Click();
            return new MtMerchandiseAttributeOptionsPage();
        }

        public MtMerchandiseProductCategoriesPage SideNavToProductCategories()
        {
            SideNavProductCategories.Click();
            return new MtMerchandiseProductCategoriesPage();
        }

        public MtMerchandiseSalesChannelsPage SideNavToSalesChannels()
        {
            SideNavSalesChannels.Click();
            return new MtMerchandiseSalesChannelsPage();
        }

        public MtMerchandiseShipBoxCategoriesPage SideNavToShipBoxCategories()
        {
            SideNavShipBoxCategories.Click();
            return new MtMerchandiseShipBoxCategoriesPage();
        }

        public MtMerchandiseShippingMethodsPage SideNavToShippingMethods()
        {
            SideNavShippingMethods.Click();
            return new MtMerchandiseShippingMethodsPage();
        }

        //common expected eles
        public void VerifyPersistentNav()
        {
            var navElements = new List<IWebElement>
            {
                MerchMgtPageTitle,
                BtnNavigateHome,
                BtnNavigateMerchandise,
                BtnNavSmartProductEngine,
                BtnLogout,
            };
            foreach (var element in navElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified: persistent nav options");
        }


        public void VerifyLandingPage()
        {
            var pageElements = new List<IWebElement>
            {
                BtnLandingMerchBlock,
                BtnLandingSmartProductEngineBlock,
            };

            foreach (var element in pageElements)
            {
                element.Verify();
            }
            Console.WriteLine("verified: landing nav options");
        }

        public void VerifySideNavigationOptions()
        {
            var sideNavElements = new List<IWebElement>
            {
                SideNavProductTypes,
                SideNavColors,
                SideNavSizes,
                SideNavAttributes,
                SideNavProductCategories,
                SideNavSalesChannels,
                SideNavShipBoxCategories,
                SideNavShippingMethods,
            };

            foreach (var element in sideNavElements)
            {
                element.Verify();
            }
            Console.WriteLine("verified: side navigation options");
        }
    }
}
