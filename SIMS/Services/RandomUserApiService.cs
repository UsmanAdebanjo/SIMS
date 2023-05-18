using Newtonsoft.Json;
using SIMS.Models;

namespace SIMS.Services
{
    public class RandomUserApiService
    {
        private readonly ThirdPartyApiService _thirdPartyApiService;

        public RandomUserApiService(ThirdPartyApiService thirdPartyApiService)
        {
            _thirdPartyApiService = thirdPartyApiService;
        }

        public async Task<string> GetData()
        {
            string apiUrl = "api/v3/PublicHolidays/2023/AT";
            string apiData= await _thirdPartyApiService.GetApiData(apiUrl);
            return apiData;
        }
    }
}
