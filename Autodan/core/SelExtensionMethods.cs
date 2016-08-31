using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Autodan.core
{
    public static class SelExtensionMethods
    {
        /// <summary>
        /// Extended method for entering text into the control
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        /// <summary>
        /// click, clear and enter text on an input
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void ClearAndEnterText(this IWebElement element, string value)
        {
            element.Click();
            element.Clear();
            element.SendKeys(value);
        }

        /// <summary>
        /// Selecting a dropdown control
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SelectDropdown(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }
        
        /// <summary>
        /// used to quickly verify presence of an element in dom; smoke/sanity tests
        /// </summary>
        /// <param name="element"></param>
        public static void Verify(this IWebElement element)
        {
            element.GetType();
        }

        public static bool VerifyIsPresent(this IWebDriver driver, By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// click and wait for up to value in seconds before error
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        /// <param name="value"></param>
        public static void ClickAndWait(this IWebElement element, IWebDriver driver, int value)
        {
            element.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(value));
        }

        public static string GetText(IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static string GetTextFromDdl(IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }
    }
}
