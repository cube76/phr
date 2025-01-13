using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using phr.Config;
using phr.Models;

namespace phr.Pages.Exceptions.Form_Action_Recommendation
{
    public class RecommendationModel : BasePageModel
    {
        private readonly ILogger<RecommendationModel> _logger;
        private readonly ApiService _apiService;

        public RecommendationModel(ILogger<RecommendationModel> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }
        public void OnGet()
        {
        }
        //public WellLastInfo WellLastInfo { get; set; }

        //public void OnPost(string wellLastInfo)
        //{
        //    WellLastInfo = JsonConvert.DeserializeObject<WellLastInfo>(wellLastInfo);

        //}
    }
}
