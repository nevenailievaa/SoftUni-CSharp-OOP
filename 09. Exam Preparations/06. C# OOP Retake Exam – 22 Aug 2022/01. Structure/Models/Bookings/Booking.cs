using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Bookings;

public class Booking : IBooking
{
    //Fields
    private IRoom room;
    private int residenceDuration;
    private int adultsCount;
    private int childrenCount;
    private int bookingNumber;

    //Constructor
    public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
    {
        this.room = room;
        ResidenceDuration = residenceDuration;
        AdultsCount = adultsCount;
        ChildrenCount = childrenCount;
        this.bookingNumber = bookingNumber;
    }

    //Properties
    public IRoom Room => room;

    public int ResidenceDuration
    {
        get => residenceDuration;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
            }
            residenceDuration = value;
        }
    }

    public int AdultsCount
    {
        get => adultsCount;
        private set
        {
            if (value < 1)
            {
                throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
            }
            adultsCount = value;
        }
    }

    public int ChildrenCount
    {
        get => childrenCount;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.ChildrenNegative);
            }
            childrenCount = value;
        }
    }

    public int BookingNumber => bookingNumber;

    //Methods
    public string BookingSummary()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Booking number: {BookingNumber}");
        sb.AppendLine($"Room type: {Room.GetType().Name}");
        sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
        sb.AppendLine($"Total amount paid: {Math.Round(ResidenceDuration * Room.PricePerNight, 2)}");

        return sb.ToString().TrimEnd();
    }
}