﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace Autodan.core
{
    internal enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        ClassName
    }

    public class BaseTest
    {
        public static IWebDriver Driver;
        
        //setup method wrapper
        public void Setup(string browserName, string serviceUrl)
        {
            if (browserName.Equals("ie"))
                Driver = new InternetExplorerDriver();
            else if (browserName.Equals("chrome"))
                Driver = new ChromeDriver();
            else if (browserName.Equals("firefox"))
                Driver = new FirefoxDriver();
            else
                Driver = new ChromeDriver();

            if (serviceUrl.ToLower().Equals("shippingmanager"))
                Driver.Navigate().GoToUrl("http://tools.cafepress.com/Shipping/");
            else if (serviceUrl.ToLower().Equals("merchtool"))
                Driver.Navigate().GoToUrl("http://tools.cafepress.com/Merchandise/");

            Console.WriteLine("Created fresh " + browserName + " instance");
            Driver.Manage().Window.Maximize();
            Console.WriteLine("Instance window maximized");
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            
            if (serviceUrl.ToLower().Equals("shippingmanager"))
                Driver.Navigate().GoToUrl("http://tools.cafepress.com/Shipping/");
            else if (serviceUrl.ToLower().Equals("merchtool"))
                Driver.Navigate().GoToUrl("http://tools.cafepress.com/Merchandise/");
            
            //UPDATE THIS
            Console.WriteLine("Navigated to: " + serviceUrl);
        }

        [TearDown]
        public void Cleanup()
        {
            Driver.Quit();
        }
    }
}