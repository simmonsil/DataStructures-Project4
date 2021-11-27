///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4
//	File Name:         IPriorityQueue.cs
//	Description:       YOUR DESCRIPTION HERE
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
    /// Defines the <see cref="IPriorityQueue{T}" />.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public interface IPriorityQueue<T> : IContainer<T> where T : IComparable
    {
        // Inserts item based on its priority
        /// <summary>
        /// The Enqueue.
        /// </summary>
        /// <param name="item">The item<see cref="T"/>.</param>
        void Enqueue(T item);

        /// <summary>
        /// The Dequeue.
        /// </summary>
        void Dequeue();

        /// <summary>
        /// The Peek.
        /// </summary>
        /// <returns>The <see cref="T"/>.</returns>
        T Peek();
    }
}
