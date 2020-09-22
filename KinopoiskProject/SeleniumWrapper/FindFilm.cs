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

        public List<Film> Find()
        {
            Console.WriteLine("Loading the page...");

            var stringUrl = $"https://www.kinopoisk.ru/index.php?kp_query={_filmName}";

            _driver.Navigate().GoToUrl(stringUrl);

            ShowAllBtn.Click();
            Task.Delay(2000).Wait(); // todo: web driver wait

            var parentDiv = _driver.FindElement(By.XPath("/html/body/main/div[4]/div[1]/table/tbody/tr/td[1]/div/div[2]"));
            var divElements = parentDiv.FindElements(By.TagName("div"));
            var listOfFilms = new List<Film>();
            if (divElements.Count < 3)
            {
                return listOfFilms;
            }
                        
            foreach (var element in divElements)
            {
                IWebElement fileNameLink = element.FindElement(By.XPath("//div[2]/p/a")); // check if the url is valid
                IWebElement yearSpan = element.FindElement(By.XPath("//div[2]/p/span"));

                var film = new Film()
                {
                    Name = fileNameLink.Text,
                    Year = new DateTime(int.Parse(yearSpan.Text)) 
                };

                listOfFilms.Add(film);
            }

            return listOfFilms;

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
