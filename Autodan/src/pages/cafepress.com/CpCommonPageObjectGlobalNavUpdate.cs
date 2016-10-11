using System;
using System.Collections.Generic;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.cafepress.com
{
    internal class CpCommonPageObjectGlobalNavUpdate : BaseTest
    {
        private readonly string _className;
        public CpCommonPageObjectGlobalNavUpdate()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
            _className = GetType().Name;
        }

        //updated nav elements
        [FindsBy(How = How.CssSelector, Using = "#b_banner")]
        public IWebElement ContainerPencilBannerTop { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_ghlink_signin > a")]
        public IWebElement BtnPencilBannerSigninJoin { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_ghlink_track > a")]
        public IWebElement BtnPencilBannerTrackOrder { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_ghlink_sell > a")]
        public IWebElement BtnPencilBannerStartSelling { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_ghlink_help > a")]
        public IWebElement BtnPencilBannerHelp { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_ghlink_activecurrency")]
        public IWebElement DdlPencilBannerCurrencyOption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_logo > a > img")]
        public IWebElement BtnGlobalNavLogoHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#q")]
        public IWebElement InputGlobalNavSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#global-filter-drop > span.filter-arrow")]
        public IWebElement DdlGlobalNavSearchProductType { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#global-searchbutton")]
        public IWebElement BtnGlobalNavSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_cart_icon")]
        public IWebElement BtnGlobalNavCart { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_ghlink_product > a > span")]
        public IWebElement DdlGlobalNavProducts { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_ghlink_interest > a > span")]
        public IWebElement DdlGlobalNavInterests { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_ghlink_recipient > a > span")]
        public IWebElement DdlGlobalNavRecipients { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_ghlink_occasion > a > span")]
        public IWebElement DdlGlobalNavOccasions { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_ghlink_shopby > span.b_ghlink.b_ghlink_promo > a")]
        public IWebElement BtnGlobalNavPromoLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_ghlink_gifts > a")]
        public IWebElement BtnGlobalNavGiftCenter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_ghlink_designyourown > a")]
        public IWebElement BtnGlobalNavDesignYourOwn { get; set; }


        ////All products dropdown list
        //[FindsBy(How = How.CssSelector, Using = "wasd1234")]
        //public IWebElement wasd1234 { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "wasd1234")]
        //public IWebElement wasd1234 { get; set; }



        //shopby DDL hover expand views        
        [FindsBy(How = How.CssSelector, Using = "#b_ghmenus > div.b_ghmenu.menu-target.b_ghmenu_product")]
        public IWebElement ContainerGlobalNavProductsExpand { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_ghmenus > div.b_ghmenu.menu-target.b_ghmenu_interest")]
        public IWebElement ContainerGlobalNavInterestsExpand { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_ghmenus > div.b_ghmenu.menu-target.b_ghmenu_recipient")]
        public IWebElement ContainerGlobalNavRecipientsExpand { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_ghmenus > div.b_ghmenu.menu-target.b_ghmenu_occasion")]
        public IWebElement ContainerGlobalNavOccasionsExpand { get; set; }

        

        //cartpage tests
        public void VerifyGlobalPencilBanner()
        {
            var pencilBannerElements = new List<IWebElement>
            {
                ContainerPencilBannerTop,
                BtnPencilBannerSigninJoin,
                BtnPencilBannerTrackOrder,
                BtnPencilBannerStartSelling,
                BtnPencilBannerHelp,
                DdlPencilBannerCurrencyOption
            };

            foreach (var element in pencilBannerElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified Pencil Banner");
        }

        public void VerifyShopByOptions()
        {
            var shopByNavElements = new List<IWebElement>
            {
                DdlGlobalNavProducts,
                DdlGlobalNavInterests,
                DdlGlobalNavRecipients,
                DdlGlobalNavOccasions,
                BtnGlobalNavPromoLink,
                BtnGlobalNavGiftCenter,
                BtnGlobalNavDesignYourOwn,
            };

            foreach (var element in shopByNavElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified Shop By elements on page");
        }

        //public void ExpandCheckTest()
        //{
        //    var ddlEmement = DdlGlobalNavProducts;
        //    var expandedView = ContainerGlobalNavProductsExpand;

        //    Actions action = new Action(Driver);
        //    action.MoveToElement(ddlEmement).Perform();
        //    Driver.Wait(1);
        //    expandedView.Verify();         
        //}

        public void VerifyShopByExpandedOptions()
        {
            var expandedShopByNavElements = new List<IWebElement>
            {
                ContainerGlobalNavProductsExpand,
                ContainerGlobalNavInterestsExpand,
                ContainerGlobalNavRecipientsExpand,
                ContainerGlobalNavOccasionsExpand,
            };

            foreach (var element in expandedShopByNavElements)
            {
                Actions action = new Actions(Driver);
                action.MoveToElement(element).Perform();
                Driver.Wait(1);
                element.Verify();
                
            }
            //todo: need to create a hover extension to hover+verify expanded views on global nav
        }

        public void SearchInputSmokeTest()
        {
            DdlGlobalNavSearchProductType.Click();

            InputGlobalNavSearch.ClearAndEnterText("test text");
        }

        
    }
}