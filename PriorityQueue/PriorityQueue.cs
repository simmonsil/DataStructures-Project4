///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4
//	File Name:         PriorityQueue.cs
//	Description:       YOUR DESCRIPTION HERE
//	Course:            CSCI 2210 - Data Structures	
//	Authors:           Kayleigh Post - postke@etsu.edu, Joshua Trimm - trimmj@etsu.edu, Isaac Simmons - simmonsi@etsu.edu
//	Created:           11/27/2021
//	Copyright:         Kayleigh Post, Joshua Trimm, Isaac Simmons, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace PriorityQueue
{
    using PriorityQueue.Interfaces;
    using System;

    /// <summary>
    /// Defines the <see cref="PriorityQueue{T}" />.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable
    {
        /// <summary>
        /// Defines the top.
        /// </summary>
        private Node<T> top;

        /// <summary>
        /// Gets or sets the Count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The Clear.
        /// </summary>
        public void Clear()
        {
            top = null;     //Nodes will be garbage collected
            Count = 0;      //Count is now 0 since PQ is empty
        }

        /// <summary>
        /// The Dequeue.
        /// </summary>
        public void Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot remove from empty queue.");
            }
            else
            {
                Node<T> oldNode = top;
                top = top.Next;
                Count--;
                oldNode = null;     //Do this so the node can be garbage collected
            }
        }

        /// <summary>
        /// The Enqueue.
        /// </summary>
        /// <param name="item">The item<see cref="T"/>.</param>
        public void Enqueue(T item)
        {
            if (Count == 0)
            {
                top = new Node<T>(item, null);
            }
            else
            {
                Node<T> current = top;
                Node<T> previous = null;

                while (current != null && current.Item.CompareTo(item) >= 0)
                {
                    previous = current;
                    current = current.Next;
                }

                Node<T> newNode = new Node<T>(item, current);

                if (previous != null)
                {
                    previous.Next = newNode;
                }
                else
                {
                    top = newNode;
                }

            }
            Count++;
        }

        /// <summary>
        /// The IsEmpty.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }

        /// <summary>
        /// The Peek.
        /// </summary>
        /// <returns>The <see cref="T"/>.</returns>
        public T Peek()
        {
            if (!IsEmpty())
            {
                return top.Item;
            }
            else
            {
                throw new InvalidOperationException("Cannot obtain top of empty priority queue.");
            }
        }
    }
}
