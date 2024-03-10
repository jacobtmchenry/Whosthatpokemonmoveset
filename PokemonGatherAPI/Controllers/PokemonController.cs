using Microsoft.AspNetCore.Mvc;
using PokemonGatherAPI.Models;
using Newtonsoft.Json;

namespace PokemonGatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        public List<Pokemon> pokemonData;

        private readonly ILogger<PokemonController> _logger;

        public PokemonController(ILogger<PokemonController> logger)
        {
            _logger = logger;
            LoadPokkemonJSONData(logger);
        }

        [HttpGet(Name = "GetPokemon")]
        public Pokemon Get()
        {
            return GetRandomPokemon();
        }

        private Pokemon GetRandomPokemon()
        {
            var random = new Random();
            int pokemonNumber = random.Next(0, 150);
            var currentPokemon = pokemonData[pokemonNumber];


            return currentPokemon;
        }

        private void LoadPokkemonJSONData(ILogger<PokemonController> logger)
        {
            using (StreamReader r = new StreamReader("data/PokemonData.json"))
            {
                string json = r.ReadToEnd();
                pokemonData = JsonConvert.DeserializeObject<List<Pokemon>>(json);
            }
        }
    }
}
