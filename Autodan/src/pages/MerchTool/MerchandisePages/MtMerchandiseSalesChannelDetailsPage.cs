﻿using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtMerchandiseSalesChannelDetailsPage
    {
        IWebElement NameContent { get; }
        void VerifyElements();
        void VerifyElementContent();
    }

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class MtMerchandiseSalesChannelDetailsPage : BaseTest, IMtMerchandiseSalesChannelDetailsPage, IBaseSmokeTest
    {
        private readonly IMtCommonToMerchandiseDetailsPage _commonPage; // i like as it reduces noise an makes allows better readability by grouping common paths stacked in single lines without anything in between.
        private const string IdLabelSelector =     "body > div.container > div.row > div.span9.view-container > fieldset > div > label:nth-child(1)";
        private const string IdContentSelector =   "body > div.container > div.row > div.span9.view-container > fieldset > div > span:nth-child(2)";
        private const string IdTextSelector =      "body > div.container > div.row > div.span9.view-container > fieldset > div > i:nth-child(3)";
        private const string NameLabelSelector =   "body > div.container > div.row > div.span9.view-container > fieldset > div > label:nth-child(4)";
        private const string NameContentSelector = "body > div.container > div.row > div.span9.view-container > fieldset > div > span:nth-child(5)";
        private const string NameSubTextSelector = "body > div.container > div.row > div.span9.view-container > fieldset > div > i:nth-child(6)";

        public MtMerchandiseSalesChannelDetailsPage() : this(new MtCommonToMerchandiseDetailsPage()){}
        public MtMerchandiseSalesChannelDetailsPage(IMtCommonToMerchandiseDetailsPage commonPage)
        {
            PageFactory.InitElements(Driver, this);
            _commonPage = commonPage;
        }

        [FindsBy(How = How.CssSelector, Using = IdLabelSelector)]
        private IWebElement IdLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = IdContentSelector)]
        private IWebElement IdContent { get; set; }

        [FindsBy(How = How.CssSelector, Using = IdTextSelector)]
        private IWebElement IdText { get; set; }

        [FindsBy(How = How.CssSelector, Using = NameLabelSelector)]
        private IWebElement NameLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = NameContentSelector)]
        public IWebElement NameContent { get; set; }

        [FindsBy(How = How.CssSelector, Using = NameSubTextSelector)]
        private IWebElement NameSubText { get; set; }

        public void VerifyElements()
        {
            var pageElements = new List<IWebElement>
            {
                IdLabel,
                IdText,
                IdContent,
                NameLabel,
                NameContent,
                NameSubText
            };
            foreach (var e in pageElements)
            {
                e.Verify();
            }
            _commonPage.VerifyElements();
            Console.WriteLine("Verified Elements on " + GetType().Name);
        }
        public void VerifyElementContent()
        {
            IdLabel.VerifyTextIsInThisElement("Id");
            IdContent.VerifyContentOfThisElementIsIntegerType();
            IdText.VerifyTextIsInThisElement("This uniquely identifies this sales channel from other sales channels");
            NameLabel.VerifyTextIsInThisElement("Name");
            NameContent.VerifyContentNotEmpty();
            NameSubText.VerifyTextIsInThisElement("This text is not displayed on the site and is for internal use only");
            Console.WriteLine("Verified Header elements have expected values on " + GetType().Name);
        }

        public void RunActions()
        {
            throw new NotImplementedException();
        }
    }
}
