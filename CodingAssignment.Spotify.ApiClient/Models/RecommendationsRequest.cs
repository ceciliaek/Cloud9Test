using Newtonsoft.Json;

namespace CodingAssignment.Spotify.ApiClient.Models
{
    public class RecommendationsRequest
    {
        [JsonProperty("energy")]
        public float Energy { get; set; }

        [JsonProperty("danceability")]
        public float Danceability { get; set; }

        [JsonProperty("acousticness")]
        public float Acousticness { get; set; }

        [JsonProperty("loudness")]
        public float Loudness { get; set; }

        [JsonProperty("valence")]
        public float Valence { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }
    }
}