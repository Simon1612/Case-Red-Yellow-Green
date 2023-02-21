namespace RedYellowGreen.API.Models;

public class MachineState
{
    public string MachineId { get; set; }
    public State CurrentState { get; set; }
    public Guid CurrentOrderId { get; set; }
}

public enum State
{
    Red,
    Yellow,
    Green
}