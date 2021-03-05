using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the equation: ");
            string equation = Console.ReadLine();
            int a = 1;
            int b = 1;
            int c = 0;
            int tempI = 0;
            double D, x1, x2, x3, x4;
            double t1 = 0;
            double t2 = 0;
            string tempString = "";
            if (equation[0] == '-') {
                tempString = "-";
                tempI = 1;
            }
            for (int i = tempI; i < equation.Length - 1; i++) {
                if (tempString == "" && i != 0) {
                    if (equation[i - 1] == '-') {
                        tempString = "-";
                    }
                }
                if (equation[i + 1] == '+' || equation[i + 1] == '-' || equation[i + 1] == '^' || equation[i + 1] == '=' || equation[i + 1] == '*') {
                    tempString = tempString + equation[i];
                    if (equation[i + 1] == '*') {
                        if (equation[i + 4] == '4')
                        {
                            a = Int32.Parse(tempString); 
                        }
                        else {
                            b = Int32.Parse(tempString);
                        }
                        tempString = "";
                        i = i + 5;
                    }
                    if (equation[i + 1] == '+' || equation[i + 1] == '-' || equation[i + 1] == '=') {
                        c = Int32.Parse(tempString);
                        tempString = "";
                        i = i + 1;
                    }
                } else
                {
                    tempString = tempString + equation[i];
                }
            }
            D = Math.Pow(b, 2) - 4 * a * c;
            if (D < 0)
            {
                Console.WriteLine("No solutions");
            }
            else {
                t1 = (- b + Math.Sqrt(D)) / 2 * a;
                t2 = (- b - Math.Sqrt(D)) / 2 * a;
                Console.WriteLine("Solutions: ");
                if (t1 > 0)
                {
                    x1 = Math.Sqrt(t1) / 2;
                    x2 = - Math.Sqrt(t1) / 2;
                    Console.WriteLine(x1.ToString() + ' ' + x2.ToString());
                }
                if (t2 > 0)
                {
                    x3 = Math.Sqrt(t2) / 2;
                    x4 = - Math.Sqrt(t2) / 2;
                    Console.WriteLine(x3.ToString() + ' ' + x4.ToString());
                }
            }
        }
    }
}
