using System;
using System.Linq;

namespace RecursiveLambdas
{
    internal class Program
    {
        public static Func<T, T> Fix<T>(Func<Func<T, T>, Func<T, T>> f)
        {
            return x => f(Fix(f))(x);
        }

        private static void Main()
        {
            var factorial = Fix<int>(self => x => x == 0 ? 1 : x*self(x - 1));

            for (var i = 0; i < 12; i++)
            {
                Console.WriteLine(factorial(i));
            }
        }
    }
}