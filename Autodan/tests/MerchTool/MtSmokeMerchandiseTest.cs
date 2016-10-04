using Autodan.core;
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
            _home.NavigateToMerchPage();
            _home.VerifySideNavigationOptions();
        }

        [Test]
        public void MtMerchProductTypesPageTest()
        {
            var productTypePage = _home.NavigateToMerchPage();
            productTypePage.VerifyElements();
            productTypePage.MerchProductTypesTableFilterTest();
            _home.NavigateToMerchPage();
            productTypePage.ViewTableByAspectRatio();
            _home.NavigateToMerchPage();
            productTypePage.DrillIntoProductTypeTable();
        }

        [Test]
        public void MtMerchProductTypeAspectRatiosPage()
        {
            //todo: create this page class and verify elements
        }

        [Test]
        public void MtMerchProductTypeDetailPageTest()
        {
            //todo: create this page class and verify elements
        }

        [Test]
        public void MtMerchandiseColorsPageTest()
        {
            _home.NavigateToMerchPage();
            var page = _home.SideNavToColors();
            page.VerifyElements();
            page.RunActions();
        }

        [Test]
        public void MtMerchandiseSizePageTest()
        {
            _home.NavigateToMerchPage();
            var mtMerchandiseSizesPage = _home.SideNavToSizes();
            mtMerchandiseSizesPage.VerifyElements();
            mtMerchandiseSizesPage.RunActions();
        }

        [Test]
        public void MtMerchandiseAttributeOptionPageTest()
        {
            _home.NavigateToMerchPage();
            var page = _home.SideNavToAttributes();
            page.VerifyElements();
        }

        [Test]
        public void MtMerchandise_ProductCategories_PageTest()
        {
            _home.NavigateToMerchPage();
            var page = _home.SideNavToProductCategories();
            page.VerifyElements();
            page.RunActions();
        }

        [Test]
        public void SalesChannelsPage_And_DetailsPage_SmokeTest()
        {
            _home.NavigateToMerchPage();
            var page = _home.SideNavToSalesChannels();
            page.VerifyElements();
            page.VerifyElementContent();
            page.RunActions();
            var baton = page.Row1Column2Content.Text;

            var detailsPage = page.GotoDetailsPage();
            detailsPage.VerifyElements();
            detailsPage.VerifyElementContent();
            Assert.AreEqual(detailsPage.NameContent.Text, baton);
        }

        [Test]
        public void ShipBoxCategoriesPage_And_DetailPage_SmokeTest()
        {
            _home.NavigateToMerchPage();
            var page = _home.SideNavToShipBoxCategories();
            page.VerifyElements();
            page.VerifyElementHasValue();
            page.RunActions();
            var baton = page.Row1Column2Content.Text;

            var detailsPage = page.GotoDetailsPage();
            detailsPage.VerifyElements();
            detailsPage.VerifyElementContent();
            Assert.AreEqual(detailsPage.NameContent.Text, baton);
        }

        [Test]
        public void ShippingMethodsPage_And_DetailsPage_SmokeTest()
        {
            _home.NavigateToMerchPage();
            var page = _home.SideNavToShippingMethods();
            page.VerifyElements();
            page.VerifyElementHasValue();
            page.RunActions();
            var baton = page.Row1Column2Content.Text;

            var detailsPage = page.GotoDetailsPage();
            detailsPage.VerifyElements();
            detailsPage.VerifyElementContent();
            Assert.AreEqual(detailsPage.NameContent.Text, baton);
        }

        [Test]
        public void MtMerchandiseCommonDetailsPageTest()
        {
            _home.NavigateToMerchPage();
            var page = _home.SideNavToSalesChannels();
            page.VerifyElements();
            page.VerifyElementContent();
            page.RunActions();
            var detailsPage = page.GotoDetailsPage();
            detailsPage.VerifyElements();
        }
    }
}