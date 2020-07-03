using System;
using System.Net.Http;
using System.Threading.Tasks;
using CodingAssignment.Spotify.ApiClient.Models;
using Flurl;
using Newtonsoft.Json;

namespace CodingAssignment.Spotify.ApiClient
{
    public class SpotifyApiClient
    {
        private const string ClientId = "996d0037680544c987287a9b0470fdbb";
        private const string ClientSecret = "5a3c92099a324b8f9e45d77e919fec13";
        protected const string BaseUrl = "https://api.spotify.com/";

        private HttpClient GetDefaultClient()
        {
            var authHandler = new SpotifyAuthClientCredentialsHttpMessageHandler(
                ClientId,
                ClientSecret,
                new HttpClientHandler());

            var client = new HttpClient(authHandler)
            {
                BaseAddress = new Uri(BaseUrl)
            };

            return client;
        }

        public async Task<RecommendationsResponse> SearchRecommendationsAsync(RecommendationsRequest recomendationsRequest, int? limit = 12)
        {
            var client = GetDefaultClient();

            var url = new Url("/v1/recommendations");
            url = url.SetQueryParam("market", "SE");
            url = url.SetQueryParam("seed_genres", recomendationsRequest.Genre);
            url = url.SetQueryParam("limit", limit);
            url = url.SetQueryParam("target_energy", recomendationsRequest.Energy/10);
            url = url.SetQueryParam("target_danceability", recomendationsRequest.Danceability / 10);
            url = url.SetQueryParam("target_acousticness", recomendationsRequest.Acousticness / 10);
            url = url.SetQueryParam("target_loudness", recomendationsRequest.Loudness / 10);
            url = url.SetQueryParam("target_valence", recomendationsRequest.Valence / 10);

            var response = await client.GetStringAsync(url);
            var artistResponse = JsonConvert.DeserializeObject<RecommendationsResponse>(response);

            return artistResponse;
        }
    }
}