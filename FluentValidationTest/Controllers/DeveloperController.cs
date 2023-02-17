namespace FluentValidationTest.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Models;

    [ApiController]
    [Route("[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly ILogger<DeveloperController> _logger;

        public DeveloperController(ILogger<DeveloperController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create(Developer developer)
        {
            return Ok();
        }
    }
}