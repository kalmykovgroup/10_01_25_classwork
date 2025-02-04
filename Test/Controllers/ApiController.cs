using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
    

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ok");
        }
    }
}
