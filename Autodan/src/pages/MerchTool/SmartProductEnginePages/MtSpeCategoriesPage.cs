using Autodan.core;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.SmartProductEnginePages
{
    public class MtSpeCategoriesPage
    {
        public MtSpeCategoriesPage()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
        }
    }
}
