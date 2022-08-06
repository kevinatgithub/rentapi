using Microsoft.AspNetCore.Mvc;
using WenasRoomForRent.Domain;
using WenasRoomForRent.Services;

namespace WenasRoomForRent.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomsController : ControllerBase
{
    private readonly IRoomService roomService;

    public RoomsController(IRoomService roomService)
    {
        this.roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
    }

    [HttpGet]
    public IActionResult List() => Ok(roomService.GetAll());

    [HttpGet("{id}")]
    public IActionResult Get(int id) => Ok(roomService.GetById(id));

    [HttpPost]
    public IActionResult Create(Room room) => Ok(roomService.Create(room));

    [HttpPut]
    public IActionResult Update(Room room)
    {
        roomService.Update(room);
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        roomService.Delete(id);
        return Ok();
    }
}
