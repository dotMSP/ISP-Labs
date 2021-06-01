using System;

namespace Lab3
{

    struct Size
    {
        public double length;
        public double width;
        public double height;
    }

    enum CarType
    {
        Diesel,
        Petrol,
        Electric,
    }
    abstract class Vehicle
    {
        protected string sizeClass;
        protected Size size;
    }
    
    class Car : Vehicle
    {
        protected string brand;
        protected string model;
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
            this.size.length = length;
            this.size.width = width;
            this.size.height = height;
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
    }

    sealed class DieselCar : Car
    {
        public DieselCar(string brand, string model, double length, double width, double height, double fuelConsumption, double fuelCapacity, double engineSize, double topSpeed, int seatNumber, int power, string licensePlate) :
            base(brand, model, length, width, height, fuelConsumption, fuelCapacity, engineSize, topSpeed, seatNumber, power, licensePlate)
        {
            
        }
        public override void Refuel()
        {
            double getFuel;
            Console.WriteLine("\nThe tank currently holds ", this.currentFuel, " L of diesel fuel");
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
            Console.WriteLine("\nCar type: ", (CarType)0);
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





    class Program
    {
        static void Main()
        {
            int input, power, seatNumber, carClass;
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
            Console.WriteLine("\nCar fuel consumption (in L/100km or in kWh/100km if it's an electrocar): ");
            while ((!double.TryParse(Console.ReadLine(), out fuelConsumption) || fuelConsumption <= 1 || fuelConsumption > 100))
            {
                Console.WriteLine("Incorrect input, retry");
            }
            Console.WriteLine("\nCar engine size (in L) (if it's an electrocar, enter 1): ");
            while ((!double.TryParse(Console.ReadLine(), out engineSize) || engineSize < 1 || engineSize > 4))
            {
                Console.WriteLine("Incorrect input, retry");
            }
            Console.WriteLine("\nCar top speed (in km/h): ");
            while ((!double.TryParse(Console.ReadLine(), out topSpeed) || topSpeed < 30 || topSpeed > 350))
            {
                Console.WriteLine("Incorrect input, retry");
            }
            Console.WriteLine("\nCar fuel capacity (in L or in kWh if it's an electrocar): ");
            while ((!double.TryParse(Console.ReadLine(), out fuelCapacity) || fuelCapacity < 1 || fuelCapacity > 300))
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
            Console.WriteLine("\nType of fuel used: 1. Diesel fuel, 2. Petrol, 3. Electrocar");
            while ((!int.TryParse(Console.ReadLine(), out carClass) || carClass < 1 || carClass > 3))
            {
                Console.WriteLine("Incorrect input, retry");
            }
            Car currentCar;
            switch (carClass) {
                case 1: currentCar = new DieselCar(brand, model, length, width, height, fuelConsumption, fuelCapacity, engineSize, topSpeed, seatNumber, power, licensePlate); break;
                case 2: currentCar = new RegularCar(brand, model, length, width, height, fuelConsumption, fuelCapacity, engineSize, topSpeed, seatNumber, power, licensePlate); break;
                case 3: currentCar = new ElectricCar(brand, model, length, width, height, fuelConsumption, fuelCapacity, engineSize, topSpeed, seatNumber, power, licensePlate); break;
                default: currentCar = new Car(brand, model, length, width, height, fuelConsumption, fuelCapacity, engineSize, topSpeed, seatNumber, power, licensePlate); break;
            }
            
            Console.WriteLine("\nCar registration complete!");
            Console.WriteLine("\n1. View car info\n2. Drive\n3. Refuel\n4. Calculate your carbon footprint");
            while ((!int.TryParse(Console.ReadLine(), out input) || input <= 0 || input > 5))
            {
                Console.WriteLine("Incorrect input, retry");
            }
            switch (input)
            {
                case 1: currentCar.ViewInfo(); break;
                case 2: currentCar.Drive(); break;
                case 3: currentCar.Refuel(); break;
                case 4: currentCar.Carbon(); break;
            }
        }
    }
}