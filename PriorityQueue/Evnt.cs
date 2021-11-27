﻿///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4
//	File Name:         Evnt.cs
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
    /// Defines the EVENTTYPE.
    /// </summary>
    public enum EVENTTYPE
    { /// <summary>
      /// Defines the ENTER.
      /// </summary>
        ENTER,
        /// <summary>
        /// Defines the LEAVE.
        /// </summary>
        LEAVE
    }

    /// <summary>
    /// Defines the <see cref="Evnt" />.
    /// </summary>
    public class Evnt : IComparable
    {
        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        public EVENTTYPE Type { get; set; }

        /// <summary>
        /// Gets or sets the Time.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the Patron.
        /// </summary>
        public int Patron { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Evnt"/> class.
        /// </summary>
        public Evnt()
        {
            Type = EVENTTYPE.ENTER;
            Time = DateTime.Now;
            Patron = -1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Evnt"/> class.
        /// </summary>
        /// <param name="type">The type<see cref="EVENTTYPE"/>.</param>
        /// <param name="time">The time<see cref="DateTime"/>.</param>
        /// <param name="patron">The patron<see cref="int"/>.</param>
        public Evnt(EVENTTYPE type, DateTime time, int patron)
        {
            Type = type;
            Time = time;
            Patron = patron;
        }

        /// <summary>
        /// The ToString.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public override string ToString()
        {
            String str = "";

            str += String.Format("Patron {0}", Patron.ToString().PadLeft(3));
            str += Type + "'s";
            str += String.Format(" at {0}", Time.ToShortTimeString().PadLeft(8));

            return str;
        }

        /// <summary>
        /// The CompareTo.
        /// </summary>
        /// <param name="obj">The obj<see cref="Object"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int CompareTo(Object obj)
        {
            if (!(obj is Evnt))
                throw new ArgumentException("The argument is not an event object.");

            Evnt e = (Evnt)obj;
            return (e.Time.CompareTo(Time));
        }
    }
}
