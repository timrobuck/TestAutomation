using Autodan.core;
using Autodan.pages.MerchTool;
using NUnit.Framework;

namespace Autodan.tests.MerchTool
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class MtSmokeTest : BaseTest
    {
        private MtLoginPageObject _loginPage;

        [SetUp]
        public void Setup()
        {
            Setup("chrome", "merchtool");     
            _loginPage = new MtLoginPageObject();
            _loginPage.VerifyLoginPageElements();
        }

        [TearDown]
        public void Teardown()
        {
            Cleanup();
        }

        [Test]
        public void MtLoginPageTest()
        {
            //login to app + return dashboard PO
            _loginPage.Login();
        }

        [Test]
        public void MtDashboardPageTest()
        {
            var common = _loginPage.Login();
            common.VerifyLandingPage();
            common.VerifyPersistentNav();
        }

        [Test]
        public void MtMerchProductTypesPageTest()
        {
            var common = _loginPage.Login();
            common.VerifyLandingPage();
            common.VerifyPersistentNav();
            var productType = common.NavToMerch();
            common.VerifySideNavigationOptions();
            productType.VerifyProductTypesPageElements();
            productType.MerchProductTypesTableFilterTest();
        }

        [Test]
        public void MtMerchandiseColorsPageTest()
        {
            var common = _loginPage.Login();
            common.VerifyLandingPage();
            common.VerifyPersistentNav();
            common.NavToMerch();
            common.VerifySideNavigationOptions();
            var mtMerchandiseColorsPage = common.SideNavToColors();
            mtMerchandiseColorsPage.VerifyColorsPageElements();
            mtMerchandiseColorsPage.MerchandiseColorFilterColors();
            mtMerchandiseColorsPage.MerchandiseColorExportToCsvButton();
            mtMerchandiseColorsPage.MerchandiseColorSelectNumberOfEntries();
        }

        [Test]
        public void MtMerchandiseSizePageTest()
        {
            
        }
    }
}