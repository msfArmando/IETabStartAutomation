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
                Automations auto = new Automations();

                try
                {
                    auto.InstallDllProcess();
                    auto.NavigateToWebSite(Paths.IeTabUrl);
                    auto.SearchWebSite(Paths.ProuniLink);

                    break;
                }

                catch (Exception)
                {
                    tries++;
                    auto.DisposeDriver();
                }
            } while (tries <= 5);
        }
    }
}