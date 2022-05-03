using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CatFacts.Models;

namespace CatFacts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatFactsController : ControllerBase
    {
        private readonly ILogger<CatFactsController> _logger;
        private readonly ICatFactsService _catFactsService;

        public CatFactsController(ILogger<CatFactsController> logger, ICatFactsService catFactsService)
        {
            _logger = logger;
            _catFactsService = catFactsService;
        }

        [HttpGet]
        public  async Task<ActionResult<CatFactsModel>> GetAsync()
        {
            var fact =  await _catFactsService.Get();
            _logger.LogInformation(JsonConvert.SerializeObject(fact));
            return Ok(fact);
        }
    }
}