using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApiVS.Models
{
    internal class GetImportantPokemonDetails
    {
        public string name { get; set; }
        public string order { get; set; }
        public List<dynamic> stats { get; set; }
        public string weight { get; set; }
    }
}
