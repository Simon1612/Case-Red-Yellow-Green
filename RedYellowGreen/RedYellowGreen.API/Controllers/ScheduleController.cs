using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedYellowGreen.API.Services;

namespace RedYellowGreen.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize("")]
public class ScheduleController : ControllerBase
{
    private readonly ILogger _logger;

    public ScheduleController(ILogger logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public Schedule Get(string machineId)
    {
        
    }

    [HttpGet]
    public IEnumerable<Models.Schedule> GetAll()
    {

    }

    [HttpPut]
    public IActionResult Update(string scheduleId)
    {


        return Ok();
    }
}