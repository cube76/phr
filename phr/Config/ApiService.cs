using Newtonsoft.Json;
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
			var response = await _httpClient.GetStringAsync($"{_apiBaseUrl}/iem/api/ExceptionSignals");
			return response;
		}

		public async Task<string> GetPassedSignals()
		{
            var token = ValidateToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			_httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKeyAzure);
			var response = await _httpClient.GetStringAsync($"{_apiBaseUrl}/iem/api/PassedSignals");
			return response;
		}

        public async Task<string> GetProductionCharts()
        {
            var token = ValidateToken();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKeyAzure);
            var response = await _httpClient.GetStringAsync($"{_apiBaseUrl}/iem/api/ProductionCharts");
            return response;
        }

        public async Task<string> GetWellLastInfo()
        {
            var token = ValidateToken();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKeyAzure);
            var response = await _httpClient.GetStringAsync($"{_apiBaseUrl}/iem/api/WellLastInfo");
            return response;
        }
        
        public async Task<string> GetOutstandingExceptions()
        {
            var token = ValidateToken();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKeyAzure);
            var response = await _httpClient.GetStringAsync($"{_apiBaseUrl}/iem/api/OutstandingExceptions");
            return response;
        }
        
        public async Task<string> GetOutstandingPasseds()
        {
            var token = ValidateToken();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKeyAzure);
            var response = await _httpClient.GetStringAsync($"{_apiBaseUrl}/iem/api/OutstandingPasseds");
            return response;
        }
        
        public async Task<string> GetWorkflowSteps()
        {
            var token = ValidateToken();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKeyAzure);
            var response = await _httpClient.GetStringAsync($"{_apiBaseUrl}/iem/api/WorkflowSteps");
            return response;
        }
    }
}
