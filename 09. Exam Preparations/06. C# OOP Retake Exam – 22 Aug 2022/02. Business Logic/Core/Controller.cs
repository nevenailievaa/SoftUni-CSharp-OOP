using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Core;

public class Controller : IController
{
    //Fields
    private HotelRepository hotels;

    //Constructor
    public Controller()
    {
        hotels = new HotelRepository();
    }

    //Methods
    public string AddHotel(string hotelName, int category)
    {
        //Hotel With That Name Already Exists
        if (hotels.Select(hotelName) != null)
        {
            return OutputMessages.HotelAlreadyRegistered;
        }

        //Creating And Adding Hotel
        Hotel currentHotel = new Hotel(hotelName, category);

        hotels.AddNew(currentHotel);
        return String.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
    }

    public string BookAvailableRoom(int adults, int children, int duration, int category)
    {
        var orderedHotels = hotels.All().OrderBy(h => h.FullName);
        int bedsNeeded = adults + children;

        bool hotelOfThatCategoryIsFound = false;

        foreach (var hotel in orderedHotels)
        {
            if (hotel.Category == category)
            {
                hotelOfThatCategoryIsFound = true;

                foreach (var room in hotel.Rooms.All().Where(r => r.PricePerNight > 0).OrderBy(r => r.BedCapacity))
                {
                    //Successfull Booking
                    if (room.BedCapacity >= bedsNeeded)
                    {
                        Booking currentBooking =
                            new Booking(room, duration, adults, children, hotel.Bookings.All().Count +1);
                        hotel.Bookings.AddNew(currentBooking);

                        return String.Format(OutputMessages.BookingSuccessful, currentBooking.BookingNumber, hotel.FullName);
                    }
                }
            }
        }

        //Hotel Of That Category Isn't Found
        if (!hotelOfThatCategoryIsFound)
        {
            return String.Format(OutputMessages.CategoryInvalid, category);
        }

        //Room With Enough Beds Isn't Found
        return OutputMessages.RoomNotAppropriate;
    }

    public string HotelReport(string hotelName)
    {
        //No Hotel With That Name
        if (!hotels.All().Any(h => h.FullName == hotelName))
        {
            return String.Format(OutputMessages.HotelNameInvalid, hotelName);
        }

        //Giving Info
        IHotel currentHotel = hotels.All().FirstOrDefault(h => h.FullName == hotelName);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Hotel name: {hotelName}");
        sb.AppendLine($"--{currentHotel.Category} star hotel");
        sb.AppendLine($"--Turnover: {currentHotel.Turnover:f2} $");
        sb.AppendLine($"--Bookings:");
        sb.AppendLine();

        if (!currentHotel.Bookings.All().Any())
        {
            sb.AppendLine("none");
        }
        else
        {
            foreach (var booking in currentHotel.Bookings.All())
            {
                sb.AppendLine(booking.BookingSummary());
                sb.AppendLine();
            }
        }

        return sb.ToString().TrimEnd();
    }

    public string SetRoomPrices(string hotelName, string roomTypeName, double price)
    {
        //Hotel With That Name Doesn't Exist
        if (hotels.Select(hotelName) == null)
        {
            return String.Format(OutputMessages.HotelNameInvalid, hotelName);
        }

        //Not A Correct Room Type
        if (roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Apartment) && roomTypeName != nameof(Studio))
        {
            throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
        }

        //Room Type Not Created Yet
        IHotel currentHotel = hotels.Select(hotelName);

        if (currentHotel.Rooms.Select(roomTypeName) == null)
        {
            return OutputMessages.RoomTypeNotCreated;
        }

        //Room Price Already Set
        IRoom currentRoom = currentHotel.Rooms.Select(roomTypeName);

        if (currentRoom.PricePerNight > 0)
        {
            throw new InvalidOperationException(ExceptionMessages.CannotResetInitialPrice);
        }

        //Setting Price
        currentRoom.SetPrice(price);
        return String.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
    }

    public string UploadRoomTypes(string hotelName, string roomTypeName)
    {
        //Hotel With That Name Doesn't Exist
        if (hotels.Select(hotelName) == null)
        {
            return String.Format(OutputMessages.HotelNameInvalid, hotelName);
        }

        //The Given Type Is Already Created
        IHotel hotel = hotels.Select(hotelName);
        if (hotel.Rooms.Select(roomTypeName) != default)
        {
            return OutputMessages.RoomTypeAlreadyCreated;
        }

        //Not A Correct Room Type
        if (roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Apartment) && roomTypeName != nameof(Studio))
        {
            throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
        }

        //Creating A Room
        IRoom room;

        if (roomTypeName == nameof(DoubleBed))
        {
            room = new DoubleBed();
        }
        else if(roomTypeName == nameof(Apartment))
        {
            room = new Apartment();
        }
        else
        {
            room = new Studio();
        }

        hotel.Rooms.AddNew(room);
        return String.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
    }
}