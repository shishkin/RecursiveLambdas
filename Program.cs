using System;
using System.Linq;

namespace RecursiveLambdas
{
    public static class LambdaEx
    {
        public static Func<TResult> Recursive<TResult>(Func<Func<TResult>, Func<TResult>> f)
        {
            return () => f(Recursive(f))();
        }

        public static Func<T, TResult> Recursive<T, TResult>(Func<Func<T, TResult>, Func<T, TResult>> f)
        {
            return x => f(Recursive(f))(x);
        }

        public static Func<T1, T2, TResult> Recursive<T1, T2, TResult>(Func<Func<T1, T2, TResult>, Func<T1, T2, TResult>> f)
        {
            return (arg1, arg2) => f(Recursive(f))(arg1, arg2);
        }

        // And so on...
    }

    internal class Program
    {

        private static void Main()
        {
            var factorial = LambdaEx.Recursive<int, int>(
                self => x => x == 0 ? 1 : x*self(x - 1));

            for (var i = 0; i < 12; i++)
            {
                Console.WriteLine(factorial(i));
            }
        }
    }
}