using Microsoft.AspNetCore.Mvc;
using PokemonGatherAPI.Models;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

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

        private string[] GetPokemonMovesData(string pokemonName, int moveNumberLimit)
        {

            if (moveNumberLimit > 0)
            {
                using (StreamReader r = new StreamReader($"data/pokemonmoves/{pokemonName}.json"))
                {
                    string json = r.ReadToEnd();

                     JObject newJsonArray = JsonConvert.DeserializeObject<JObject>(json);
                    JArray jsonArray = (JArray)newJsonArray["moves"];
                    var pokeMoves = jsonArray.ToObject<string[]>();

                    return PickRandomMoves(pokeMoves);
                }
            }

            return Array.Empty<string>();


        }

        private string[] PickRandomMoves(string[] pokemonMovesArray)
        {
            Random random = new Random();
            string[] newPokemonArray = new string[4];

            for (int pokemonMoveNumber = 0; pokemonMoveNumber < 4; pokemonMoveNumber++)
            {
                int randomIndex = random.Next(pokemonMovesArray.Length);
                newPokemonArray[pokemonMoveNumber] = pokemonMovesArray[randomIndex];
            }

            return newPokemonArray;
        }

        private Pokemon GetRandomPokemon()
        {
            var random = new Random();
            //int pokemonNumber = random.Next(0, 150);
            //var currentPokemon = pokemonData[pokemonNumber];
            var currentPokemon = pokemonData[0];
            currentPokemon.Moves = GetPokemonMovesData(currentPokemon.Name, 4);


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
