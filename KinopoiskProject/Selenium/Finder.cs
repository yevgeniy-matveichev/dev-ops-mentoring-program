using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Selenium
{
    [TestClass]
    public class Finder
    {
        readonly static IWebDriver driver = new ChromeDriver(@"C:\temp");
        [TestMethod]
        public async void TestMethod1(string filmName)
        {
            await Task.Run(() =>
            {
                driver.Navigate().GoToUrl($"https://www.kinopoisk.ru/index.php?kp_query={filmName}");
                //IWebElement element = 
                driver.FindElement(By.XPath(@"/html/body/main/div[4]/div[1]/table/tbody/tr/td[1]/div/div[2]/div/div[2]/p/a")).SendKeys(Keys.Enter);
                driver.Navigate().Refresh();
                IWebElement element = driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[2]/div[2]/div[2]/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[2]/a"));
                driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[2]/div[2]/div[2]/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[2]/a")).SendKeys(Keys.Enter);
                }
            );
           // driver.Quit();
        }
    }
}
