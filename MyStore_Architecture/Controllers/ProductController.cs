using Microsoft.AspNetCore.Mvc;

namespace MyStore_Architecture.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
      

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("");
        }
    }
}
