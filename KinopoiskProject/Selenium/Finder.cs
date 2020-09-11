using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium;

namespace Selenium
{
    [TestClass]
    public class Finder
    {
        readonly static IWebDriver driver = new ChromeDriver(@"C:\temp");
        [TestMethod]
        public async void TestMethod1()
        {
            await Task.Run(() => driver.Navigate().GoToUrl("http://kinopoisk.ru/"));
            driver.Quit();
        }
    }
}
