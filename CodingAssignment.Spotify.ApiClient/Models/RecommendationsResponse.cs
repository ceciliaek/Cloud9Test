using Newtonsoft.Json;
using System;

namespace CodingAssignment.Spotify.ApiClient.Models
{
    public partial class RecommendationsResponse
    {
        [JsonProperty("tracks")]
        public Track[] Tracks { get; set; }

        [JsonProperty("seeds")]
        public Seed[] Seeds { get; set; }
    }

    public partial class Seed
    {
        [JsonProperty("initialPoolSize")]
        public long InitialPoolSize { get; set; }

        [JsonProperty("afterFilteringSize")]
        public long AfterFilteringSize { get; set; }

        [JsonProperty("afterRelinkingSize")]
        public long AfterRelinkingSize { get; set; }

        [JsonProperty("href")]
        public Uri Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Track
    {
        [JsonProperty("artists")]
        public Artist[] Artists { get; set; }

        [JsonProperty("disc_number")]
        public long DiscNumber { get; set; }

        [JsonProperty("duration_ms")]
        public long DurationMs { get; set; }

        [JsonProperty("explicit")]
        public bool Explicit { get; set; }

        [JsonProperty("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }

        [JsonProperty("href")]
        public Uri Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_playable")]
        public bool IsPlayable { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("preview_url")]
        public Uri PreviewUrl { get; set; }

        [JsonProperty("track_number")]
        public long TrackNumber { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}