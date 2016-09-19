using Autodan.core;
using Autodan.pages.cafepress.com;
using NUnit.Framework;

namespace Autodan.tests.cafepress.com.cart
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class CpCartSmokeTest : BaseTest
    {
        private CpCommonPageObject _common;
        private CpCartPageObject _cart;
        private CpProductDescriptionPageObject _pdp;

        [SetUp]
        public void Setup()
        {
            if(CheckForSkipSetup())
                return;

            Setup("headless", "cafepress");
        }

        [TearDown]
        public void TearDown()
        {
            Cleanup();
        }

        [Test, Category("SkipSetup")]
        public void CartSmokeTest()
        {
            Setup("headless", "cafepress");
        }
    }
}