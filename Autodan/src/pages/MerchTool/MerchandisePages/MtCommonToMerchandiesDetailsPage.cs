using OpenQA.Selenium;

namespace Autodan.pages.MerchTool.MerchandisePages
{
    public interface IMtCommonToMerchandiseDetailsPage
    {
        void VerifyElements();
        void VerifyPresentation();
        IWebElement BreadCrumbDetails { get; set; }
        IWebElement Legend { get; set; }
    }
}