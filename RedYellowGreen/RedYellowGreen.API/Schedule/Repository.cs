namespace RedYellowGreen.API.Schedule;

public interface IRepository
{
    Schedule.Model Get(string machineId);
}

public class Repository : IRepository
{
    public Repository()
    {
    }

    public Schedule.Model Get(string machineId)
    {
        // Get the current state of specified machine from database

        return new Schedule.Model() { };
    }
}