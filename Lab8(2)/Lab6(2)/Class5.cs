using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    sealed class ElectricCar : Car
    {
        public ElectricCar(string brand, string model, double length, double width, double height, double fuelConsumption, double fuelCapacity, double engineSize, double topSpeed, int seatNumber, int power, string licensePlate) :
            base(brand, model, length, width, height, fuelConsumption, fuelCapacity, engineSize, topSpeed, seatNumber, power, licensePlate)
        {

        }
        public override void Drive()
        {
            double travelDist;
            Console.WriteLine("\nHow far do you need to travel (in km)?");
            while (!double.TryParse(Console.ReadLine(), out travelDist) || travelDist < 0.1 || (travelDist / 100 * this.fuelConsumption > this.currentFuel))
            {
                Console.WriteLine("Incorrect input or you don't have enough fuel, retry");
            }
            this.currentFuel -= travelDist * this.fuelConsumption;
            this.mileage += travelDist;
        }
        public override void Refuel()
        {
            double getFuel;
            Console.WriteLine("\nThe accumulator currently holds ", this.currentFuel, " kWh of energy");
            Console.WriteLine("\nHow much energy do you want to get (in kWh)?");
            while (!double.TryParse(Console.ReadLine(), out getFuel) || (this.currentFuel + getFuel > fuelCapacity))
            {
                Console.WriteLine("The accumulator can't fit this much energy, retry");
            }
            this.currentFuel += getFuel;
            OnRefuelCompleted();
        }

        public override void ViewInfo()
        {
            Console.WriteLine("\nCar brand: ", brand);
            Console.WriteLine("\nCar model: ", model);
            Console.WriteLine("\nCar type: ", (CarType)2);
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

        public override void Carbon()
        {
            Console.WriteLine("\nYou have produced no CO2 emissions because you have an electrocar.");
        }
    }
}
