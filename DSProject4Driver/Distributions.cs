///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4
//	File Name:         Distributions.cs
//	Description:       Contains random number distributions for generating number of customers and checkout duration.
//	Course:            CSCI 2210 - Data Structures	
//	Authors:           Kayleigh Post - postke@etsu.edu, Joshua Trimm - trimmj@etsu.edu, Isaac Simmons - simmonsi@etsu.edu
//	Created:           11/27/2021
//	Copyright:         Kayleigh Post, Joshua Trimm, Isaac Simmons, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace DSProject4Driver
{
    using System;

    /// <summary>
    /// Defines the <see cref="Distributions" /> used in the simulation.
    /// </summary>
    public static class Distributions
    {
        /// <summary>
        /// Defines the Random object.
        /// </summary>
        private static Random rando = new Random();

        /// <summary>
        /// The Poisson distribution. Gives a random number of customers based on user-expected number of customers.
        /// </summary>
        /// <param name="expectedValue">The expectedValue<see cref="double"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public static int Poisson(double expectedValue)
        {
            double dLimit = -expectedValue;
            double dSum = Math.Log(rando.NextDouble());

            int Count;
            for (Count = 0; dSum > dLimit; Count++)
            {
                dSum += Math.Log(rando.NextDouble());
            }
            return Count;
        }

        /// <summary>
        /// The NegativeExponential distribution. Gives the random checkout duration based on user expected duration.
        /// </summary>
        /// <param name="ExpectedValue">The ExpectedValue<see cref="double"/>.</param>
        /// <returns>The <see cref="double"/>.</returns>
        public static double NegativeExponential(double ExpectedValue)
        {
            return -ExpectedValue * Math.Log(rando.NextDouble(), Math.E);
        }
    }
}
