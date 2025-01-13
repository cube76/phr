using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using phr.Config;
using phr.Models;

namespace phr.Pages.Passed
{
    public class PassedModel : BasePageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApiService _apiService;
        public PassedModel(ILogger<IndexModel> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public List<PassedSignals> Signals { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            try
            {
                var token = HttpContext.Session.GetString("Token");
                _logger.LogInformation("dalam: {ExceptCode}", token);
                if (token.IsNullOrEmpty())
                {
                    return RedirectToPage("/Login");
                }
                try
                {
                    var task1 = _apiService.GetPassedSignals();

                    var result1 = await task1;
                    var jsonSignals = JsonConvert.DeserializeObject<List<PassedSignals>>(result1);

                    Signals = jsonSignals;

                }
                catch (Exception ex)
                {
                    return RedirectToPage("/Login");
                }
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Login");
            }
            return Page();
        }
    }
}

