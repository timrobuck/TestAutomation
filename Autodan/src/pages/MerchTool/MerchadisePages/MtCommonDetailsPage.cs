using System.Collections.Generic;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.MerchadisePages
{
    public class MtMerchandiseDetailsPage : BaseTest
    {
        public string FirstRowContentFromLaunchPage { get; private set; }

        public MtMerchandiseDetailsPage(string firstRowContentFromLaunchPage)
        {
            PageFactory.InitElements(Driver, this);
            FirstRowContentFromLaunchPage = firstRowContentFromLaunchPage;
        }
        
        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > ul > li.active")]
        public IWebElement BreadCrumbDetails { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > legend")]
        public IWebElement Legend { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > div > label:nth-child(1)")]
        public IWebElement IdLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > div > span:nth-child(2)")]
        public IWebElement IdValue { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > div > i:nth-child(3)")]
        public IWebElement IdText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > div > label:nth-child(4)")]
        public IWebElement NameLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > div > span:nth-child(5)")]
        public IWebElement NameValue { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div.span9.view-container > fieldset > div > i:nth-child(6)")]
        public IWebElement NameText { get; set; }

        public void VerifyElements()
        {
            foreach (var element in new List<IWebElement>
            {
                BreadCrumbDetails,
                Legend,
                IdLabel,
                IdValue,
                IdText,
                NameLabel,
                NameValue,
                NameText
            })
                element.Verify();
        }

        public void ValidatePresentation()
        {
            BreadCrumbDetails.ValidateTextIsInThisElement("Details");
            Legend.ValidateTextIsInThisElement("Details");
            IdLabel.ValidateTextIsInThisElement("Id");
            IdValue.ValidateValueIsNumeric();
            IdText.ValidateTextIsInThisElement("This uniquely identifies this sales channel from other sales channels");
            NameLabel.ValidateTextIsInThisElement("Name");
            NameValue.ValidateTextIsInThisElement(FirstRowContentFromLaunchPage);
            NameText.ValidateTextIsInThisElement("This text is not displayed on the site and is for internal use only");
        }
    }

}