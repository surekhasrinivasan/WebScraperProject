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
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("disable-popup-blocking");

            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Navigate().GoToUrl("https://login.yahoo.com");

            chromeDriver.Manage().Window.Maximize();
            IWebElement username = chromeDriver.FindElement(By.XPath("//*[@id=\"login-username\"]"));
            username.SendKeys("surekha.srinivasan@yahoo.com");
            username.Submit();

            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            IWebElement password = wait.Until(driver => chromeDriver.FindElement(By.Id("login-passwd")));
            password.SendKeys("Careerdevs");
            password.SendKeys(Keys.Enter);

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            chromeDriver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view/v1");
            
            var closePopUp = chromeDriver.FindElement(By.XPath("//*[@id=\"fin-tradeit\"]/div[2]/div/div/div[2]/button[2]"));
            closePopUp.Click();

            var stocks = chromeDriver.FindElements(By.XPath("//*[@id=\"main\"]/section/section[2]/div[2]/table/tbody/tr[*]/td[*]"));
            foreach (var stock in stocks)
                Console.WriteLine(stock.Text);
        }
    }    
}
