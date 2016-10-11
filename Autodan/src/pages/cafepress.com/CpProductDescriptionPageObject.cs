using System;
using System.Collections.Generic;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.cafepress.com
{
    internal class CpProductDescriptionPageObject
    {
        public CpProductDescriptionPageObject()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#AddToCartButtonId")]
        public IWebElement BtnAddToCart { get; set; }


        //expected eles

        //page actions
        public void AddItemToCart()
        {
            BtnAddToCart.Click();
        }
    }
}