using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;

namespace BlogTestFramework
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }
        public static void Initialise()
        {
            Instance = new ChromeDriver("..\\driver");
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10.00);
        }

        public static void Close()
        {
            Instance.Close();
        }


    }
}