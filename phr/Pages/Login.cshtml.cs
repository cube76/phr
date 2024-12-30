using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using phr.Config;
using phr.Models;

namespace phr.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly ApiService _apiService;

        public LoginModel(ILogger<LoginModel> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public IActionResult OnGet()
        {
            var token = HttpContext.Session.GetString("Token");
            _logger.LogInformation("token login: {ExceptCode}", token);
            if (token != null)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
        }

        [BindProperty]

        public LoginRequest Input { get; set; }


        public string ErrorMessage { get; set; }


        public async Task<IActionResult> OnPostAsync()

        {
            if (!ModelState.IsValid)

            {

                return Page();

            }


            var requestBody = new

            {

                userName = Input.Username,

                password = Input.Password

            };

            try

            {

                var response = await _apiService.Login(requestBody);

                var tokenResponse = JsonConvert.DeserializeObject<LoginResponse>(response);


                // Store the token in session or any other storage
                _logger.LogError("output: {ErrorMessage}", tokenResponse.expiresIn);
                HttpContext.Session.SetString("Token", tokenResponse.jwtToken);


                // Redirect to a protected page

                return RedirectToPage("/Index");

            }

            catch (HttpRequestException ex)

            {

                ErrorMessage = "Login failed. Please check your credentials.";
                _logger.LogError("login failed: {ErrorMessage}", ex.Message);

                // Optionally log the exception
                ViewData["Error"] = ErrorMessage;
            }

            catch (JsonException ex)

            {

                ErrorMessage = "An error occurred while processing the response.";
                _logger.LogError("login Error calling the API: {ErrorMessage}", ex.Message);

                // Optionally log the exception
                ViewData["Error"] = ErrorMessage;
            }


            return Page();
        }
    }

}
