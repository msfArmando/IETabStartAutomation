using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IETabStartAutomation
{
    public class WebDriverInstance
    {
        public static IWebDriver Driver { get; set; }
        public WebDriverInstance()
        {
            EdgeOptions options = new EdgeOptions();
            options.AddExtension(@"C:\IETabStartAutomation\CRX\HEHIJBFGIEKMJFKFJPBKBAMMJBDENADD_16_10_16_1.crx");
            Driver = new EdgeDriver(options);
        }

        public IWebDriver ReturnDriver()
        {
            return Driver;
        }
    }
}
