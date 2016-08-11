using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodan
{
    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        ClassName
    }

    class PropertiesCollection
    {
        //autoimplemented property
        public static IWebDriver driver { get; set; }
    }
}
