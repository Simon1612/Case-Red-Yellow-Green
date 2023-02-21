namespace RedYellowGreen.API.Ordering;

public interface IService
{
    Ordering.Order? Get(Guid id);
    IEnumerable<Ordering.Order> GetAll();
    bool Update(Ordering.Order state);
    bool Add(Ordering.Order state);
}

public class Service : IService
{
    private readonly Ordering.IRepository _repository; // Alternatively get the orders from somewhere else e.g. another API
    public Service(Ordering.IRepository repository)
    {
        _repository = repository;
    }

    public Ordering.Order? Get(Guid id)
    {
        return _repository.Get(id);
    }

    public IEnumerable<Ordering.Order> GetAll()
    {
        return _repository.GetAll();
    }

    public bool Update(Ordering.Order state)
    {
        return _repository.Update(state);

        // Possible event history.
    }

    public bool Add(Ordering.Order state)
    {
        return _repository.Add(state);

        // Possible event history.
    }
}