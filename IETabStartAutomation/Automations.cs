using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IETabStartAutomation
{
    public class Automations
    {
        public IWebDriver Driver { get; set; }
        public Custom Custom { get; set; }

        public Automations()
        {
            WebDriverInstance webDriverInstance = new WebDriverInstance();
            Driver = webDriverInstance.ReturnDriver();
            Custom = new Custom(Driver);
        }

        public void NavigateToWebSite(string url)
        {
            Driver.Navigate().GoToUrl(url);
            Driver.Manage().Window.Maximize();
        }

        public void SearchWebSite(string link)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement addressbox = Custom.TryFindElementByXpathWithAttempts(5, 5, "//input[contains(@id, 'address-box')]");
            var btnAccept = Custom.TryFindElementByXpathWithAttemptsThrowNull(5, 5, "//button[contains(@id, 'trial-continue')]");

            if (btnAccept != null)
            {
                try
                {
                    btnAccept.Click();
                }
                catch (Exception)
                {
                    Custom.TryClickBtnJs(5, 1, "trial-continue");
                }
            }

            if(Custom.TryFindElementByXpathWithAttemptsThrowNull(5, 1, "//title[contains(., 'about:blank')]") != null)
            {
                addressbox = Custom.TryFindElementByXpathWithAttempts(5, 5, "//input[contains(@id, 'address-box')]");
                btnAccept = Custom.TryFindElementByXpathWithAttemptsThrowNull(5, 5, "//button[contains(@id, 'trial-continue')]");
                SetUrlToProuni(addressbox, link);
            }

            try
            {
                wait.Until(drv => drv.PageSource.Contains("Não é possível acessar esta página") ||
                drv.PageSource.Contains("A navegação para a página da Web foi cancelada") ||
                drv.PageSource.Contains("Verifique se o endereço") ||
                drv.PageSource.Contains("O endereço não é válido"));

                throw new Exception("Page not load");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Page not load"))
                    throw new Exception("Page not load");
                return;
            }
        }

        public void InstallDllProcess()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd C:\\IETabStartAutomation\\Microsoft CAPICOM 2.1.0.2 SDK\\Lib\\X86 && regsvr32 capicom.dll";
            startInfo.Verb = "runas";
            startInfo.UseShellExecute = true;
            process.StartInfo = startInfo;
            process.Start();
        }

        public void DisposeDriver()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        public void SetUrlToProuni(IWebElement addressbox, string link)
        {
            Thread.Sleep(1000);
            addressbox.Clear();
            addressbox.Clear();
            Thread.Sleep(1000);
            addressbox.SendKeys(link);
            Thread.Sleep(1000);
            Custom.TryClickBtnJs(5, 1, "go-btn");
            Thread.Sleep(1000);
        }
    }
}
