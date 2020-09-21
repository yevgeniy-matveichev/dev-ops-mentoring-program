using System;
using System.Collections.Generic;

namespace FilmsDataModel
{
    public class Film
    {
        public string Name { get; }

        public string Country { get; }

        public DateTime Year { get; }

        public string Rating { get; }

        public List<string> Actors { get; }
    }
}
