using System;

namespace OOP_Lab2
{
    internal class MyFrac
    {
        private long nom;
        private long denom;

        public long Nom
        {
            get { return nom; }
            set { nom = value; Normalize(); }
        }

        public long Denom
        {
            get { return denom; }
            set
            {
                if (value == 0) throw new ArgumentException("Знаменник не може бути 0");
                denom = value;
                Normalize();
            }
        }

        public MyFrac(long nom, long denom)
        {
            if (denom == 0) throw new ArgumentException("Знаменник не може бути 0");
            this.nom = nom;
            this.denom = denom;
            Normalize();
        }

        private void Normalize()
        {
            long gcd = GCD(Math.Abs(nom), Math.Abs(denom));
            nom /= gcd;
            denom /= gcd;

            if (denom < 0)
            {
                nom = -nom;
                denom = -denom;
            }
        }

        private static long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public string ToStringWithIntPart()
        {
            long integerPart = nom / denom;
            long remainder = nom % denom;

            if (remainder == 0) return integerPart.ToString();
            if (integerPart == 0) return remainder + "/" + denom;
            return "(" + integerPart + " + " + remainder + "/" + denom + ")";
        }

        public double ToDouble()
        {
            return (double)nom / denom;
        }

        public MyFrac Add(MyFrac other)
        {
            return new MyFrac(nom * other.denom + denom * other.nom, denom * other.denom);
        }

        public MyFrac Subtract(MyFrac other)
        {
            return new MyFrac(nom * other.denom - denom * other.nom, denom * other.denom);
        }

        public MyFrac Multiply(MyFrac other)
        {
            return new MyFrac(nom * other.nom, denom * other.denom);
        }

        public MyFrac Divide(MyFrac other)
        {
            if (other.nom == 0) throw new DivideByZeroException();
            return new MyFrac(nom * other.denom, denom * other.nom);
        }

        public static MyFrac CalcExpr1(int n)
        {
            MyFrac sum = new MyFrac(0, 1);
            for (int i = 1; i <= n; i++)
            {
                sum = sum.Add(new MyFrac(1, i * (i + 1)));
            }
            return sum;
        }

        public static MyFrac CalcExpr2(int n)
        {
            MyFrac product = new MyFrac(1, 1);
            for (int i = 2; i <= n; i++)
            {
                product = product.Multiply(new MyFrac((i - 1) * (i + 1), i * i));
            }
            return product;
        }

        public static void PrintOperations(MyFrac f1, MyFrac f2, int n)
        {
            Console.WriteLine("Перший дріб: " + f1);
            Console.WriteLine("Другий дріб: " + f2);
            Console.WriteLine("Додавання: " + f1.Add(f2));
            Console.WriteLine("Віднімання: " + f1.Subtract(f2));
            Console.WriteLine("Множення: " + f1.Multiply(f2));
            Console.WriteLine("Ділення: " + f1.Divide(f2));
            Console.WriteLine("CalcExpr1(" + n + ") = " + MyFrac.CalcExpr1(n));
            Console.WriteLine("CalcExpr2(" + n + ") = " + MyFrac.CalcExpr2(n));
        }
        public override string ToString()
        {
            return nom + "/" + denom;
        }
    }
}
