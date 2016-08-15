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
    class ShippingManagerSmokeTest
    {
        
        [SetUp]
        public void Initialize()
        {
            //build browser
            PropertiesCollection.driver = new ChromeDriver();
            Console.WriteLine("Created browser instance");
            PropertiesCollection.driver.Manage().Window.Maximize();
            Console.WriteLine("Instance window maximized");
            
            //navigate to application
            PropertiesCollection.driver.Navigate().GoToUrl("http://tools.cafepress.com/Shipping/");
            Console.WriteLine("Navigated to URL: tools.cafepress.com/Shipping/");
        }

        [Test]
        public void LoginPageTest()
        {
            //navigate to login page of Shipping Manager app
            SMLoginPageObject loginPage = new SMLoginPageObject();

            //verify login page elements
            loginPage.VerifyLoginPageElements();

            //login to app + returns dashboard page object
            loginPage.Login();
        }

        [Test]
        public void DashboardPageTest()
        {
            //login to app
            SMLoginPageObject loginPage = new SMLoginPageObject();
            SMCommonPageObject common = loginPage.Login();

            //smoke test dashboard page
            common.VerifyPersistentNav();
            common.VerifyDashboardPageElements();
        }

        [Test]
        public void StockStatusProductTypeTest()
        {
            //init page object & login to app
            SMLoginPageObject loginPage = new SMLoginPageObject();
            SMCommonPageObject common = loginPage.Login();
            

            //navigate to Product type page & init locators
            SMStockStatusPageObject stockStatus = common.NavigateToStockStatus();


            //smoke test of stockstatus - product type data table
            common.VerifyPersistentNav();
            stockStatus.VerifyStockStatusProductTypePageElements();
            common.VerifyDataTableOnPage();
            
            stockStatus.ProductTypeTableFilterInputTest();
            common.VerifyDataTableOnPage();


            //drill into product type table to nav to Production Facilities page/table
            stockStatus.ProductTypeDrillIntoTable();
        }

        [Test]
        public void StockStatusProductionFacilitiesTest()
        {
            //init page object & login to app
            SMLoginPageObject loginPage = new SMLoginPageObject();
            SMCommonPageObject common = loginPage.Login();
            

            //navigate to Product type page & init locators
            SMStockStatusPageObject stockStatus = common.NavigateToStockStatus();


            //drill into product type table to navigate to production facilities page & init page object
            stockStatus.ProductTypeDrillIntoTable();


            //smoke test prod facilities
            common.VerifyPersistentNav();
            stockStatus.VerifyStockStatusProductionFacilitiesPageElements();
            common.VerifyDataTableOnPage();
            
            stockStatus.ProductionFacilitiesTableFilterInputTest();
            common.VerifyDataTableOnPage();
        }


        [Test]
        public void StockStatusCurrentStockTest()
        {
            //init page object & login to app
            SMLoginPageObject loginPage = new SMLoginPageObject();
            SMCommonPageObject common = loginPage.Login();


            //navigate to product type page & init locators
            SMStockStatusPageObject stockStatus = common.NavigateToStockStatus();


            //drill into product type table - drill into prod facilities table
            stockStatus.ProductTypeDrillIntoTable();
            stockStatus.ProductionFacilitiesDrillIntoTable();

            //smoke test view stock status page
            common.VerifyPersistentNav();
            stockStatus.VerifyStockStatusViewStockStatusPageElements();

            
        }

        [TearDown]
        public void Cleanup()
        {
            PropertiesCollection.driver.Close();
            Console.WriteLine("Test completed; collapsing instance");
        }
    }
}
