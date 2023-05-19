using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SIMS.Dtos;
using SIMS.Services;

namespace SIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThirdPartyApiController : ControllerBase
    {
        private readonly ThirdPartyApiClient _thirdPartyApiClient;
        public ThirdPartyApiController(ThirdPartyApiClient thirdPartyApiClient)
        {
            _thirdPartyApiClient = thirdPartyApiClient;
        }

        [HttpGet]
        public async Task <ActionResult> GetData()
        {
            var json = JsonConvert.DeserializeObject<List<Holiday>>(await _thirdPartyApiClient.GetApiData());

            return Ok(json);
            
        }
    }
}
