using Microsoft.AspNetCore.Mvc;

namespace HelloWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public String GetMessage()
        {
            return "S.A Dost";
        }
    }
}
