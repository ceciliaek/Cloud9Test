using CodingAssignment.Spotify.ApiClient;
using CodingAssignment.Spotify.ApiClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Cloud9SpotifyApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetRecommendations(RecommendationsRequest recommendationsRequest)
        {
            var spotifyApiClient = new SpotifyApiClient();
            var recommendations = await spotifyApiClient.SearchRecommendationsAsync(recommendationsRequest, 3);

            var returnHtml = new List<string>();
            foreach (var item in recommendations.Tracks)
            {
                returnHtml.Add($"{item.Type}/{item.Id}");
            }

            return Json(returnHtml, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ShowMeMore()
        {
            float.TryParse(Request.QueryString["energy"], out float energy);
            float.TryParse(Request.QueryString["danceability"], out float danceability);
            float.TryParse(Request.QueryString["acousticness"], out float acousticness);
            float.TryParse(Request.QueryString["loudness"], out float loudness);
            float.TryParse(Request.QueryString["valence"], out float valence);
            var genre = Request.QueryString["genre"];

            RecommendationsRequest recomendationsRequest = new RecommendationsRequest
            {
                Energy = energy,
                Danceability = danceability,
                Acousticness = acousticness,
                Loudness = loudness,
                Valence = valence,
                Genre = genre
            };

            var spotifyApiClient = new SpotifyApiClient();
            var recommendations = await spotifyApiClient.SearchRecommendationsAsync(recomendationsRequest, 24);

            return View(recommendations);
        }
    }
}