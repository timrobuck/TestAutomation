using System;
using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.SmartProductEnginePages
{
    public class MtSpeEditPtnCategoryPage : BaseTest
    {
        private readonly MtCommonToSpePages _mtCommonToSpePages;
        private string pageName = "Edit PTN Category Page";
        private readonly MtCommonToEditDetailPages _mtCommonToEditDetailPages;

        public MtSpeEditPtnCategoryPage()
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

        //table record content
        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories_info")]
        public IWebElement ShowingEntries { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories > thead > tr > td:nth-child(1) > div")]
        public IWebElement ColumnHeader1 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories > thead > tr > td:nth-child(2) > div")]
        public IWebElement ColumnHeader2 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories > thead > tr > td:nth-child(3) > div")]
        public IWebElement ColumnHeader3 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories > thead > tr > td:nth-child(4) > div")]
        public IWebElement ColumnHeader4 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories > tbody > tr:nth-child(1) > td.sorting_1")]
        public IWebElement TableIdValueFromFirstRow { get; set; }

        //assuming there is at least one valid row in the table
        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories > tbody > tr:nth-child(1) > td.sorting_1")]
        public IWebElement Column1Row1FromTable { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#SmartProductCategories > tbody > tr:nth-child(1) > td:nth-child(2)")]
        public IWebElement Column2Row1FromTable { get; set; }

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
            LableShowEntries.Verify();
            DropDownNumberOfEntriesToShow.Verify();
            InputFilter.Verify();
            CheckBoxRemoveRecord.Verify();
            LabelFilter.Verify();
            ColumnHeader1.Verify();
            ColumnHeader2.Verify();
            ColumnHeader3.Verify();
            ColumnHeader4.Verify();
            ShowingEntries.Verify();
            TableIdValueFromFirstRow.Verify();
            Column1Row1FromTable.Verify();
            Column2Row1FromTable.Verify();
            Showing1ToXofYentries.Verify();
            Console.WriteLine("Verified elements show expected content");
        }

        private void VerifyUniqueElementsHaveExpectedContent()
        {
            LableShowEntries.VerifyTextIsInThisElement("Show");
            CheckBoxRemoveRecord.VerifyTextIsInThisElement("Remove");
            ColumnHeader1.VerifyTextIsInThisElement("Product Type Id");
            ColumnHeader2.VerifyTextIsInThisElement("Product Type Name");
            ColumnHeader3.VerifyTextIsInThisElement("In Smart Product ");
            ColumnHeader4.VerifyTextIsInThisElement("Remove?");
            Console.WriteLine("Verified elements show expected content");
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
        }
    }
}
