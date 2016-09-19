using System;
using System.Collections.Generic;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.cafepress.com
{
    internal class CpCommonPageObject
    {
        public CpCommonPageObject()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
        }

        //comomon+shared nav elements
        [FindsBy(How = How.CssSelector, Using = "#wasd1234")]
        public IWebElement wasd1234 { get; set; }



        //expected elements


        //common page actions

    }
}
