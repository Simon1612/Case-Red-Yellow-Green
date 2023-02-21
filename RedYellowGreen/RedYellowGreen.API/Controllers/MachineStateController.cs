using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedYellowGreen.API.Services;

namespace RedYellowGreen.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize("")]
public class MachineStateController : ControllerBase
{
    private readonly ILogger _logger;

    public MachineStateController(ILogger logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Order> Get(string machineId)
    {

    }

    [HttpGet]
    public IEnumerable<Order> GetAll()
    {

    }

    [HttpPost]
    public IEnumerable<Order> Post(string machineId)
    {

    }
}