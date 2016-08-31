using Autodan.core;
using Autodan.pages.MerchTool;
using Autodan.pages.ShippingManager;
using NUnit.Core;
using NUnit.Framework;

namespace Autodan.tests.MerchTool
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class MtSmokeTest : BaseTest
    {
        [Test]
        public void MtLoginPageTest()
        {
            //build test
            Setup("chrome", "merchtool");

            // nav to login page of MerchTools
            var loginPage = new MtLoginPageObject();

            //verify login page eles
            loginPage.VerifyLoginPageElements();

            //login to app + return dashboard PO
            loginPage.Login();

            //teardown
            Cleanup();
        }

        [Test]
        public void MtDashboardPageTest()
        {
            //build test
            Setup("chrome", "merchtool");

            //nav to login page
            var loginPage = new MtLoginPageObject();
            var common = loginPage.Login();

            //smoke test dashboard page(landing page)
            common.VerifyLandingPage();
            common.VerifyPersistentNav();
        }

        [Test]
        public void MtMerchProductTypesPage()
        {
            Setup("chrome", "merchtool");
            
            var loginPage = new MtLoginPageObject();
            var common = loginPage.Login();

            common.VerifyLandingPage();
            common.VerifyPersistentNav();

            var productType = common.NavToMerch();
            common.VerifySideNavigationOptions();
            
            productType.VerifyProductTypesPageElements();
            productType.MerchProductTypesTableFilterTest();
        }
    }
}