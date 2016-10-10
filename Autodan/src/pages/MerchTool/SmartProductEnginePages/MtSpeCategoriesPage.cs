using System;
using System.Collections.Generic;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.SmartProductEnginePages
{
    public class MtSpeCategoriesPage:BaseTest
    {
        private readonly MtCommonToSpePages _mtCommonToSpePages;
        private string pageName = "Smart Product Engine Categores Page";
        private readonly MtCommonToEditDetailPages _mtCommonToEditDetailPages;

        public MtSpeCategoriesPage()
        {
            PageFactory.InitElements(Driver, this);
            _mtCommonToSpePages = new MtCommonToSpePages(pageName);
            _mtCommonToEditDetailPages = new MtCommonToEditDetailPages();
        }
        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories_length > label")]
        public IWebElement LableShowEntries { get; set; } //always includes "Show " etc

        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories_length > label > select")]
        public IWebElement DropDownNumberOfEntriesToShow { get; set; }//always includes "50,25,10

        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories_filter > label > input")]
        public IWebElement InputFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories_filter")]
        public IWebElement LabelFilter { get; set; }//always includes "Filter:"

        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories > tbody > tr:nth-child(1) > td:nth-child(4) > label")]
        private IWebElement CheckBoxRemoveRecord { get; set; } //do not test this until stage is ready.

        //table body record content
        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories > tbody > tr:nth-child(1) > td:nth-child(3) > a")]
        public IWebElement NavigateToEditDetailsPage { get; set; } //click the "edit" to navigate to the details edit page

        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories_info")]
        public IWebElement ShowingEntries { get; set; }

        //Columns
        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories > thead > tr > td:nth-child(1) > div")]
        public IWebElement Column1Header { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories > thead > tr > td:nth-child(2) > div")]
        public IWebElement Column2Header { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories > thead > tr > td:nth-child(3) > div")]
        public IWebElement Column3Header { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories > thead > tr > td:nth-child(4) > div")]
        public IWebElement Column4Header { get; set; }

        //assuming there is at least 2 valid rows in the table body
        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories > tbody > tr:nth-child(2) > td:nth-child(3) > a")]
        public IWebElement ClickableEditFrom2ndRow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories > tbody > tr:nth-child(2) > td:nth-child(2)")]
        public IWebElement Column2Row2FromTable { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories > tbody > tr:nth-child(2) > td.sorting_1")]
        public IWebElement Column1Row2FromTable { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories_info")]
        public IWebElement Showing1ToXofYentries { get; set; }


        public void VerifyElementsExist()
        {
            _mtCommonToSpePages.VerifyCommonElementsExist();
            VerifyUniqueElementsExist();
            Console.WriteLine("Verified Elements Exist on " + pageName);
        }
        public void VerifyElementsHaveExpectedContent()
        {
            _mtCommonToSpePages.VerifyCommonElementsHaveExpectedContent();
            VerifyUniqueElementsHaveExpectedContent();
            Console.WriteLine("Verified Elements have Expected Content on " + pageName);
        }

        public void RunActions()
        {
            ActionSelectNumberOfLines();
            Console.WriteLine("Verified the number of entries dropdown works.");
            ActionSortAscendingDescendingByTableColumnHeaderClick();
            Console.WriteLine("Verified Sort mechanism on each column header works.");
            //todo: UpdateExistigProductTypesExclusions.Click  do this only after stage is available
        }

        private void VerifyUniqueElementsExist()
        {
            var pageElements = new List<IWebElement>
            {
                LableShowEntries,
                DropDownNumberOfEntriesToShow,
                InputFilter,
                NavigateToEditDetailsPage,
                CheckBoxRemoveRecord,
                LabelFilter,
                Column1Header,
                Column2Header,
                Column3Header,
                Column4Header,
                ShowingEntries,
                Column1Row2FromTable,
                Column2Row2FromTable,
                Showing1ToXofYentries
            };

            foreach (var e in pageElements)
               e.Verify();
        }

        private void VerifyUniqueElementsHaveExpectedContent()
        {
            LableShowEntries.VerifyTextIsInThisElement("Show");
            NavigateToEditDetailsPage.VerifyTextIsInThisElement("edit");
            CheckBoxRemoveRecord.VerifyTextIsInThisElement("Remove");
            Column1Header.VerifyTextIsInThisElement("Category Name");
            Column2Header.VerifyTextIsInThisElement("Number of Product Types");
            Column3Header.VerifyTextIsInThisElement("Edit");
            Column4Header.VerifyTextIsInThisElement("Remove?");
        }
        private void ActionSelectNumberOfLines()
        {
            DropDownNumberOfEntriesToShow.SelectDropdownWithWait(Driver, "10", 5);
            DropDownNumberOfEntriesToShow.SelectDropdownWithWait(Driver, "10", 5);
            if (!ShowingEntries.Text.Contains("10"))
                throw new Exception("Select Number Of Lines to Show [50 to 10] did not work");

            Console.WriteLine("Verified the dropdown to filter lines from 50 to 10 for " + pageName);
        }

        private void ActionSortAscendingDescendingByTableColumnHeaderClick()
        {
            var beforeSortValue = Column1Row2FromTable.Text;
            _mtCommonToSpePages.SortAscendingDescendingByTableColumnHeaderIdClickTheTriangle.Click();
            var afterSortValue = Column1Row2FromTable.Text;
            if (beforeSortValue == afterSortValue)
                throw new Exception("Resorting items does not appear to work");
        }

        public void VerifyCountFromSpePageMatchesCountOnDetailsPage()
        {
            var originatingPageCount = Column2Row2FromTable.Text;
            NavigateToEditDetailsPage.ClickAndWait(Driver, 2);
            if (Showing1ToXofYentries.Text.Contains(originatingPageCount))
                throw new Exception("Compare expected equivalent values between FromPage and LandingPage failed!");
        }

        public MtSpeEditPtnCategoryPage GotoAndReturnNewEditPtnCategoryPage()
        {
            ClickableEditFrom2ndRow.Click();
            return new MtSpeEditPtnCategoryPage();
        }
    }
}
