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
            _home.NavigateToMerchPage();
            var ptnPage = _home.SideNavToProductTypes();
            var page = ptnPage.NavigateToProductTypesByAspectRatioPage();
            page.VerifyElements();
            page.VerifyElementContent();
            page.RunActions();
        }

        [Test]
        public void ProductTypesDetailPageTest()
        {
            var masterPage = _home.NavigateToMerchPage();
            var detailPage = masterPage.NavigateToProductTypeDetailsPageByClickOnRow(); //row 1 is ptn 0 for mug, it has example of most elements to verify
            detailPage.VerifyElements();
            detailPage.VerifyOptionalElements();
            detailPage.VerifyOptionalElement(521, detailPage.LiWebsiteExclusionOptional);//this navigates to another ptn detail page then verifies the element. 
            detailPage.VerifyDependentElements();
            detailPage.VerifyDependentElement(1220, detailPage.R1C2VolumeRowDataDependentOnC1, detailPage.R1C1VolumeRowDataOptional);
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