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
            switch (carClass)
            {
                case 1: currentCar = new DieselCar(brand, model, length, width, height, fuelConsumption, fuelCapacity, engineSize, topSpeed, seatNumber, power, licensePlate); break;
                case 2: currentCar = new RegularCar(brand, model, length, width, height, fuelConsumption, fuelCapacity, engineSize, topSpeed, seatNumber, power, licensePlate); break;
                case 3: currentCar = new ElectricCar(brand, model, length, width, height, fuelConsumption, fuelCapacity, engineSize, topSpeed, seatNumber, power, licensePlate); break;
                default: currentCar = new Car(brand, model, length, width, height, fuelConsumption, fuelCapacity, engineSize, topSpeed, seatNumber, power, licensePlate); break;
            }

            currentCar.RefuelCompleted += currentCar_RefuelCompleted;

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
        public static void currentCar_RefuelCompleted()
        {
            Console.WriteLine("Refueled!");
        }
    }
}