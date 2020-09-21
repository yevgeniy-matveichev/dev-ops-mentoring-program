using FilmsDataModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace SeleniumWrapper
{
    public class FindFilm : IFindFilm, IDisposable
    {
        private readonly IWebDriver driver;
        private readonly string filmName;

        public FindFilm(string filmName)
        {
            driver = new ChromeDriver(@"C:\temp");
            this.filmName = filmName;
        }

        public void Dispose()
        {
            driver.Dispose();
        }

        public List<Film> Find()
        {
            Console.WriteLine("Loading the page...");

            var stringUrl = $"https://www.kinopoisk.ru/index.php?kp_query={filmName}";

            driver.Navigate().GoToUrl(stringUrl);

            //driver.FindElement(By.XPath(@"/html/body/main/div[4]/div[1]/table/tbody/tr/td[1]/div/div[2]/div/div[2]/p/a")).SendKeys(Keys.Enter);
            //driver.Navigate().Refresh();
            //IWebElement element = driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[2]/div[2]/div[2]/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[2]/a"));
            //driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[2]/div[2]/div[2]/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[2]/a")).SendKeys(Keys.Enter);

            return null;
        }
    }
}
