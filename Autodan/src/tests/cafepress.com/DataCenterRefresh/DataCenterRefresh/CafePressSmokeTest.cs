using System;
using Autodan.core;
using Autodan.pages.cafepress.com;
using NUnit.Framework;

namespace Autodan.tests.DataCenterRefresh
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class DataCenterRefreshTesting : BaseTest
    {
        private CpCommonPageObjectGlobalNavUpdate _common;
        private CpProductDescriptionPageObject _pdp;

        [SetUp]
        public void Setup()
        {
            if (CheckForSkipSetup())
                return;

            Setup("chrome", "cafepress.live");
            _common = new CpCommonPageObjectGlobalNavUpdate();
            _pdp = new CpProductDescriptionPageObject();
        }

        [TearDown]
        public void TearDown()
        {
            Cleanup();
        }

        [Test]
        public void SmokeTestCartHover()
        {
            //todo: oh god it's gross and hacky but in a pinch to finish some quick and dirty tests for datacenter refresh
            _common.VerifyCartHoverEmptyCart();
            Console.WriteLine("Navigating to PDP page, adding item to cart, and retesting Cart hover menu");
            Driver.Navigate().GoToUrl("http://www.cafepress.com/mf/74111597/catnip_magnets?productId=1702076661");
            _pdp.AddItemToCart();
            Console.WriteLine("Item added to cart");
            Driver.Wait(5000); //added static wait of 5 because the js doesn't update with the item in the cart until after the animation
            _common.VerifyCartHoverWithItem();
        }

        [Test]
        public void SmokeTestGlobalNav()
        {
            _common.VerifyGlobalPencilBanner();
            _common.VerifyShopByOptions();
            _common.VerifyGlobalNavExpandedView();
            _common.VerifySearchInput();
        }

        [Test]
        public void SmokeTestGlobalFooter()
        {
            _common.VerifyFooterExclusiveOffers();
            _common.VerifyFooterSocialMediaElements();
            _common.VerifyFooterHelpElements();
            _common.VerifyFooterAboutElements();
            _common.VerifyInternationalElements();
            _common.VerifyFooterUserAgreement();
            _common.VerifyFooterMcAfeeSecure();
        }
    }
}
