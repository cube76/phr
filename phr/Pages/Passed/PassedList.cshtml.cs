using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using phr.Config;
using phr.Models;
using phr.Pages.Exceptions;

namespace phr.Pages.Passed
{
    public class PassedListModel : BasePageModel
    {
        private readonly ILogger<PassedListModel> _logger;
        private readonly ApiService _apiService;

        public PassedListModel(ILogger<PassedListModel> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public List<OutstandingPassed> OutstandingPasseds { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var task1 = _apiService.GetOutstandingPasseds();

                var result1 = await task1;
                var json = JsonConvert.DeserializeObject<List<OutstandingPassed>>(result1);

                OutstandingPasseds = json;

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

