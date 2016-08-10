using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Autodan.adcore.selenium;

namespace Autodan.src.pages
{
    
    class ShippingManagerLoginPageElements
    {

        public ShippingManagerLoginPageElements()
        {
            PageFactory.InitElements(Tester.driver, this);
        }
        
        [FindsBy(How = How.CssSelector, Using = ".navbar-text")]
        public IWebElement CafepressImageLogo { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".navbar-text")]
        public IWebElement ShippingManagerPageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".container.view-container>h1")]
        public IWebElement LoginHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#UserName")]
        public IWebElement UsernameInputField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#Password")]
        public IWebElement PasswordInputField { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-lg.btn-primary.btn-block")]
        public IWebElement LoginBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "html>body>footer")]
        public IWebElement PageFooter { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".container>p")]
        public IWebElement CopyrightFooter { get; set; }

    }
}