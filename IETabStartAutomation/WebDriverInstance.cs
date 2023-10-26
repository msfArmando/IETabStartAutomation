using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            ChromeOptions options = new ChromeOptions();
            options.AddExtension(@"C:\IETabStartAutomation\CRX\HEHIJBFGIEKMJFKFJPBKBAMMJBDENADD_16_10_16_1.crx");
            Driver = new ChromeDriver(options);
        }

        public IWebDriver ReturnDriver()
        {
            return Driver;
        }
    }
}
