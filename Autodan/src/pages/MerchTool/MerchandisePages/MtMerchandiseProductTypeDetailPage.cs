using System.Linq.Expressions;
using Autodan.core;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtMerchandiseProductTypeDetailPage
    {
        void VerifyElements();
        void VerifyElementContent();
    }
    public class MtMerchandiseProductTypeDetailPage : BaseTest, IBaseSmokeTest, IMtMerchandiseProductTypeDetailPage
    {
        //From tn to SearchDescription top of page
        private readonly IMtCommonToMerchandiseDetailsPage _common;
        private const string ImagePtn = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span3.clear > img";
        private const string LblDescriptionSummary = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.description-box.span11 > label:nth-child(1)";
        private const string DescriptionSummary = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.description-box.span11 > p:nth-child(2)";
        private const string LblDescription = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span8.two-column-display > label:nth-child(1)";
        private const string Description = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.description-box.span11 > p:nth-child(4)";
        private const string LblProductTypeNo = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span8.two-column-display > label:nth-child(1)";
        private const string ProductTypeNo = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span8.two-column-display > span:nth-child(2)";
        private const string LblCaption = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span8.two-column-display > label.has-tooltip";
        private const string Caption = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span8.two-column-display > label.has-tooltip";
        private const string LblShortCaption = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span8.two-column-display > span:nth-child(4)";
        private const string ShortCaption = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span8.two-column-display > span:nth-child(6)";
        private const string LblShorDesc = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span8.two-column-display > label:nth-child(7)";
        private const string ShortDesc = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.span8.two-column-display > span:nth-child(8)";

        private const string LblSearchDetails = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.description-box.span11 > label:nth-child(5)";
        private const string SearchDetails = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.description-box.span11 > p:nth-child(6)";
        private const string LblSeachDescription = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.description-box.span11 > label:nth-child(7)";
        private const string SearchDescription = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.description-box.span11 > p:nth-child(8)";
        private const string LegendColors = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(2) > fieldset:nth-child(1) > legend";
        private const string LegendSizes = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(2) > fieldset:nth-child(3) > legend";
        private const string LegendAttributes = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(2) > fieldset:nth-child(5) > legend";

        //Colors Sizes Attibutes
        private const string ListColors = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(2) > fieldset:nth-child(1) > ul";
        private const string ListSizes = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(2) > fieldset:nth-child(3) > ul";
        private const string ListAttributes = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(2) > fieldset:nth-child(5) > ul";//cant find a ptn with these yet
        private const string ColorItem1ImageUrlHidden = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(2) > fieldset:nth-child(1) > ul > li:nth-child(1) > img";
        private const string ColorItem1Xpath = "/html/body/div[3]/div[3]/div[2]/div/div[1]/fieldset[1]/ul/li[1]/text()";   // example  1: White
        private const string SizeItem1 = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(2) > fieldset:nth-child(3) > ul > li:nth-child(1)"; //example <li>4: Small </li>
        private const string AttributeItem1 = "";//cant find a product with this

        //Imaging Attributes comments           
        private const string LegendImageingAttributes = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > legend";
        private const string LblImageSizeComment = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(1) > div.description-box.span11 > p:nth-child(8)";
        private const string ImageSizeComment = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div.span11 > span";

        //Imaging Attributes 1st column labels  crunch data
        private const string LblImage1Caption = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(1) > label";
        private const string LblImage2Caption = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(2) > label";
        private const string LblImageDpi = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(3) > label";
        private const string LblPrintDpi = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(4) > label";
        private const string LblIsDarkGarment = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(5) > label";

        //Imaging Attributes 2nd column labels  crunch data
        private const string LblShowTwoSides = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(1) > label";
        private const string LblEditTwoSides = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(2) > label";
        private const string LblUsesAlign = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(3) > label";
        private const string LblUsesBorder = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(4) > label";
        private const string LblUsesPosition = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(5) > label";

        //Imaging Attributes 1st column content crunch data
        private const string Image1Caption = "body > div.container > div.row > div.span9.view - container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(1) > span";
        private const string Image2Caption = "body > div.container > div.row > div.span9.view - container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(2) > span";
        private const string ImageDpi = "body > div.container > div.row > div.span9.view - container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(3) > span";
        private const string PrintDpi = "body > div.container > div.row > div.span9.view - container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(4) > span";
        private const string IsDarkGarmant = "body > div.container > div.row > div.span9.view - container > div > fieldset:nth-child(3) > div:nth-child(3) > div:nth-child(5) > span";

        //Imaging Attributes 2nd column content crunch data
        private const string ShowTwoSides = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(1) > span";
        private const string EditTwoSides = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(2) > span";
        private const string UsesAlign = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(3) > span";
        private const string UsesBorder = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(4) > span";
        private const string UsesPosition = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(3) > div:nth-child(4) > div:nth-child(5) > span";

        //Crunch Info table
        private const string LegendCrunchInfo = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > legend";
        private const string HeaderOrientation = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > thead > tr > td:nth-child(1)";
        private const string HeaderPerspective = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > thead > tr > td:nth-child(2)";
        private const string HeaderMediaRegion = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > thead > tr > td:nth-child(3)";
        private const string HeaderAspectRatio = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > thead > tr > td:nth-child(4)";
        private const string HeaderWidth = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > thead > tr > td:nth-child(5)";
        private const string HeaderHeight = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > thead > tr > td:nth-child(6)";
        private const string HeaderTemplate = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > thead > tr > td:nth-child(7)";
        //assume at least a first row of data in this table
        private const string TableOrientationR1C1 = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
        private const string TablePerspectiveR1C2 = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
        private const string TableMediaRegion1C3 = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(3)";
        private const string TableAspectRatioR1C4 = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
        private const string TableWidthR1C5 = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(5)";
        private const string TableHeightR1C6 = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(6)";
        private const string TableTemplateR1C6 = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(7)";

        //Sales Channels and Pricing SCP
        private const string LegendSalesChannelsAndPricing ="body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > legend";
        private const string BasePrice ="body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > div:nth-child(2)";
        private const string MulisidePrintSurcharge ="body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > div:nth-child(3)";
        private const string RestockFee = "body > div.container > div.row > div.span9.view - container > div > fieldset:nth-child(6) > div:nth-child(4)";
        //SCP table headers
        private const string HeaderId ="body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > thead > tr > td:nth-child(1)";
        private const string HeaderName = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > thead > tr > td:nth-child(2";
        private const string HeaderPrice = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > thead > tr > td:nth-child(3";
        private const string HeaderSalePrice = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > thead > tr > td:nth-child(4)";
        private const string HeaderStartDate = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > thead > tr > td:nth-child(5)";
        private const string HeaderEndDate = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > thead > tr > td:nth-child(6)";
        //SCP data (only id and name req)
        private const string TableIdR1C1 = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
        private const string TableNameR1C2 = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
        private const string TablePriceR1C3 = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(3";
        private const string TableSalePriceR1C4 = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
        private const string TableStartDateR1C5 = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(5)";
        private const string TableEndDateR1C6 = "body > div.container > div.row > div.span9.view-container > div > fieldset:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(6)";

        //Markup Pricing
        private const string LegendMarkupPricing ="body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(1) > legend";
        private const string HdrProfile ="body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(1) > table > thead > tr > td:nth-child(1)";
        private const string HdrMarkupPrice = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(1) > table > thead > tr > td:nth-child(2)";
        private const string R1C1MarkupRowDataOptional ="body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(1) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
        private const string R1C2MarkupRowDataDependentOnC1 ="body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(1) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
        
        //Volume Pricing
        private const string LegendVolumePriceing = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(3) > legend";
        private const string HdrQuantity = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(3) > table > thead > tr > td:nth-child(1)";
        private const string HdrVolumePrice = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(3) > table > thead > tr > td:nth-child(2)";
        private const string R1C1VolumeRowDataOptional = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
        private const string R1C2VolumeRowDataDependentOnC1 = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(7) > fieldset:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(2)";

        //ProductCategories list items are optional
        private const string LegendProductCategories = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(8) > fieldset:nth-child(1) > legend";
        private const string LiProductCategoriesOptional = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(8) > fieldset:nth-child(1) > ul > li:nth-child(1)";
        //Member Exclusive list items are optional
        private const string LegendMemberExclusive = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(8) > fieldset:nth-child(3) > legend";
        private const string LiMemberExclusionOptional = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(8) > fieldset:nth-child(1) > ul > li:nth-child(1)";

        private const string LegendShipping = "";
        private const string ShippingCategory = "";
        private const string HdrId = "";
        private const string HdrShippingMethod = "";
        private const string HdrPrice = "";
        private const string HdrAdditionalPrice = "";
        private const string R1C1Optional = "";
        private const string R1C2DependentOnC1 = "";
        private const string R1C3DependentOnC1 = "";
        private const string R1C4DependentOnC1CanBeEmpty = "";
        //Excluded Countries list may be empty
        private const string LegendExcludedCountries = "body > div.container > div.row > div.span9.view-container > div > div:nth-child(10) > fieldset:nth-child(1) > legend";
        private const string LiExcludedCountriesOptional = "";
        //Excluded Shipping Methods list may be empty
        private const string LegendExcludedShippingMethod ="body > div.container > div.row > div.span9.view-container > div > div:nth-child(10) > fieldset:nth-child(3) > legend";
        private const string LiExcludedShippingMethodOptional = "";
        //Website Exclusions list may be empty
        private const string LegendWebsiteExclusions = "";
        private const string LiWebsiteExclusionOptional = "";




        public MtMerchandiseProductTypeDetailPage() : this(new MtCommonToMerchandiseDetailsPage()) { }
        public MtMerchandiseProductTypeDetailPage(IMtCommonToMerchandiseDetailsPage common)
        {
            PageFactory.InitElements(Driver, this);
            _common = common;
        }

        public void VerifyElements()
        {
            throw new System.NotImplementedException();
        }

        public void VerifyElementContent()
        {
            throw new System.NotImplementedException();
        }

        public void RunActions()
        {
            throw new System.NotImplementedException();
        }

        private void ActionVerifyOptionalDependentData()
        {
            //todo: if optional elements exists and has data then dependent elements must exist and have data
            //todo: continued...build call into Extentions to handle this. 

        }
    }
}
