using Microsoft.AspNetCore.Mvc;

namespace Globalque.Controllers
{
    [ApiController]
    public class SystemController : ControllerBase
    {
        [HttpGet("ping")]
        public ActionResult<PingDto> Ping()
        {
            return Ok(new PingDto());
        }
    }
}
