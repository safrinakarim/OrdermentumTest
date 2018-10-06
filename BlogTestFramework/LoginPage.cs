using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlogTestFramework
{
    public class LoginPage
    {
        public static void Goto()
        {
            Driver.Instance.Navigate().GoToUrl("https://demo.fork-cms.com/private/");
            // Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5.00);
        }

        public static LoginCommand LoginAs(string username)
        {
            return new LoginCommand(username);
        }
    }

    public class LoginCommand
    {
        public string username;
        public string password;

        public LoginCommand(String username)
        {
            this.username = username;
        }

        public LoginCommand withPassword(string password)
        {
            this.password = password;
            return this;

        }

        public void Login()
        {
            IWebElement inputus = Driver.Instance.FindElement(By.XPath("//*[@id='backendEmail']"));
            inputus.SendKeys(username);

            IWebElement inputpass = Driver.Instance.FindElement(By.XPath("//*[@id='backendPassword']"));
            inputpass.SendKeys(password);
            
            IWebElement loginbutton = Driver.Instance.FindElement(By.XPath("//button[@title='Log in']"));
            loginbutton.Click();

            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5.00);

        }

    }
}
