using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi.Model;
public class PokemonSpeciesResult
{
    public int Count { get; set; }
    public string Next { get; set; }
    public string Previous { get; set; }
    public List<PokemonResult> Results { get; set; }
}
