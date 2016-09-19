using System;
using System.Collections.Generic;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.cafepress.com
{
    internal class CpCartPageObject
    {
        public CpCartPageObject()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#wasd1234")]
        public IWebElement Wasd1234 { get; set; }
        

        //expected elements

    }
}
