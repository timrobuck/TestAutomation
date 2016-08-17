using Autodan.core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodan
{
    class ShippingManagerSmokeTest : BaseTest
    {

        [Test]
        public void LoginPageTest()
        {
            //build test
            Setup("chrome");

            //navigate to login page of Shipping Manager app
            SMLoginPageObject loginPage = new SMLoginPageObject();

            //verify login page elements
            loginPage.VerifyLoginPageElements();

            //login to app + returns dashboard page object
            loginPage.Login();

            //teardown
            Cleanup();
        }

        [Test]
        public void DashboardPageTest()
        {
            //build test
            Setup("chrome");

            //login to app
            SMLoginPageObject loginPage = new SMLoginPageObject();
            SMCommonPageObject common = loginPage.Login();

            //smoke test dashboard page
            common.VerifyPersistentNav();
            common.VerifyDashboardPageElements();

            //teardown
            Cleanup();
        }

        [Test]
        public void StockStatusProductTypeTest()
        {
            //build test
            Setup("chrome");

            //init page object & login to app
            SMLoginPageObject loginPage = new SMLoginPageObject();
            SMCommonPageObject common = loginPage.Login();

            //navigate to Product type page & init locators
            SMStockStatusPageObject stockStatus = common.NavigateToStockStatus();

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
        public void StockStatusProductionFacilitiesTest()
        {
            //build test
            Setup("chrome");

            //init page object & login to app
            SMLoginPageObject loginPage = new SMLoginPageObject();
            SMCommonPageObject common = loginPage.Login();

            //navigate to Product type page & init locators
            SMStockStatusPageObject stockStatus = common.NavigateToStockStatus();

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
        public void StockStatusCurrentStockTest()
        {
            //build test
            Setup("chrome");

            //init page object & login to app
            SMLoginPageObject loginPage = new SMLoginPageObject();
            SMCommonPageObject common = loginPage.Login();

            //navigate to product type page & init locators
            SMStockStatusPageObject stockStatus = common.NavigateToStockStatus();

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
        public void SMStockStatusSmokeTest()
        {
            //build test
            Setup("chrome");

            //init page object & login to app
            SMLoginPageObject loginPage = new SMLoginPageObject();
            SMCommonPageObject common = loginPage.Login();

            //navigate to stock status - product type & init locators
            SMStockStatusPageObject stockStatus = common.NavigateToStockStatus();

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
        public void SMSlaSmokeTest()
        {
            //build test
            Setup("chrome");

            //init page object & login to app
            SMLoginPageObject loginPage = new SMLoginPageObject();
            SMCommonPageObject common = loginPage.Login();

            //navigate to product type page & init locators (sla)
            SMSlaPageObject slaPage = common.NavigateToSLA();

            //smoke test SLA - Product type
            common.VerifyPersistentNav();
            slaPage.VerifySLAProductTypePageElements();
            slaPage.SLAProductTypeTableFilterInputTest();
            slaPage.ClickSLAProductTypeTableRow();

            //smoke test SLA - Facilities
            common.VerifyPersistentNav();
            slaPage.VerifySLAProductionFacilitiesPageElements();
            slaPage.SLAProductionFacilitiesTableFilterInputTest();
            slaPage.ClickSLAFacilitiesTableRow();

            //smoke test SLA - Current SLA
            common.VerifyPersistentNav();
            slaPage.VerifySLAViewCurrentSLAPageElements();

            //teardown
            Cleanup();
        }

        [Test]
        public void SMFacilitiesSmokeTest()
        {
            //build test
            Setup("chrome");

            //init page object and login to app
            SMLoginPageObject loginPage = new SMLoginPageObject();
            SMCommonPageObject common = loginPage.Login();

            //nav to facilities landing page and init locators
            SMFacilitiesPageObject facPage = common.NavigateToFacilities();

            //smoke test Facilities - Select a facility
            common.VerifyPersistentNav();
            facPage.VerifyFacilitySelectFacilityPageElements();
            facPage.FacilitiesSelectFacilityTableFilterInputTest();
            facPage.ClickSLAFacilitiesTableRow();

            //smoke test View facility subpage
            common.VerifyPersistentNav();
            facPage.VerifyViewFacilityPageElements();
        }

    }
}