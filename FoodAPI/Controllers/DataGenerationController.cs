using FoodAPI.Data;
using FoodAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataGenerationController : ControllerBase
    {

        private readonly DataGenerationService _dataGenerationService;

        public DataGenerationController(DataGenerationService dataGenerationService)
        {
            _dataGenerationService = dataGenerationService;
        }

        [HttpPost("generate")]
        public IActionResult GenerateData()
        {
            _dataGenerationService.GenerateRandomData();
            return Ok("Random data generated successfully.");
        }
    }
}
