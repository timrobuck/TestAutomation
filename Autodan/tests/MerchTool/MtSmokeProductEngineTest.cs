using Autodan.core;
using Autodan.pages.MerchTool.MtCommonPages;
using Autodan.pages.MerchTool.MtCommonSitePages;
using NUnit.Framework;

namespace Autodan.tests.MerchTool
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class MtSmokeProductEngineTest : BaseTest
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
            _home.NavToSmartProductEngine();
        }

        [Test]
        public void MtSpeAdministrativeFunctionsPageTest()
        {
            var mtSpeAdministrativeFuntionsPage = _home.NavToSmartProductEngine();
            mtSpeAdministrativeFuntionsPage.VerifyElements();
            mtSpeAdministrativeFuntionsPage.VerifyElementHasExpectedValue();
            mtSpeAdministrativeFuntionsPage.RunActions();
        }
    }
}