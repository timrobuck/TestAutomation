using Autodan.core;
using Autodan.pages.MerchTool.MtCommonSitePages;
using NUnit.Framework;

namespace Autodan.tests.MerchTool.MtSmokeProductEngineTests
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
            _home.NavgateToSmartProductEnginePage();
        }

        [Test, Description("")]
        public void MtSpeAdministrativeFunctionsPageTest()
        {
            var mtSpeAdministrativeFuntionsPage = _home.NavgateToSmartProductEnginePage();
            mtSpeAdministrativeFuntionsPage.VerifyElements();
            mtSpeAdministrativeFuntionsPage.VerifyElementHasExpectedValue();
        }

        [Test, Description("")]
        public void MtSpeCategoriesPageTest()
        {
            var adminPage = _home.NavgateToSmartProductEnginePage();
            var page  = adminPage.GotoCategoriesPage();
            page.VerifyElementsExist();
            page.VerifyElementsHaveExpectedContent();
            page.RunActions();
        }

        [Test, Description("")]
        public void MtSpeEditCategoryPageTest()
        {
            var adminPage = _home.NavgateToSmartProductEnginePage();
            var categoryPage = adminPage.GotoCategoriesPage();
            var page = categoryPage.GotoAndReturnNewEditPtnCategoryPage();   
            page.VerifyElementsExist();
            page.VerifyElementsHaveExpectedContent();
            page.RunActions();
        }

        [Test, Description("")]
        public void MtSpeEditFitNCropPageTest()
        {
            var adminPage = _home.NavgateToSmartProductEnginePage();
            var page = adminPage.GotoMtSpeEditFitNCropPage();
            page.VerifyElementsExist();
            page.VerifyElementsHaveExpectedContent();
            page.RunActions();
        }

        [Test, Description("")]
        public void MtSpeMemberExclusionPageTest()
        {
            var adminPage = _home.NavgateToSmartProductEnginePage();
            var page = adminPage.GotoMemberExclusionPages();
            page.VerifyElementsExist();
            page.VerifyElementsHaveExpectedContent();
            page.RunActions();
        }

        [Test, Description("")]
        public void MtSpeProductTypeExclusionPageTest()
        {
            var adminPage = _home.NavgateToSmartProductEnginePage();
            var page = adminPage.GoToPtnExclusionPage();
            page.VerifyElementsExist();
            page.VerifyElementsHaveExpectedContent();
            page.RunActions();
        }
    }
}