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
            var recommendations = await spotifyApiClient.SearchRecommendationsAsync(recommendationsRequest);

            var returnHtml = new List<string>();
            foreach (var item in recommendations.Tracks)
            {
                returnHtml.Add($"{item.Type}/{item.Id}");
            }

            return Json(returnHtml, JsonRequestBehavior.AllowGet);
        }
    }
}