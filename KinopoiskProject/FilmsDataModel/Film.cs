using System;
using System.Collections.Generic;

namespace FilmsDataModel
{
    public class Film
    {
        public string Name { get; set; }

        public string Country { get; set; }

        //public DateTime Year { get; set; }
        public string Year { get; set; }

        public string Rating { get; set; }

        public List<string> Actors { get; set; }

        public string Duration { get; set; }
    }
}
