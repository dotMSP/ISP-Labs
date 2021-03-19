using System;

namespace ConsoleApp5
{
    class Program
    {
        static void PFind(double a, double b, double c, out double P) => P = a + b + c;
        static void SFind(double a, double b, double c, double P, out double S) => S = Math.Round(Math.Pow((P / 2) * ((P / 2) - a) * ((P / 2) - b) * ((P / 2) - c), 0.5), 2);
        static void RFind(double a, double b, double c, double P, double S, out double R) => R = Math.Round((a * b * c) / (4 * S), 2);
        static void rFind(double a, double b, double c, double P, double S, out double r) => r = Math.Round((2 * S) / (a + b + c), 2);
        static void hFind(double S, double a, double b, double c, out double h1, out double h2, out double h3)
        {
            double P = 0;
            PFind(a, b, c, out P);
            SFind(a, b, c, P, out S);
            h1 = 2 * S / a;
            h2 = 2 * S / b;
            h3 = 2 * S / c;
        }
        static void mFind(double a, double b, double c, out double m1, out double m2, out double m3)
        {
            m1 = 0.5 * (Math.Pow(((2 * Math.Pow(b, 2)) + (2 * Math.Pow(c, 2))) - Math.Pow(a, 2), 0.5));
            m2 = 0.5 * (Math.Pow(((2 * Math.Pow(a, 2)) + (2 * Math.Pow(c, 2))) - Math.Pow(b, 2), 0.5));
            m3 = 0.5 * (Math.Pow(((2 * Math.Pow(a, 2)) + (2 * Math.Pow(b, 2))) - Math.Pow(c, 2), 0.5));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("To find:\n1.Sides with 1 side and 2 angles\n2.Angles\n3.P\n4.S\n5.R\n6.r\n7.h\n8.m");
            int input = Convert.ToInt32(Console.ReadLine());
            double a, b, c, A, B, C, P = 0, S = 0, R = 0, r = 0, h1 = 0, h2 = 0, h3 = 0, m1 = 0, m2 = 0, m3 = 0;
            switch (input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Side length and 2 angle sizes: ");
                    c = Convert.ToDouble(Console.ReadLine());
                    A = Convert.ToDouble(Console.ReadLine()) * Math.PI / 180;
                    B = Convert.ToDouble(Console.ReadLine()) * Math.PI / 180;
                    C = Math.PI - (A + B);
                    a = Math.Round((c / Math.Sin(C)) * Math.Sin(A), 2);
                    b = Math.Round((c / Math.Sin(C)) * Math.Sin(B), 2);
                    Console.WriteLine("Sides = :\n" + a + b);
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Sides = :\n");
                    a = Convert.ToDouble(Console.ReadLine());
                    b = Convert.ToDouble(Console.ReadLine());
                    c = Convert.ToDouble(Console.ReadLine());
                    A = Math.Round(Math.Acos((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c)) * (180 / Math.PI), 2);
                    B = Math.Round(Math.Acos((Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c)) * (180 / Math.PI), 2);
                    C = Math.Round(Math.Acos((Math.Pow(b, 2) + Math.Pow(a, 2) - Math.Pow(c, 2)) / (2 * b * a)) * (180 / Math.PI), 2);
                    Console.WriteLine("a = " + a + " A = " + A + " \nb = " + b + " B = " + B + " \nc = " + c + " C = " + C + " \n");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Sides = ");
                    a = Convert.ToDouble(Console.ReadLine());
                    b = Convert.ToDouble(Console.ReadLine());
                    c = Convert.ToDouble(Console.ReadLine());
                    PFind(a, b, c, out P);
                    Console.WriteLine("P =  " + P);
                    Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Sides = ");
                    a = Convert.ToDouble(Console.ReadLine());
                    b = Convert.ToDouble(Console.ReadLine());
                    c = Convert.ToDouble(Console.ReadLine());
                    PFind(a, b, c, out P);
                    SFind(a, b, c, P, out S);
                    Console.WriteLine("S = " + S);
                    Console.ReadLine();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Sides = ");
                    a = Convert.ToDouble(Console.ReadLine());
                    b = Convert.ToDouble(Console.ReadLine());
                    c = Convert.ToDouble(Console.ReadLine());
                    PFind(a, b, c, out P);
                    SFind(a, b, c, P, out S);
                    RFind(a, b, c, P, S, out R);
                    Console.WriteLine("R = " + R);
                    Console.ReadLine();
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("Sides = ");
                    a = Convert.ToDouble(Console.ReadLine());
                    b = Convert.ToDouble(Console.ReadLine());
                    c = Convert.ToDouble(Console.ReadLine());
                    PFind(a, b, c, out P);
                    SFind(a, b, c, P, out S);
                    rFind(a, b, c, P, S, out r);
                    Console.WriteLine("r = " + r);
                    Console.ReadLine();
                    break;
                case 7:
                    Console.WriteLine("Sides = ");
                    a = Convert.ToDouble(Console.ReadLine());
                    b = Convert.ToDouble(Console.ReadLine());
                    c = Convert.ToDouble(Console.ReadLine());
                    PFind(a, b, c, out P);
                    SFind(a, b, c, P, out S);
                    hFind(S, a, b, c, out h1, out h2, out h3);
                    Console.WriteLine("Height to a = " + a + " = " + h1 + " \nheight to b = " + b + " = " + h2 + " \nheight to c = " + c + " = " + h3);
                    Console.ReadLine();
                    break;
                case 8:
                    Console.WriteLine("Sides = ");
                    a = Convert.ToDouble(Console.ReadLine());
                    b = Convert.ToDouble(Console.ReadLine());
                    c = Convert.ToDouble(Console.ReadLine());
                    mFind(a, b, c, out m1, out m2, out m3);
                    Console.WriteLine("Median to a = " + a + " = " + m1 + " \nMedian to b = " + b + " = " + m2 + " \nMedian to c = " + c + " = " + m3);
                    Console.ReadLine();
                    break;
            }
        }
    }
}

