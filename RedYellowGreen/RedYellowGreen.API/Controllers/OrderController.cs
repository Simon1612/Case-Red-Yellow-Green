using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RedYellowGreen.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize("")]
public class OrderController : ControllerBase
{
    private readonly ILogger _logger;

    public OrderController(ILogger logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public Models.Order Get(Guid orderId)
    {

    }

    [HttpGet("all")]
    public IEnumerable<Models.Order> GetAll()
    {

    }

    [HttpPost]
    public IActionResult Post(Models.Order newOrder)
    {


        return Ok();
    }

    [HttpPut]
    public IActionResult Update(Models.Order updatedOrder)
    {


        return Ok();
    }
}