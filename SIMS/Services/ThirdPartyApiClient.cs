namespace SIMS.Services
{
    public class ThirdPartyApiClient
    {
        private readonly HttpClient _httpClient;

        public ThirdPartyApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetApiData()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://date.nager.at/api/v3/publicholidays/2023/AT");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
    }
}
