using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using phr.Config;
using phr.Models;
using phr.Pages.Exceptions.General_Information;

namespace phr.Pages.Exceptions.Form_Action_Recommendation
{
    public class ActionRecommendationModel : BasePageModel
    {
        private readonly ILogger<ActionRecommendationModel> _logger;
        private readonly ApiService _apiService;

        public ActionRecommendationModel(ILogger<ActionRecommendationModel> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }
        public void OnGet(string uwi, string name, string alt, string grid)
        {
            ViewData["uwi"] = uwi;
            ViewData["name"] = name;
            ViewData["alt"] = alt;
            ViewData["grid"] = grid;
        }
        public WellLastInfo WellLastInfo { get; set; }

        //public void OnPost(string wellLastInfo)
        //{
        //    WellLastInfo = JsonConvert.DeserializeObject<WellLastInfo>(wellLastInfo);
        //    ViewData["WellLastInfo"] = JsonConvert.SerializeObject(WellLastInfo);
        //}
    }
}
