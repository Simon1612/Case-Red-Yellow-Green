namespace RedYellowGreen.API;

public static class DatabaseMock
{
    private static readonly List<Ordering.Order> Orders = new()
    {
        new Ordering.Order { Id = Guid.NewGuid(), Date = DateTime.UtcNow.AddMinutes(-10), Description = "Some description 1", OrderedBy = "Supervisor Glen" },
        new Ordering.Order { Id = Guid.NewGuid(), Date = DateTime.UtcNow.AddMinutes(-11), Description = "Some description 2", OrderedBy = "Supervisor Sarah" },
        new Ordering.Order { Id = Guid.NewGuid(), Date = DateTime.UtcNow.AddMinutes(-12), Description = "Some description 3", OrderedBy = "Supervisor Dorthe" },
        new Ordering.Order { Id = Guid.NewGuid(), Date = DateTime.UtcNow.AddMinutes(-20), Description = "Some description 4", OrderedBy = "Supervisor Glen" },
        new Ordering.Order { Id = Guid.NewGuid(), Date = DateTime.UtcNow.AddMinutes(-21), Description = "Some description 5", OrderedBy = "Supervisor Sarah" },
        new Ordering.Order { Id = Guid.NewGuid(), Date = DateTime.UtcNow.AddMinutes(-22), Description = "Some description 6", OrderedBy = "Supervisor Dorthe" },
        new Ordering.Order { Id = Guid.NewGuid(), Date = DateTime.UtcNow.AddMinutes(-30), Description = "Some description 7", OrderedBy = "Supervisor Glen" },
        new Ordering.Order { Id = Guid.NewGuid(), Date = DateTime.UtcNow.AddMinutes(-31), Description = "Some description 8", OrderedBy = "Supervisor Sarah" },
        new Ordering.Order { Id = Guid.NewGuid(), Date = DateTime.UtcNow.AddMinutes(-32), Description = "Some description 9", OrderedBy = "Supervisor Dorthe" }
    };

    private static readonly List<Equipment.State> States = new() // When using a real database, I would join with the Order table to get the CurrentOrder object
    {
        new Equipment.State { EquipmentId = "1", CurrentState = Equipment.CurrentState.Green, CurrentOrder = Orders[0]},
        new Equipment.State { EquipmentId = "2", CurrentState = Equipment.CurrentState.Yellow, CurrentOrder = Orders[1]},
        new Equipment.State { EquipmentId = "3", CurrentState = Equipment.CurrentState.Red, CurrentOrder = Orders[2]}
    };

    private static readonly List<Equipment.Event> Events = new()
    {
        new Equipment.Event { State = States[0], Date = DateTime.UtcNow.AddMinutes(-10), ChangedBy = "Worker Henriette" },
        new Equipment.Event { State = States[1], Date = DateTime.UtcNow.AddMinutes(-5), ChangedBy = "Worker Poul" },
        new Equipment.Event { State = States[2], Date = DateTime.UtcNow.AddMinutes(-2), ChangedBy = "Worker Ramtin" }
    };

    private static readonly List<Scheduling.Schedule> Schedules = new() // Same idea as with States
    {
        new Scheduling.Schedule { EquipmentId = "1", ScheduledOrders = new List<Ordering.Order>{ Orders[0], Orders[3], Orders[6] } },
        new Scheduling.Schedule { EquipmentId = "2", ScheduledOrders = new List<Ordering.Order>{ Orders[1], Orders[4], Orders[7] } },
        new Scheduling.Schedule { EquipmentId = "3", ScheduledOrders = new List<Ordering.Order>{ Orders[2], Orders[5], Orders[8] } }
    };

    public static Equipment.State? GetState(string equipmentId) => States.FirstOrDefault(x => x.EquipmentId == equipmentId);

    public static IEnumerable<Equipment.Event> GetEvents(string equipmentId) => Events.FindAll(x => x.State?.EquipmentId == equipmentId);

    public static Ordering.Order? GetOrder(Guid id) => Orders.FirstOrDefault(x => x.Id == id);

    public static Scheduling.Schedule? GetSchedule(string equipmentId) => Schedules.FirstOrDefault(x => x.EquipmentId == equipmentId);

    public static IEnumerable<Equipment.State> GetAllStates() => States;

    public static IEnumerable<Equipment.Event> GetAllEvents() => Events;

    public static IEnumerable<Ordering.Order> GetAllOrders() => Orders;

    public static IEnumerable<Scheduling.Schedule> GetAllSchedules() => Schedules;

    public static bool Update(Equipment.State state)
    {
        var obj = States.FirstOrDefault(x => x.EquipmentId == state.EquipmentId);

        if (obj == null)
            return false;

        obj.CurrentOrder = state.CurrentOrder;
        obj.CurrentState = state.CurrentState;
        return true;
    }

    public static bool Update(Ordering.Order order)
    {
        var obj = Orders.FirstOrDefault(x => x.Id == order.Id);

        if (obj == null)
            return false;

        obj.Date = order.Date;
        obj.Description = order.Description;
        obj.OrderedBy = order.OrderedBy;
        return true;
    }

    public static bool Update(Scheduling.Schedule schedule)
    {
        var obj = Schedules.FirstOrDefault(x => x.EquipmentId == schedule.EquipmentId);

        if (obj == null)
            return false;

        obj.ScheduledOrders = schedule.ScheduledOrders;
        return true;
    }

    public static bool Add(Equipment.State state)
    {
        var obj = States.FirstOrDefault(x => x.EquipmentId == state.EquipmentId);

        if (obj != null)
            return false;

        States.Add(state);
        return true;
    }

    public static void Add(Equipment.Event stateEvent) => Events.Add(stateEvent);

    public static bool Add(Ordering.Order order)
    {
        var obj = Orders.FirstOrDefault(x => x.Id == order.Id);

        if (obj != null)
            return false;

        Orders.Add(order);
        return true;
    }

    public static bool Add(Scheduling.Schedule schedule)
    {
        var obj = Schedules.FirstOrDefault(x => x.EquipmentId == schedule.EquipmentId);

        if (obj != null)
            return false;

        Schedules.Add(schedule);
        return true;
    }
}