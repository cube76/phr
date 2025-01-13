using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using phr.Config;
using phr.Models;

namespace phr.Pages.Passed
{
    public class WellActionReportModel : BasePageModel
    {
        private readonly ILogger<WellActionReportModel> _logger;
        private readonly ApiService _apiService;

        public WellActionReportModel(ILogger<WellActionReportModel> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public List<WorkflowStep> WorkflowSteps { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var task1 = _apiService.GetWorkflowSteps();

                var result1 = await task1;
                var json = JsonConvert.DeserializeObject<List<WorkflowStep>>(result1);
                WorkflowSteps = json;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "An error occurred while fetching.");
                return RedirectToPage("/Login");
            }
            return Page();
        }
    }
}
