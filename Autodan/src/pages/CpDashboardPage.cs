using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Autodan.adcore.selenium;

namespace Autodan.src.pages
{
    
    class CpDashboardPage
    {

        public CpDashboardPage()
        {
            PageFactory.InitElements(Tester.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#eic")]
        public IWebElement FirstTimeDiscountOverlayContainer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#eic-close")]
        public IWebElement FirstTimeDiscountOverlayCloseBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".shop-text")]
        public IWebElement MainNavigationShopBtn { get; set; }

    }
}