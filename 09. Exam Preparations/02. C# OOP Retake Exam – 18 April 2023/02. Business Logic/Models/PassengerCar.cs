namespace EDriveRent.Models
{
    public class PassengerCar : Vehicle
    {
        //Fields
        private const double maxMileage = 450;

        //Constructor
        public PassengerCar(string brand, string model, string licensePlateNumber) : base(brand, model, maxMileage, licensePlateNumber) { }
    }
}
