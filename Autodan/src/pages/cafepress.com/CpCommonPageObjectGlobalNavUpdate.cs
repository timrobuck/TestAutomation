using System;
using System.Collections.Generic;
using Autodan.core;
using OpenQA.Selenium;
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
        

        //shopby DDL hover expand views        
        [FindsBy(How = How.CssSelector, Using = "#b_ghmenus > div.b_ghmenu.menu-target.b_ghmenu_product")]
        public IWebElement ContainerGlobalNavProductsExpand { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_ghmenus > div.b_ghmenu.menu-target.b_ghmenu_interest")]
        public IWebElement ContainerGlobalNavInterestsExpand { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_ghmenus > div.b_ghmenu.menu-target.b_ghmenu_recipient")]
        public IWebElement ContainerGlobalNavRecipientsExpand { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#b_ghmenus > div.b_ghmenu.menu-target.b_ghmenu_occasion")]
        public IWebElement ContainerGlobalNavOccasionsExpand { get; set; }


        //global Footer
        [FindsBy(How = How.CssSelector, Using = "#emailSignupForm > label")]
        public IWebElement TxtGetExclusiveOffers { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#emailSignupForm > div > input")]
        public IWebElement InputEmailAddressOffers { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#emailSignupForm > div > button")]
        public IWebElement BtnSubscribeOffers { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#emailSignupForm > div > div.email-checkbox > input")]
        public IWebElement CheckboxAgeVerification { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-social")]
        public IWebElement TxtSocialMediaFollow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-social > div > a:nth-child(1)")]
        public IWebElement BtnSocialMediaFacebook { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-social > div > a:nth-child(2)")]
        public IWebElement BtnSocialMediaTwitter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-social > div > a:nth-child(3)")]
        public IWebElement BtnSocialMediaPinterest { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(1) > h4")]
        public IWebElement TxtHelpHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(1) > div > li:nth-child(1) > a")]
        public IWebElement LinkTrackOrder { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(1) > div > li:nth-child(2) > a")]
        public IWebElement LinkFaq { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(1) > div > li:nth-child(3) > a")]
        public IWebElement LinkReturns { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(1) > div > li:nth-child(4) > a")]
        public IWebElement LinkShipping { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(1) > div > li:nth-child(5) > a")]
        public IWebElement LinkContactUs { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(2) > h4")]
        public IWebElement TxtAboutHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(2) > div > li:nth-child(1) > a")]
        public IWebElement LinkAboutCafePress { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(2) > div > li:nth-child(2) > a")]
        public IWebElement LinkBlog { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(2) > div > li:nth-child(3) > a")]
        public IWebElement LinkPrivacyStatement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(2) > div > li:nth-child(4) > a")]
        public IWebElement LinkReportInfringement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(2) > div > li:nth-child(5) > a")]
        public IWebElement LinkSitemap { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(2) > div > li:nth-child(6) > a")]
        public IWebElement LinkTags { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(2) > div > li:nth-child(7) > a")]
        public IWebElement LinkProducts { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(3) > h4")]
        public IWebElement TxtInternationalHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(3) > div > li:nth-child(1) > a")]
        public IWebElement LinkAustralia { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(3) > div > li:nth-child(2) > a")]
        public IWebElement LinkCanada { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(3) > div > li:nth-child(3) > a")]
        public IWebElement LinkUnitedKindom { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.footer-ribbon-wrap.clearfix > ul:nth-child(3) > div > li:nth-child(4) > a")]
        public IWebElement LinkUsAndWorld { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div.copyright > a")]
        public IWebElement LinkUserAgreement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#scanalert > a > img")]
        public IWebElement BtnMacAfeeSecure { get; set; }


        //Cart hover quick view
        [FindsBy(How = How.CssSelector, Using = "#nav-cart-upsell")]
        public IWebElement ContainerCartHoverUpSell { get; set; } //always available

        [FindsBy(How = How.CssSelector, Using = "#sub-nav-cart > div.cart-empty")]
        public IWebElement TxtEmptyCartHeader { get; set; } //requires empty cart

        [FindsBy(How = How.CssSelector, Using = "#sub-nav-cart > a.cart-btn-wrap.top > input")]
        public IWebElement BtnCartHoverProceedToCheckout { get; set; } //item required in cart

        [FindsBy(How = How.CssSelector, Using = "#sub-nav-cart > div:nth-child(2)")]
        public IWebElement TxtCartHoverCartHeader { get; set; } //item required in cart

        [FindsBy(How = How.CssSelector, Using = "#intentionallyBadSelector")]
        public IWebElement BadSelector { get; set; } //item required in cart



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

        public void VerifySearchInput()
        {
            DdlGlobalNavSearchProductType.Click();
            InputGlobalNavSearch.ClearAndEnterText("test text");
        }

        public void VerifyGlobalNavExpandedView()
        {
            const int animationTime = 1000;

            DdlGlobalNavProducts.HoverAndVerify(ContainerGlobalNavProductsExpand, Driver, animationTime);
            DdlGlobalNavInterests.HoverAndVerify(ContainerGlobalNavInterestsExpand, Driver, animationTime);
            DdlGlobalNavRecipients.HoverAndVerify(ContainerGlobalNavRecipientsExpand, Driver, animationTime);
            DdlGlobalNavOccasions.HoverAndVerify(ContainerGlobalNavOccasionsExpand, Driver, animationTime);

            Console.WriteLine("Verified expanded Shop By Expanded options");
        }

        public void VerifyCartHoverWithItem()
        {
            const int hoverLoadTime = 2000;

            BtnGlobalNavCart.HoverAndVerify(ContainerCartHoverUpSell, Driver, hoverLoadTime);
            BtnGlobalNavCart.HoverAndVerify(BtnCartHoverProceedToCheckout, Driver, hoverLoadTime);
            BtnGlobalNavCart.HoverAndVerify(TxtCartHoverCartHeader, Driver, hoverLoadTime);

            Console.WriteLine("Verifeid cart hover menu with an item in the cart");
        }

        public void VerifyCartHoverEmptyCart()
        {
            const int hoverLoadTime = 2000;

            BtnGlobalNavCart.HoverAndVerify(ContainerCartHoverUpSell, Driver, hoverLoadTime);
            BtnGlobalNavCart.HoverAndVerify(TxtEmptyCartHeader, Driver, hoverLoadTime);

            Console.WriteLine("Verified Cart hover menu with no items in cart");
        }

        public void VerifyFooterExclusiveOffers()
        {
            var exclusiveOffersElements = new List<IWebElement>
            {
                TxtGetExclusiveOffers,
                InputEmailAddressOffers,
                BtnSubscribeOffers,
                CheckboxAgeVerification,
            };

            foreach (var element in exclusiveOffersElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified Exclusive Offers elements");
        }

        public void VerifyFooterSocialMediaElements()
        {
            var cpSocialMediaElements = new List<IWebElement>
            {
                BtnSocialMediaFacebook,
                BtnSocialMediaTwitter,
                BtnSocialMediaPinterest,
            };
            foreach (var element in cpSocialMediaElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified Social Media Links");
        }

        public void VerifyFooterHelpElements()
        {
            var helpElements = new List<IWebElement>
            {
                TxtHelpHeader,
                LinkTrackOrder,
                LinkFaq,
                LinkReturns,
                LinkShipping,
                LinkContactUs,
            };
            foreach (var element in helpElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified Help sublinks");
        }

        public void VerifyFooterAboutElements()
        {
            var aboutElements = new List<IWebElement>
            {
                TxtAboutHeader,
                LinkAboutCafePress,
                LinkBlog,
                LinkPrivacyStatement,
                LinkReportInfringement,
                LinkSitemap,
                LinkTags,
                LinkProducts,
            };
            foreach (var element in aboutElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified About sublinks");
        }

        public void VerifyInternationalElements()
        {
            var internationalElements = new List<IWebElement>
            {
                TxtInternationalHeader,
                LinkAustralia,
                LinkCanada,
                LinkUnitedKindom,
                LinkUsAndWorld,
            };
            foreach (var element in internationalElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified International sublinks");
        }

        public void VerifyFooterUserAgreement()
        {
            LinkUserAgreement.Verify();
            Console.WriteLine("Verified User Agreement link present");
        }

        public void VerifyFooterMcAfeeSecure()
        {
            BtnMacAfeeSecure.Verify();
            Console.WriteLine("Verified McAfee Secure link/button");
        }
    }
}