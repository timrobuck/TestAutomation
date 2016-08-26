using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool
{
    internal class MtCommonPageObject
    {

        public MtCommonPageObject()
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
        public void NavToMerch()
        {
            NavBtnMerchandise.Click();   
        }

        public void NavToSmartProductEngine()
        {
            NavBtnSmartProductEngine.Click();
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

        public void SideNavToColors()
        {
            SideNavColors.Click();
        }

        public void SideNavToSizes()
        {
            SideNavSizes.Click();
        }

        public void SideNavToAttributes()
        {
            SideNavAttributes.Click();
        }

        public void SideNavToProductCategories()
        {
            SideNavProductCategories.Click();
        }

        public void SideNavToSalesChannels()
        {
            SideNavSalesChannels.Click();
        }

        public void SideNavToShipBoxCategories()
        {
            SideNavShipBoxCategories.Click();
        }

        public void SideNavToShippingMethods()
        {
            SideNavShippingMethods.Click();
        }


        //common expected eles
        public void VerifyPersistentNav()
        {
            MerchMgtPageTitle.Verify();
            NavBtnHome.Verify();
            NavBtnMerchandise.Verify();
            NavBtnSmartProductEngine.Verify();
            BtnLogout.Verify();
        }

        public void VerifyLandingPage()
        {
            BtnLandingMerchBlock.Verify();
            BtnLandingSmartProductEngineBlock.Verify();            
        }

        public void VerifySideNavigationOptions()
        {
            SideNavProductTypes.Verify();
            SideNavColors.Verify();
            SideNavSizes.Verify();
            SideNavAttributes.Verify();
            SideNavProductCategories.Verify();
            SideNavSalesChannels.Verify();
            SideNavShipBoxCategories.Verify();
            SideNavShippingMethods.Verify();
        }
    }
}
