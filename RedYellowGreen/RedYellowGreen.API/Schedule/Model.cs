using System.Collections.Immutable;

namespace RedYellowGreen.API.Schedule;

public record Model
{
    public string MachineId { get; set; }
    public ImmutableList<Order.Model> Orders { get; set; }
}