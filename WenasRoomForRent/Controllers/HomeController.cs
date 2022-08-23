using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WenasRoomForRent.Api.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Home()
        {
            return Redirect("/index.html");
        }
    }
}
