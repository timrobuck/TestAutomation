using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;

namespace Autodan.core
{
    public static class SelExtensionMethods
    {
        // ReSharper disable once NotAccessedField.Local //need this to hide noise from resharper
        private static Type _type;

        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        // click, clear and enter text on an input
        public static void ClearAndEnterText(this IWebElement element, string value)
        {
            element.Click();
            element.Clear();
            element.SendKeys(value);
        }

        // Selecting a dropdown control
        public static void SelectDropdown(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }

        public static void SelectDropdownWithWait(this IWebElement element, IWebDriver driver, string value, int wait)
        {
            new SelectElement(element).SelectByText(value);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(wait));
        }

        // verify presence of an element in dom; smoke/sanity tests
        public static void Verify(this IWebElement element)
        {
            _type = element.GetType();
        }
        // verify presence of element: if used with 'debugger.isattched' condition and run debug from test runner, this can give a list of all failures in a test suite on single run
        public static bool VerifyOrSendMessage(this IWebElement element)
        {
            try
            {
                _type = element.GetType();
            }
            catch (Exception ex)
            {
                var sb = new StringBuilder();
                sb.Append(" ERROR!   ").Append(ex.Message);
                if (!Debugger.IsAttached) throw new Exception(sb.ToString());
                WriteLine(sb.ToString());
                return false;
            }
            return true;
        }

        //// <summary>
        //note:some elements are present and required only if an optional element is first present.
        //approach: we will examine if the optional is present then and only then will an error be thrown if the required element is missing
        //// </summary>
        public static bool VerifyElementDependentOnOptionalElement(this IWebElement requiredDependent, IWebElement optional)
        {
            try { _type = optional.GetType(); }
            catch { return false; }

            try { requiredDependent.Verify(); }
            catch (Exception ex)
            {
                var sb = new StringBuilder();
                sb.Append(" ERROR!   ").Append(ex.Message).Append("Element is dependent and required on if optional element is present");
                if (!Debugger.IsAttached) throw new Exception(sb.ToString());
                WriteLine();
                return false;
            }
            return true;
        }

        public static void VerifyTextIsInThisElement(this List<IWebElement> elements, int orderOfOccuranceOnPage, string targetContent)
        {
            if (!elements[orderOfOccuranceOnPage - 1].Text.Contains(targetContent))
                throw new Exception("targetText=" + targetContent + " was not found for this element.");
        }

        public static void VerifyAndVerifyExpectedContent(this IWebElement element, string targetText)
        {
            _type = element.GetType();
            VerifyTextIsInThisElement(element, targetText);
        }

        public static int VerifyContentOfThisElementIsIntegerType(this IWebElement element)
        {
            return int.Parse(element.Text.Trim());
        }

        public static void VerifyTextIsInThisElement(this IWebElement element, string targetContent)
        {
            if (!element.Text.Contains(targetContent))
                throw new Exception("element.text=" + element.Text + " but targetText=" + targetContent + " does not match.");
        }

        public static void VerifyContentNotEmpty(this IWebElement element)
        {
            if (string.IsNullOrEmpty(element.Text))
                throw new Exception(" Empty String : Content Value is Missing ");
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

        public static void ClickAndWait(this IWebElement element, IWebDriver driver, int seconds)
        {
            element.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
        }

        // <summary>
        // click and wait for up to value in seconds before error
        // </summary>
        // <param name="element"></param>
        // <param name="driver"></param>
        // <param name="value"></param>
        public static void ClickAndWait(this IWebElement element, int value)
        {
            element.Click();
            Thread.Sleep(value);
        }

        public static void Wait(this IWebDriver driver, int value)
        {
            Thread.Sleep(value);
        }

        public static string GetText(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static string GetTextFromDdl(IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault()?.Text;
        }
    }
}
