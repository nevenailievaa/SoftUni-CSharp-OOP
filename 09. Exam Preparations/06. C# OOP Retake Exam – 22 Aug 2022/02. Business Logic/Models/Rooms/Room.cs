using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Rooms;

public abstract class Room : IRoom
{
    //Fields
    private int bedCapacity;
    private double pricePerNight;

    protected Room(int bedCapacity)
    {
        this.bedCapacity = bedCapacity;
        PricePerNight = 0;
    }

    //Properties
    public int BedCapacity => bedCapacity;

    public double PricePerNight
    {
        get => pricePerNight;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
            }
            pricePerNight = value;
        }
    }

    //Methods
    public void SetPrice(double price)
    {
        PricePerNight = price;
    }
}
