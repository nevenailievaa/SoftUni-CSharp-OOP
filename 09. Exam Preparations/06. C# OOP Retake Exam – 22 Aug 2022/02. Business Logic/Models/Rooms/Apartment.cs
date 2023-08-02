using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Rooms;

public class Apartment : Room
{
    //Fields
    private const int defaultBedCapacity = 6;

    //Constructor
    public Apartment() : base(defaultBedCapacity) { }
}
