using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using phr.Config;
using phr.Models;

namespace phr.Pages.Exceptions.General_Information
{
    public class WelldownInfoModel : BasePageModel
    {
        private readonly ILogger<WelldownInfoModel> _logger;
        private readonly ApiService _apiService;

        public WelldownInfoModel(ILogger<WelldownInfoModel> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }
        public void OnGet()
        {
        }
        public WellLastInfo WellLastInfo { get; set; }

        public void OnPost(string wellLastInfo)
        {
            WellLastInfo = JsonConvert.DeserializeObject<WellLastInfo>(wellLastInfo);

        }
    }
}
