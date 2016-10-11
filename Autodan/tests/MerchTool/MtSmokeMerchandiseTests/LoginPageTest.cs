using Autodan.core;
using Autodan.pages.MerchTool.MtCommonSitePages;
using NUnit.Framework;

namespace Autodan.tests.MerchTool.MtSmokeMerchandiseTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class LoginPageTest : BaseTest
    {
        private MtLoginPageObject _loginPage;
        private MtHomePageObject _home;

        [SetUp]
        public void Setup(){}

        [TearDown]
        public void Teardown()
        {
            Cleanup();
        }

         [Test]
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
    }
}