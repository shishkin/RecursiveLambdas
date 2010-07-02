using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecursiveLambdas
{
    class Program
    {
        public static Func<T, T> Fix<T>(Func<Func<T, T>, Func<T, T>> f)
        {
            return x => f(Fix(f))(x);
        }

        static void Main(string[] args)
        {
            var factorial = Fix<int>(fac => x => x == 0 ? 1 : x * fac(x - 1));

            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine(factorial(i));
            }
        }
    }
}
