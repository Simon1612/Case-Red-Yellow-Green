namespace RedYellowGreen.API.Ordering;

public interface IRepository
{
    Ordering.Order? Get(Guid id);
    IEnumerable<Ordering.Order> GetAll();
    bool Update(Ordering.Order order);
    bool Add(Ordering.Order order);
}

public class Repository : IRepository
{
    public Ordering.Order? Get(Guid id) => DatabaseMock.GetOrder(id);

    public IEnumerable<Ordering.Order> GetAll() => DatabaseMock.GetAllOrders();

    public bool Update(Ordering.Order order) => DatabaseMock.Update(order);

    public bool Add(Ordering.Order order) => DatabaseMock.Add(order);
}