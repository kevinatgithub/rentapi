using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WenasRoomForRent.Api.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/payments")]
        [HttpGet("/payments/{id:int}")]
        [HttpGet("/profiles/create")]
        [HttpGet("/rents")]
        [HttpGet("/profiles")]
        [HttpGet("/profiles/transfer/{id:int}/{oldRoomId:int}")]
        [HttpGet("/profiles/create")]
        [HttpGet("/profiles/{id:int}")]
        [HttpGet("/profiles/{id:int}/update")]
        [HttpGet("/rooms")]
        [HttpGet("/rooms/create")]
        [HttpGet("/rooms/{id:int}")]
        [HttpGet("/rooms/{id:int}/update")]
        [HttpGet("/notfound")]
        [HttpGet("/")]
        public IActionResult Home()
        {
            return Redirect("/index.html");
        }
    }
}
