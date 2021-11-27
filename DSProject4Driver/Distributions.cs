///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4
//	File Name:         Distributions.cs
//	Description:       YOUR DESCRIPTION HERE
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
    /// Defines the <see cref="Distributions" />.
    /// </summary>
    public static class Distributions
    {
        /// <summary>
        /// Defines the rando.
        /// </summary>
        private static Random rando = new Random();

        /// <summary>
        /// The Poisson.
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
        /// The NegativeExponential.
        /// </summary>
        /// <param name="ExpectedValue">The ExpectedValue<see cref="double"/>.</param>
        /// <returns>The <see cref="double"/>.</returns>
        public static double NegativeExponential(double ExpectedValue)
        {
            return -ExpectedValue * Math.Log(rando.NextDouble(), Math.E);
        }
    }
}
