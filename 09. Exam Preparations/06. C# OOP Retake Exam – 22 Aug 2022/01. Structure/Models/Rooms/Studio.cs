using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Rooms;

public class Studio : Room
{
    //Fields
    private const int defaultBedCapacity = 4;

    //Constructor
    public Studio() : base(defaultBedCapacity) { }
}