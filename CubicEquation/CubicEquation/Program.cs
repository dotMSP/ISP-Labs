using System;

namespace CubicEquation
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, A, B, t;
            Console.WriteLine("a = ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("b = ");
            b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("c = ");
            c = Convert.ToDouble(Console.ReadLine());
            double Q = (Math.Pow(a, 2) - 3 * b) / 9;
            double R = (2 * Math.Pow(a, 3) - 9 * a * b + 27 * c) / 54;
            if (Math.Pow(R, 2) < Math.Pow(Q, 3)) {
                t = Math.Acos(R / Math.Sqrt(Math.Pow(Q, 3))) / 3;
                var x1 = -2 * Math.Sqrt(Q) * Math.Cos(t) - a / 3;
                var x2 = -2 * Math.Sqrt(Q) * Math.Cos(t + (2 * Math.PI / 3)) - a / 3;
                var x3 = -2 * Math.Sqrt(Q) * Math.Cos(t - (2 * Math.PI / 3)) - a / 3;
                Console.WriteLine("Solutions: " + x1 + ' ' + x2 + ' ' + x3);
            }
            if (Math.Pow(R, 2) >= Math.Pow(Q, 3)) {
                A = -Math.Sign(R) * Math.Pow(Math.Abs(R) + Math.Sqrt(Math.Pow(R, 2) - Math.Pow(Q, 3)), (1.0 / 3.0));
                if (A == 0)
                {
                    B = 0.0;
                }
                else {
                    B = Q / A;
                }
                var x1 = (A + B) - a / 3;
                var x2 = - (A + B) / 2 - (a / 3) + (System.Numerics.Complex.ImaginaryOne * Math.Sqrt(3) * (A - B) / 2);
                var x3 = - (A + B) / 2 - (a / 3) - (System.Numerics.Complex.ImaginaryOne * Math.Sqrt(3) * (A - B) / 2);
                if (A == B)
                {
                    x2 = - A - a / 3;
                }
                Console.WriteLine("Solutions: " + x1 + ' ' + x2 + ' ' + x3);
            }
        }
    }
}
