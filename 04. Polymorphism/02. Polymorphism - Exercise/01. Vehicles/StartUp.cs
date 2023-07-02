using Vehicles;

//Input
string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

double carFuelQuantity = double.Parse(carInfo[1]);
double carFuelConsumption = double.Parse(carInfo[2]);
Car car = new Car(carFuelQuantity, carFuelConsumption);

double truckFuelQuantity = double.Parse(truckInfo[1]);
double truckFuelConsumption = double.Parse(truckInfo[2]);
Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption);

int commandsCount = int.Parse(Console.ReadLine());

//Action
for (int i = 0; i < commandsCount; i++)
{
    string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    //Car
    if (command[1] == "Car")
    {
        //Drive
        if (command[0] == "Drive")
        {
            Console.WriteLine(car.Drive(double.Parse(command[2])));
        }
        //Refuel
        else if (command[0] == "Refuel")
        {
            car.Refuel(double.Parse(command[2]));
        }
    }

    //Truck
    else if (command[1] == "Truck")
    {
        //Drive
        if (command[0] == "Drive")
        {
            Console.WriteLine(truck.Drive(double.Parse(command[2])));
        }
        //Refuel
        else if (command[0] == "Refuel")
        {
            truck.Refuel(double.Parse(command[2]));
        }
    }
}

//Output
Console.WriteLine($"Car: {car.FuelQuantity:f2}");
Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");