using Microsoft.AspNetCore.Mvc;

namespace RedYellowGreen.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly Ordering.IService _service;


    public OrderController(Ordering.IService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<Ordering.Order> Get(Guid id)
    {
        var order = _service.Get(id);

        if (order == null)
            return BadRequest($"No Order with ID '{id}' registered.");

        return Ok(order);
    }

    [HttpGet("all")]
    public IEnumerable<Ordering.Order> GetAll()
    {
        return _service.GetAll();
    }

    [HttpPut("update")]
    public IActionResult Update(Ordering.Order order)
    {
        var result = _service.Update(order);

        if (!result)
            return BadRequest($"No Order with ID '{order?.Id}' registered.");

        return Ok();
    }

    [HttpPut("add")]
    public IActionResult Add(Ordering.Order order)
    {
        var result = _service.Add(order);

        if (!result)
            return BadRequest($"An Order with ID '{order?.Id}' already exists.");

        return Ok();
    }
}