using EverybodyCodes.Api.QueryParams;
using EverybodyCodes.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EverybodyCodes.Api.Controllers;

[ApiController]
public class CamerasController : ControllerBase
{
    private readonly ICameraService _cameraService;

    public CamerasController(ICameraService cameraService)
    {
        _cameraService = cameraService;
    }

    [HttpGet("api/cameras")]
    public IActionResult Get()
    {
        var cameras = _cameraService.GetAll();
        return Ok(cameras);
    }

    [HttpGet("api/cameras/divisibleby")]
    public IActionResult Get([FromQuery] DivisibleByGetParams queryParams)
    {
        if (queryParams.Numbers == null)
            return BadRequest(nameof(queryParams.Numbers));

        var cameras = _cameraService.GetDivisibleBy(queryParams.Numbers, queryParams.Negation);
        return Ok(cameras);
    }
}
