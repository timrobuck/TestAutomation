using Autodan.core;
using Autodan.pages.ShippingManager;
using NUnit.Framework;

namespace Autodan.tests.ShippingManager
{
    internal class ShippingManagerSmokeTest : BaseTest
    {

        [Test]
        public void SmLoginPageTest()
        {
            //build test
            Setup("chrome");

            //navigate to login page of Shipping Manager app
            SmLoginPageObject loginPage = new SmLoginPageObject();

            //verify login page elements
            loginPage.VerifyLoginPageElements();

            //login to app + returns dashboard page object
            loginPage.Login();

            //teardown
            Cleanup();
        }

        [Test]
        public void SmDashboardPageTest()
        {
            //build test
            Setup("chrome");

            //login to app
            SmLoginPageObject loginPage = new SmLoginPageObject();
            SmCommonPageObject common = loginPage.Login();

            //smoke test dashboard page
            common.VerifyPersistentNav();
            common.VerifyDashboardPageElements();

            //teardown
            Cleanup();
        }

        [Test]
        public void SmStockStatusProductTypeTest()
        {
            //build test
            Setup("chrome");

            //init page object & login to app
            SmLoginPageObject loginPage = new SmLoginPageObject();
            SmCommonPageObject common = loginPage.Login();

            //navigate to Product type page & init locators
            SmStockStatusPageObject stockStatus = common.NavigateToStockStatus();

            //smoke test of stockstatus - product type data table
            common.VerifyPersistentNav();
            stockStatus.VerifyStockStatusProductTypePageElements();
            common.VerifyDataTableOnPage();

            stockStatus.StockStatusProductTypeTableFilterInputTest();
            common.VerifyDataTableOnPage();

            //drill into product type table to nav to Production Facilities page/table
            stockStatus.ClickProductTypeTableRow();

            //teardown
            Cleanup();
        }

        [Test]
        public void SmStockStatusProductionFacilitiesTest()
        {
            //build test
            Setup("chrome");

            //init page object & login to app
            SmLoginPageObject loginPage = new SmLoginPageObject();
            SmCommonPageObject common = loginPage.Login();

            //navigate to Product type page & init locators
            SmStockStatusPageObject stockStatus = common.NavigateToStockStatus();

            //drill into product type table to navigate to production facilities page & init page object
            stockStatus.ClickProductTypeTableRow();

            //smoke test prod facilities
            common.VerifyPersistentNav();
            stockStatus.VerifyStockStatusProductionFacilitiesPageElements();
            common.VerifyDataTableOnPage();

            stockStatus.StockStatusProdFacilitiesTableFilterInputTest();
            common.VerifyDataTableOnPage();

            //teardown
            Cleanup();
        }


        [Test]
        public void SmStockStatusCurrentStockTest()
        {
            //build test
            Setup("chrome");

            //init page object & login to app
            SmLoginPageObject loginPage = new SmLoginPageObject();
            SmCommonPageObject common = loginPage.Login();

            //navigate to product type page & init locators
            SmStockStatusPageObject stockStatus = common.NavigateToStockStatus();

            //drill into product type table - drill into prod facilities table
            stockStatus.ClickProductTypeTableRow();
            stockStatus.ClickProdFacilitiesTableRow();

            //smoke test view stock status page
            common.VerifyPersistentNav();
            stockStatus.VerifyStockStatusCurrentStockStatusPageElements();

            //teardown
            Cleanup();
        }

        [Test]
        public void SmStockStatusSmokeTest()
        {
            //build test
            Setup("chrome");

            //init page object & login to app
            SmLoginPageObject loginPage = new SmLoginPageObject();
            SmCommonPageObject common = loginPage.Login();

            //navigate to stock status - product type & init locators
            SmStockStatusPageObject stockStatus = common.NavigateToStockStatus();

            //smoke test Stock Status - Product Type page
            common.VerifyPersistentNav();
            stockStatus.VerifyStockStatusProductTypePageElements();
            stockStatus.StockStatusProductTypeTableFilterInputTest();
            stockStatus.ClickProductTypeTableRow();

            //smoke test Stock Status - Production Facilities page
            common.VerifyPersistentNav();
            stockStatus.VerifyStockStatusProductionFacilitiesPageElements();
            stockStatus.StockStatusProdFacilitiesTableFilterInputTest();
            stockStatus.ClickProdFacilitiesTableRow();

            //smoke test Stock Status - Current stock status
            common.VerifyPersistentNav();
            stockStatus.VerifyStockStatusCurrentStockStatusPageElements();

            //teardown
            Cleanup();
        }

        [Test]
        public void SmSlaSmokeTest()
        {
            //build test
            Setup("chrome");

            //init page object & login to app
            SmLoginPageObject loginPage = new SmLoginPageObject();
            SmCommonPageObject common = loginPage.Login();

            //navigate to product type page & init locators (sla)
            SmSlaPageObject slaPage = common.NavigateToSla();

            //smoke test SLA - Product type
            common.VerifyPersistentNav();
            slaPage.VerifySlaProductTypePageElements();
            slaPage.SlaProductTypeTableFilterInputTest();
            slaPage.ClickSlaProductTypeTableRow();

            //smoke test SLA - Facilities
            common.VerifyPersistentNav();
            slaPage.VerifySlaProductionFacilitiesPageElements();
            slaPage.SlaProductionFacilitiesTableFilterInputTest();
            slaPage.ClickSlaFacilitiesTableRow();

            //smoke test SLA - Current SLA
            common.VerifyPersistentNav();
            slaPage.VerifySlaViewCurrentSlaPageElements();

            //teardown
            Cleanup();
        }

        [Test]
        public void SmFacilitiesSmokeTest()
        {
            //build test
            Setup("chrome");

            //init page object and login to app
            SmLoginPageObject loginPage = new SmLoginPageObject();
            SmCommonPageObject common = loginPage.Login();

            //nav to facilities landing page and init locators
            SmFacilitiesPageObject facPage = common.NavigateToFacilities();

            //smoke test Facilities - Select a facility
            common.VerifyPersistentNav();
            facPage.VerifyFacilitySelectFacilityPageElements();
            facPage.FacilitiesSelectFacilityTableFilterInputTest();
            facPage.ClickSlaFacilitiesTableRow();

            //smoke test View facility subpage
            common.VerifyPersistentNav();
            facPage.VerifyViewFacilityPageElements();
        }

        [Test]
        public void SmReportsSmokeTest()
        {
            //build test
            Setup("chrome");

            //init page object and login to app
            SmLoginPageObject loginPage = new SmLoginPageObject();
            SmCommonPageObject common = loginPage.Login();

            //nav to reports landing page and init locators
            SmReportsPageObject reportsPage = common.NavigateToReports();

            //smoke test Reports - View Reports
            common.VerifyPersistentNav();
            reportsPage.VerifyReportsPageElements();
            reportsPage.TestReportsTableFilterInput();
            reportsPage.ClickReportsTableRow();

            //smoke test Reports - Facility reports page
            common.VerifyPersistentNav();
            reportsPage.VerifyReportsFacilityStockAvailPageElements();
        }
    }
}