using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using System.ComponentModel.DataAnnotations;
using OpenQA.Selenium.Support.UI;

namespace IETabStartAutomation
{
    public class Program
    {
        public static IWebDriver Driver { get; set; }
        public static void Main(string[] args)
        {
            WebDriverInstance webDriverInstance = new WebDriverInstance();
            Driver = webDriverInstance.ReturnDriver();

            WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 60));

            Driver.Navigate().GoToUrl("chrome-extension://hehijbfgiekmjfkfjpbkbammjbdenadd/nhc.htm#url=https://www.ietab.net/ie-tab-documentation?from=chromeurl");
            Driver.Manage().Window.Maximize();

            wait.Until(wd => wd.WindowHandles.Count == 2);

            var handles = Driver.WindowHandles;

            Driver.SwitchTo().Window(handles[1]);
            Driver.Close();
            Driver.SwitchTo().Window(handles[0]);

            Driver.FindElement(By.XPath("//button[contains(@id, 'trial-continue')]")).Click();
        }
    }
}