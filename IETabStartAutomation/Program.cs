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
            int tries = 0;
            do
            {
                try
                {
                    string link = "http://prouni.mec.gov.br/prouni2006/Login/";
                    WebDriverInstance webDriverInstance = new WebDriverInstance();
                    Driver = webDriverInstance.ReturnDriver();
                    Custom custom = new Custom(Driver);

                    WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 60));

                    Driver.Navigate().GoToUrl("chrome-extension://hehijbfgiekmjfkfjpbkbammjbdenadd/nhc.htm#url=https://www.ietab.net/ie-tab-documentation?from=chromeurl");
                    Driver.Manage().Window.Maximize();

                    wait.Until(wd => wd.WindowHandles.Count == 2);
                    Thread.Sleep(2000);

                    for (int i = 0; i < 3; i++)
                    {
                        IWebElement addressbox = custom.TryFindElementByXpathWithAttempts(5, 5, "//input[contains(@id, 'address-box')]");
                        addressbox.Clear();

                        Thread.Sleep(1000);
                        addressbox.SendKeys(link);
                        addressbox.Clear();
                        addressbox.SendKeys(link);

                        custom.TryClickBtnJs(5, 1, "go-btn");

                        var btnAccept = custom.TryFindElementByXpathWithAttemptsThrowNull(5, 5, "//button[contains(@id, 'trial-continue')]");
                        if (btnAccept != null)
                        {
                            try
                            {
                                btnAccept.Click();
                            }
                            catch (Exception)
                            {
                                custom.TryClickBtnJs(5, 1, "trial-continue");
                            }
                        }
                    }
                    
                    break;
                }
                catch (Exception)
                {
                    tries++;
                    Driver.Quit();
                    Driver.Dispose();
                }
            } while (tries <= 5);
        }
    }
}