namespace RedYellowGreen.API.Services;

public class MachineState
{
    private readonly ILogger _logger;
    public MachineState(ILogger logger)
    {
        _logger = logger;
    }
}