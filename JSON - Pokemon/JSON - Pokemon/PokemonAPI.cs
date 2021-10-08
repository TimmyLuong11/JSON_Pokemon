using System;
using System.Collections.Generic;
using System.Text;

namespace JSON___Pokemon
{
    class PokemonAPI
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<PokeName> results { get; set; }
    }
}
