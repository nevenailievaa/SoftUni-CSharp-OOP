﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Rooms;

public class DoubleBed : Room
{
    //Fields
    private const int defaultBedCapacity = 2;

    //Constructor
    public DoubleBed() : base(defaultBedCapacity) { }
}
