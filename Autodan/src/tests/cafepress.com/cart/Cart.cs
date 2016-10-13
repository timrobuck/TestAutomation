using System;
using Autodan.core;
using Autodan.pages.cafepress.com;
using NUnit.Framework;
using OpenQA.Selenium;
using By = OpenQA.Selenium.Extensions.By;

namespace Autodan.tests.cafepress.com.cart
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class CafePressCart : BaseTest
    {
        private CpCommonPageObject _common;
        private CpCartPageObject _cart;

        [SetUp]
        public void Setup()
        {
            if (CheckForSkipSetup())
                return;

            Setup("headless", "cafepress.dev");
            _common = new CpCommonPageObject();
            _cart = new CpCartPageObject();
        }

        [TearDown]
        public void TearDown()
        {
            Cleanup();
        }

        [Test]
        public void CartSmokeTest()
        {
            _common.AddItemAndGoToCart(); //hacky workaround while cart doesn't save-  needs to be removed
            _common.SmokeTestCommonNav();
            _cart.SmokeTestCart();
        }

        [Test]
        public void CartCommonNavTest()
        {
            _common.AddItemAndGoToCart();
            _common.SmokeTestCommonNav();
            _common.SmokeTestGlobalPageFooter();
        }
    }
}