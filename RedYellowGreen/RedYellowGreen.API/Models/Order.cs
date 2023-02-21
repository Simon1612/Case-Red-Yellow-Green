namespace RedYellowGreen.API.Models;

public class Order
{
    public Guid OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderedBy { get; set; }
    public string OrderDescription { get; set; }
}