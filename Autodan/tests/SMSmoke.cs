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
    class SMSmokeTest
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
        public void SmokeTest()
        {
            //init common
            SMCommonPageObject common = new SMCommonPageObject();

            //navigate to login page of Shipping Manager app
            SMLoginPageObject loginPage = new SMLoginPageObject();

            //verify login page elements
            loginPage.VerifyLoginPageElements();

            //login to app + returns dashboard page object
            SMDashboardPageObject dashboard = loginPage.Login("dpeterson", "ADano!#1519!#");

            //Verify page elements on Dashboard page
            dashboard.VerifyDashboardPageElements();

            //navigate to Product type page && init locators
            dashboard.NavToStockStatusProductType();
            SMStockStatusProductTypePageObject producttype = new SMStockStatusProductTypePageObject();

            //smoke test of stockstatus - product type data table
            producttype.VerifyStockStatusProductTypePageElements();
            common.VerifyDataTableOnPage();

            //smoke test filter input && re-verify data table
            producttype.TestTableFilterInput();
            common.VerifyDataTableOnPage();

            //drill into product type table to nav to Production Facilities page/table
            producttype.DrillIntoTable();
            SMStockStatusProductionFacilitiesPageObject ProdFacilities = new SMStockStatusProductionFacilitiesPageObject();

            //smoke test prod facilities
            ProdFacilities.VerifyStockStatusProductionFacilitiesPageElements();
            common.VerifyDataTableOnPage();
        }

        [TearDown]
        public void Cleanup()
        {
            PropertiesCollection.driver.Close();
            Console.WriteLine("Test completed; collapsing instance");
        }
    }
}
