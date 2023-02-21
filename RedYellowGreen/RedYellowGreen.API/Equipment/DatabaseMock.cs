namespace RedYellowGreen.API.Equipment;

public static class DatabaseMock
{
    private static readonly List<Equipment.State > States = new()
    {
            new Equipment.State { EquipmentId = "1", CurrentState = CurrentState.Green, CurrentOrderId = Guid.Parse("7efb0c59-20b1-418c-b45d-9c6f50ca6938")},
            new Equipment.State { EquipmentId = "2", CurrentState = CurrentState.Yellow, CurrentOrderId = Guid.Parse("078922f2-f139-4626-9b90-7fe7ae8165ae")},
            new Equipment.State { EquipmentId = "3", CurrentState = CurrentState.Red, CurrentOrderId = Guid.Parse("5dbc9716-6ed5-479e-be62-94c44002caa7")}
    };

    private static readonly List<Equipment.Event> Events = new()
    {
            new Equipment.Event { State = States[0], Date = DateTime.UtcNow.AddMinutes(-10), ChangedBy = "Worker Henriette" },
            new Equipment.Event { State = States[1], Date = DateTime.UtcNow.AddMinutes(-5), ChangedBy = "Worker Poul" },
            new Equipment.Event { State = States[2], Date = DateTime.UtcNow.AddMinutes(-2), ChangedBy = "Worker Ramtin" }
    };

    public static Equipment.State? GetState(string equipmentId) => States.FirstOrDefault(x => x.EquipmentId == equipmentId);

    public static IEnumerable<Equipment.Event> GetEvents(string equipmentId) => Events.FindAll(x => x.State?.EquipmentId == equipmentId);

    public static IEnumerable<Equipment.State > GetAllStates() => States;

    public static IEnumerable<Equipment.Event> GetAllEvents() => Events;

    public static bool Update(Equipment.State state)
    {
        var obj = States.FirstOrDefault(x => x.EquipmentId == state.EquipmentId);

        if (obj == null)
            return false;
        
        obj.CurrentOrderId = state.CurrentOrderId;
        obj.CurrentState = state.CurrentState;
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
}