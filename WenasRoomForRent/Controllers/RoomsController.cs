using Microsoft.AspNetCore.Mvc;
using WenasRoomForRent.Api.Filters;
using WenasRoomForRent.Domain;
using WenasRoomForRent.Services;

namespace WenasRoomForRent.Api.Controllers;

[RequestLogger]
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

    [HttpGet("filterByProfileId/{id}")]
    public IActionResult List(int id) => Ok(roomService.GetByProfileId(id));

    [HttpGet("filterByName/{name}")]
    public IActionResult FilterByName(string name) => Ok(roomService.GetByName(name));

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
