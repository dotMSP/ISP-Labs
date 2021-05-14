﻿using System;

namespace Lab3
{
    class Vehicle
    {
        protected string sizeClass;
    }
    class Car : Vehicle
    {
        protected string brand;
        protected string model;
        protected double length, width, height;
        protected double fuelConsumption, fuelCapacity;
        protected double topSpeed;
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
            this.length = length;
            this.width = width;
            this.height = height;
            this.fuelConsumption = fuelConsumption;
            this.fuelCapacity = fuelCapacity;
            this.topSpeed = topSpeed;
            this.seatNumber = seatNumber;
            this.power = power;
            this.engineSize = engineSize;
            this.licensePlate = licensePlate;
            this.currentFuel = fuelCapacity;
            this.mileage = 0;
        }

        public void ViewInfo()
        {
            Console.WriteLine("\nCar brand: ", brand);
            Console.WriteLine("\nCar model: ", model);
            Console.WriteLine("\nCar length: ", length);
            Console.WriteLine("\nCar width: ", width);
            Console.WriteLine("\nCar height: ", height);
            Console.WriteLine("\nCar fuel consumption: ", fuelConsumption);
            Console.WriteLine("\nCar fuel capacity: ", fuelCapacity);
            Console.WriteLine("\nCar top speed: ", topSpeed);
            Console.WriteLine("\nCar seats: ", seatNumber);
            Console.WriteLine("\nCar power: ", power);
            Console.WriteLine("\nCar license number: ", licensePlate);
            Console.WriteLine("\nCar mileage: ", mileage);
        }

        public void Drive()
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

        public void Refuel()
        {
            double getFuel;
            Console.WriteLine("\nThe tank currently holds ", this.currentFuel, " L of fuel");
            Console.WriteLine("\nHow much fuel do you want to get (in L)?");
            while (!double.TryParse(Console.ReadLine(), out getFuel) || (this.currentFuel + getFuel > fuelCapacity))
            {
                Console.WriteLine("The tank can't fit this much fuel fuel, retry");
            }
            this.currentFuel += getFuel;
        }
        public void Carbon()
        {
            double carbonRate = 0;
            if (this.engineSize <= 2.5) carbonRate = 0.11;
            if (this.engineSize > 2.5) carbonRate = 0.183;
            double carbonEmissions = mileage * carbonRate;
            Console.WriteLine("\nSo far your car has produced ", carbonEmissions, " kg of CO2");
        }
    }

    


    class Program
    {
        static void Main()
        {
            int input, power, seatNumber;
            double length, width, height, fuelConsumption, fuelCapacity, topSpeed, engineSize;
            string brand, model, licensePlate;
            Console.WriteLine("Before starting, you must register your car, fill in the appropriate information");
            Console.WriteLine("\nCar brand: ");
            brand = Console.ReadLine();
            Console.WriteLine("\nCar model: ");
            model = Console.ReadLine();
            Console.WriteLine("\nCar license number: ");
            licensePlate = Console.ReadLine();
            while ((licensePlate.Length < 4 || licensePlate.Length > 8))
            {
                Console.WriteLine("Incorrect input, retry");
                licensePlate = Console.ReadLine();
            }
            Console.WriteLine("\nCar length (in cm): ");
            while ((!double.TryParse(Console.ReadLine(), out length) || length < 200 || length > 1000))
            {
                Console.WriteLine("Incorrect input, retry");
            }
            Console.WriteLine("\nCar width (in cm): ");
            while ((!double.TryParse(Console.ReadLine(), out width) || width < 100 || width > 500))
            {
                Console.WriteLine("Incorrect input, retry");
            }
            Console.WriteLine("\nCar height (in cm): ");
            while ((!double.TryParse(Console.ReadLine(), out height) || height < 70 || height > 400))
            {
                Console.WriteLine("Incorrect input, retry");
            }
            Console.WriteLine("\nCar fuel consumption (in L/100km): ");
            while ((!double.TryParse(Console.ReadLine(), out fuelConsumption) || fuelConsumption <= 1 || fuelConsumption > 20))
            {
                Console.WriteLine("Incorrect input, retry");
            }
            Console.WriteLine("\nCar engine size (in L): ");
            while ((!double.TryParse(Console.ReadLine(), out engineSize) || engineSize < 1 || engineSize > 4))
            {
                Console.WriteLine("Incorrect input, retry");
            }
            Console.WriteLine("\nCar top speed (in km/h): ");
            while ((!double.TryParse(Console.ReadLine(), out topSpeed) || topSpeed < 30 || topSpeed > 350))
            {
                Console.WriteLine("Incorrect input, retry");
            }
            Console.WriteLine("\nCar fuel capacity (in L): ");
            while ((!double.TryParse(Console.ReadLine(), out fuelCapacity) || fuelCapacity < 20 || fuelCapacity > 300))
            {
                Console.WriteLine("Incorrect input, retry");
            }
            Console.WriteLine("\nCar power (in HP): ");
            while ((!int.TryParse(Console.ReadLine(), out power) || power < 100 || power > 1000))
            {
                Console.WriteLine("Incorrect input, retry");
            }
            Console.WriteLine("\nCar seats: ");
            while ((!int.TryParse(Console.ReadLine(), out seatNumber) || seatNumber < 1 || seatNumber > 10))
            {
                Console.WriteLine("Incorrect input, retry");
            }
            Car CurrentCar = new Car(brand, model, length, width, height, fuelConsumption, fuelCapacity, engineSize, topSpeed, seatNumber, power, licensePlate);
            Console.WriteLine("\nCar registration complete!");

            Console.WriteLine("\n1. View car info\n2. Drive\n3. Refuel\n4. Calculate your carbon footprint");
            while ((!int.TryParse(Console.ReadLine(), out input) || input <= 0 || input > 5))
            {
                Console.WriteLine("Incorrect input, retry");
            }
            switch (input) {
                case 1: CurrentCar.ViewInfo(); break;
                case 2: CurrentCar.Drive(); break;
                case 3: CurrentCar.Refuel(); break;
                case 4: CurrentCar.Carbon(); break;
            }
        }
    }
}
