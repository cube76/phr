using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using phr.Config;
using phr.Models;
using phr.Pages.Exceptions.Production_Surveliance;

namespace phr.Pages.Exceptions
{
    public class ExceptionListModel : BasePageModel
    {
        private readonly ILogger<ExceptionListModel> _logger;
        private readonly ApiService _apiService;

        public ExceptionListModel(ILogger<ExceptionListModel> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public List<OutstandingException> OutstandingExceptions { get; set; }

        public async Task<IActionResult> OnGetAsync(string id, string code, string name)
        {
            ViewData["id"] = id;
            ViewData["name"] = name;
            ViewData["code"] = code;
            try
            {
                var task1 = _apiService.GetOutstandingExceptions();

                var result1 = await task1;
                var json = JsonConvert.DeserializeObject<List<OutstandingException>>(result1);

                OutstandingExceptions = json;

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
