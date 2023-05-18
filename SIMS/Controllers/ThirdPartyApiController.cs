using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIMS.Services;

namespace SIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThirdPartyApiController : ControllerBase
    {
        private readonly RandomUserApiService _randomUserApiService;
        public ThirdPartyApiController(RandomUserApiService randomUserApiService)
        {
            _randomUserApiService = randomUserApiService;
        }

        [HttpGet]
        public ActionResult GetData()
        {
            return Ok(_randomUserApiService.GetData());
        }
    }
}
