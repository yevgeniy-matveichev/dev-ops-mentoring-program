using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Module1.TypesAndClasses.Tests.SeleniumTests
{
    public class KatsiarynaTests : IDisposable
    {
        static IWebDriver driverGC;

        public KatsiarynaTests()
        {
            driverGC = new ChromeDriver(@"D:\chromedriver_win32");
        }

        public void Dispose()
        {
            driverGC.Dispose();
        }

        [Fact]
        public void TestGC()
        {
            driverGC.Navigate().GoToUrl("https://www.google.com/");
            driverGC.FindElement(By.XPath("/html/body/div/div[2]/form/div[2]/div[1]/div[1]/div/div[2]/input")).SendKeys("Selenium");
            driverGC.FindElement(By.XPath("/html/body/div/div[2]/form/div[2]/div[1]/div[1]/div/div[2]/input")).SendKeys(Keys.Enter);
        }
    }
}
