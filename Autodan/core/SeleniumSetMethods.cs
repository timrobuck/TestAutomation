using System.Linq;
using NUnit.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Autodan.core
{
    public static class SeleniumSetMethods
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
        /// Click into a button, Checkbox, option etc
        /// </summary>
        /// <param name="element"></param>
        public static void Clicks(this IWebElement element)
        {
            element.Click();
        }

        /// <summary>
        /// Selecting a dropdown contorl
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SelectDropdown(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }



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
    }
}
