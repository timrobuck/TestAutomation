using System;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.SmartProductEnginePages
{
    public class MtCommonToSpePages : BaseTest
    {
        public MtCommonToSpePages(string pageName)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > ul > li:nth-child(1) > a")]
        public IWebElement BreadCrumbHome { get; set; }//always "Home"

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > ul > li:nth-child(2) > a")]
        public IWebElement BreadCrumbSmartProductEngine { get; set; }// always "Smart Product Engine" 

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset:nth-child(4) > i")]
        public IWebElement ToCreateANewLabel { get; set; }//always includes "To create " etc

        [FindsBy(How = How.ClassName, Using = "dataTables_paginate")]
        public IWebElement BtnSetPagination { get; set; }

        [FindsBy(How = How.ClassName, Using = "DataTables_sort_wrapper")]
        public IWebElement SortAscendingDescendingByTableColumnHeaderIdClickTheTriangle { get; set; }

        public void VerifyCommonElementsExist()
        {
            BreadCrumbHome.Verify();
            BreadCrumbSmartProductEngine.Verify();
            ToCreateANewLabel.Verify();
            BtnSetPagination.Verify();
            SortAscendingDescendingByTableColumnHeaderIdClickTheTriangle.Verify();
            Console.WriteLine("Verified Common Elements");
        }

        public void VerifyCommonElementsHaveExpectedContent()
        {
            BreadCrumbHome.VerifyTextIsInThisElement("Home");
            BreadCrumbSmartProductEngine.VerifyTextIsInThisElement("Smart Product Engine");
            Console.WriteLine("Verified Common Elements Have Expected Content");
        }
    }
}
