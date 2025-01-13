using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using phr.Config;
using phr.Models;

namespace phr.Pages.Exceptions.General_Information
{
    public class GeneralInformationModel : BasePageModel
    {
        private readonly ILogger<GeneralInformationModel> _logger;
        private readonly ApiService _apiService;

        public GeneralInformationModel(ILogger<GeneralInformationModel> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public WellLastInfo WellLastInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(string id, string code, string name)
        {
            ViewData["id"] = id;
            ViewData["name"] = name;
            ViewData["code"] = code;
            try
            {
                var task1 = _apiService.GetWellLastInfo();

                var result1 = await task1;
                var json = JsonConvert.DeserializeObject<List<WellLastInfo>>(result1);

                WellLastInfo = json.LastOrDefault();
                ViewData["WellLastInfo"] = JsonConvert.SerializeObject(WellLastInfo);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching production charts.");
                return RedirectToPage("/Login");
            }
            return Page();
        }
    }
}
