namespace RedYellowGreen.API.Services;

public class Order
{
    private readonly ILogger _logger;

    public Order(ILogger logger)
    {
        _logger = logger;
    }
}