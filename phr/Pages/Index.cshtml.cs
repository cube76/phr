using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using phr.Config;
using phr.Models;

namespace phr.Pages
{
	public class IndexModel : PageModel
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

		//public void OnGet()
		//{

		//}

		public List<ExceptionDetails> Exceptions { get; set; }
		public List<PassedSignals> Signals { get; set; }

		public async Task<IActionResult> OnPostAsync()
		{
			var requestBody = new
			{
				userName = "userwell1",
				password = "userwell1"
			};

			var response = await _apiService.Login(requestBody);

			// Handle the response
			ViewData["ApiResponse"] = response;

			return Page();
		}

		public async Task OnGetAsync()
		{
			_logger.LogInformation("Calling the API for exception details...");

			try
			{
				var client1 = new HttpClient();
				var request = new HttpRequestMessage(HttpMethod.Post, "https://phrapigw-dev.azure-api.net/Account/Token");
				request.Headers.Add("Ocp-Apim-Subscription-Key", "001f1f5b4cde4dfa8928523eb43dc1c4");
				var content = new StringContent("{\r\n    \"userName\": \"userwell1\",\r\n    \"password\": \"userwell1\"\r\n}", null, "application/json");
				request.Content = content;
				var response1 = await client1.SendAsync(request);
				response1.EnsureSuccessStatusCode();
				var responseContent = await response1.Content.ReadAsStringAsync();
				var objects = JsonConvert.DeserializeObject<Login>(responseContent);
				_logger.LogInformation("hasil: {ExceptCode}", objects.jwtToken);
				try
				{
					var task1 = _apiService.GetExceptionSignals(objects.jwtToken);
					var task2 = _apiService.GetPassedSignals(objects.jwtToken);

					// Run both tasks concurrently
					await Task.WhenAll(task1, task2);

					var result1 = await task1;
					var result2 = await task2;

					Exceptions = JsonConvert.DeserializeObject<List<ExceptionDetails>>(result1);
					Signals = JsonConvert.DeserializeObject<List<PassedSignals>>(result2);
					ViewData["WellException"] = Exceptions?.Count(e => e.ExceptType == "WELL") ?? 0;
					ViewData["NonWellException"] = Exceptions?.Count(e => e.ExceptType != "WELL") ?? 0;
					ViewData["WellSignals"] = Signals?.Count(e => e.ActionType == "WELL") ?? 0;
					ViewData["NonWellSignals"] = Signals?.Count(e => e.ActionType != "WELL") ?? 0;
					ViewData["ItemCount"] = 4;

					_logger.LogInformation("oweowe: {ExceptCode}", Exceptions?.Count);
				}
				catch (Exception ex)
				{
					_logger.LogError("Error calling the API: {ErrorMessage}", ex.Message);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError("Error calling the API: {ErrorMessage}", ex.Message);
			}
		}
	}
}
