///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4
//	File Name:         Node.cs
//	Description:       Node that holds an individual item to be placed in the priority queue
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
    /// Defines the Node class
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public class Node<T> where T : IComparable
    {
        /// <summary>
        /// Gets or sets the Item in the node
        /// </summary>
        public T Item { get; set; }

        /// <summary>
        /// Gets or sets what is in the next node
        /// </summary>
        public Node<T> Next { get; set; }

        /// <summary>
        /// Initializes a new instance of the node with a passed in value and link
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
