using System.Text.Json.Serialization;

namespace Starwars.Core.Entities
{
    public class Jedi
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; } 

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("species")]
        public string Species { get; set; } 

        [JsonPropertyName("homeworld")]
        public string Homeworld { get; set; } = string.Empty;

        [JsonPropertyName("lightsaberColor")]
        public string LightsaberColor { get; set; } = string.Empty;

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
