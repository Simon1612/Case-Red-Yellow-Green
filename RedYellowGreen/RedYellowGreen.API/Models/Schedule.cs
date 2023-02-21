using System.Collections.Immutable;

namespace RedYellowGreen.API.Models;

public class Schedule
{
    public string MachineId { get; set; }
    public ImmutableList<Models.Order> Orders { get; set; }
}