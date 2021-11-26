using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProject4Driver
{
    public static class Distributions
    {
        private static Random rando = new Random();
        public static int Poisson(double expectedValue)
        {
            double dLimit = -expectedValue;
            double dSum = Math.Log(rando.NextDouble());

            int Count;
            for(Count = 0; dSum > dLimit; Count++)
            {
                dSum += Math.Log(rando.NextDouble());
            }
            return Count;
        }
        public static double NegativeExponential(double ExpectedValue)
        {
            return -ExpectedValue * Math.Log(rando.NextDouble(), Math.E);
        }
    }
}
