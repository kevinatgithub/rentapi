using Microsoft.AspNetCore.Mvc;
using WenasRoomForRent.Api.Models;
using WenasRoomForRent.Services;

namespace WenasRoomForRent.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestLogController : ControllerBase
{
    private readonly IRequestLogService requestLogService;

    public RequestLogController(IRequestLogService requestLogService) => this.requestLogService = requestLogService ?? throw new ArgumentNullException(nameof(requestLogService));

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(requestLogService.GetLogs().Select(i => new RequestLogResponse
        {
            Action = i.Item1,
            DateTime = i.Item2
        }));
    }
}
