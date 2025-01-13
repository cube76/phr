using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using phr.Config;
using phr.Models;

namespace phr.Pages.Exceptions.Production_Surveliance
{
    public class DetailGraphicModel : BasePageModel
    {
        private readonly ILogger<DetailGraphicModel> _logger;
        private readonly ApiService _apiService;

        public DetailGraphicModel(ILogger<DetailGraphicModel> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public List<ProductionChart> productionChart { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var task1 = _apiService.GetProductionCharts();

                var result1 = await task1;
                var json = JsonConvert.DeserializeObject<List<ProductionChart>>(result1);

                ViewData["ChartData"] = result1;

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

