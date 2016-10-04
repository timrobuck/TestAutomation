using Autodan.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Autodan.pages.MerchTool.SmartProductEnginePages
{
    class MtCommonToEditDetailPages:BaseTest
    {
        public MtCommonToEditDetailPages()
        {
            PageFactory.InitElements(Driver, this);
        }

        //common elements to detail pages //using ClassName to make this more generic
        [FindsBy(How=How.ClassName,Using= "dataTables_info")]
        public IWebElement ShowingXtoYofZentries { get; set; }
    }
}
