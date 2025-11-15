using Microsoft.AspNetCore.Mvc;

namespace backend_math_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("🚀 API Math Backend funcionando!");
    }
}