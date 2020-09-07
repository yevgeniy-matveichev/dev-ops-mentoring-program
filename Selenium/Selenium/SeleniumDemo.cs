using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Selenium
{
    [TestClass]
    public class SeleniumDemo
    {
        static IWebDriver driverFF;
        static IWebDriver driverGC;
        

        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
           // driverFF = new FirefoxDriver();
            driverGC = new ChromeDriver(@"C:\C_Cources");
        }
        /* [TestMethod]
         public void TestFirefoxDriver()
         {
             driverFF.Navigate().GoToUrl("http://google.com");
             driverFF.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
             driverFF.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
         }
        */
        [TestMethod]
        public void TestChromeDriver()
        {
            path = driverGC.Navigate().GoToUrl("http://tut.by");
            driverGC.FindElement(By.XPath("/html/body/ul")).SendKeys("YouTube");
            driverGC.FindElement(By.Name("q")).SendKeys(Keys.Enter);
        }
    }
}
