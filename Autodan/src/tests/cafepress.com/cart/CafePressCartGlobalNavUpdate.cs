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
    public class CafePressCartGlobalNavUpdate : BaseTest
    {
        private CpCommonPageObjectGlobalNavUpdate _common;
        private CpCartPageObject _cart;

        [SetUp]
        public void Setup()
        {
            if(CheckForSkipSetup())
                return;

            Setup("chrome", "cafepress.live");
            _common = new CpCommonPageObjectGlobalNavUpdate();
            _cart = new CpCartPageObject();
        }

        [TearDown]
        public void TearDown()
        {
            Cleanup();
        }

        [Test]
        public void GlobalNavSmokeTest()
        {
            _common.VerifyGlobalPencilBanner();
        }
    }
}