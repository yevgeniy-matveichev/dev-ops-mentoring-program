using FilmsDataModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeleniumWrapper
{
    public class FindFilm : IFindFilm, IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly string _filmName;
        //private readonly Film _film;

        // todo: if film was not found

        private IWebElement ShowAllBtn => _driver.FindElement(By.XPath("//*[@id=\"block_left_pad\"]/div/div[3]/p[2]/a"));

        public FindFilm(string filmName)
        {
            _driver = new ChromeDriver(@"C:\temp");

            _filmName = filmName;
            //_film = film;
        }

        public void Dispose()
        {
            _driver.Dispose();
        }

        public List<Film> Find()
        {
            var stringUrl = $"https://www.kinopoisk.ru/index.php?kp_query={_filmName}";

            _driver.Navigate().GoToUrl(stringUrl);

            ShowAllBtn.Click();
            Task.Delay(2000).Wait(); // todo: web driver wait

            var elements = _driver.FindElements(By.ClassName("element"));
            var listOfFilms = new List<Film>();
                        
            foreach (var element in elements)
            {
                var film = new Film()
                {
                    Name = element.FindElement(By.ClassName("name")).Text,
                    Year = element.FindElement(By.ClassName("name")).FindElement(By.ClassName("year")).Text
                };

                listOfFilms.Add(film);
            }

            return listOfFilms;
        }
    }
}
