///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4
//	File Name:         Node.cs
//	Description:       YOUR DESCRIPTION HERE
//	Course:            CSCI 2210 - Data Structures	
//	Authors:           Kayleigh Post - postke@etsu.edu, Joshua Trimm - trimmj@etsu.edu, Isaac Simmons - simmonsi@etsu.edu
//	Created:           11/27/2021
//	Copyright:         Kayleigh Post, Joshua Trimm, Isaac Simmons, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace PriorityQueue
{
    using System;

    /// <summary>
    /// Defines the <see cref="Node{T}" />.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public class Node<T> where T : IComparable
    {
        /// <summary>
        /// Gets or sets the Item.
        /// </summary>
        public T Item { get; set; }

        /// <summary>
        /// Gets or sets the Next.
        /// </summary>
        public Node<T> Next { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="value">The value<see cref="T"/>.</param>
        /// <param name="link">The link<see cref="Node{T}"/>.</param>
        public Node(T value, Node<T> link)
        {
            Item = value;
            Next = link;
        }
    }
}
