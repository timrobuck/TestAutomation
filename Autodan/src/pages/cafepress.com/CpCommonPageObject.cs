using System;
using System.Collections.Generic;
using System.Linq;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.cafepress.com
{
    public class CpCommonPageObject : BaseTest
    {
        public CpCommonPageObject()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
        }

        //comomon+shared nav elements
        [FindsBy(How = How.CssSelector, Using = "#cp_TopRibbon")]
        public IWebElement ContainerBannerDiscountAndSavings { get; set; }

        //persistent nav
        [FindsBy(How = How.CssSelector, Using = "#cafepress-navbar-main > ul.nav.navbar-nav.hidden-xs > li:nth-child(1) > a")]
        public IWebElement BtnDdlIntl { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cafepress-navbar-main > ul.nav.navbar-nav.hidden-xs > li:nth-child(2) > a")]
        public IWebElement BtnNavShop { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cafepress-navbar-main > ul.nav.navbar-nav.hidden-xs > li:nth-child(3) > a")]
        public IWebElement BtnNavCreate { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cafepress-navbar-main > ul.nav.navbar-nav.hidden-xs > li:nth-child(4) > a")]
        public IWebElement BtnNavSell { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cafepress-navbar-main > ul.nav.navbar-nav.hidden-xs > li:nth-child(5) > a")]
        public IWebElement BtnNavGifts { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#searchInput")]
        public IWebElement InputNavSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cafepress-navbar-main > div > div.pull-left > form > div > div > span > button")]
        public IWebElement BtnNavSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cp_NavBarCart")]
        public IWebElement BtnCartQuickView { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#featureditems")]
        public IWebElement ContainerCartQuickViewFeaturedItems { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cp_ShoppingCartText")]
        public IWebElement ContainerCartQuickViewShoppingCart { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#shopping-cart > li > div.col-sm-4.col-xs-12 > div.row > div:nth-child(1) > h4")]
        public IWebElement TxtCartQuickViewSubtotal { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#shopping-cart > li > div.col-sm-4.col-xs-12 > div.row > div.col-xs-6.text-center > a")]
        public IWebElement BtnNavToCart { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cafepress-navbar-main > div > div.pull-right > ul > li:nth-child(2)")]
        public IWebElement BtnExpandUserAccount { get; set; }


        //intl currency dropdown options
        [FindsBy(How = How.CssSelector, Using = "#currencyOptions")]
        public IWebElement DdlExpandChangeCurrency { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#currencyOptions > option:nth-child(1)")]
        public IWebElement DdlAudCurrencyOption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#currencyOptions > option:nth-child(2)")]
        public IWebElement DdlCadCurrencyOption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#currencyOptions > option:nth-child(3)")]
        public IWebElement DdlEurCurrencyOption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#currencyOptions > option:nth-child(4)")]
        public IWebElement DdlGbpCurrencyOption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#currencyOptions > option:nth-child(5)")]
        public IWebElement DdlUsdCurrencyOption { get; set; }


        //user account dropdown options
        [FindsBy(How = How.CssSelector, Using = "#account > li > div > a.btn-block.btn.btn-success")]
        public IWebElement BtnUaSignOut { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#account > li > div > a:nth-child(2)")]
        public IWebElement BtnUaTrackOrder { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#account > li > div > a:nth-child(4)")]
        public IWebElement BtnUaFavorites { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#account > li > div > a:nth-child(6)")]
        public IWebElement BtnUaSettings { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#account > li > div > a:nth-child(8)")]
        public IWebElement BtnUaHelp { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#account > li > div > a:nth-child(10)")]
        public IWebElement BtnUaShops { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#account > li > div > a:nth-child(3)")]
        public IWebElement BtnUaViewProfile { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#account > li > div > a:nth-child(5)")]
        public IWebElement BtnUaDashboard { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#account > li > div > a:nth-child(7)")]
        public IWebElement BtnUaMyDesigns { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#account > li > div > a:nth-child(9)")]
        public IWebElement BtnUaReports { get; set; }


        //page footer
        [FindsBy(How = How.CssSelector, Using = "body > footer")]
        public IWebElement ContainerGlobalFooter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#SubscribeEmail")]
        public IWebElement InputOfferEmailAddress { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#emailSignupForm > div > div.input-group > span > button")]
        public IWebElement BtnSubOfferEmail { get; set; }
        
        //social media
        [FindsBy(How = How.CssSelector, Using = "#cp_SocialMediaLinks > a.facebook > span.fa-stack.fa-lg > i.fa.fa-facebook.fa-stack-1x")]
        public IWebElement BtnFacebookSocialMediaLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cp_SocialMediaLinks > a.twitter")]
        public IWebElement BtnTwitterSocialMediaLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cp_SocialMediaLinks > a.pinterest > span.fa-stack.fa-lg > i.fa.fa-pinterest.fa-stack-1x")]
        public IWebElement BtnPinterestSocialMediaLink { get; set; }

        public void SmokeTestGlobalPageFooter()
        {
            var globalFooter = new List<IWebElement>
            {
                ContainerGlobalFooter,
                InputOfferEmailAddress,
                BtnSubOfferEmail,
                BtnFacebookSocialMediaLink,
                BtnPinterestSocialMediaLink,
                BtnTwitterSocialMediaLink
            };

            foreach (var element in globalFooter)
            {
                element.Verify();
            }
            Console.WriteLine("Verified global page footer");
        }

        public void VerifyPersistentNav()
        {
            var persistentNav = new List<IWebElement>
            {
                BtnDdlIntl,
                BtnNavShop,
                BtnNavCreate,
                BtnNavSell,
                BtnNavGifts,
                InputNavSearch,
                BtnNavSearch,
                BtnCartQuickView,
                BtnExpandUserAccount,
            };

            foreach (var element in persistentNav)
            {
                element.Verify();
            }
            Console.WriteLine("Verified persistent navigation elements");
        }
        

        public void VerifyCurrencyOptions()
        {
            var currencyOptions = new List<IWebElement>
            {
                DdlAudCurrencyOption,
                DdlCadCurrencyOption,
                DdlEurCurrencyOption,
                DdlGbpCurrencyOption,
                DdlUsdCurrencyOption,
            };

            BtnDdlIntl.Click();
            DdlExpandChangeCurrency.Click();

            foreach (var element in currencyOptions)
            {
                element.Verify();
            }

            BtnDdlIntl.Click();
            Console.WriteLine("Verified available currency options");
        }

        public void VerifyCartQuickViewElements()
        {
            BtnCartQuickView.Click();

            var cartElements = new List<IWebElement>
            {
                ContainerCartQuickViewFeaturedItems,
                ContainerCartQuickViewShoppingCart,
                TxtCartQuickViewSubtotal,
                BtnNavToCart,
            };

            foreach (var element in cartElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified cart quick view elements");
        }

        public void VerifyUserAccountElements()
        {
            var uaElements = new List<IWebElement>
            {
                BtnUaSignOut,
                BtnUaTrackOrder,
                BtnUaFavorites,
                BtnUaSettings,
                BtnUaHelp,
                BtnUaShops,
                BtnUaViewProfile,
                BtnUaDashboard,
                BtnUaMyDesigns,
                BtnUaReports,
            };

            BtnExpandUserAccount.Click();

            foreach (var element in uaElements)
            {
                element.Verify();
            }

            BtnExpandUserAccount.Click();
            Console.WriteLine("verified user account dropdown elements/options");
        }

        public void SmokeTestCommonNav()
        {
            VerifyPersistentNav();
            VerifyCartQuickViewElements();
            VerifyCurrencyOptions();
            VerifyUserAccountElements();
        }


        /// <summary>
        /// todo: hacky work around while cart save is broken- this needs to be removed once DE resolved
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > div > div > div.col-sm-7 > div > div.panel-heading > div > div.col-sm-3 > form > div > div.col-sm-12.text-center > button")]
        public IWebElement BtnAddToCartPdp { get; set; }

        public void AddItemToCart()
        {
            BtnAddToCartPdp.Click();    
        }

        public void AddItemAndGoToCart()
        {
            Driver.Navigate().GoToUrl("http://10.1.2.115/product/829702495");
            AddItemToCart();
            WaitForAjax();
        }
    }
}