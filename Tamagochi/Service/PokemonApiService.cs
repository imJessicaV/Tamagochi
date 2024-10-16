using RestSharp;
using Newtonsoft.Json;
using Tamagochi.Model;
using Tamagotchi.Model;

namespace Tamagochi.Service
{
    public class PokemonApiService
    {
        public List<PokemonResult> ObterEspeciesDisponiveis()
        {
            // Obter a lista de espécies de Pokémons
            var client = new RestClient();
            var request = new RestRequest("https://pokeapi.co/api/v2/pokemon-species/", Method.Get);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new Exception("Erro ao obter espécies de Pokémons");
            }

            var pokemonEspeciesResposta = JsonConvert.DeserializeObject<PokemonSpeciesResult>(response.Content);

            return pokemonEspeciesResposta.Results;
        }

        public PokemonDetailsResult ObterDetalhesDaEspecie(PokemonResult especie)
        {
            // Obter as características do Pokémon escolhido
            var client = new RestClient();
            var request = new RestRequest($"https://pokeapi.co/api/v2/pokemon/{especie.Name}", Method.Get);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new Exception($"Erro ao obter detalhes da espécie: {especie.Name}");
            }

            return JsonConvert.DeserializeObject<PokemonDetailsResult>(response.Content);
        }
    }
}
