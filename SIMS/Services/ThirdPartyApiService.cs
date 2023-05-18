namespace SIMS.Services
{
    public class ThirdPartyApiService
    {
        private readonly ILogger<ThirdPartyApiService> _logger;
        private readonly HttpClient _httpClient;
        public ThirdPartyApiService(ILogger<ThirdPartyApiService> logger , HttpClient httpClient)
        {
            _logger = logger;   
            _httpClient = httpClient;   
        }

        public async Task<string> GetApiData(string apiUrl)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

    }
}
