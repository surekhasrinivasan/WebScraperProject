using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ScraperProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Navigate().GoToUrl("https://login.yahoo.com");

            chromeDriver.Manage().Window.Maximize();
            IWebElement username = chromeDriver.FindElement(By.XPath("//*[@id=\"login-username\"]"));
            username.SendKeys("surekha.srinivasan@yahoo.com");
            username.Submit();
            
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(8));
            IWebElement password = wait.Until(driver => chromeDriver.FindElement(By.Id("login-passwd")));
            password.SendKeys("Careerdevs");
            password.SendKeys(Keys.Enter);

            chromeDriver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view/v1");            
        }
    }    
}
