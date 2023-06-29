namespace ClassBoxData;

public class Box
{
    //Fields
    private const string PropertyValueExceptionMessage = "{0} cannot be zero or negative.";
    private double length;
    private double width;
    private double height;

    //Constructor
    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    //Properties
    public double Length
    {
        get => length;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException(String.Format(PropertyValueExceptionMessage, nameof(Length)));
            }
            else
            {
                length = value;
            }
        }
    }
    public double Width
    {
        get => width;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException(String.Format(PropertyValueExceptionMessage, nameof(Width)));
            }
            else
            {
                width = value;
            }
        }
    }
    public double Height
    {
        get => height;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException(String.Format(PropertyValueExceptionMessage, nameof(Height)));
            }
            else
            {
                height  = value;
            }
        }
    }

    //Methods
    public double SurfaceArea() => (2 * Length * Width) + (2 * Length * Height) + (2 * Width * height);
    public double LeteralSurfaceArea() => (2 * Length * Height) + (2 * Width * Height);
    public double Volume() => length * width * height;
}
