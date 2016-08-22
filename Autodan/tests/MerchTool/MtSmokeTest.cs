using Autodan.core;
using Autodan.pages.MerchTool;
using NUnit.Framework;

namespace Autodan.tests.MerchTool
{
    internal class MtSmokeTest : BaseTest
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
        public void DashboardPageTest()
        {
            //build test
        }
    }
}