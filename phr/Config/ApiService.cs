using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace phr.Config
{
	public class ApiService
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiBaseUrl;
		private readonly string _apiKeyAzure;
		private readonly string _ocpApimSubscriptionKey;

		public ApiService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_apiBaseUrl = configuration["ApiSettings:BaseUrl"];
			_apiKeyAzure = configuration["ApiSettings:ApiKeyAzure"];
			_ocpApimSubscriptionKey = configuration["ApiSettings:OcpApimSubscriptionKey"];
		}

		public async Task<string> Login(object requestBody)
		{
			var jsonContent = JsonConvert.SerializeObject(requestBody);
			var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

			// Add custom headers
			_httpClient.DefaultRequestHeaders.Clear();
			_httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "HeaderValue");  // Example of adding a custom header

			// Send the POST request
			var response = await _httpClient.PostAsync("https://api1.example.com/data", content);
			response.EnsureSuccessStatusCode();

			// Read the response content as a string
			var responseData = await response.Content.ReadAsStringAsync();

			return responseData;
		}

		public async Task<string> GetExceptionSignals(string token)
		{
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			_httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKeyAzure);
			var response = await _httpClient.GetStringAsync($"{_apiBaseUrl}/iem/api/ExceptionSignals");
			return response;
		}

		public async Task<string> GetPassedSignals(string token)
		{
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			_httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKeyAzure);
			var response = await _httpClient.GetStringAsync($"{_apiBaseUrl}/iem/api/PassedSignals");
			return response;
		}
	}
}
