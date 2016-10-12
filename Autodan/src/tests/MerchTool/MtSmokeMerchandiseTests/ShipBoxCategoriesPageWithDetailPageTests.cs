using Autodan.core;
using Autodan.pages.MerchTool.MtCommonSitePages;
using Autodan.tests.MerchTool.MtSmokeTestUtilites;
using NUnit.Framework;

namespace Autodan.tests.MerchTool.MtSmokeMerchandiseTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class ShipBoxCategoriesPageWithDetailsPageTests : BaseTest
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
    }
}