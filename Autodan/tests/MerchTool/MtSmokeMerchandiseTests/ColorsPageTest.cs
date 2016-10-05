using Autodan.core;
using Autodan.pages.MerchTool.MtCommonSitePages;
using Autodan.tests.MerchTool.MtSmokeTestUtilites;
using NUnit.Framework;

namespace Autodan.tests.MerchTool.MtSmokeMerchandiseTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class ColorsPageTest : BaseTest
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
        public void ColorsPage_Test()
        {
            _home.NavigateToMerchPage();
            var page = _home.SideNavToColors();
            page.VerifyElements();
            page.RunActions();
        }
    }
}