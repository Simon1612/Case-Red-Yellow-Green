namespace RedYellowGreen.API.Ordering;

public record Order
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string? OrderedBy { get; set; }
    public string? Description { get; set; }
}