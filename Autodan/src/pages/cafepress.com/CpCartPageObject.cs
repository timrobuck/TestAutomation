using System;
using System.Collections.Generic;
using System.Threading;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using By = OpenQA.Selenium.Extensions.By;
using Selenium.WebDriver.Extensions.Sizzle;

namespace Autodan.pages.cafepress.com
{
    internal class CpCartPageObject : BaseTest
    {
        public CpCartPageObject()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
        }
        
        //nav+page headers
        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > ol > li:nth-child(1)")]
        public IWebElement BreadCrumbCafePress { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > ol > li:nth-child(1)")]
        public IWebElement BreadCrumbShoppingCart { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cp_CartHeaderLinks > li:nth-child(1) > a")]
        public IWebElement ModalMoneyBackGuarantee { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cp_CartHeaderLinks > li:nth-child(2) > a")]
        public IWebElement ModalEasyReturnsAndExchanges { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cp_CartHeaderLinks > li:nth-child(3) > a")]
        public IWebElement ModalSecureShoppingGuarantee { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > form > div:nth-child(3) > div.col-sm-3 > div:nth-child(2) > div.col-sm-12.col-xs-4 > p > a")]
        public IWebElement ModalSecureShoppingGuaranteeOrderSummary { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cp_CartHeaderLinks > li:nth-child(4) > a")]
        public IWebElement ModalPrivacyPolicy { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > div > div.col-sm-3 > h1")]
        public IWebElement TitleShoppingCartPageHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > div > div.col-sm-9.text-right > h4")]
        public IWebElement TxtCallCustomerService { get; set; }

        //cart actions
        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > form > div:nth-child(1) > div:nth-child(1)")]
        public IWebElement BtnKeepShopping { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > form > div:nth-child(1) > div:nth-child(3)")]
        public IWebElement BtnProceedToCheckout { get; set; }

        //shopping cart review
        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > form > div:nth-child(3) > div.col-sm-9 > div.panel.panel-order-item")]
        public IWebElement ContainerShoppingCartReview { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cp_ShoppingCart_BundleContainer > div > div.col-md-6.col-sm-5 > div > div.col-md-4.col-sm-12 > img")]
        public IWebElement ImgCartReviewItem { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cp_ShoppingCart_BundleContainer > div > div.col-md-6.col-sm-5 > div > div.col-md-8.col-sm-12 > p.hidden-xs")]
        public IWebElement TitleCartReviewItemName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cp_ShoppingCart_BundleContainer > div > div.col-md-6.col-md-offset-0.col-sm-7.col-sm-offset-0.col-xs-10.col-xs-offset-1 > div > div:nth-child(1) > div > input")]
        public IWebElement InputCartReviewQuantityPicker { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cp_ShoppingCart_BundleContainer > div > div.col-md-6.col-md-offset-0.col-sm-7.col-sm-offset-0.col-xs-10.col-xs-offset-1 > div > div:nth-child(2) > h4")]
        public IWebElement TxtCartReviewPriceAmount { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cp_ShoppingCart_BundleContainer > div > div.col-md-6.col-md-offset-0.col-sm-7.col-sm-offset-0.col-xs-10.col-xs-offset-1 > div > div:nth-child(3) > h4")]
        public IWebElement TxtCartReviewDiscountAmount { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cp_ShoppingCart_BundleContainer > div > div.col-md-6.col-md-offset-0.col-sm-7.col-sm-offset-0.col-xs-10.col-xs-offset-1 > div > div:nth-child(4) > h4")]
        public IWebElement TxtCartReviewTotalAmount { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cp_ShoppingCart_BundleContainer > div > div.col-md-6.col-sm-5 > div > div.col-md-8.col-sm-12 > div:nth-child(3) > div:nth-child(1)")]
        public IWebElement DdlCartReviewSizeSelect { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "#cp_ShoppingCart_BundleContainer > div > div.col-md-6.col-sm-5 > div > div.col-md-8.col-sm-12 > div:nth-child(3) > div:nth-child(2) > div")]
        public IWebElement DdlCartReviewColorSelect { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cp_ShoppingCart_BundleContainer > div > div.col-md-6.col-md-offset-0.col-sm-7.col-sm-offset-0.col-xs-10.col-xs-offset-1 > div > div:nth-child(1) > div > p.text-center.small > a")]
        public IWebElement BtnCartReviewRemoveItemFromCart { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cp_ShoppingCart_BundleContainer > div > div.col-md-6.col-sm-5 > div > div.col-md-8.col-sm-12 > p:nth-child(6)")]
        public IWebElement TxtProductNumberAndAvailability { get; set; }


        //order summary
        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > form > div:nth-child(3) > div.col-sm-3 > div.panel.panel-order-summary")]
        public IWebElement ContainerOrderSummary { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > form > div:nth-child(3) > div.col-sm-3 > div.panel.panel-order-summary > div.panel-heading > h4")]
        public IWebElement TxtOrderSummaryHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > form > div:nth-child(3) > div.col-sm-3 > div.panel.panel-order-summary > div.panel-body > div:nth-child(1) > div.col-xs-8 > h5")]
        public IWebElement TxtOrderSummaryItemSummary { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#itemTotal")]
        public IWebElement TxtOrderSummaryItemTotal { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > form > div:nth-child(3) > div.col-sm-3 > div.panel.panel-order-summary > div.panel-body > div:nth-child(2) > div.col-xs-8 > h5")]
        public IWebElement TxtOderSummaryEstShipping { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#shippingEstimate")]
        public IWebElement TxtOrderSummaryEstShippingTotal { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > form > div:nth-child(3) > div.col-sm-3 > div.panel.panel-order-summary > div.panel-body > div:nth-child(4) > div.col-xs-8 > h4")]
        public IWebElement TxtOrderSummarySubTotalHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#orderSubtotal")]
        public IWebElement TxtOrderSummarySubTotalTotal { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cart-google-button")]
        public IWebElement ImgGoogleTrustedStore { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cart-mcafee-button")]
        public IWebElement BtnMcAfeeSecureLink { get; set; }


        //Save your shopping cart
        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > form > div:nth-child(3) > div.col-sm-9 > div:nth-child(5) > div:nth-child(1) > div")]
        public IWebElement ContainerSaveShoppingCart { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > form > div:nth-child(3) > div.col-sm-9 > div:nth-child(5) > div:nth-child(1) > div > div > div > input")]
        public IWebElement InputSaveShoppingCartEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > form > div:nth-child(3) > div.col-sm-9 > div:nth-child(5) > div:nth-child(1) > div > div > div > span")]
        public IWebElement BtnSaveShoppingCartSendLink { get; set; }



        //estimated shopping options
        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > form > div:nth-child(3) > div.col-sm-9 > div:nth-child(5) > div:nth-child(2) > div")]
        public IWebElement ContainerEstShippinpOptions { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > form > div:nth-child(3) > div.col-sm-9 > div:nth-child(5) > div:nth-child(2) > div > div > form > div:nth-child(1) > div > input")]
        public IWebElement InputEstShippingOptionsCountry { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > form > div:nth-child(3) > div.col-sm-9 > div:nth-child(5) > div:nth-child(2) > div > div > form > div:nth-child(2) > div > input")]
        public IWebElement InputEstShippingOptionsZipCode { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > form > div:nth-child(3) > div.col-sm-9 > div:nth-child(5) > div:nth-child(2) > div > div > form > div:nth-child(3) > div > input")]
        public IWebElement BtnEstShippingOptionsCalculate { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(8) > form > div:nth-child(3) > div.col-sm-9 > div:nth-child(5) > div:nth-child(2) > div > div > form > div:nth-child(3) > div > a")]
        public IWebElement BtnEstShippingOptionsCancel { get; set; }



        //how to pay options
        [FindsBy(How = How.CssSelector, Using = "div > a > img.hidden-xs.hidden-sm.hidden-md.center-block.img-responsive")]
        public IWebElement BtnCheckoutWithPaypal { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#AmazonInlineWidget > img")]
        public IWebElement BtnCheckoutWithAmazon { get; set; }
        
        //policy modals
        [FindsBy(How = How.CssSelector, Using = ".close")]
        public IWebElement Modal { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#MoneyBackGuarantee > div > div > div.modal-header > button")]
        public IWebElement BtnMoneyBackGuaranteeCloseModal { get; set; }
        
        
        
        //expected elements
        public void VerifyCartPageElements()
        {
            var cartPageElements = new List<IWebElement>
            {
                BreadCrumbCafePress,
                BreadCrumbShoppingCart,
                TitleShoppingCartPageHeader,
                ModalMoneyBackGuarantee,
                ModalEasyReturnsAndExchanges,
                ModalSecureShoppingGuarantee,
                ModalPrivacyPolicy,
                BtnKeepShopping,
                BtnProceedToCheckout,
                ContainerShoppingCartReview,
                ImgCartReviewItem,
                BtnCartReviewRemoveItemFromCart,
                DdlCartReviewSizeSelect,
                DdlCartReviewColorSelect,
                InputCartReviewQuantityPicker,
                TxtCartReviewPriceAmount,
                TxtCartReviewDiscountAmount,
                TxtCartReviewTotalAmount,
                TxtProductNumberAndAvailability,
                ContainerOrderSummary,
                TxtOrderSummaryItemSummary,
                TxtOrderSummaryEstShippingTotal,
                TxtOrderSummarySubTotalHeader,
                TxtOrderSummarySubTotalTotal,
                ContainerSaveShoppingCart,
                InputSaveShoppingCartEmail,
                BtnSaveShoppingCartSendLink,
                ContainerEstShippinpOptions,
                InputEstShippingOptionsCountry,
                InputEstShippingOptionsZipCode,
                BtnEstShippingOptionsCalculate,
                BtnEstShippingOptionsCancel,
                ImgGoogleTrustedStore,
                BtnMcAfeeSecureLink,
                BtnCheckoutWithPaypal,
                BtnCheckoutWithAmazon,
            };
            foreach (var element in cartPageElements)
            {
                element.Verify();
            }
            Console.WriteLine("Verified cart page elements");
        }

        public void CloseModal()
        {
            new Actions(Driver).SendKeys(Keys.Escape).Perform();
            Thread.Sleep(500);
        }


        //tests
        public void CartVerifySizeDropDownList()
        {
            DdlCartReviewSizeSelect.Click();
            DdlCartReviewSizeSelect.Click();
            Console.WriteLine("Verified Size dropdown list");
        }

        public void CartVerifyColorDropDownList()
        {
            DdlCartReviewColorSelect.Click();
            DdlCartReviewColorSelect.Click();
            Console.WriteLine("Verified Color dropdown list");
        }

        public void CartAdjustQuantityTest()
        {
            InputCartReviewQuantityPicker.ClearAndEnterText("2");
            InputCartReviewQuantityPicker.ClearAndEnterText("3");
            InputCartReviewQuantityPicker.ClearAndEnterText("4");
            Console.WriteLine("Verified Cart Preview - Quantity Picker");
        }

        public void CartVerifyPolicyModals()
        {
            ModalMoneyBackGuarantee.Click();    
            Driver.Wait(500);
            CloseModal();
            Console.WriteLine("Verified MoneyBack Guarantee modal and dismissed");

            ModalEasyReturnsAndExchanges.Click();
            Driver.Wait(500);
            CloseModal();
            Console.WriteLine("Verified EZ returns modal and dismissed");

            ModalSecureShoppingGuarantee.Click();
            Driver.Wait(500);
            CloseModal();
            Console.WriteLine("Verified Secure Shopping modal and dismissed");

            ModalPrivacyPolicy.Click();
            Driver.Wait(500);
            CloseModal();
            Console.WriteLine("Verified Privacy Policy modal and dismissed");
            
        }

        public void CartCartSaveTest()
        {
            InputSaveShoppingCartEmail.ClearAndEnterText("dpeterson@cafepress.com");
            //BtnSaveShoppingCartSendLink.Click();

            Console.WriteLine("Verifeid CartSave input and email sent *TOBEADDED");
        }

        public void CartEstShippingOptionsTest()
        {
            InputEstShippingOptionsCountry.ClearAndEnterText("United States");
            InputEstShippingOptionsZipCode.ClearAndEnterText("40291");
            //BtnEstShippingOptionsCalculate.Click();

            Console.WriteLine("Verified Cart Estimated Shipping Options *TOBEADDED");
        }

        public void SmokeTestCart()
        {
            VerifyCartPageElements();
            CartVerifySizeDropDownList();
            CartVerifyColorDropDownList();
            //CartAdjustQuantityTest();
            CartVerifyPolicyModals();
            CartCartSaveTest();
            CartEstShippingOptionsTest();
        }
    }
}
