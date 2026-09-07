using Microsoft.AspNetCore.Mvc;

namespace MySecureApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;

        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger;
        }

        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            _logger.LogInformation("Health check endpoint called");
            return Ok(new { status = "healthy", timestamp = DateTime.UtcNow });
        }
    }
}
