using System;
using System.Collections.Generic;
using System.Text;

namespace JSON___Pokemon
{
    class PokemonName
    {
        public string name { get; set; }
        public string url { get; set; }

        public override string ToString()
        {
            return $"{name}";
        }
    }
}
