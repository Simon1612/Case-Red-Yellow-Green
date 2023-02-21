namespace RedYellowGreen.API.Scheduling;

public interface IRepository
{
    Scheduling.Schedule? Get(string equipmentId);
    IEnumerable<Scheduling.Schedule> GetAll();
    bool Update(Scheduling.Schedule schedule);
    bool Add(Scheduling.Schedule schedule);
}

public class Repository : IRepository
{
    public Scheduling.Schedule? Get(string equipmentId) => DatabaseMock.GetSchedule(equipmentId);

    public IEnumerable<Scheduling.Schedule> GetAll() => DatabaseMock.GetAllSchedules();

    public bool Update(Scheduling.Schedule schedule) => DatabaseMock.Update(schedule);

    public bool Add(Scheduling.Schedule schedule) => DatabaseMock.Add(schedule);
}