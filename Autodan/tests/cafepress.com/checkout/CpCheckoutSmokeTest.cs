using Autodan.core;
using Autodan.pages.cafepress.com;
using NUnit.Framework;

namespace Autodan.tests.cafepress.com.checkout
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class CpCheckoutSmokeTest : BaseTest
    {
        private CpCommonPageObject _common;

        [SetUp]
        public void Setup()
        {
            if (CheckForSkipSetup())
                return;

            Setup("chrome", "cafepress");

        }
    }
}