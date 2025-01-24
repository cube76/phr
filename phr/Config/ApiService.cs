using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace phr.Config
{
	public class ApiService
	{
        private readonly ILogger<ApiService> _logger;
        private readonly HttpClient _httpClient;
		private readonly string _apiBaseUrl;
		private readonly string _apiKeyAzure;
		private readonly string _ocpApimSubscriptionKey;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiService(ILogger<ApiService> logger, HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
		{
            _logger = logger;
            _httpClient = httpClient;
			_apiBaseUrl = configuration["ApiSettings:BaseUrl"];
			_apiKeyAzure = configuration["ApiSettings:ApiKeyAzure"];
			_ocpApimSubscriptionKey = configuration["ApiSettings:OcpApimSubscriptionKey"];
            _httpContextAccessor = httpContextAccessor;
        }

        public string ValidateToken()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(token))
            {
                throw new InvalidOperationException("Token is null or empty. Please log in.");
            }
            return token; 
        }
        private void HandleErrorResponse(HttpStatusCode statusCode)
        {
            if (statusCode == HttpStatusCode.Unauthorized)
            {
                _httpContextAccessor.HttpContext.Session.Remove("Token");
                _httpContextAccessor.HttpContext.Response.Redirect("/Login");
            }
            else
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Error");
                throw new InvalidOperationException("Error calling api");
            }
        }

        public async Task<string> Login(object requestBody)
		{
            var jsonContent = JsonConvert.SerializeObject(requestBody);
			var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

			_httpClient.DefaultRequestHeaders.Clear();
			_httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _ocpApimSubscriptionKey); 

			var response = await _httpClient.PostAsync("https://phrapigw-dev.azure-api.net/Account/Token", content);
			response.EnsureSuccessStatusCode();

			var responseData = await response.Content.ReadAsStringAsync();

			return responseData;
		}

		public async Task<string> GetExceptionSignals()
		{
            var token = ValidateToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			_httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKeyAzure);
			var response = await _httpClient.GetAsync($"{_apiBaseUrl}/iem/api/ExceptionSignals");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                HandleErrorResponse(response.StatusCode);
                return null; 
            }
		}

		public async Task<string> GetPassedSignals()
		{
            var token = ValidateToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			_httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKeyAzure);
			var response = await _httpClient.GetAsync($"{_apiBaseUrl}/iem/api/PassedSignals");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                HandleErrorResponse(response.StatusCode);
                return null;
            }
        }

        public async Task<string> GetProductionCharts()
        {
            var token = ValidateToken();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKeyAzure);
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/iem/api/ProductionCharts");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                HandleErrorResponse(response.StatusCode);
                return null;
            }
        }

        public async Task<string> GetWellLastInfo()
        {
            var token = ValidateToken();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKeyAzure);
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/iem/api/WellLastInfo");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                HandleErrorResponse(response.StatusCode);
                return null;
            }
        }
        
        public async Task<string> GetOutstandingExceptions()
        {
            var token = ValidateToken();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKeyAzure);
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/iem/api/OutstandingExceptions");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                HandleErrorResponse(response.StatusCode);
                return null;
            }
        }
        
        public async Task<string> GetOutstandingPasseds()
        {
            var token = ValidateToken();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKeyAzure);
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/iem/api/OutstandingPasseds");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                HandleErrorResponse(response.StatusCode);
                return null;
            }
        }
        
        public async Task<string> GetWorkflowSteps()
        {
            var token = ValidateToken();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKeyAzure);
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/iem/api/WorkflowSteps");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                HandleErrorResponse(response.StatusCode);
                return null;
            }
        }
    }
}
