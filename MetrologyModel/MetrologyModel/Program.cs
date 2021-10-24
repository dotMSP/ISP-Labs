using System;
using System.IO;

namespace MetrologyModel
{
    class Program
    {
        static void Main(string[] args)
        {
            int amtUnsuccessful, amtTotal, amtErrorTypes, input;
            float successChance;
            float sum = 0;
            string[] errorTypes = System.IO.File.ReadAllLines(@"C:\Users\andre\source\repos\MetrologyModel\ErrorTypes.txt");
            double[] errorTypeChances = new double[errorTypes.Length];
            int[] errorTypeOccurences = new int[errorTypes.Length];
            Random random = new Random();
            for (int i = 0; i < errorTypes.Length; i++)
            {
                errorTypeChances[i] = random.NextDouble();
            }            
            Console.WriteLine("\n1. Run the test with semi-random data, 2. Use custom exception types and data");
            while (!int.TryParse(Console.ReadLine(), out input) || (input != 1 && input != 2))
            {
                Console.WriteLine("Incorrect input, retry");
            }
            switch (input) {
                case 1:
                    {
                        Console.WriteLine("\nAmount of times ran: ");
                        while (!int.TryParse(Console.ReadLine(), out amtTotal) || amtTotal <= 0)
                        {
                            Console.WriteLine("Incorrect input, retry");
                        }
                        Console.WriteLine("\nAmount of times ran with an exception: ");
                        while (!int.TryParse(Console.ReadLine(), out amtUnsuccessful) || (amtUnsuccessful <= 0 || amtUnsuccessful > amtTotal))
                        {
                            Console.WriteLine("Incorrect input, retry");
                        }
                        amtErrorTypes = errorTypes.Length;
                        int currentIter = 0;
                        for (int i = 0; i < errorTypes.Length; i++)
                        {
                            errorTypeOccurences[i] = random.Next(0, amtUnsuccessful - currentIter);
                            currentIter += errorTypeOccurences[i];
                        }
                        for (int i = 0; i < amtErrorTypes; i++) {
                            sum += (float)errorTypeChances[i] * ((float)errorTypeOccurences[i] - 1) / (float)amtTotal;                           
                        }
                        successChance = ((float)amtUnsuccessful / (float)amtTotal) + sum;
                        Console.WriteLine("\nResulting success chance = " + successChance);
                        break;
                    }                                   
 
                
                
                
                
                case 2:
                    {
                        Console.WriteLine("\nAmount of custom exception types to add: ");
                        while (!int.TryParse(Console.ReadLine(), out input) || input <= 0)
                        {
                            Console.WriteLine("Incorrect input, retry");
                        }
                        string[] errorTypesCustom = new String[input];
                        for (int i = 0; i < input; i++)
                        {
                            Console.WriteLine("\nCustom exception type ", i + 1);
                            errorTypesCustom[i] = Console.ReadLine();
                            Console.WriteLine("\nCustom exception type chance (0 - 100) ", i + 1);
                            while (!double.TryParse(Console.ReadLine(), out errorTypeChances[i]) || (errorTypeChances[i] < 0 || errorTypeChances[i] > 100))
                            {
                                Console.WriteLine("Incorrect input, retry");
                            }
                        }
                        StreamWriter sw = new StreamWriter(@"C:\Users\andre\source\repos\MetrologyModel\ErrorTypes.txt");
                        for (int i = 0; i < input; i++)
                        {
                            sw.WriteLine(errorTypesCustom[i]);
                        }
                        sw.Close();
                        Console.WriteLine("\nAmount of times ran: ");
                        while (!int.TryParse(Console.ReadLine(), out amtTotal) || amtTotal <= 0)
                        {
                            Console.WriteLine("Incorrect input, retry");
                        }
                        Console.WriteLine("\nAmount of times ran with an exception: ");
                        while (!int.TryParse(Console.ReadLine(), out amtUnsuccessful) || (amtUnsuccessful <= 0 || amtUnsuccessful > amtTotal))
                        {
                            Console.WriteLine("Incorrect input, retry");
                        }
                        amtErrorTypes = errorTypes.Length;
                        for (int i = 0; i < amtErrorTypes; i++)
                        {
                            sum += (float)errorTypeChances[i] * ((float)errorTypeOccurences[i] - 1) / (float)amtTotal;
                        }
                        successChance = ((float)amtUnsuccessful / (float)amtTotal) + sum;
                        Console.WriteLine("\nResulting success chance = " + successChance);
                        break;
                    }                    
            }            
        }
    }
}
