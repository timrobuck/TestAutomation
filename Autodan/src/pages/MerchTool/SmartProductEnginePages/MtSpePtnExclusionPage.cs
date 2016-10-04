using System;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.SmartProductEnginePages
{
    public class MtSpePtnExclusionPage:BaseTest
    { 
        private readonly MtCommonToSpePages _mtCommonToSpePages;
        private string pageName = "Smart Product Engine PTNExclusion Page";
        private readonly MtCommonToEditDetailPages _mtCommonToEditDetailPages;

        public MtSpePtnExclusionPage()
        {
            PageFactory.InitElements(Driver, this);
            _mtCommonToSpePages = new MtCommonToSpePages(pageName);
            _mtCommonToEditDetailPages = new MtCommonToEditDetailPages();
        }
        [FindsBy(How = How.CssSelector, Using = "#ProductTypeExclusions_length > label")]
        public IWebElement LableShowEntries { get; set; } //always includes "Show " etc

        [FindsBy(How = How.CssSelector, Using = "#ProductTypeExclusions_length > label > select")]
        public IWebElement DropDownNumberOfEntriesToShow { get; set; }//always includes "50,25,10

        [FindsBy(How = How.CssSelector, Using = "#ProductTypeExclusions_filter > label > input")]
        public IWebElement InputFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#ProductTypeExclusions_filter")]
        public IWebElement LabelFilter { get; set; }//always includes "Filter:"

        [FindsBy(How = How.CssSelector, Using = "#ProductTypeExclusions > tbody > tr:nth-child(1) > td:nth-child(3) > label")]
        private IWebElement CheckBoxRemoveRecord { get; set; } //do not test this until stage is ready.

       [FindsBy(How = How.CssSelector, Using = "#ProductTypeExclusions_info")]
        public IWebElement ShowingEntries { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#ProductTypeExclusions > thead > tr > td:nth-child(1) > div")]
        public IWebElement Column1Header { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#ProductTypeExclusions > thead > tr > td:nth-child(2) > div")]
        public IWebElement Column2Header { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#ProductTypeExclusions > thead > tr > td:nth-child(3) > div")]
        public IWebElement Column3Header { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#ProductTypeExclusions > tbody > tr:nth-child(1) > td.sorting_1")]
        public IWebElement TableIdValueFromFirstRow { get; set; }

        //assuming there is at least one valid row in the table
        [FindsBy(How = How.CssSelector, Using = "#ProductTypeExclusions > tbody > tr:nth-child(1) > td.sorting_1")]
        public IWebElement Column1Row1FromTable { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#ProductTypeExclusions > tbody > tr:nth-child(1) > td:nth-child(2)")]
        public IWebElement Column2Row1FromTable { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#ProductTypeExclusions_info")]
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
            Console.WriteLine("Verify Elements have Expected Content on " + pageName);
        }

        public void RunActions()
        {
            ActionSelectNumberOfLines();
            Console.WriteLine("Verify the number of entries dropdown works.");
            ActionSortAscendingDescendingByTableColumnHeaderClick();
            Console.WriteLine("Verify Sort mechanism on each column header works.");
            //todo: UpdateExistigProductTypesExclusions.Click  do this only after stage is available
        }

        private void VerifyUniqueElementsExist()
        {
            LableShowEntries.Verify();
            DropDownNumberOfEntriesToShow.Verify();
            InputFilter.Verify();
            CheckBoxRemoveRecord.Verify();
            LabelFilter.Verify();
            Column1Header.Verify();
            Column2Header.Verify();
            Column3Header.Verify();
            ShowingEntries.Verify();
            TableIdValueFromFirstRow.Verify();
            Column1Row1FromTable.Verify();
            Column2Row1FromTable.Verify();
            Showing1ToXofYentries.Verify();
        }

        private void VerifyUniqueElementsHaveExpectedContent()
        {
            LableShowEntries.VerifyTextIsInThisElement("Show");
            CheckBoxRemoveRecord.VerifyTextIsInThisElement("Remove");
            Column1Header.VerifyTextIsInThisElement("Product Type Id");
            Column2Header.VerifyTextIsInThisElement("Product Type Name");
            Column3Header.VerifyTextIsInThisElement("Remove?");
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
            var beforeSortValue = TableIdValueFromFirstRow.Text;
            _mtCommonToSpePages.SortAscendingDescendingByTableColumnHeaderIdClickTheTriangle.Click();
            var afterSortValue = TableIdValueFromFirstRow.Text;
            if (beforeSortValue == afterSortValue)
                throw new Exception("Resorting items does not appear to work");

            Console.WriteLine("Verify Column Sort");
        }

        public void VerifyCountFromSpePageMatchesCountOnDetailsPage()
        {
            var originatingPageCount = Column1Row1FromTable.Text;
            if (Showing1ToXofYentries.Text.Contains(originatingPageCount))
                throw new Exception("Compare expected equivalent values between FromPage to Detail LandingPage failed!");
        }

    }
}
