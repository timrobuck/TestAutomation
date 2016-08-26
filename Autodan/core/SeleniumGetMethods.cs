using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Autodan.core
{
    internal class SeleniumGetMethods
    {
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
