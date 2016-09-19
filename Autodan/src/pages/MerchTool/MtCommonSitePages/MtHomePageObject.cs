using System;
using System.Collections.Generic;
using Autodan.core;
using Autodan.pages.MerchTool.MerchandisePages;
using Autodan.pages.MerchTool.SmartProductEnginePages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.MtCommonPages
{
    internal class MtHomePageObject
    {

        public MtHomePageObject()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
        }


        //common & shared nav elements
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.header > h1")]
        public IWebElement MerchMgtPageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#logoutForm > a")]
        public IWebElement BtnLogout { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.navbar > div.navbar-inner > ul > li:nth-child(1) > a")]
        public IWebElement NavBtnHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.navbar > div.navbar-inner > ul > li:nth-child(2) > a")]
        public IWebElement NavBtnMerchandise { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.navbar > div.navbar-inner > ul > li:nth-child(3) > a")]
        public IWebElement NavBtnSmartProductEngine { get; set; }

        //landingpage eles
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > ul.home-buttons > li.merch-list")]
        public IWebElement BtnLandingMerchBlock { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > ul.home-buttons > li.smart-products-engine")]
        public IWebElement BtnLandingSmartProductEngineBlock { get; set; }

        //side navigation options
        //sidenav
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span2 > ul > li:nth-child(1) > a")]
        public IWebElement SideNavProductTypes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span2 > ul > li:nth-child(2) > a")]
        public IWebElement SideNavColors { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span2 > ul > li:nth-child(3) > a")]
        public IWebElement SideNavSizes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span2 > ul > li:nth-child(4) > a")]
        public IWebElement SideNavAttributes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span2 > ul > li:nth-child(5) > a")]
        public IWebElement SideNavProductCategories { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span2 > ul > li:nth-child(6) > a")]
        public IWebElement SideNavSalesChannels { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span2 > ul > li:nth-child(7) > a")]
        public IWebElement SideNavShipBoxCategories { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span2 > ul > li:nth-child(8) > a")]
        public IWebElement SideNavShippingMethods { get; set; }


        //common page actions
        public MtMerchProductTypesPageObject NavToMerch()
        {
            NavBtnMerchandise.Click();
            return new MtMerchProductTypesPageObject();
        }

        public MtSpeAdministativeFunctionPage NavToSmartProductEngine()
        {
            NavBtnSmartProductEngine.Click();
            return new MtSpeAdministativeFunctionPage();
        }

        public void Logout()
        {
            BtnLogout.Click();
        }

        //Merchandise - Side nav options
        public void SideNavToProductTypes()
        {
            SideNavProductTypes.Click();
        }

        public MtMerchandiseColorsPageObject SideNavToColors()
        {
            SideNavColors.Click();
            return new MtMerchandiseColorsPageObject();
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
                NavBtnHome,
                NavBtnMerchandise,
                NavBtnSmartProductEngine,
                BtnLogout,
            };
            foreach (IWebElement element in navElements)
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

            foreach (IWebElement element in pageElements)
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

            foreach (IWebElement element in sideNavElements)
            {
                element.Verify();
            }
            Console.WriteLine("verified: side navigation options");
        }
    }
}
