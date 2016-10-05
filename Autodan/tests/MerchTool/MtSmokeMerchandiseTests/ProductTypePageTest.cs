using Autodan.core;
using Autodan.pages.MerchTool.MtCommonSitePages;
using Autodan.tests.MerchTool.MtSmokeTestUtilites;
using NUnit.Framework;

namespace Autodan.tests.MerchTool.MtSmokeMerchandiseTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class ProductTypePageTest:BaseTest
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
    }
}