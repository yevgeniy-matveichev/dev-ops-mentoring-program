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

        // todo: if film was not found

        private IWebElement ShowAllBtn => _driver.FindElement(By.XPath("//*[@id=\"block_left_pad\"]/div/div[3]/p[2]/a"));

        public FindFilm(string filmName)
        {
            _driver = new ChromeDriver(@"C:\temp");
            _filmName = filmName;
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
                try
                {
                    var filmName = element.FindElement(By.ClassName("name")).Text;
                    var filmYear = element.FindElement(By.ClassName("year")).Text;
                    var film = new Film()
                    {
                        Name = filmName,
                        Year = filmYear
                    };

                    listOfFilms.Add(film);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally { }
            }

            return listOfFilms;
        }

        public Film FilmInfo(string filmName)
        {
            var stringUrl = $"https://www.kinopoisk.ru/index.php?kp_query={_filmName}";

            _driver.Navigate().GoToUrl(stringUrl);

            var film = _driver.FindElement(By.XPath("//*[@id=\"block_left_pad\"]/div/div[2]/div/div[2]/p/a"));
            film.Click();
            Task.Delay(2000).Wait();

            var listOfCountries = new List<string>();
            var countriesDiv = _driver.FindElement(By.XPath("//*[@id=\"__next\"]/div/div[2]/div[1]/div[2]/div/div[3]/div/div/div[2]/div[1]/div/div[2]/div[2]"));
            var countries = countriesDiv.FindElements(By.ClassName("styles_linkLight__1Nxon styles_link__1N3S2"));
            foreach (var country in countries)
            {
                var c = country.FindElement(By.ClassName("styles_linkLight__1Nxon styles_link__1N3S2")).Text;
                listOfCountries.Add(c);
            }

            //var listOfActors = new List<string>();
            //var castingBtn = _driver.FindElement(By.XPath("//*[@id=\"__next\"]/div/div[2]/div[1]/div[2]/div/div[3]/div/div/div[2]/div[2]/div[1]/div[1]/h3/a"));
            //castingBtn.Click();
            //Task.Delay(2000).Wait();


            var f = new Film()
            {
                Name = $"{filmName}",
                Country = string.Join(", ", listOfCountries),
                Year = _driver.FindElement(By.XPath("//*[@id=\"__next\"]/div/div[2]/div[1]/div[2]/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[2]/a")).Text,
                Rating = _driver.FindElement(By.XPath("//*[@id=\"__next\"]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div[3]/div/div/div[2]/div[1]/div[1]/span[1]/a")).Text,
                //Actors = "",
                Duration = _driver.FindElement(By.XPath("//*[@id=\"__next\"]/div/div[2]/div[1]/div[2]/div/div[3]/div/div/div[2]/div[1]/div/div[25]/div[2]/div")).Text
            };

            return f;
        }
    }
}
