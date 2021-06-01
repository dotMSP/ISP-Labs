using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Car : Vehicle, IComparable<Car>
    {
        protected string brand;
        protected string model;
        protected double fuelConsumption, fuelCapacity;
        protected int topSpeed;
        protected double engineSize;
        protected int seatNumber;
        protected int power;
        protected string licensePlate;
        protected double currentFuel;
        protected double mileage;


        public Car(string brand, string model, double length, double width, double height, double fuelConsumption, double fuelCapacity, double engineSize, double topSpeed, int seatNumber, int power, string licensePlate)
        {
            this.brand = brand;
            this.model = model;
            this.size.length = length;
            this.size.width = width;
            this.size.height = height;
            this.fuelConsumption = fuelConsumption;
            this.fuelCapacity = fuelCapacity;
            this.topSpeed = (int)topSpeed;
            this.seatNumber = seatNumber;
            this.power = power;
            this.engineSize = engineSize;
            this.licensePlate = licensePlate;
            this.currentFuel = fuelCapacity;
            this.mileage = 0;
        }

        public virtual void ViewInfo()
        {
            Console.WriteLine("\nCar brand: ", brand);
            Console.WriteLine("\nCar model: ", model);
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

        public virtual void Drive()
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

        public virtual void Refuel()
        {
            double getFuel;
            Console.WriteLine("\nThe tank currently holds ", this.currentFuel, " L of fuel");
            Console.WriteLine("\nHow much fuel do you want to get (in L)?");
            while (!double.TryParse(Console.ReadLine(), out getFuel) || (this.currentFuel + getFuel > fuelCapacity))
            {
                Console.WriteLine("The tank can't fit this much fuel, retry");
            }
            this.currentFuel += getFuel;
        }
        public virtual void Carbon()
        {
            double carbonRate = 0;
            if (this.engineSize <= 2.5) carbonRate = 0.11;
            if (this.engineSize > 2.5) carbonRate = 0.183;
            double carbonEmissions = mileage * carbonRate;
            Console.WriteLine("\nSo far your car has produced ", carbonEmissions, " kg of CO2");
        }

        public int CompareTo(Car other)
        {
            if (topSpeed == other.topSpeed)
            {
                if (power > other.power) return 1;
                else if (power < other.power) return -1;
                return 0;
            }
            return topSpeed - other.topSpeed;
        }
    }
}
