namespace RedYellowGreen.API.Equipment;

public record State
{
    public string? EquipmentId { get; set; }
    public CurrentState CurrentState { get; set; }
    public Guid CurrentOrderId { get; set; }
}

public enum CurrentState
{
    Red,
    Yellow,
    Green
}