using Microsoft.AspNetCore.Mvc;

namespace SampleAspNetWithEfCore.Controllers
{
    [ApiController]
    public class SystemController : ControllerBase
    {
        private readonly SystemOptions _options;

        public SystemController(SystemOptions options)
        {
            _options = options;
        }

        [HttpGet("ping")]
        public ActionResult<PingDto> Ping()
        {
            return Ok(new PingDto(_options.UseUtc, _options.PingMessageSuffix));
        }
    }
}
