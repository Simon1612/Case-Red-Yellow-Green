using Microsoft.AspNetCore.Mvc;

namespace RedYellowGreen.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly Scheduling.IService _service;

    public ScheduleController(Scheduling.IService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<Scheduling.Schedule> Get(string equipmentId)
    {
        var order = _service.Get(equipmentId);

        if (order == null)
            return BadRequest($"No Schedule Equipment ID '{equipmentId}' registered.");

        return Ok(order);
    }

    [HttpGet("all")]
    public IEnumerable<Scheduling.Schedule> GetAll()
    {
        return _service.GetAll();
    }

    [HttpPut("update")]
    public IActionResult Update(Scheduling.Schedule schedule)
    {
        var result = _service.Update(schedule);

        if (!result)
            return BadRequest($"No Schedule for Equipment ID '{schedule.EquipmentId}' registered.");

        return Ok();
    }

    [HttpPut("add")]
    public IActionResult Add(Scheduling.Schedule schedule)
    {
        var result = _service.Add(schedule);

        if (!result)
            return BadRequest($"A Schedule for Equipment ID '{schedule.EquipmentId}' already exists.");

        return Ok();
    }
}