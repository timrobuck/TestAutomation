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
        [FindsBy(How = How.CssSelector, Using = "wasd1234")]
        public IWebElement wasd1234 { get; set; }

        public void VerifyPersistentNav()
        {

        }
    }
}
