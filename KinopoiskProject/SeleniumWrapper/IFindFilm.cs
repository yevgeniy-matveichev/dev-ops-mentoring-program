using FilmsDataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWrapper
{
    interface IFindFilm
    {
        public List<Film> Find();
    }
}
