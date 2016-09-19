using Autodan.core;
using Autodan.pages.MerchTool.MtCommonPages;
using Autodan.pages.MerchTool.MtCommonSitePages;
using NUnit.Framework;

namespace Autodan.tests.MerchTool
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class MtSmokeMerchandiseTest : BaseTest
    {
        private MtLoginPageObject _loginPage;
        private MtHomePageObject _home;

        [SetUp]
        public void Setup()
        {
            if (CheckForSkipSetup())
                return;

            Setup("chrome", "merchtool");
            _loginPage = new MtLoginPageObject();
            _home = _loginPage.Login();
        }

        [TearDown]
        public void Teardown()
        {
            Cleanup();
        }

        [Test, Category("SkipSetup")]
        public void MtLoginPageTest()
        {
            Setup("chrome", "merchtool");
            _loginPage = new MtLoginPageObject();
            _loginPage.VerifyLoginPageElements();
            _home = _loginPage.Login();
            _home.VerifyLandingPage();
            _home.VerifyPersistentNav();
            _home.NavToMerch();
            _home.VerifySideNavigationOptions();
        }

        [Test]
        public void MtMerchProductTypesPageTest()
        {
            var productType = _home.NavToMerch();
            productType.VerifyProductTypesPageElements();
            productType.MerchProductTypesTableFilterTest();
        }

        [Test]
        public void MtMerchandiseColorsPageTest()
        {
            _home.NavToMerch();
            var mtMerchandiseColorsPage = _home.SideNavToColors();
            mtMerchandiseColorsPage.VerifyColorsPageElements();
            mtMerchandiseColorsPage.MerchandiseColorFilterColors();
            mtMerchandiseColorsPage.MerchandiseColorExportToCsvButton();
            mtMerchandiseColorsPage.MerchandiseColorSelectNumberOfEntries();
            mtMerchandiseColorsPage.SortAscendingDescendingByTableColumnHeaderClick();
        }

        [Test]
        public void MtMerchandiseSizePageTest()
        {
            _home.NavToMerch();
            var mtMerchandiseSizesPage = _home.SideNavToSizes();
            mtMerchandiseSizesPage.VerifySizesPageElements();
            mtMerchandiseSizesPage.MerchandiseSizeFilterSizes();
            mtMerchandiseSizesPage.MerchandiseSizeExportToCsvButton();
            mtMerchandiseSizesPage.MerchandiseSizeSelectNumberOfEntries();
            mtMerchandiseSizesPage.SortAscendingDescendingByTableColumnHeaderClick();
        }

        [Test]
        public void MtMerchandiseAttributeOptionPageTest()
        {
            _home.NavToMerch();
            var mtMerchandiseAttributeOptionsPage = _home.SideNavToAttributes();
            mtMerchandiseAttributeOptionsPage.VerifyAttributeOptionPageElements();
        }

        [Test]
        public void MtMerchandise_ProductCategories_PageTest()
        {
            _home.NavToMerch();
            var mtMerchandiseProductCategoriesPage = _home.SideNavToProductCategories();
            mtMerchandiseProductCategoriesPage.VerifyElements();
            mtMerchandiseProductCategoriesPage.RunActions();
        }

        [Test]
        public void MtMerchandise_SalesChannels_PageTest()
        {
            _home.NavToMerch();
            var mtMerchandiseSaleChannelsPage = _home.SideNavToSalesChannels();
            mtMerchandiseSaleChannelsPage.VerifyElements();
            mtMerchandiseSaleChannelsPage.ValidateElementHasValue();
            mtMerchandiseSaleChannelsPage.RunActions();
        }

        [Test]
        public void MtMerchandise_ShipBoxCategories_PageTest()
        {
            _home.NavToMerch();
            var page = _home.SideNavToShipBoxCategories();
            page.VerifyElements();
            page.ValidateElementHasValue();
            page.RunActions();
        }

        [Test]
        public void MtMerchandise_ShippingMethods_PageTest()
        {
            _home.NavToMerch();
            var page = _home.SideNavToShippingMethods();
            page.VerifyElements();
            page.ValidateElementHasValue();
            page.RunActions();
        }

        [Test]
        public void MtMerchandiseDetailsPageTest()
        {
            _home.NavToMerch();
            var page = _home.SideNavToSalesChannels();
            page.VerifyElements();
            page.ValidateElementHasValue();
            page.RunActions();
            var detailsPage = page.GotoDetailsPage();
            detailsPage.VerifyElements();
            detailsPage.ValidatePresentation();
        }
    }
}