using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;

namespace EDriveRent.Models;

public class Route : IRoute
{
    //Fields
    private string startPoint;
    private string endPoint;
    private double length;
    private int routeId;
    private bool isLocked;

    //Constructor
    public Route(string startPoint, string endPoint, double length, int routeId)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        this.length = length;
        this.routeId = routeId;
        this.isLocked = false;
    }

    //Properties
    public string StartPoint
    {
        get => startPoint;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.StartPointNull);
            }
        }
    }

    public string EndPoint
    {
        get => endPoint;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.EndPointNull);
            }
        }
    }

    public double Length
    {
        get => length;
        private set
        {
            if (value < 1)
            {
                throw new ArgumentException(ExceptionMessages.RouteLengthLessThanOne);
            }
        }
    }

    public int RouteId { get => routeId; private set => routeId = value; }

    public bool IsLocked { get => isLocked; private set => isLocked = value; }

    //Methods
    public void LockRoute()
    {
        isLocked = true;
    }
}