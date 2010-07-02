using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecursiveLambdas
{
    class Program
    {
        public delegate T Self<T>(Self<T> self);

        static void Main(string[] args)
        {

        }
    }
}
