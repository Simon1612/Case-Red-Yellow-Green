namespace RedYellowGreen.API.Order;

public record Model
{
    public Guid OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderedBy { get; set; }
    public string OrderDescription { get; set; }
}