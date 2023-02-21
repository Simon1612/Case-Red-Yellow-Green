namespace RedYellowGreen.API.Equipment;

public interface IService
{
    Equipment.State? GetState(string equipmentId);
    IEnumerable<Equipment.Event> GetEvents(string equipmentId);
    IEnumerable<Equipment.State> GetAllStates();
    IEnumerable<Equipment.Event> GetAllEvents();
    bool Update(Equipment.State state, string changedBy);
    bool Add(Equipment.State state);
}

public class Service : IService
{
    private readonly IRepository _repository;
    public Service(IRepository repository)
    {
        _repository = repository;
    }

    public Equipment.State? GetState(string equipmentId)
    {
        return _repository.GetState(equipmentId);
    }

    public IEnumerable<Equipment.Event> GetEvents(string equipmentId)
    {
        return _repository.GetEvents(equipmentId);
    }

    public IEnumerable<Equipment.State> GetAllStates()
    {
        return _repository.GetAllStates();
    }

    public IEnumerable<Equipment.Event> GetAllEvents()
    {
        return _repository.GetAllEvents();
    }

    public bool Update(Equipment.State state, string changedBy)
    {
        var stateResult = _repository.Update(state);

        if(!stateResult)
            return false;

        _repository.Add(new Event { State = state, Date = DateTime.UtcNow, ChangedBy = changedBy });

        return stateResult;
    }

    public bool Add(Equipment.State state)
    {
        return _repository.Add(state);
    }
}