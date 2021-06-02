using System;

namespace Lab7
{
    class Program
    {
        static void Main()
        {
            int input1, input2, input3, input4;
            string input5;
            Console.WriteLine("Numerator 1: ");
            while (!int.TryParse(Console.ReadLine(), out input1))
            {
                Console.WriteLine("Incorrect input, retry");
            }
            Console.WriteLine("Denominator 1: ");
            while (!int.TryParse(Console.ReadLine(), out input2) || input2 < 0)
            {
                Console.WriteLine("Incorrect input, retry");
            }
            Console.WriteLine("Numerator 2: ");
            while (!int.TryParse(Console.ReadLine(), out input3))
            {
                Console.WriteLine("Incorrect input, retry");
            }
            Console.WriteLine("Denominator 2: ");
            while (!int.TryParse(Console.ReadLine(), out input4) || input4 < 0)
            {
                Console.WriteLine("Incorrect input, retry");
            }
            RationalNumber a = new RationalNumber(input1, input2);
            RationalNumber b = new RationalNumber(input3, input4);
            RationalNumber n = a + b;
            Console.WriteLine("{a} + {b} = " + n);
            n = a - b;
            Console.WriteLine("{a} - {b} = " + n.ToString("."));
            n = a * b;
            Console.WriteLine("{a} * {b} = " + n);
            n = a / b;
            Console.WriteLine("{a} / {b} = " + n);
            Console.WriteLine("{a} > {b} - " + (a > b));
            Console.WriteLine("{a} < {b} - " + (a < b));
            Console.WriteLine("{a} == {b} - " + (a == b));
            Console.WriteLine("{a} != {b} - " + (a != b));
            Console.WriteLine("Enter a decimal to parse: ");
            input5 = Console.ReadLine();
            Console.WriteLine("Parse: " + RationalNumber.Parse(input5));
            n.Reduce();
            Console.WriteLine("Reduction: " + n);
            Console.WriteLine("{n} to int: " + (int)n);
            Console.WriteLine("{n} to double: " + (double)n);
        }
    }
}
