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

        #region properties 

        private IEnumerable<IWebElement> AllFilms => _driver.FindElements(By.ClassName("element"));

        private IWebElement ShowAllBtn => _driver.FindElement(By.XPath("//*[@id=\"block_left_pad\"]/div/div[3]/p[2]/a"));

        private IWebElement CreationDate => _driver.FindElement(By.XPath("//*[@id=\"__next\"]/div/div[2]/div[2]/div[2]/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[2]/a"));

        private IWebElement Country => _driver.FindElement(By.XPath("//*[@id=\"__next\"]/div/div[2]/div[2]/div[2]/div/div[3]/div/div/div[2]/div[1]/div/div[2]/div[2]/a"));

        private IWebElement FilmName => _driver.FindElement(By.ClassName("styles_title__2l0HH"));

        //private IWebElement Rating => _driver.FindElement(By.XPath(""));

        //private IWebElement Actors => _driver.FindElement(By.XPath(""));

        #endregion

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

        readonly List<Film> ListOfFilms = new List<Film>();

        public List<Film> Find()
        {
            Console.WriteLine("Loading the page...");

            var stringUrl = $"https://www.kinopoisk.ru/index.php?kp_query={_filmName}";

            _driver.Navigate().GoToUrl(stringUrl);

            ShowAllBtn.Click();
            Task.Delay(2000).Wait();

            //Film film1 = new Film();
            //film1.

            //foreach (var film in AllFilms)
            //{
            //    film.Click();
            //    Task.Delay(2000).Wait();

            //    var date = CreationDate.Text;
            //    var country = Country.Text;
            //    var name = FilmName.Text;
            //}

            //ListOfFilms.Add(film);

            return null;
        }
    }
}
