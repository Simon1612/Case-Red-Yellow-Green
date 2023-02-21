namespace RedYellowGreen.API.Scheduling;

public interface IRepository
{
    Scheduling.Schedule Get(string machineId);
}

public class Repository : IRepository
{
    public Repository()
    {
    }

    public Scheduling.Schedule Get(string machineId)
    {
        // Get the current state of specified machine from database

        return new Scheduling.Schedule() { };
    }
}