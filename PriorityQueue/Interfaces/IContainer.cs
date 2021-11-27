///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4
//	File Name:         IContainer.cs
//	Description:       YOUR DESCRIPTION HERE
//	Course:            CSCI 2210 - Data Structures	
//	Authors:           Kayleigh Post - postke@etsu.edu, Joshua Trimm - trimmj@etsu.edu, Isaac Simmons - simmonsi@etsu.edu
//	Created:           11/27/2021
//	Copyright:         Kayleigh Post, Joshua Trimm, Isaac Simmons, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace PriorityQueue.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IContainer{T}" />.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public interface IContainer<T>
    {
        //Remove all objects from the container
        /// <summary>
        /// The Clear.
        /// </summary>
        void Clear();

        //Returns true if container is empty
        /// <summary>
        /// The IsEmpty.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        bool IsEmpty();

        //Returns the number of entries in the container
        /// <summary>
        /// Gets or sets the Count.
        /// </summary>
        int Count { get; set; }
    }
}
