using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace FilmsSearcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading the page...");
            
            const string filmName = "Maugli";
            var stringUrl = $"https://www.kinopoisk.ru/index.php?kp_query={filmName}";

            IWebDriver driver = new ChromeDriver(@"C:\temp");
            driver.Navigate().GoToUrl(stringUrl);

            //IWebElement element = 
            driver.FindElement(By.XPath(@"/html/body/main/div[4]/div[1]/table/tbody/tr/td[1]/div/div[2]/div/div[2]/p/a")).SendKeys(Keys.Enter);
            driver.Navigate().Refresh();
            IWebElement element = driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[2]/div[2]/div[2]/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[2]/a"));
            driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[2]/div[2]/div[2]/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[2]/a")).SendKeys(Keys.Enter);
            
            Console.WriteLine("The page is loaded");
            Console.ReadLine();
        }
    }
}
