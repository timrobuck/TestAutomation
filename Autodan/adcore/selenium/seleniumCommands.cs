using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodan.adcore.selenium
{

    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        ClassName,
    }

    class Tester
    {
        //Auto-implement property
        public static IWebDriver driver { get; set; }
    }
}

public static class WebDriverExtensions
{
    //Displayed
    public static bool IsElementDisplayed(this IWebDriver driver, By element)
    {
        if (driver.FindElements(element).Count > 0)
        {
            if (driver.FindElement(element).Displayed)
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }
    }

    //Enabled
    public static bool IsElementEnabled(this IWebDriver driver, By element)
    {
        if (driver.FindElements(element).Count > 0)
        {
            if (driver.FindElement(element).Enabled)
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }

    }
}