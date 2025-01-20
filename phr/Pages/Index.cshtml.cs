using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using phr.Config;
using phr.Models;

namespace phr.Pages
{
    public class IndexModel : BasePageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApiService _apiService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl;
        private readonly string _apiKeyAzure;
        private readonly string _ocpApimSubscriptionKey;

        public IndexModel(ILogger<IndexModel> logger, ApiService apiService, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _logger = logger;
            _apiService = apiService;
            _httpClientFactory = httpClientFactory;
            _apiBaseUrl = configuration["ApiSettings:BaseUrl"];
            _apiKeyAzure = configuration["ApiSettings:ApiKeyAzure"];
            _ocpApimSubscriptionKey = configuration["ApiSettings:OcpApimSubscriptionKey"];
        }

        public List<ExceptionDetails> Exceptions { get; set; }
        public List<PassedSignals> Signals { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {            
            try
            {
                var task1 = _apiService.GetExceptionSignals();
                var task2 = _apiService.GetPassedSignals();

                await Task.WhenAll(task1, task2);

                var result1 = await task1;
                var result2 = await task2;
                var jsonException = JsonConvert.DeserializeObject<List<ExceptionDetails>>(result1);
                var jsonPassed = JsonConvert.DeserializeObject<List<PassedSignals>>(result2);

                Exceptions = jsonException.Take(4).ToList();
                Signals = jsonPassed.Take(4).ToList();
                ViewData["WellException"] = jsonException?.Count(e => e.ExceptType == "WELL") ?? 0;
                ViewData["NonWellException"] = jsonException?.Count(e => e.ExceptType != "WELL") ?? 0;
                ViewData["WellSignals"] = jsonPassed?.Count(e => e.ActionType == "WELL") ?? 0;
                ViewData["NonWellSignals"] = jsonPassed?.Count(e => e.ActionType != "WELL") ?? 0;
                ViewData["ItemCount"] = 4;

                var user = HttpContext.Session.GetObjectFromJson<LoginResponse>("User");
                ViewData["username"] = user.userName;
                ViewData["role"] = user.role[0];

                return Page();
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("token invalid",ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error calling the API 1: {ErrorMessage}", ex.Message);
            }

            return RedirectToPage("/Login");
        }

    }
}
