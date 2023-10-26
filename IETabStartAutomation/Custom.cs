using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V116.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace IETabStartAutomation
{
    public class Custom
    {
        public IWebDriver Driver { get; set; }
        public IJavaScriptExecutor jse { get; set; }

        public Custom(IWebDriver Driver)
        {
            this.Driver = Driver;
            this.jse = (IJavaScriptExecutor)Driver;
        }

        public IWebElement TryFindElementByXpathWithAttempts(int tries, int secs, string path)
        {
            var times = 0;
            do
            {
                try
                {
                    return Driver.FindElement(By.XPath(path));
                }
                catch (Exception)
                {
                    times++;
                    Thread.Sleep(secs * 1000);
                }
            } while (times < tries);
            throw new Exception("Elemento não encontrado.");
        }

        public IWebElement TryFindElementByXpathWithAttemptsThrowNull(int tries, int secs, string path)
        {
            var times = 0;
            do
            {
                try
                {
                    return Driver.FindElement(By.XPath(path));
                }
                catch (Exception)
                {
                    times++;
                    Thread.Sleep(secs * 1000);
                }
            } while (times < tries);
            return null;
        }

        public void TryClickElement(int tries, int secs, IWebElement element)
        {
            var times = 0;
            do
            {
                try
                {
                    element.Click();
                    return;
                }
                catch (Exception)
                {
                    Thread.Sleep(secs * 1000);
                    times++;
                }
            } while (times < tries);
            throw new Exception("Element in not clickable.");
        }

        public IWebElement TryFindElementsWithAttempts(int tries, int secs, string path)
        {
            var times = 0;
            do
            {
                try
                {
                    return (IWebElement)Driver.FindElements(By.XPath(path));
                }
                catch (Exception)
                {
                    times++;
                    Thread.Sleep(secs * 1000);
                }
            } while (times < tries);
            throw new Exception("Elementos não encontrados.");
        }

        public IWebElement TryClickBtnJs(int tries, int secs, string id)
        {
            var times = 0;
            do
            {
                try
                {
                    jse.ExecuteScript($"document.getElementById('{id}').click();");
                }
                catch (Exception)
                {
                    times++;
                    Thread.Sleep(secs * 1000);
                }
            } while (times < tries);
            throw new Exception("Element not clickable.");
        }

        public void WaitForLoadPage(string path)
        {
            //TODO
            //WAITFORLOADPAGE
        }
    }
}
