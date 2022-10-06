using KevApp.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KevApp.Api.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly AppDbContext context;

        public HomeController(AppDbContext context)
        {
            this.context = context;
        }

        //[HttpGet("/")]
        //public IActionResult Home()
        //{
        //    return Redirect("/index.html");
        //}

        [Authorize]
        [HttpGet("Test")]
        public IActionResult Cities()
        {
            return Ok(context.Cities);
        }
    }
}
