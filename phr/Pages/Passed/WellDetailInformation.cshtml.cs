using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using phr.Config;
using phr.Models;

namespace phr.Pages.Passed
{
    public class WellDetailInformationModel : BasePageModel
    {
        private readonly ILogger<WellDetailInformationModel> _logger;
        private readonly ApiService _apiService;

        public WellDetailInformationModel(ILogger<WellDetailInformationModel> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public WellLastInfo WellLastInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(string id, string code, string name)
        {
            try
            {
                var task1 = _apiService.GetWellLastInfo();

                var result1 = await task1;
                var json = JsonConvert.DeserializeObject<List<WellLastInfo>>(result1);

                WellLastInfo = json.LastOrDefault();

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
