namespace RedYellowGreen.API.Equipment;

public record Event
{
    public Equipment.State? State { get; set; }
    public DateTime Date { get; set; }
    public string? ChangedBy { get; set; } //Maybe not possible / needed?
}