using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodan.core;
using OpenQA;
using OpenQA.Selenium.Support.PageObjects;


namespace Autodan.pages.MerchTool
{
    internal class MtMerchandiseColorsPageObject:BaseTest
    {

        public MtMerchandiseColorsPageObject()
        {
            PageFactory.InitElements(BaseTest.Driver, this);
        }


       
    }
}
