﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

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


    public class BaseTest : Attribute
    {
        public const string SkipSetup = "SkipSetup";

        public static IWebDriver Driver;

        //setup
        public void Setup(string browserName, string serviceUrl)
        {
            if (browserName.ToLower().Equals("ie"))
                Driver = new InternetExplorerDriver();
            else if (browserName.ToLower().Equals("chrome"))
                Driver = new ChromeDriver();
            else if (browserName.ToLower().Equals("firefox"))
                Driver = new FirefoxDriver();
            else if (browserName.ToLower().Equals("headless"))
                Driver = new PhantomJSDriver();
            else
                Driver = new ChromeDriver();

            if (serviceUrl.ToLower().Equals("shippingmanager"))
                Driver.Navigate().GoToUrl("http://tools.cafepress.com/Shipping/");
            else if (serviceUrl.ToLower().Equals("merchtool"))
                Driver.Navigate().GoToUrl("http://tools.cafepress.com/Merchandise/");
            else if (serviceUrl.ToLower().Equals("cafepress.dev"))
                Driver.Navigate().GoToUrl("http://10.1.2.115/");
            else if (serviceUrl.ToLower().Equals("cafepress.live"))
                Driver.Navigate().GoToUrl("https://cafepress.com/");


            Console.WriteLine("Created fresh " + browserName + " instance");
            Driver.Manage().Window.Maximize();
            Console.WriteLine("Instance window maximized");
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            Console.WriteLine("Navigated to: " + serviceUrl);
        }

        [TearDown]
        //runs teardown- closes active instance and retires process 
        public void Cleanup()
        {
            Driver.Quit();
        }

        /// do not confuse with .Quit method-  close simply closes the browser
        /// the process will continue until retired/disposed
        public void DriverClose()
        {
            Driver.Close();
        }

        public void DriverDispose()
        {
            Driver.Dispose();
        }


        
        /// sleeps on ajax requests
        public void WaitForAjax(int timeout = 30)
        {
            var sw = new Stopwatch();
            sw.Start();
            while (true)
            {
                if (sw.Elapsed.Seconds > timeout) throw new Exception("Timeout");
                var javaScriptExecutor = Driver as IJavaScriptExecutor;
                var ajaxIsComplete = javaScriptExecutor != null &&
                                     (bool)javaScriptExecutor.ExecuteScript("return jQuery.active == 0");
                if (ajaxIsComplete)
                    break;
                Thread.Sleep(100);
            }
        }

        public bool CheckForSkipSetup()
        {
            var categories = TestContext.CurrentContext.Test
                .Properties["Category"];

            var skipSetup = categories != null && categories.Contains(SkipSetup);
            return skipSetup;
        }
    }
}