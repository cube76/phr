using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using phr.Config;
using phr.Models;
using phr.Pages.Exceptions.General_Information;

namespace phr.Pages.Exceptions.Form_Action_Recommendation
{
    public class WellInformationModel : BasePageModel
    {
        private readonly ILogger<WellInformationModel> _logger;
        private readonly ApiService _apiService;

        public WellInformationModel(ILogger<WellInformationModel> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public WellLastInfo WellLastInfo { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var task1 = _apiService.GetWellLastInfo();

                var result1 = await task1;
                var json = JsonConvert.DeserializeObject<List<WellLastInfo>>(result1);

                WellLastInfo = json.LastOrDefault();
                _logger.LogInformation("keluarg" + WellLastInfo);
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
