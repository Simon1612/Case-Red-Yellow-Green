namespace RedYellowGreen.API.Scheduling;

public interface IService
{
    Scheduling.Schedule? Get(string equipmentId);
    IEnumerable<Scheduling.Schedule> GetAll();
    bool Update(Scheduling.Schedule schedule);
    bool Add(Scheduling.Schedule schedule);
}

public class Service : IService
{
    private readonly Scheduling.IRepository _repository; // Alternatively get the schedules from somewhere else e.g. another API
    public Service(Scheduling.IRepository repository)
    {
        _repository = repository;
    }

    public Scheduling.Schedule? Get(string equipmentId)
    {
        return _repository.Get(equipmentId);
    }

    public IEnumerable<Scheduling.Schedule> GetAll()
    {
        return _repository.GetAll();
    }

    public bool Update(Scheduling.Schedule schedule)
    {
        return _repository.Update(schedule);

        // Possible event history.
    }

    public bool Add(Scheduling.Schedule schedule)
    {
        return _repository.Add(schedule);

        // Possible event history.
    }
}