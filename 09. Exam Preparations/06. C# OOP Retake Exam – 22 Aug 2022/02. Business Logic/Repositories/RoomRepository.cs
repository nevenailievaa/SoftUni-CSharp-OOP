using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories;

public class RoomRepository : IRepository<IRoom>
{
    //Fields
    private List<IRoom> rooms;

    //Constructor
    public RoomRepository()
    {
        rooms = new List<IRoom>();
    }

    //Methods
    public void AddNew(IRoom model) => rooms.Add(model);

    public IReadOnlyCollection<IRoom> All() => rooms;

    public IRoom Select(string criteria) => rooms.FirstOrDefault(r => r.GetType().Name == criteria);
}
