///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4
//	File Name:         IPriorityQueue.cs
//	Description:       IPriorityQueue interface that implements a priority queue. This code was pulled from Dr. Bailes slides.
//	Course:            CSCI 2210 - Data Structures	
//	Authors:           Kayleigh Post - postke@etsu.edu, Joshua Trimm - trimmj@etsu.edu, Isaac Simmons - simmonsi@etsu.edu
//	Created:           11/27/2021
//	Copyright:         Kayleigh Post, Joshua Trimm, Isaac Simmons, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace PriorityQueue.Interfaces
{
    using System;

    /// <summary>
    /// Defines the IPriorityQueue interface
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public interface IPriorityQueue<T> : IContainer<T> where T : IComparable
    {
        // Inserts item based on its priority
        /// <summary>
        /// Required enqueue method to enqueue something into the queue
        /// </summary>
        /// <param name="item">The item<see cref="T"/>.</param>
        void Enqueue(T item);

        /// <summary>
        /// Required dequeue method to dequeue something from the queue
        /// </summary>
        void Dequeue();

        /// <summary>
        /// Required peek method to see what is next in the queue
        /// </summary>
        /// <returns>The <see cref="T"/>.</returns>
        T Peek();
    }
}
