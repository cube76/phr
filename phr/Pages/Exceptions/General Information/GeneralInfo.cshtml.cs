using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using phr.Config;
using phr.Models;

namespace phr.Pages.Exceptions.General_Information
{
    public class GeneralInfoModel : BasePageModel
    {
        private readonly ILogger<GeneralInfoModel> _logger;
        private readonly ApiService _apiService;

        public GeneralInfoModel(ILogger<GeneralInfoModel> logger, ApiService apiService)
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
