namespace RedYellowGreen.API.Scheduling;

public record Schedule
{
    public string? EquipmentId { get; set; }
    public IEnumerable<Ordering.Order>? ScheduledOrders { get; set; }
}