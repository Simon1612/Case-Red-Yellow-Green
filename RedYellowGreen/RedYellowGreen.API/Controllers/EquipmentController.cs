using Microsoft.AspNetCore.Mvc;

namespace RedYellowGreen.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EquipmentController : ControllerBase
{
    private readonly Equipment.IService _equipmentService;

    public EquipmentController(Equipment.IService equipmentService)
    {
        _equipmentService = equipmentService;
    }

    [HttpGet]
    public ActionResult<Equipment.State> GetState(string equipmentId)
    {
        var state = _equipmentService.GetState(equipmentId);

        if (state == null)
            return BadRequest($"No Equipment with ID '{equipmentId}' registered.");

        return Ok(state);
    }

    [HttpGet("events")]
    public IEnumerable<Equipment.Event> GetEvents(string equipmentId)
    {
        return _equipmentService.GetEvents(equipmentId);
    }

    [HttpGet("all")]
    public IEnumerable<Equipment.State> GetAllStates()
    {
        return _equipmentService.GetAllStates();
    }

    [HttpGet("events/all")]
    public IEnumerable<Equipment.Event> GetAllEvents()
    {
        return _equipmentService.GetAllEvents();
    }

    [HttpPut]
    public IActionResult Update(Equipment.State state)
    {
        var result = _equipmentService.Update(state, "SomeWorkerIdReceivedThroughAuth");

        if (!result)
            return BadRequest($"No Equipment with ID '{state?.EquipmentId}' registered.");

        return Ok();
    }
}