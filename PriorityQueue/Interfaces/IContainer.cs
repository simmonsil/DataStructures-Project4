///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4
//	File Name:         IContainer.cs
//	Description:       The IContainer interface, providing functionality to the Priority Queue. This code was pulled from Dr. Bailes slides.
//	Course:            CSCI 2210 - Data Structures	
//	Authors:           Kayleigh Post - postke@etsu.edu, Joshua Trimm - trimmj@etsu.edu, Isaac Simmons - simmonsi@etsu.edu
//	Created:           11/27/2021
//	Copyright:         Kayleigh Post, Joshua Trimm, Isaac Simmons, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace PriorityQueue.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IContainer{T}" /> interface.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public interface IContainer<T>
    {
        /// <summary>
        /// The Clear. Remove all objects from the container.
        /// </summary>
        void Clear();

        /// <summary>
        /// The IsEmpty boolean. Returns true if container is empty.
        /// </summary>
        /// <returns>The IsEmpty <see cref="bool"/>.</returns>
        bool IsEmpty();

        /// <summary>
        /// Gets or sets the Count. Returns the number of entries in the container.
        /// </summary>
        int Count { get; set; }
    }
}
