using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecursiveLambdas
{
    class Program
    {
        public delegate T Self<T>(Self<T> self);

        public static readonly Self<Func<Func<Func<int, int>, Func<int, int>>, Func<int, int>>> Y
            = y => f => x => f(y(y)(f))(x);

        public static readonly Func<Func<Func<int, int>, Func<int, int>>, Func<int, int>> Fix
            = Y(Y);

        static void Main(string[] args)
        {
            var factorial = Fix(fac => x => x == 0 ? 1 : x * fac(x - 1));

            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine(factorial(i));
            }
        }
    }
}
