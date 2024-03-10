using Newtonsoft.Json;

namespace PokemonGatherAPI.Models
{
    public class Pokemon
    {
        public int Number { get; set; }

        public string Name { get; set; }

        [JsonProperty("Type 1")]
        public string Type1 { get; set; }

        [JsonProperty("Type 2")]
        public string Type2 { get; set; }
        //public Move[] moves {  get; set; }
        public File PokemonPicture { get; set; }
    }
}
