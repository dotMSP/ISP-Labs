using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    sealed class RegularCar : Car
    {
        public RegularCar(string brand, string model, double length, double width, double height, double fuelConsumption, double fuelCapacity, double engineSize, double topSpeed, int seatNumber, int power, string licensePlate) :
            base(brand, model, length, width, height, fuelConsumption, fuelCapacity, engineSize, topSpeed, seatNumber, power, licensePlate)
        {

        }
        public override void Refuel()
        {
            double getFuel;
            Console.WriteLine("\nThe tank currently holds ", this.currentFuel, " L of petroleum fuel");
            Console.WriteLine("\nHow much fuel do you want to get (in L)?");
            while (!double.TryParse(Console.ReadLine(), out getFuel) || (this.currentFuel + getFuel > fuelCapacity))
            {
                Console.WriteLine("The tank can't fit this much fuel, retry");
            }
            this.currentFuel += getFuel;
        }

        public override void ViewInfo()
        {
            Console.WriteLine("\nCar brand: ", brand);
            Console.WriteLine("\nCar model: ", model);
            Console.WriteLine("\nCar type: ", (CarType)1);
            Console.WriteLine("\nCar length: ", size.length);
            Console.WriteLine("\nCar width: ", size.width);
            Console.WriteLine("\nCar height: ", size.height);
            Console.WriteLine("\nCar fuel consumption: ", fuelConsumption);
            Console.WriteLine("\nCar fuel capacity: ", fuelCapacity);
            Console.WriteLine("\nCar top speed: ", topSpeed);
            Console.WriteLine("\nCar seats: ", seatNumber);
            Console.WriteLine("\nCar power: ", power);
            Console.WriteLine("\nCar license number: ", licensePlate);
            Console.WriteLine("\nCar mileage: ", mileage);
        }
    }
}
