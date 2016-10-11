using OpenQA.Selenium;

namespace Autodan.core
{
    public  class WebElementWrapper
    {
        public WebElementWrapper(IWebElement webElement, string commonContent, string uniqueContent)
        {
            Element = webElement;
            UniqueContent = uniqueContent;
            CommonContent = commonContent;
        }
        public  IWebElement Element { get; set; }

        public  string UniqueContent { get; set; }

        public  string CommonContent { get; set; }
    }
}
