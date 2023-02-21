using Microsoft.AspNetCore.Mvc;

namespace RedYellowGreen.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EquipmentController : ControllerBase
{
    private readonly Equipment.IService _service;

    public EquipmentController(Equipment.IService service)
    {
        _service = service;
    }

    [HttpGet("state")]
    public ActionResult<Equipment.State> GetState(string equipmentId)
    {
        var state = _service.GetState(equipmentId);

        if (state == null)
            return BadRequest($"No Equipment with ID '{equipmentId}' registered.");

        return Ok(state);
    }

    [HttpGet("events")]
    public IEnumerable<Equipment.Event> GetEvents(string equipmentId)
    {
        return _service.GetEvents(equipmentId);
    }

    [HttpGet("state/all")]
    public IEnumerable<Equipment.State> GetAllStates()
    {
        return _service.GetAllStates();
    }

    [HttpGet("events/all")]
    public IEnumerable<Equipment.Event> GetAllEvents()
    {
        return _service.GetAllEvents();
    }

    [HttpPut("state/update")]
    public IActionResult Update(Equipment.State state)
    {
        var result = _service.Update(state, "SomeWorkerIdReceivedThroughAuth");

        if (!result)
            return BadRequest($"No Equipment with ID '{state?.EquipmentId}' registered.");

        return Ok();
    }
}