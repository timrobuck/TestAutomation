using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtMerchandiseProductTypeDetailPage
    {
        void VerifyElements();
        void VerifyOptionalElements();
        void VerifyOptionalElement(int ptn, IWebElement webElement);
        void VerifyDependentElements();
        void VerifyDependentElement(int ptn, IWebElement dependent, IWebElement optional);
        MtMerchProductTypesByPtnPage NavigateBackToProductTypePage();
        IWebElement LiWebsiteExclusionOptional { get; set; }
        IWebElement R1C2VolumeRowDataDependentOnC1 { get; set; }
        IWebElement R1C1VolumeRowDataOptional { get; set; }
    }

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class MtMerchandiseProductTypeDetailPage : BaseTest, IBaseSmokeTest, IMtMerchandiseProductTypeDetailPage
    {
        //From tn to SearchDescription top of page
        private readonly string _pageName;
        private readonly IMtMerchProductTypesByPtnPage _mtMerchProductTypesByPtnPage;


        public MtMerchandiseProductTypeDetailPage() : this( new MtMerchProductTypesByPtnPage(null, null)) { }
        public MtMerchandiseProductTypeDetailPage(IMtMerchProductTypesByPtnPage mtMerchproductTypesByPtnPagePage)
        {
            _pageName = GetType().Name;
            PageFactory.InitElements(Driver, this);
            _mtMerchProductTypesByPtnPage = mtMerchproductTypesByPtnPagePage;
        }

        #region Selectors as const
        private const string ImagePtnSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span3.clear > img";
        private const string LblDescriptionSummarySelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.description-box.span11 > label:nth-child(1)";
        private const string DescriptionSummarySelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.description-box.span11 > p:nth-child(2)";
        private const string LblDescriptionSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span8.two-column-display > label:nth-child(1)";
        private const string DescriptionSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.description-box.span11 > p:nth-child(4)";
        private const string LblProductTypeNoSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span8.two-column-display > label:nth-child(1)";
        private const string ProductTypeNoSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span8.two-column-display > span:nth-child(2)";
        private const string LblCaptionSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span8.two-column-display > label.has-tooltip";
        private const string CaptionSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span8.two-column-display > label.has-tooltip";
        private const string LblShortCaptionSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span8.two-column-display > span:nth-child(4)";
        private const string ShortCaptionSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span8.two-column-display > span:nth-child(6)";
        private const string LblShortDescSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span8.two-column-display > label:nth-child(7)";
        private const string ShortDescSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span8.two-column-display > span:nth-child(8)";

        private const string LblSearchDetailsSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.description-box.span11 > label:nth-child(5)";
        private const string SearchDetailsSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.description-box.span11 > p:nth-child(6)";
        private const string LblSeachDescriptionSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.description-box.span11 > label:nth-child(7)";
        private const string SearchDescriptionSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.description-box.span11 > p:nth-child(8)";
        private const string LegendColorsSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(2) > fieldset:nth-child(1) > legend";
        private const string LegendSizesSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(2) > fieldset:nth-child(3) > legend";
        private const string LegendAttributesSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(2) > fieldset:nth-child(5) > legend";

        //Colors Sizes Attibutes
        private const string ListColorsSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(2) > fieldset:nth-child(1) > ul";
        private const string ListSizesSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(2) > fieldset:nth-child(3) > ul";
        private const string ColorItem1ImageUrlHiddenSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(2) > fieldset:nth-child(1) > ul > li:nth-child(1) > img";
        private const string ColorItem1Selector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(2) > fieldset:nth-child(1) > ul > li:nth-child(1)";   // example  1: White
        private const string SizeItem1Selector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(2) > fieldset:nth-child(3) > ul > li:nth-child(1)"; //example <li>4: Small </li>
        
        //Imaging Attributes comments           
        private const string LegendImageingAttributesSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > legend";
        private const string LblImageSizeCommentSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.description-box.span11 > p:nth-child(8)";
        private const string ImageSizeCommentSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div.span11 > span";

        //Imaging Attributes 1st column labels  crunch data
        private const string LblImage1CaptionSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(1) > label";
        private const string LblImage2CaptionSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(2) > label";
        private const string LblImageDpiSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(3) > label";
        private const string LblPrintDpiSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(4) > label";
        private const string LblIsDarkGarmentSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(5) > label";

        //Imaging Attributes 2nd column labels  crunch data
        private const string LblShowTwoSidesSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(1) > label";
        private const string LblEditTwoSidesSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(2) > label";
        private const string LblUsesAlignSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(3) > label";
        private const string LblUsesBorderSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(4) > label";
        private const string LblUsesPositionSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(5) > label";

        //Imaging Attributes 1st column content crunch data
        private const string Image1CaptionSelector = @"body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(1) > span";
        private const string Image2CaptionSelector = @"body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(2) > span";
        private const string ImageDpiSelector = @"body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(3) > span";
        private const string PrintDpiSelector = @"body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(4) > span";
        private const string IsDarkGarmantSelector = @"body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(5) > span";

        //Imaging Attributes 2nd column content crunch data
        private const string ShowTwoSidesSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(1) > span";
        private const string EditTwoSidesSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(2) > span";
        private const string UsesAlignSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(3) > span";
        private const string UsesBorderSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(4) > span";
        private const string UsesPositionSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(5) > span";

        //Crunch Info table
        private const string LegendCrunchInfoSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > legend";
        private const string HeaderOrientationSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > thead > tr > td:nth-child(1)";
        private const string HeaderPerspectiveSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > thead > tr > td:nth-child(2)";
        private const string HeaderMediaRegionSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > thead > tr > td:nth-child(3)";
        private const string HeaderAspectRatioSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > thead > tr > td:nth-child(4)";
        private const string HeaderWidthSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > thead > tr > td:nth-child(5)";
        private const string HeaderHeightSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > thead > tr > td:nth-child(6)";
        private const string HeaderTemplateSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > thead > tr > td:nth-child(7)";
        //assume at least a first row of data in this table
        private const string TableOrientationR1C1Selector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
        private const string TablePerspectiveR1C2Selector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
        private const string TableMediaRegionR1C3Selector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(3)";
        private const string TableAspectRatioR1C4Selector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
        private const string TableWidthR1C5Selector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(5)";
        private const string TableHeightR1C6Selector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(6)";
        private const string TableTemplateR1C6Selector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(7)";

        //Sales Channels and Pricing SCP
        private const string LegendSalesChannelsAndPricingSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > legend";
        private const string BasePriceSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > div:nth-child(2)";
        private const string MulisidePrintSurchargeSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > div:nth-child(3)";
        private const string RestockFeeSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > p";
        //SCP table headers
        private const string HeaderIdSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > thead > tr > td:nth-child(1)";
        private const string HeaderNameSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > thead > tr > td:nth-child(2";
        private const string HeaderPriceSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > thead > tr > td:nth-child(3";
        private const string HeaderSalePriceSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > thead > tr > td:nth-child(4)";
        private const string HeaderStartDateSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > thead > tr > td:nth-child(5)";
        private const string HeaderEndDateSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > thead > tr > td:nth-child(6)";
        //SCP data (only id and name req)
        private const string TableIdR1C1Selector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
        private const string TableNameR1C2Selector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
        private const string TablePriceR1C3Selector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(3";
        private const string TableSalePriceR1C4Selector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
        private const string TableStartDateR1C5Selector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(5)";
        private const string TableEndDateR1C6Selector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(6)";

        //Markup Pricing
        private const string LegendMarkupPricingSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(1) > legend";
        private const string HdrProfileSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(1) > table > thead > tr > td:nth-child(1)";
        private const string HdrMarkupPriceSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(1) > table > thead > tr > td:nth-child(2)";
        private const string R1C1MarkupRowDataOptionalSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(1) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
        private const string R1C2MarkupRowDataDependentOnC1Selector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(1) > table > tbody > tr:nth-child(1) > td:nth-child(2)";

        //Volume Pricing
        private const string LegendVolumePriceingSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(3) > legend";
        private const string HdrQuantitySelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(3) > table > thead > tr > td:nth-child(1)";
        private const string HdrVolumePriceSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(3) > table > thead > tr > td:nth-child(2)";
        private const string R1C1VolumeRowDataOptionalSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
        private const string R1C2VolumeRowDataDependentOnC1Selector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(2)";

        //ProductCategories list items are optional
        private const string LegendProductCategoriesSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(8) > fieldset:nth-child(1) > legend";
        private const string LiProductCategoriesOptionalSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(8) > fieldset:nth-child(1) > ul > li:nth-child(1)";
        //Member Exclusive list items are optional
        private const string LegendMemberExclusiveSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(8) > fieldset:nth-child(3) > legend";
        
        //Shipping
        private const string LegendShippingSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(9) > legend";
        private const string ShippingCategorySelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(9) > p";
        private const string HdrIdSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(9) > table > thead > tr > td:nth-child(1)";
        private const string HdrShippingMethodSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(9) > table > thead > tr > td:nth-child(2)";
        private const string HdrPriceSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(9) > table > thead > tr > td:nth-child(3)";
        private const string HdrAdditionalPriceSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(9) > table > thead > tr > td:nth-child(4)";
        private const string R1C1OptionalSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(9) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
        private const string R1C2DependentOnC1Selector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(9) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
        private const string R1C3DependentOnC1Selector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(9) > table > tbody > tr:nth-child(1) > td:nth-child(3";
        private const string R1C4DependentOnC1CanBeEmptySelector = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(9) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
        //Excluded Countries list may be empty
        private const string LegendExcludedCountriesSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(10) > fieldset:nth-child(1) > legend";
        private const string LiExcludedCountriesOptionalSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(10) > fieldset:nth-child(1) > ul > li:nth-child(1)";
        //Excluded Shipping Methods list may be empty
        private const string LegendExcludedShippingMethodSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(10) > fieldset:nth-child(3) > legend";
        private const string LiExcludedShippingMethodOptionalSelector = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(10) > fieldset:nth-child(3) > ul > li:nth-child(1)";
        //Website Exclusions list may be empty
        private const string LegendWebsiteExclusionsSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset.span5 > legend";
        private const string LiWebsiteExclusionOptionalSelector = "body > div.container > div.row > div.span9.view-container > div > fieldset.span5 > ul > li";

        //navigations from this page
        private const string BreadCrumbMerchandiseSelector = "body > div.container > div.row > div.span9.view-container > ul > li:nth-child(2) > a";

        #endregion

        #region WebElements defined as properties
        [FindsBy(How = How.CssSelector, Using = ImagePtnSelector)]
        private IWebElement ImagePtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblDescriptionSummarySelector)]
        private IWebElement LblDescriptionSummary { get; set; }

        [FindsBy(How = How.CssSelector, Using = DescriptionSummarySelector)]
        private IWebElement DescriptionSummary { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblDescriptionSelector)]
        private IWebElement LblDescription { get; set; }

        [FindsBy(How = How.CssSelector, Using = DescriptionSelector)]
        private IWebElement Description { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblProductTypeNoSelector)]
        private IWebElement LblProductTypeNo { get; set; }

        [FindsBy(How = How.CssSelector, Using = ProductTypeNoSelector)]
        private IWebElement ProductTypeNo { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblCaptionSelector)]
        private IWebElement LblCaption { get; set; }

        [FindsBy(How = How.CssSelector, Using = CaptionSelector)]
        private IWebElement Caption { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblShortCaptionSelector)]
        private IWebElement LblShortCaption { get; set; }

        [FindsBy(How = How.CssSelector, Using = ShortCaptionSelector)]
        private IWebElement ShortCaption { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblShortDescSelector)]
        private IWebElement LblShortDesc { get; set; }

        [FindsBy(How = How.CssSelector, Using = ShortDescSelector)]
        private IWebElement ShortDesc { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblSearchDetailsSelector)]
        private IWebElement LblSearchDetails { get; set; }

        [FindsBy(How = How.CssSelector, Using = SearchDetailsSelector)]
        private IWebElement SearchDetails { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblSeachDescriptionSelector)]
        private IWebElement LblSeachDescription { get; set; }

        [FindsBy(How = How.CssSelector, Using = LegendColorsSelector)]
        private IWebElement LegendColors { get; set; }

        [FindsBy(How = How.CssSelector, Using = SearchDescriptionSelector)]
        private IWebElement SearchDescription { get; set; }

        [FindsBy(How = How.CssSelector, Using = LegendSizesSelector)]
        private IWebElement LegendSizes { get; set; }

        [FindsBy(How = How.CssSelector, Using = LegendAttributesSelector)]
        private IWebElement LegendAttributes { get; set; }

        [FindsBy(How = How.CssSelector, Using = ListColorsSelector)]
        private IWebElement ListColors { get; set; }

        [FindsBy(How = How.CssSelector, Using = ListSizesSelector)]
        private IWebElement ListSizes { get; set; }

        [FindsBy(How = How.CssSelector, Using = ColorItem1ImageUrlHiddenSelector)]
        private IWebElement ColorItem1ImageUrlHidden { get; set; }

        [FindsBy(How = How.CssSelector, Using = ColorItem1Selector)]
        private IWebElement ColorItem1Xpath { get; set; }

        [FindsBy(How = How.CssSelector, Using = SizeItem1Selector)]
        private IWebElement SizeItem1 { get; set; }

        [FindsBy(How = How.CssSelector, Using = LegendImageingAttributesSelector)]
        private IWebElement LegendImageingAttributes { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblImageSizeCommentSelector)]
        private IWebElement LblImageSizeComment { get; set; }

        [FindsBy(How = How.CssSelector, Using = ImageSizeCommentSelector)]
        private IWebElement ImageSizeComment { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblImage1CaptionSelector)]
        private IWebElement LblImage1Caption { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblImage2CaptionSelector)]
        private IWebElement LblImage2Caption { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblImageDpiSelector)]
        private IWebElement LblImageDpi { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblPrintDpiSelector)]
        private IWebElement LblPrintDpi { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblIsDarkGarmentSelector)]
        private IWebElement LblIsDarkGarment { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblShowTwoSidesSelector)]
        private IWebElement LblShowTwoSides { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblEditTwoSidesSelector)]
        private IWebElement LblEditTwoSides { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblUsesAlignSelector)]
        private IWebElement LblUsesAlign { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblUsesBorderSelector)]
        private IWebElement LblUsesBorder { get; set; }

        [FindsBy(How = How.CssSelector, Using = LblUsesPositionSelector)]
        private IWebElement LblUsesPosition { get; set; }

        [FindsBy(How = How.CssSelector, Using = Image1CaptionSelector)]
        private IWebElement Image1Caption { get; set; }

        [FindsBy(How = How.CssSelector, Using = Image2CaptionSelector)]
        private IWebElement Image2Caption { get; set; }

        [FindsBy(How = How.CssSelector, Using = ImageDpiSelector)]
        private IWebElement ImageDpi { get; set; }

        [FindsBy(How = How.CssSelector, Using = PrintDpiSelector)]
        private IWebElement PrintDpi { get; set; }

        [FindsBy(How = How.CssSelector, Using = IsDarkGarmantSelector)]
        private IWebElement IsDarkGarmant { get; set; }

        [FindsBy(How = How.CssSelector, Using = ShowTwoSidesSelector)]
        private IWebElement ShowTwoSides { get; set; }

        [FindsBy(How = How.CssSelector, Using = EditTwoSidesSelector)]
        private IWebElement EditTwoSides { get; set; }

        [FindsBy(How = How.CssSelector, Using = UsesAlignSelector)]
        private IWebElement UsesAlign { get; set; }

        [FindsBy(How = How.CssSelector, Using = UsesBorderSelector)]
        private IWebElement UsesBorder { get; set; }

        [FindsBy(How = How.CssSelector, Using = UsesPositionSelector)]
        private IWebElement UsesPosition { get; set; }

        [FindsBy(How = How.CssSelector, Using = LegendCrunchInfoSelector)]
        private IWebElement LegendCrunchInfo { get; set; }

        [FindsBy(How = How.CssSelector, Using = HeaderOrientationSelector)]
        private IWebElement HeaderOrientation { get; set; }

        [FindsBy(How = How.CssSelector, Using = HeaderPerspectiveSelector)]
        private IWebElement HeaderPerspective { get; set; }

        [FindsBy(How = How.CssSelector, Using = HeaderMediaRegionSelector)]
        private IWebElement HeaderMediaRegion { get; set; }

        [FindsBy(How = How.CssSelector, Using = HeaderAspectRatioSelector)]
        private IWebElement HeaderAspectRatio { get; set; }

        [FindsBy(How = How.CssSelector, Using = HeaderWidthSelector)]
        private IWebElement HeaderWidth { get; set; }

        [FindsBy(How = How.CssSelector, Using = HeaderHeightSelector)]
        private IWebElement HeaderHeight { get; set; }

        [FindsBy(How = How.CssSelector, Using = HeaderTemplateSelector)]
        private IWebElement HeaderTemplate { get; set; }

        [FindsBy(How = How.CssSelector, Using = TableOrientationR1C1Selector)]
        private IWebElement TableOrientationR1C1 { get; set; }

        [FindsBy(How = How.CssSelector, Using = TablePerspectiveR1C2Selector)]
        private IWebElement TablePerspectiveR1C2 { get; set; }

        [FindsBy(How = How.CssSelector, Using = TableMediaRegionR1C3Selector)]
        private IWebElement TableMediaRegionR1C3 { get; set; }

        [FindsBy(How = How.CssSelector, Using = TableAspectRatioR1C4Selector)]
        private IWebElement TableAspectRatioR1C4 { get; set; }

        [FindsBy(How = How.CssSelector, Using = TableWidthR1C5Selector)]
        private IWebElement TableWidthR1C5 { get; set; }

        [FindsBy(How = How.CssSelector, Using = TableHeightR1C6Selector)]
        private IWebElement TableHeightR1C6 { get; set; }

        [FindsBy(How = How.CssSelector, Using = TableTemplateR1C6Selector)]
        private IWebElement TableTemplateR1C6 { get; set; }

        [FindsBy(How = How.CssSelector, Using = LegendSalesChannelsAndPricingSelector)]
        private IWebElement LegendSalesChannelsAndPricing { get; set; }

        [FindsBy(How = How.CssSelector, Using = BasePriceSelector)]
        private IWebElement BasePrice { get; set; }

        [FindsBy(How = How.CssSelector, Using = MulisidePrintSurchargeSelector)]
        private IWebElement MulisidePrintSurcharge { get; set; }

        [FindsBy(How = How.CssSelector, Using = RestockFeeSelector)]
        private IWebElement RestockFee { get; set; }

        [FindsBy(How = How.CssSelector, Using = HeaderIdSelector)]
        private IWebElement HeaderId { get; set; }

        [FindsBy(How = How.CssSelector, Using = HeaderNameSelector)]
        private IWebElement HeaderName { get; set; }

        [FindsBy(How = How.CssSelector, Using = HeaderPriceSelector)]
        private IWebElement HeaderPrice { get; set; }

        [FindsBy(How = How.CssSelector, Using = HeaderSalePriceSelector)]
        private IWebElement HeaderSalePrice { get; set; }

        [FindsBy(How = How.CssSelector, Using = HeaderStartDateSelector)]
        private IWebElement HeaderStartDate { get; set; }

        [FindsBy(How = How.CssSelector, Using = HeaderEndDateSelector)]
        private IWebElement HeaderEndDate { get; set; }

        [FindsBy(How = How.CssSelector, Using = TableIdR1C1Selector)]
        private IWebElement TableIdR1C1 { get; set; }

        [FindsBy(How = How.CssSelector, Using = TableNameR1C2Selector)]
        private IWebElement TableNameR1C2 { get; set; }

        [FindsBy(How = How.CssSelector, Using = TablePriceR1C3Selector)]
        private IWebElement TablePriceR1C3 { get; set; }

        [FindsBy(How = How.CssSelector, Using = TableSalePriceR1C4Selector)]
        private IWebElement TableSalePriceR1C4 { get; set; }

        [FindsBy(How = How.CssSelector, Using = TableStartDateR1C5Selector)]
        private IWebElement TableStartDateR1C5 { get; set; }

        [FindsBy(How = How.CssSelector, Using = TableEndDateR1C6Selector)]
        private IWebElement TableEndDateR1C6 { get; set; }

        [FindsBy(How = How.CssSelector, Using = LegendMarkupPricingSelector)]
        private IWebElement LegendMarkupPricing { get; set; }

        [FindsBy(How = How.CssSelector, Using = HdrProfileSelector)]
        private IWebElement HdrProfile { get; set; }

        [FindsBy(How = How.CssSelector, Using = HdrMarkupPriceSelector)]
        private IWebElement HdrMarkupPrice { get; set; }

        [FindsBy(How = How.CssSelector, Using = R1C1MarkupRowDataOptionalSelector)]
        private IWebElement R1C1MarkupRowDataOptional { get; set; }

        [FindsBy(How = How.CssSelector, Using = R1C2MarkupRowDataDependentOnC1Selector)]
        private IWebElement R1C2MarkupRowDataDependentOnC1 { get; set; }

        [FindsBy(How = How.CssSelector, Using = LegendVolumePriceingSelector)]
        private IWebElement LegendVolumePriceing { get; set; }

        [FindsBy(How = How.CssSelector, Using = HdrQuantitySelector)]
        private IWebElement HdrQuantity { get; set; }

        [FindsBy(How = How.CssSelector, Using = HdrVolumePriceSelector)]
        private IWebElement HdrVolumePrice { get; set; }

        [FindsBy(How = How.CssSelector, Using = R1C1VolumeRowDataOptionalSelector)]
        public IWebElement R1C1VolumeRowDataOptional { get; set; }

        [FindsBy(How = How.CssSelector, Using = R1C2VolumeRowDataDependentOnC1Selector)]
        public IWebElement R1C2VolumeRowDataDependentOnC1 { get; set; }

        [FindsBy(How = How.CssSelector, Using = LegendProductCategoriesSelector)]
        private IWebElement LegendProductCategories { get; set; }

        [FindsBy(How = How.CssSelector, Using = LiProductCategoriesOptionalSelector)]
        private IWebElement LiProductCategoriesOptional { get; set; }

        [FindsBy(How = How.CssSelector, Using = LegendMemberExclusiveSelector)]
        private IWebElement LegendMemberExclusive { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = LegendShippingSelector)]
        private IWebElement LegendShipping { get; set; }

        [FindsBy(How = How.CssSelector, Using = ShippingCategorySelector)]
        private IWebElement ShippingCategory { get; set; }

        [FindsBy(How = How.CssSelector, Using = HdrIdSelector)]
        private IWebElement HdrId { get; set; }

        [FindsBy(How = How.CssSelector, Using = HdrShippingMethodSelector)]
        private IWebElement HdrShippingMethod { get; set; }

        [FindsBy(How = How.CssSelector, Using = HdrPriceSelector)]
        private IWebElement HdrPrice { get; set; }

        [FindsBy(How = How.CssSelector, Using = HdrAdditionalPriceSelector)]
        private IWebElement HdrAdditionalPrice { get; set; }

        [FindsBy(How = How.CssSelector, Using = R1C1OptionalSelector)]
        private IWebElement R1C1Optional { get; set; }

        [FindsBy(How = How.CssSelector, Using = R1C2DependentOnC1Selector)]
        private IWebElement R1C2DependentOnC1 { get; set; }

        [FindsBy(How = How.CssSelector, Using = R1C3DependentOnC1Selector)]
        private IWebElement R1C3DependentOnC1 { get; set; }

        [FindsBy(How = How.CssSelector, Using = R1C4DependentOnC1CanBeEmptySelector)]
        private IWebElement R1C4DependentOnC1CanBeEmpty { get; set; }

        [FindsBy(How = How.CssSelector, Using = LegendExcludedCountriesSelector)]
        private IWebElement LegendExcludedCountries { get; set; }

        [FindsBy(How = How.CssSelector, Using = LiExcludedCountriesOptionalSelector)]
        private IWebElement LiExcludedCountriesOptional { get; set; }

        [FindsBy(How = How.CssSelector, Using = LegendExcludedShippingMethodSelector)]
        private IWebElement LegendExcludedShippingMethod { get; set; }

        [FindsBy(How = How.CssSelector, Using = LiExcludedShippingMethodOptionalSelector)]
        private IWebElement LiExcludedShippingMethodOptional { get; set; }

        [FindsBy(How = How.CssSelector, Using = LegendWebsiteExclusionsSelector)]
        private IWebElement LegendWebsiteExclusions { get; set; }

        [FindsBy(How = How.CssSelector, Using = LiWebsiteExclusionOptionalSelector)]
        public IWebElement LiWebsiteExclusionOptional { get; set; }

        [FindsBy(How = How.CssSelector, Using = BreadCrumbMerchandiseSelector)]
        private IWebElement BreadCrumbMerchandise { get; set; }
        #endregion

        //some elements will be present only under certain conditions.
        public void VerifyOptionalElements()
        {
            VerifyOptionalElement(521, LiWebsiteExclusionOptional);
            //todo: VerifyOptionalElement(, AttributeItem1); // if and when we find an example 
            //todo: VerifyOptionalElement(0, ListAttributes);//if and when we find an example 
            VerifyOptionalElement(1198, LiExcludedCountriesOptional);
            VerifyOptionalElement(1198, LiExcludedShippingMethodOptional);
        }

        public void VerifyOptionalElement(int ptn, IWebElement webElement)
        {
            NavigateBackToProductTypePage();
            _mtMerchProductTypesByPtnPage.NavigateToProductTypeDetailsPageBySearchInput(ptn);//enter ptn into search and click:  this ptn has a websiteExclusion item not present in mug  
            webElement.VerifyOrSendMessage();
            Console.WriteLine("Verified Optional Element using ptn=" + ptn);
        }

        public void VerifyElements()
        {
            var pageElements = new List<IWebElement>  //condition: we are on the first item in the list ptn=0 Mug
            {
                ImagePtn,
                LblDescriptionSummary,
                DescriptionSummary,
                LblDescription,
                Description,
                LblProductTypeNo,
                ProductTypeNo,
                LblCaption,
                Caption,
                LblShortCaption,
                ShortCaption,
                LblShortDesc,
                ShortDesc,
                LblSearchDetails,
                SearchDetails,
                LblSeachDescription,
                SearchDescription,
                LegendColors,
                LegendSizes,
                LegendAttributes,
                ListColors,
                ListSizes,
                ColorItem1ImageUrlHidden,
                ColorItem1Xpath,
                SizeItem1,
                LegendImageingAttributes,
                LblImageSizeComment,
                ImageSizeComment,
                LblImage1Caption,
                LblImage2Caption,
                LblImageDpi,
                LblPrintDpi,
                LblIsDarkGarment,
                LblShowTwoSides,
                LblEditTwoSides,
                LblUsesAlign,
                LblUsesBorder,
                LblUsesPosition,
                Image1Caption,
                Image2Caption,
                ImageDpi,
                PrintDpi,
                IsDarkGarmant,
                ShowTwoSides,
                EditTwoSides,
                UsesAlign,
                UsesBorder,
                UsesPosition,
                LegendCrunchInfo,
                HeaderOrientation,
                HeaderPerspective,
                HeaderMediaRegion,
                HeaderAspectRatio,
                HeaderWidth,
                HeaderHeight,
                HeaderTemplate,
                TableOrientationR1C1,
                TablePerspectiveR1C2,
                TableMediaRegionR1C3,
                TableAspectRatioR1C4,
                TableWidthR1C5,
                TableHeightR1C6,
                TableTemplateR1C6,
                LegendSalesChannelsAndPricing,
                BasePrice,
                MulisidePrintSurcharge,
                RestockFee,
                HeaderId,
                HeaderName,
                HeaderPrice,
                HeaderSalePrice,
                HeaderStartDate,
                HeaderEndDate,
                TableIdR1C1,
                TableNameR1C2,
                TablePriceR1C3,
                TableSalePriceR1C4,
                TableStartDateR1C5,
                TableEndDateR1C6,
                LegendMarkupPricing,
                HdrProfile,
                HdrMarkupPrice,
                R1C1MarkupRowDataOptional,
                R1C2MarkupRowDataDependentOnC1,
                LegendVolumePriceing,
                HdrQuantity,
                HdrVolumePrice,
                R1C1VolumeRowDataOptional,
                R1C2VolumeRowDataDependentOnC1,
                LegendProductCategories,
                LiProductCategoriesOptional,
                LegendMemberExclusive,
                LegendShipping,
                ShippingCategory,
                HdrId,
                HdrShippingMethod,
                HdrPrice,
                HdrAdditionalPrice,
                R1C1Optional,
                R1C2DependentOnC1,
                R1C3DependentOnC1,
                R1C4DependentOnC1CanBeEmpty,
                LegendExcludedCountries,
                LegendExcludedShippingMethod,
                LegendWebsiteExclusions
            };
            var failCount = pageElements.Count(e => !e.VerifyOrSendMessage());
            if (Debugger.IsAttached && failCount > 0)
                throw new Exception(string.Join(" running VerifyElements fail count =", failCount, " for ", _pageName));

            Console.WriteLine("Verified Page Elements for " + _pageName);
        }

        public void RunActions()
        {
            throw new NotImplementedException();
        }

        public void VerifyDependentElements()
        {
            VerifyDependentElement(1122, R1C2MarkupRowDataDependentOnC1, R1C1MarkupRowDataOptional);
            VerifyDependentElement(1220, R1C2VolumeRowDataDependentOnC1, R1C1VolumeRowDataOptional);
        }

        public void VerifyDependentElement(int ptn, IWebElement dependent, IWebElement optional)
        {
            NavigateBackToProductTypePage();
            _mtMerchProductTypesByPtnPage.NavigateToProductTypeDetailsPageBySearchInput(ptn);//enter ptn into search and click:  this ptn has a websiteExclusion item not present in mug   
            dependent.VerifyElementDependentOnOptionalElement(optional);
            Console.WriteLine("Verified dependent element for ptn=" + ptn);
        }

        public MtMerchProductTypesByPtnPage NavigateBackToProductTypePage()
        {
            BreadCrumbMerchandise.ClickAndWait(2);
            WaitForAjax();
            return _mtMerchProductTypesByPtnPage as MtMerchProductTypesByPtnPage;
        }
    }
}
