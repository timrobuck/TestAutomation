using Autodan.core;
using Autodan.pages.MerchTool.MerchadisePages;
using NUnit.Framework;

namespace Autodan.tests.MerchTool
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class MtSmokeTest : BaseTest
    {
        private MtLoginPageObject _loginPage;
        private MtCommonPageObject _common;

        [SetUp]
        public void Setup()
        {
            if (CheckForSkipSetup())
                return;

            Setup("chrome", "merchtool");
            _loginPage = new MtLoginPageObject();
            _common = _loginPage.Login();
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
            _loginPage.Login();
        }
        public void MtDashboardPage_VerifyLandingPageTest()
        {
            _common.VerifyLandingPage();
            _loginPage.VerifyLoginPageElements();
        }

        [Test]
        public void MtDashboardPage_VerifyCommonNavigationTest()
        {
            _common.VerifyPersistentNav();
        }
        [Test]
        public void MtDashboardPage_VerifyCommonTest()
        {
            _common.VerifyPersistentNav();
        }
        [Test]
        public void MtDashboardPage_VerifySideNavigationOptionsTest()
        {
            _common.NavToMerch();
            _common.VerifySideNavigationOptions();
        }

        [Test]
        public void MtMerchProductTypesPageTest()
        {
            var productType = _common.NavToMerch();
            productType.VerifyProductTypesPageElements();
            productType.MerchProductTypesTableFilterTest();
        }

        [Test]
        public void MtMerchandiseColorsPageTest()
        {
            _common.NavToMerch();
            var mtMerchandiseColorsPage = _common.SideNavToColors();
            mtMerchandiseColorsPage.VerifyColorsPageElements();
            mtMerchandiseColorsPage.MerchandiseColorFilterColors();
            mtMerchandiseColorsPage.MerchandiseColorExportToCsvButton();
            mtMerchandiseColorsPage.MerchandiseColorSelectNumberOfEntries();
            mtMerchandiseColorsPage.SortAscendingDescendingByTableColumnHeaderClick();
        }

        [Test]
        public void MtMerchandiseSizePageTest()
        {
            _common.NavToMerch();
            var mtMerchandiseSizesPage = _common.SideNavToSizes();
            mtMerchandiseSizesPage.VerifySizesPageElements();
            mtMerchandiseSizesPage.MerchandiseSizeFilterSizes();
            mtMerchandiseSizesPage.MerchandiseSizeExportToCsvButton();
            mtMerchandiseSizesPage.MerchandiseSizeSelectNumberOfEntries();
            mtMerchandiseSizesPage.SortAscendingDescendingByTableColumnHeaderClick();
        }

        [Test]
        public void MtMerchandiseAttributeOptionPageTest()
        {
            _common.NavToMerch();
            var mtMerchandiseAttributeOptionsPage = _common.SideNavToAttributes();
            mtMerchandiseAttributeOptionsPage.VerifyAttributeOptionPageElements();
        }

        [Test]
        public void MtMerchandise_ProductCategories_PageTest()
        {
            _common.NavToMerch();
            var mtMerchandiseProductCategoriesPage = _common.SideNavToProductCategories();
            mtMerchandiseProductCategoriesPage.VerifyElements();
            mtMerchandiseProductCategoriesPage.RunActions();
        }

        [Test]
        public void MtMerchandise_SalesChannels_PageTest()
        {
            _common.NavToMerch();
            var page = _common.SideNavToSalesChannels();
            page.VerifyElements();
            page.ValidateElementHasValue();
            page.RunActions();
        }

        [Test]
        public void MtMerchandise_ShipBoxCategories_PageTest()
        {
            _common.NavToMerch();
            var page = _common.SideNavToShipBoxCategories();
            page.VerifyElements();
            page.ValidateElementHasValue();
            page.RunActions();
        }

        [Test]
        public void MtMerchandise_ShippingMethods_PageTest()
        {
            _common.NavToMerch();
            var page = _common.SideNavToShippingMethods();
            page.VerifyElements();
            page.ValidateElementHasValue();
            page.RunActions();
        }

        [Test]
        public void MtMerchandiseDetailsPageTest()
        {
            _common.NavToMerch();
            var page = _common.SideNavToSalesChannels();
            page.VerifyElements();
            page.ValidateElementHasValue();
            page.RunActions();
            var detailsPage = page.GotoDetailsPage();
            detailsPage.VerifyElements();
            detailsPage.ValidatePresentation();
        }
    }
}