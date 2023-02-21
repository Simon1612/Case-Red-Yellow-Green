namespace RedYellowGreen.API.Equipment;

public interface IRepository
{
    Equipment.State? GetState(string equipmentId);
    IEnumerable<Equipment.Event> GetEvents(string equipmentId);
    IEnumerable<Equipment.State> GetAllStates();
    IEnumerable<Equipment.Event> GetAllEvents();
    bool Update(Equipment.State state);
    bool Add(Equipment.State state);
    void Add(Equipment.Event stateEvent);
}

public class Repository : IRepository
{
    public Equipment.State? GetState(string equipmentId) => DatabaseMock.GetState(equipmentId);

    public IEnumerable<Equipment.Event> GetEvents(string equipmentId) => DatabaseMock.GetEvents(equipmentId);

    public IEnumerable<Equipment.State> GetAllStates() => DatabaseMock.GetAllStates();

    public IEnumerable<Equipment.Event> GetAllEvents() => DatabaseMock.GetAllEvents();

    public bool Update(Equipment.State state) => DatabaseMock.Update(state);

    public bool Add(Equipment.State state) => DatabaseMock.Add(state);

    public void Add(Equipment.Event stateEvent) => DatabaseMock.Add(stateEvent);
}