using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;


namespace Module1.TypesAndClasses.Tests.API_tests
{
   [TestClass]
    public class Unitest1
    {
        static IWebDriver driverFF;
        static IWebDriver driverGC;
        static IWebDriver driverIE;
        static IWebDriver driverED;

        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        { 
            driverFF = new FirefoxDriver();
            driverGC = new ChromeDriver(@"C:\C# Cources\chromedriver.exe");
            driverIE = new InternetExplorerDriver();
            driverED = new EdgeDriver();
        }

        [TestMethod]
        public void TestFirefoxDriver()
        {
            driverFF.Navigate().GoToUrl("http://www.google.com");
            driverFF.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
            driverFF.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
        }

        [TestMethod]
        public void TestChromeDriver()
        {
            driverGC.Navigate().GoToUrl("http://www.google.com");
            driverGC.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
            driverGC.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
        }
    }

}
