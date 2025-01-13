using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using phr.Config;
using phr.Models;

namespace phr.Pages.Exceptions
{
    public class ExceptionModel : BasePageModel
    {
        private readonly ILogger<ExceptionModel> _logger;
        private readonly ApiService _apiService;

        public ExceptionModel(ILogger<ExceptionModel> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
            Input = new ExceptionDetails();
        }

        public List<ExceptionDetails> ExceptionsFull { get; set; }
        public ExceptionDetails Input { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            try
            {
                var task1 = _apiService.GetExceptionSignals();

                var result1 = await task1;
                var jsonException = JsonConvert.DeserializeObject<List<ExceptionDetails>>(result1);

                ExceptionsFull = jsonException;

            }
            catch (Exception ex)
            {
                _logger.LogInformation("exceptionslist: {Code}", ex.Message);
                return RedirectToPage("/Login");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogInformation("Received Code: {Code}, Name: {Name}", Input.ExceptName, Input.ExceptCode);
            TempData["Code"] = Input.ExceptCode;
            TempData["Name"] = Input.ExceptName;

            return RedirectToPage("/ExceptionList");
        }
    }

}
