using Autodan.core;
using Autodan.pages.MerchTool.MtCommonSitePages;
using Autodan.tests.MerchTool.MtSmokeTestUtilites;
using NUnit.Framework;

namespace Autodan.tests.MerchTool.MtSmokeMerchandiseTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class ProductTypeDetailsPageTest : BaseTest
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
        public void ProductTypesDetailsPageTest()
        {
            var masterPage = _home.NavigateToMerchPage();
            var detailPage = masterPage.NavigateToProductTypeDetailsPageByClickOnRow(); //row 1 is ptn 0 for mug, it has example of most elements to verify
            detailPage.VerifyElements();
            detailPage.VerifyOptionalElements();
            detailPage.VerifyOptionalElement(521, detailPage.LiWebsiteExclusionOptional);//this navigates to another ptn detail page then verifies the element. 
            detailPage.VerifyDependentElements();
            detailPage.VerifyDependentElement(1220, detailPage.R1C2VolumeRowDataDependentOnC1, detailPage.R1C1VolumeRowDataOptional);
        }
    }
}