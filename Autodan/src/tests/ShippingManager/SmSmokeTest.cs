using Autodan.core;
using Autodan.pages.ShippingManager;
using NUnit.Framework;

namespace Autodan.tests.ShippingManager
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class SmSmokeTest : BaseTest
    {
        private SmLoginPageObject _loginPage;
        private SmCommonPageObject _common;


        [SetUp]
        public void Setup()
        {
            if (CheckForSkipSetup())
                return;

            Setup("chrome", "shippingmanager");
            _loginPage = new SmLoginPageObject();
            _common = _loginPage.Login();
        }

        [TearDown]
        public void Teardown()
        {
            Cleanup();
        }

        [Test, Category("SkipSetup")]
        public void SmLoginPageTest()
        {
            Setup("chrome", "shippingmanager");
            _loginPage = new SmLoginPageObject();
            _loginPage.VerifyLoginPageElements();
            _loginPage.Login();    
        }
        public void SmDashboardPage_VerifyLandingPageTest()
        {
            _common.VerifyPersistentNav();
            _common.VerifyDashboardPageElements();
        }

        [Test]
        public void SmStockStatus_VerifyProductTypePageTest()
        {
            var stockStatus = _common.NavigateToStockStatus();
            _common.VerifyPersistentNav();
            stockStatus.VerifyStockStatusProductTypePageElements();
            _common.VerifyDataTableOnPage();
            stockStatus.StockStatusProductTypeTableFilterInputTest();
            _common.VerifyDataTableOnPage();
            stockStatus.ClickProductTypeTableRow();
        }

        [Test]
        public void SmStockStatus_VerifyProductionFacilitiesTest()
        {
            var stockStatus = _common.NavigateToStockStatus();
            stockStatus.ClickProductTypeTableRow();
            _common.VerifyPersistentNav();
            stockStatus.VerifyStockStatusProductionFacilitiesPageElements();
            _common.VerifyDataTableOnPage();
            stockStatus.StockStatusProdFacilitiesTableFilterInputTest();
            _common.VerifyDataTableOnPage();
        }

        [Test]
        public void SmStockStatus_VerifyCurrentStockTest()
        {
            var stockStatus = _common.NavigateToStockStatus();
            stockStatus.ClickProductTypeTableRow();
            stockStatus.ClickProdFacilitiesTableRow();
            _common.VerifyPersistentNav();
            stockStatus.VerifyStockStatusCurrentStockStatusPageElements();
        }

        [Test]
        public void SmStockStatusSmokeTest()
        {
            var stockStatus = _common.NavigateToStockStatus();
            _common.VerifyPersistentNav();
            stockStatus.VerifyStockStatusProductTypePageElements();
            stockStatus.StockStatusProductTypeTableFilterInputTest();
            stockStatus.ClickProductTypeTableRow();
            _common.VerifyPersistentNav();
            stockStatus.VerifyStockStatusProductionFacilitiesPageElements();
            stockStatus.StockStatusProdFacilitiesTableFilterInputTest();
            stockStatus.ClickProdFacilitiesTableRow();
            _common.VerifyPersistentNav();
            stockStatus.VerifyStockStatusCurrentStockStatusPageElements();
        }

        [Test]
        public void SmSlaSmokeTest()
        {
            var slaPage = _common.NavigateToSla();
            _common.VerifyPersistentNav();
            slaPage.VerifySlaProductTypePageElements();
            slaPage.SlaProductTypeTableFilterInputTest();
            slaPage.ClickSlaProductTypeTableRow();
            _common.VerifyPersistentNav();
            slaPage.VerifySlaProductionFacilitiesPageElements();
            slaPage.SlaProductionFacilitiesTableFilterInputTest();
            slaPage.ClickSlaFacilitiesTableRow();
            _common.VerifyPersistentNav();
            slaPage.VerifySlaViewCurrentSlaPageElements();
        }

        [Test]
        public void SmFacilitiesSmokeTest()
        {
            var facPage = _common.NavigateToFacilities();
            _common.VerifyPersistentNav();
            facPage.VerifyFacilitySelectFacilityPageElements();
            facPage.FacilitiesSelectFacilityTableFilterInputTest();
            facPage.ClickSlaFacilitiesTableRow();
            _common.VerifyPersistentNav();
            facPage.VerifyViewFacilityPageElements();
        }

        [Test]
        public void SmReportsSmokeTest()
        {
            var reportsPage = _common.NavigateToReports();
            _common.VerifyPersistentNav();
            reportsPage.VerifyReportsPageElements();
            reportsPage.TestReportsTableFilterInput();
            reportsPage.ClickReportsTableRow();
            _common.VerifyPersistentNav();
            reportsPage.VerifyReportsFacilityStockAvailPageElements();
        }
    }
}