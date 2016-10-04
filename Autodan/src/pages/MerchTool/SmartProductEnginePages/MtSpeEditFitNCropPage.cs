using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace Autodan.pages.MerchTool.SmartProductEnginePages
{
    public class MtSpeEditFitNCropPage : BaseTest
    {
        private readonly MtCommonToSpePages _mtCommonToSpePages;
        private readonly string _pageName = " MtSpeEditFitNCropPage ";

        public MtSpeEditFitNCropPage()
        {
            PageFactory.InitElements(Driver, this);
            _mtCommonToSpePages = new MtCommonToSpePages(_pageName);
        }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > ul > li.active")]
        public IWebElement BreadCrumbActive { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > h2")]
        public IWebElement HeaderH2 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset:nth-child(3) > i")]
        public IWebElement InstructionNoteForTheDropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset:nth-child(3) > legend")]
        public IWebElement LegendSelect { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#productTypeId")]
        public IWebElement DropDownProductType { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset:nth-child(3) > form > div > input")]
        public IWebElement ButtonLoadProductType { get; set; }

        //only after the ButtonLoadProductType is clicked does the configuration for that ptn appear. So
        //1)before varify above elements
        //a)test that the ConfigurationEntryTable does not exist beforehand  
        //b)that the SaveChangesButton does not exist

        [FindsBy(How = How.CssSelector, Using = "#FitAndFillConfigurationsForm > table")]
        public IWebElement ConfigurationEntryTable { get; set; }//Make sure we can do a dropdown and select a Detail page 

        [FindsBy(How = How.CssSelector, Using = "#FitAndFillConfigurationsForm > input.btn.btn-primary")]
        public IWebElement ButtonSaveChanges { get; set; }

        //2)after the button click,
        //a) see that the ConfigurationEntryTable does exist and
        //b)that the table matches up with the selection in the drop down
        [FindsBy(How = How.CssSelector, Using = "#productTypeId > option:nth-child(1)")]
        public IWebElement FirstItemInDropDown { get; set; }//make sure the list loads

        [FindsBy(How = How.Id, Using = "SelectedProductType_Id")]
        public IWebElement HiddenIdRequired { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset:nth-child(4) > legend")]
        public IWebElement LegendEdit { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div.row > div > fieldset:nth-child(4) > i")]
        public IWebElement InstructionNoteForSaveChangesButton { get; set; }

        //column headers
        [FindsBy(How = How.CssSelector, Using = "#FitAndFillConfigurationsForm > table > thead > tr > td:nth-child(1)")]
        public IWebElement ColumnHeader1 { get; set; }//"Is Default?"
        [FindsBy(How = How.CssSelector, Using = "#FitAndFillConfigurationsForm > table > thead > tr > td:nth-child(2)")]
        public IWebElement ColumnHeader2 { get; set; }//"Media Region"
        [FindsBy(How = How.CssSelector, Using = "#FitAndFillConfigurationsForm > table > thead > tr > td:nth-child(3)")]
        public IWebElement ColumnHeader3 { get; set; } // "Crop %"
        [FindsBy(How = How.CssSelector, Using = "#FitAndFillConfigurationsForm > table > thead > tr > td:nth-child(4)")]
        public IWebElement ColumnHeader4 { get; set; } //"Bleed %"
        [FindsBy(How = How.CssSelector, Using = "#FitAndFillConfigurationsForm > table > thead > tr > td:nth-child(5)")]
        public IWebElement ColumnHeader5 { get; set; } // "Buffer"
        [FindsBy(How = How.CssSelector, Using = "#FitAndFillConfigurationsForm > table > thead > tr > td:nth-child(6)")]
        public IWebElement ColumnHeader6 { get; set; }// "Coverage"

        //1st record in the table
        [FindsBy(How = How.CssSelector, Using = "#FitAndFillConfigurationsForm > table > tbody > tr > td:nth-child(1)")]
        public IWebElement IsDefaultField { get; set; }//True or False"

        [FindsBy(How = How.CssSelector, Using = "#FitAndFillRegions_0__RegionId")]
        public IWebElement HiddenInputRegionIdField { get; set; }  //must be an int

        [FindsBy(How = How.CssSelector, Using = "#FitAndFillRegions_0__RegionName")]
        public IWebElement HiddenRegionNameField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#FitAndFillRegions_0__CropPercent ")]
        public IWebElement InputCropPercentField { get; set; }  //must be number <= 1.00

        [FindsBy(How = How.CssSelector, Using = "#FitAndFillRegions_0__BleedPercent")]
        public IWebElement InputBleedPercentField { get; set; } //must be a number <= 1.00

        [FindsBy(How = How.CssSelector, Using = "#FitAndFillRegions_0__Buffer")]
        public IWebElement InputBufferField { get; set; }  // must be a number

        [FindsBy(How = How.CssSelector, Using = "#FitAndFillRegions_0__Coverage")]
        public IWebElement InputCoverageField { get; set; }  //must be a number


        public void VerifyElementsExist()
        {
            VerifyElementsExistBeforeSelection();
            ActionSelectPtnFromDropdown(); //do this to make the rest of the page show.
            VerifyElementsExistAfterSelection();
            Console.WriteLine("Verified Elements Exist on " + _pageName);
        }

        public void ActionSelectPtnFromDropdown()
        {
            ButtonLoadProductType.ClickAndWait(Driver, 5);
        }

        private void VerifyElementsExistBeforeSelection()
        {
            var pageElements = new List<IWebElement>
            {
                BreadCrumbActive,
                HeaderH2,
                InstructionNoteForTheDropDown,
                LegendSelect,
                DropDownProductType,
                ButtonLoadProductType
            };
            foreach (var element in pageElements)
            {
                element.Verify();
            }
        }

        private void VerifyElementsExistAfterSelection()
        {
            var pageElements = new List<IWebElement>
            {
                ConfigurationEntryTable,
                ButtonSaveChanges,
                FirstItemInDropDown,
                HiddenIdRequired,
                LegendEdit,
                InstructionNoteForSaveChangesButton,
                ColumnHeader1,
                ColumnHeader2,
                ColumnHeader3,
                ColumnHeader4,
                ColumnHeader5,
                ColumnHeader6,
                IsDefaultField,
                HiddenInputRegionIdField,
                HiddenRegionNameField,
                InputCropPercentField,
                InputBleedPercentField,
                InputBufferField,
                InputCoverageField,
                HiddenIdRequired
            };
            foreach (var element in pageElements)
            {
                element.Verify();
            }
        }

        public void VerifyElementsHaveExpectedContent()
        {
            _mtCommonToSpePages.VerifyCommonElementsHaveExpectedContent();
            Console.WriteLine("Verify Elements have Expected Content on " + _pageName);
        }

        public void RunActions()
        {
            //todo: until we have a stage enviroment to work against. To dangerous to build out.
            Console.WriteLine("Verify the number of entries dropdown works.");

        }
    }
}
