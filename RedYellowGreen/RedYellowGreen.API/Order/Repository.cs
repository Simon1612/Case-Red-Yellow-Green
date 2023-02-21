namespace RedYellowGreen.API.Order;

public interface IRepository
{
}

public class Repository : IRepository
{
    public Repository()
    {
    }

    public Order.Model Get(string machineId)
    {
        // Get the current state of specified machine from database

        return new Order.Model() { };
    }
}