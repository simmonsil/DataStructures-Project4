///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4
//	File Name:         Customer.cs
//	Description:       YOUR DESCRIPTION HERE
//	Course:            CSCI 2210 - Data Structures	
//	Authors:           Kayleigh Post - postke@etsu.edu, Joshua Trimm - trimmj@etsu.edu, Isaac Simmons - simmonsi@etsu.edu
//	Created:           11/27/2021
//	Copyright:         Kayleigh Post, Joshua Trimm, Isaac Simmons, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace DSProject4Driver
{
    using PriorityQueue;
    using System;

    /// <summary>
    /// Defines the <see cref="Customer" />.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets the EnterEvent.
        /// </summary>
        public Evnt EnterEvent { get; set; } = null;

        /// <summary>
        /// Gets or sets the LeavingEvent.
        /// </summary>
        public Evnt LeavingEvent { get; set; } = null;

        /// <summary>
        /// Gets or sets the StayInterval.
        /// </summary>
        public TimeSpan StayInterval { get; set; }

        /// <summary>
        /// Gets or sets the CustomerId.
        /// </summary>
        public int CustomerId { get; set; }
    }
}
