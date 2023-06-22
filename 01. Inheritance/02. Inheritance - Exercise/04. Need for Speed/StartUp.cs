namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar sportCar = new SportCar(300, 100);
            RaceMotorcycle raceMotorCycle = new RaceMotorcycle(150, 100);
            Car car = new Car(100, 100);

            sportCar.Drive(10);
            raceMotorCycle.Drive(10);
            car.Drive(10);

            Console.WriteLine($"Sport Car remaining fuel: {sportCar.Fuel}");
            Console.WriteLine($"Race Motorcycle remaining fuel: {raceMotorCycle.Fuel}");
            Console.WriteLine($"Car remaining fuel: {car.Fuel}");
        }
    }
}
