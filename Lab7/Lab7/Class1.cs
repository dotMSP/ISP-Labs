using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    class RationalNumber : IComparable<RationalNumber>
    {
        public int Numerator;
        public int Denominator;

        public RationalNumber(int num, int denom)
        {
            Numerator = num;
            Denominator = denom;
        }

        private static int GreatestCommonDivis(int a, int b)
        {
            int tmp;

            if (a < b)
            {
                tmp = a;
                a = b;
                b = tmp;
            }
            else if (a == b)
            {
                return a;
            }

            while (b > 0)
            {
                tmp = b;
                b = a % b;
                a = tmp;
            }

            return a;
        }

        private static int LeastCommonMult(int num, int den)
        {
            return num * den / GreatestCommonDivis(num, den);
        }
        public static RationalNumber operator +(RationalNumber num1, RationalNumber num2)
        {
            int leastCommonMult = LeastCommonMult(num1.Denominator, num2.Denominator);
            return new RationalNumber(num1.Numerator * leastCommonMult / num1.Denominator + num2.Numerator * leastCommonMult / num2.Denominator, leastCommonMult);
        }

        public static RationalNumber operator -(RationalNumber num1, RationalNumber num2)
        {
            int leastCommonMult = LeastCommonMult(num1.Denominator, num2.Denominator);
            return new RationalNumber(num1.Numerator * leastCommonMult / num1.Denominator - num2.Numerator * leastCommonMult / num2.Denominator, leastCommonMult);
        }

        public static RationalNumber operator *(RationalNumber num1, RationalNumber num2)
        {
            return new RationalNumber(num1.Numerator * num2.Numerator, num1.Denominator * num2.Denominator);
        }

        public static RationalNumber operator /(RationalNumber num1, RationalNumber num2)
        {
            if ((num1.Numerator > 0 && num2.Numerator > 0) || (num1.Numerator < 0 && num2.Numerator < 0))
            {
                return new RationalNumber(Math.Abs(num1.Numerator * num2.Denominator), Math.Abs(num1.Denominator * num2.Numerator));
            }
            else
            {
                return new RationalNumber(-Math.Abs(num1.Numerator * num2.Denominator), Math.Abs(num1.Denominator * num2.Numerator));
            }
        }

        public static bool operator >(RationalNumber num1, RationalNumber num2)
        {
            int leastCommonMult = LeastCommonMult(num1.Denominator, num2.Denominator);
            return num1.Numerator * leastCommonMult / num1.Denominator > num2.Numerator * leastCommonMult / num2.Denominator;
        }

        public static bool operator <(RationalNumber num1, RationalNumber num2)
        {
            int leastCommonMult = LeastCommonMult(num1.Denominator, num2.Denominator);
            return num1.Numerator * leastCommonMult / num1.Denominator < num2.Numerator * leastCommonMult / num2.Denominator;
        }

        public static bool operator ==(RationalNumber num1, RationalNumber num2)
        {
            int leastCommonMult = LeastCommonMult(num1.Denominator, num2.Denominator);
            return num1.Numerator * leastCommonMult / num1.Denominator == num2.Numerator * leastCommonMult / num2.Denominator;
        }

        public static bool operator !=(RationalNumber num1, RationalNumber num2)
        {
            int leastCommonMult = LeastCommonMult(num1.Denominator, num2.Denominator);
            return num1.Numerator * leastCommonMult / num1.Denominator != num2.Numerator * leastCommonMult / num2.Denominator;
        }

        public override string ToString() => Numerator.ToString() + "/" + Denominator.ToString();

        public string ToString(string format) => format == "." ? ((double)Numerator / Denominator).ToString() : "";

        public static RationalNumber Parse(string input)
        {
            if (input.Contains('/'))
            {
                string[] split = input.Split('/');
                return new RationalNumber(int.Parse(split[0]), int.Parse(split[1]));
            }
            else if (input.Contains('.'))
            {
                string[] split = input.Split('.');
                return new RationalNumber(int.Parse(split[0] + split[1]), (int)Math.Pow(10, split[1].Length));
            }
            else
            {
                return new RationalNumber(0, 1);
            }
        }

        public void Reduce()
        {
            int greatestCommonDivis = GreatestCommonDivis(Math.Abs(Numerator), Denominator);
            Numerator /= greatestCommonDivis;
            Denominator /= greatestCommonDivis;
        }

        public static implicit operator short(RationalNumber n) => (short)(n.Numerator / n.Denominator);

        public static implicit operator int(RationalNumber n) => n.Numerator / n.Denominator;

        public static implicit operator long(RationalNumber n) => n.Numerator / n.Denominator;

        public static implicit operator float(RationalNumber n) => (float)n.Numerator / n.Denominator;

        public static implicit operator double(RationalNumber n) => (double)n.Numerator / n.Denominator;

        public int CompareTo(RationalNumber other) => this == other ? 0 : (this > other ? 1 : -1);
    }
}
