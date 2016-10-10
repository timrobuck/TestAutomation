using Autodan.core;
using Autodan.pages.MerchTool.MtCommonSitePages;
using Autodan.tests.MerchTool.MtSmokeTestUtilites;
using NUnit.Framework;

namespace Autodan.tests.MerchTool.MtSmokeMerchandiseTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class MtSmokeMerchandiseTest : BaseTest
    {
        private MtHomePageObject _home;

        [SetUp]
        public void Setup()
        {
            var homePageLogin = new LoginToHomePageUtility();
            _home = homePageLogin.GetHomePage();
        }

        [TearDown]
        public void Teardown()
        {
            Cleanup();
        }

        [Test]
        public void MtLoginPageTest()
        {
            _home.VerifyLandingPage();
            _home.VerifyPersistentNav();
            _home.NavigateToMerchPage();
            _home.VerifySideNavigationOptions();
        }

        [Test]
        public void ProductTypesPageTest()
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
        public void ProductCategories_PageTest()
        {
            _home.NavigateToMerchPage();
            var page = _home.SideNavToProductCategories();
            page.VerifyElements();
            page.RunActions();
        }

        [Test]
        public void AttributeOptionPageTest()
        {
            _home.NavigateToMerchPage();
            var page = _home.SideNavToAttributes();
            page.VerifyElements();
        }

        [Test]
        public void ColorsPageTest()
        {
            _home.NavigateToMerchPage();
            var page = _home.SideNavToColors();
            page.VerifyElements();
            page.RunActions();
        }

        [Test]
        public void CommonDetailsPageTest()
        {
            _home.NavigateToMerchPage();
            var page = _home.SideNavToSalesChannels();
            page.VerifyElements();
            page.VerifyElementContent();
            page.RunActions();
            var detailsPage = page.GotoDetailsPage();
            detailsPage.VerifyElements();
        }

        [Test]
        public void SizePageTest()
        {
            _home.NavigateToMerchPage();
            var mtMerchandiseSizesPage = _home.SideNavToSizes();
            mtMerchandiseSizesPage.VerifyElements();
            mtMerchandiseSizesPage.RunActions();
        }

        [Test]
        public void ProductTypeAspectRatiosPage()
        {
            //todo: create this page class and verify elements
            _home.NavigateToMerchPage();
            var ptnPage = _home.SideNavToProductTypes();
            var page = ptnPage.NavigateToProductTypesByAspectRatioPage();
            //page.IsAt("");
            page.VerifyElements();
            page.VerifyElementContent();
            page.RunActions();
        }

        [Test]
        public void ProductTypeDetailPageTest()
        {
            //todo: create this page class and verify elements
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
    }
}