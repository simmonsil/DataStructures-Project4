///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4
//	File Name:         MenuHelper.cs
//	Description:       The MenuHelper displays the line simulation.
//	Course:            CSCI 2210 - Data Structures	
//	Authors:           Kayleigh Post - postke@etsu.edu, Joshua Trimm - trimmj@etsu.edu, Isaac Simmons - simmonsi@etsu.edu
//	Created:           11/27/2021
//	Copyright:         Kayleigh Post, Joshua Trimm, Isaac Simmons, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace DSProject1
{
    using DSProject4Driver;
    using PriorityQueue;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Windows;
    using System.Windows.Forms;
    using Menu = UtilityNamespace.Menu;
    using MessageBox = System.Windows.Forms.MessageBox;

    /// <summary>
    /// <see cref="MenuHelper" /> add functionality to Dr. Bailes MenuDemo package.
    /// </summary>
    public static class MenuHelper
    {
        #region Fields
        /// <summary>
        /// Defines the Menu.
        /// </summary>
        public static Menu Menu;

        /// <summary>
        /// Defines the Priority Queue of Events.
        /// </summary>
        public static PriorityQueue<Evnt> PriorityQueue = new PriorityQueue<Evnt>();

        /// <summary>
        /// Defines the time that the store opens.
        /// </summary>
        public static DateTime OpeningTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 8, 0, 0);

        /// <summary>
        /// Defines the number of registers.
        /// </summary>
        private static int NumberOfRegisters;

        /// <summary>
        /// Defines the expected time spent in checkout.
        /// </summary>
        private static double ServiceTime;

        /// <summary>
        /// Defines the total number of hours that the store is open.
        /// </summary>
        private static int HoursOfOperation;

        /// <summary>
        /// Defines the NumberOfCustomers.
        /// </summary>
        private static int NumberOfCustomers;

        /// <summary>
        /// Defines the rando.
        /// </summary>
        private static Random rando = new Random();

        /// <summary>
        /// Defines the shortest time spent in checkout.
        /// </summary>
        private static TimeSpan shortest;

        /// <summary>
        /// Defines the longest time spent in checkout.
        /// </summary>
        private static TimeSpan longest;

        /// <summary>
        /// Defines the average time spent in checkout.
        /// </summary>
        private static TimeSpan average;

        /// <summary>
        /// Defines the totalTime.
        /// </summary>
        private static TimeSpan totalTime;

        /// <summary>
        /// Defines the CustomerHolder.
        /// </summary>
        private static List<Customer> CustomerHolder = new List<Customer>();

        /// <summary>
        /// Defines the Registers.
        /// </summary>
        private static List<Queue<Customer>> Registers = new List<Queue<Customer>>();

        /// <summary>
        /// Defines the longestLine.
        /// </summary>
        private static int longestLine;

        /// <summary>
        /// Defines the processedEvents.
        /// </summary>
        private static int processedEvents;

        /// <summary>
        /// Defines the arrivals.
        /// </summary>
        private static int arrivals;

        /// <summary>
        /// Defines the departures.
        /// </summary>
        private static int departures;
        #endregion

        #region Setup
        /// <summary>
        /// The Setup is used to set define how the console will look and prompt the user with a welcome message. It will also define what the menu items will say.
        /// </summary>
        public static void Setup()
        {
            // Set the color of the console
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();

            // Instantiate Dr. Bailes Menu class.
            Menu menu = new Menu("Simulation Menu");

            // Add items to the menu
            menu = menu + "Set the number of Customers" + "Set the number of hours of operation" + "Set the number of Registers" + "Set the expected checkout duration" + "Run the simulation" + "End the program";

            // Set the menu to a global variable. 
            Menu = menu;
        }

        /// <summary>
        /// The MenuChoice monitors the users menu selection.
        /// </summary>
        /// <param name="choiceNumber">The choiceNumber<see cref="int"/>.</param>
        public static void MenuChoice(int choiceNumber)
        {

            // While loop pulled from Dr. Bailes MenuDemoDriver
            while (choiceNumber != 6)
            {
                // check what option the user chose
                switch (choiceNumber)
                {
                    case 1: // Set the number of Customers
                        Console.Write("How many Customers are expected to be served in a day?  ");
                        var numbOfReg = Console.ReadLine();

                        var parsed = Int32.TryParse(numbOfReg, out NumberOfCustomers);

                        if (!parsed)
                        {
                            MessageBox.Show($"{DateTime.Now}\nPlease only use a numeric value.", $"User Input Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            Console.WriteLine("\nNumber of customers expected set successfully!");
                            PressAnyKey();
                        }

                        break;

                    case 2: // Set the number of hours of operation
                        Console.Write("How many hours will the store be open?  ");

                        var numbOfHours = Console.ReadLine();

                        var parsedInt = Int32.TryParse(numbOfHours, out HoursOfOperation);

                        if (!parsedInt)
                        {
                            MessageBox.Show($"{DateTime.Now}\nPlease only use a numeric value.", $"User Input Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            Console.WriteLine("\nStore hours set successfully!");
                            PressAnyKey();
                        }

                        break;

                    case 3: // Set the number of lines
                        Console.Write("How many checkout lines will be simulated?  ");

                        var numbOfWindows = Console.ReadLine();

                        var parsedIntWin = Int32.TryParse(numbOfWindows, out NumberOfRegisters);

                        if (!parsedIntWin)
                        {
                            MessageBox.Show($"{DateTime.Now}\nPlease only use a numeric value.", $"User Input Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Console.WriteLine("\nNumber of checkout lines set successfully!");
                            PressAnyKey();
                        }

                        break;

                    case 4: // Set the expected checkout duration
                        Console.Write("What is the expected service time for a customer, in minutes?  ");

                        var checkoutDuration = Console.ReadLine();

                        var parsedIntService = double.TryParse(checkoutDuration, out ServiceTime);

                        if (!parsedIntService)
                        {
                            MessageBox.Show($"{DateTime.Now}\nPlease only use a numeric value.", $"User Input Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Console.WriteLine("\nExpected service time set successfully!");
                            PressAnyKey();
                        }

                        break;

                    case 5: // Run the simulation

                        // if user didn't use the menu to set the parameters, set them to defaults specified in the documentation.
                        if (!PropertiesReadyForCalculation())
                        {
                            NumberOfCustomers = 50;
                            NumberOfRegisters = 3;
                            ServiceTime = 5.75;
                            HoursOfOperation = 16;
                        }

                        // Create the patrons and their events.
                        GeneratePatronEvents();

                        // if it is ready, run the simulation
                        DoSimulation();

                        Console.ReadKey();
                        break;
                    case 6: // exit the program
                        break;
                }  // end of switch

                choiceNumber = Menu.GetChoice();
            }  // end of while
        }

        /// <summary>
        /// The PropertiesReadyForCalculation.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        private static bool PropertiesReadyForCalculation()
        {
            if (NumberOfRegisters == 0 || NumberOfCustomers == 0 || ServiceTime == 0 || HoursOfOperation == 0)
                return false;
            return true;
        }
        #endregion

        #region I/O Utilities
        /// <summary>
        /// The Skip.
        /// </summary>
        /// <param name="numLineBreaks">The numLineBreaks<see cref="int"/>.</param>
        public static void Skip(int numLineBreaks)
        {
            for (int i = 0; i < numLineBreaks; i++)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// The PrintDashes.
        /// </summary>
        /// <param name="numDashes">The numDashes<see cref="int"/>.</param>
        public static void PrintDashes(int numDashes)
        {
            for (int i = 0; i < numDashes; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// The PressAnyKey.
        /// </summary>
        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue... ");
            Console.ReadKey();
        } 
        #endregion

        /// <summary>
        /// The GeneratePatronEvents.
        /// </summary>
        public static void GeneratePatronEvents()
        {
            TimeSpan start;
            TimeSpan interval;
            shortest = new TimeSpan(0, 100000, 0);  //shortest stay
            longest = new TimeSpan(0, 0, 0);        //longest stay
            totalTime = new TimeSpan(0, 0, 0);      //total of all stays used for finding avg
            NumberOfCustomers = Distributions.Poisson(NumberOfCustomers);   //Poisson distribution based on expected

            for (int patron = 1; patron <= NumberOfCustomers; patron++)
            {
                // Create a new Customer
                Customer newCust = new Customer
                {
                    CustomerId = patron,
                };

                //Random start time based on the number of minutes in the 16 hours we are open
                start = new TimeSpan(0, 0, rando.Next(HoursOfOperation * 60 * 60));
                //Random (neg. exp.) interval with a minimum of 2 minutes; expected time = 5.75 (5 minutes and 45 seconds).
                interval = new TimeSpan(0, 0, (int)(2.0*60 + 60*Distributions.NegativeExponential(ServiceTime - 2)));
                totalTime += interval;

                // Set how long the customer will stay.
                newCust.StayInterval = interval;

                if (shortest > interval)
                    shortest = interval;
                if (longest < interval)
                    longest = interval;

                //Create the entering event.
                Evnt enteringEvent = new Evnt(EVENTTYPE.ENTER, OpeningTime.Add(start), patron);

                // Add the event to the customer.
                newCust.EnterEvent = enteringEvent;

                //Enqueue the arrival event for this person
                PriorityQueue.Enqueue(enteringEvent);

                // Add the customer to the list of Customers visiting the store
                CustomerHolder.Add(newCust);
            }

            int seconds = (int)(totalTime.TotalSeconds / NumberOfCustomers);   //avg for all patrons
            average = new TimeSpan(0, 0, seconds);
        }

        /// <summary>
        /// The SetLinesAsQueues.
        /// </summary>
        private static void SetLinesAsQueues()
        {
            for (var i = 0; i < NumberOfRegisters; i++)
            {
                Registers.Add(new Queue<Customer>());
            }
        }

        /// <summary>
        /// The GetShortestLine.
        /// </summary>
        /// <returns>The <see cref="Queue{Customer}"/>.</returns>
        private static Queue<Customer> GetShortestLine()
        {
            Queue<Customer> minLine = new Queue<Customer>();

            for (var i = 0; i < Registers.Count; i++)
            {
                if (i == 0)
                    minLine = Registers[i];

                if (minLine.Count > Registers[i].Count)
                    minLine = Registers[i];
            }

            return minLine;
        }

        /// <summary>
        /// The GetLongestLine.
        /// </summary>
        /// <returns>The <see cref="Queue{Customer}"/>.</returns>
        private static Queue<Customer> GetLongestLine()
        {
            Queue<Customer> maxLine = new Queue<Customer>();

            for (var i = 0; i < Registers.Count; i++)
            {
                if (i == 0)
                    maxLine = Registers[i];

                if (maxLine.Count < Registers[i].Count)
                    maxLine = Registers[i];
            }

            return maxLine;
        }

        /// <summary>
        /// The GetCustomerFromList.
        /// </summary>
        /// <param name="customerId">The customerId<see cref="int"/>.</param>
        /// <returns>The <see cref="Customer"/>.</returns>
        private static Customer GetCustomerFromList(int customerId)
        {
            return CustomerHolder.FirstOrDefault(x => x.CustomerId == customerId);
        }

        /// <summary>
        /// The DoSimulation.
        /// </summary>
        private static void DoSimulation()
        {
            longestLine = 0;
            processedEvents = 0;
            arrivals = 0;
            departures = 0;

            // Set the number of lines for customers to enter.
            SetLinesAsQueues();

            while (PriorityQueue.Count > 0)
            {
                // Get the longest line count so far.
                longestLine = GetLongestLine().Count < longestLine ? longestLine : GetLongestLine().Count;
                Console.Clear();

                if (PriorityQueue.Peek().Type == EVENTTYPE.ENTER)  //ENTER event
                {
                    // Find the shortest line.
                    var currentShortestLine = GetShortestLine();

                    // Get the next customer from the priority queue
                    var getTheNextCustomer = GetCustomerFromList(PriorityQueue.Peek().Patron);


                    if (currentShortestLine.Count == 0)
                    {
                        // Put the customer in the queue, i.e., the shortest line.
                        currentShortestLine.Enqueue(getTheNextCustomer);

                        //Create the leaving event
                        Evnt leavingEvent = new Evnt(EVENTTYPE.LEAVE, getTheNextCustomer.EnterEvent.Time.Add(getTheNextCustomer.StayInterval), getTheNextCustomer.CustomerId);

                        // Add the leave event to the customer
                        getTheNextCustomer.LeavingEvent = leavingEvent;

                        //Enqueue the departure for this event
                        PriorityQueue.Enqueue(leavingEvent);
                    }
                    else
                    {

                        // Put the customer in the queue, i.e., the shortest line.
                        currentShortestLine.Enqueue(getTheNextCustomer);
                    }

                    // Then remove it form the Priority Queue.
                    PriorityQueue.Dequeue();

                    arrivals++;

                }
                else //LEAVE event
                {
                    
                    departures++;

                    // Get the customer that is leaving
                    var getTheNextCustomer = GetCustomerFromList(PriorityQueue.Peek().Patron);

                    // Find the line they are in.
                    var customersLine = FindCustomersLine(getTheNextCustomer);

                    if (customersLine != null)
                    {
                        // Then remove "Dequeue" them from that line. 
                        customersLine.Dequeue();

                        // Then remove it form the Priority Queue.
                        PriorityQueue.Dequeue();


                        if (customersLine.Count != 0)
                        {
                            // Peek the customer that is now first in line
                            var newFirstCustomer = customersLine.Peek();

                            //Create the leaving event
                            Evnt leavingEvent = new Evnt(EVENTTYPE.LEAVE, newFirstCustomer.EnterEvent.Time.Add(newFirstCustomer.StayInterval), newFirstCustomer.CustomerId);

                            // Add the leave event to the customer object
                            newFirstCustomer.LeavingEvent = leavingEvent;

                            //Enqueue the departure for this event
                            PriorityQueue.Enqueue(leavingEvent);
                        }
                    }
                }
                processedEvents++;
                DisplayLines();
                Thread.Sleep(50);
            }
            DisplayTotals();
        }

        /// <summary>
        /// The DisplayLines.
        /// </summary>
        private static void DisplayLines()
        {
            int registerCount = 0;
            string format = "0000";

            Console.WriteLine("Simulating Lines");
            PrintDashes(20);
            foreach (var line in Registers)
            {
                registerCount++;
                Console.Write($"Register #{registerCount}: ");

                foreach (var customer in line)
                {
                    Console.Write(" {0} ", customer.CustomerId.ToString(format));
                }
                Console.WriteLine();
            }
            PrintDashes(20);
            Console.WriteLine($"Longest Queue Encountered So Far: {longestLine}");
            Console.WriteLine();
            Console.Write("Arrivals: ".PadLeft(25));
            Console.WriteLine(arrivals);
            Console.Write("Departures: ".PadLeft(25));
            Console.WriteLine(departures);
            Console.WriteLine($"Events Processed So Far: {processedEvents}");
        }

        /// <summary>
        /// The DisplayTotals.
        /// </summary>
        private static void DisplayTotals()
        {
            Console.WriteLine($"The average service time for {CustomerHolder.Count} customers was {average}");
            Console.WriteLine($"The minimum service time was {shortest}");
            Console.WriteLine($"The maximum service time was {longest}");

            PressAnyKey();
        }

        /// <summary>
        /// The FindCustomersLine.
        /// </summary>
        /// <param name="customerInFornt">The customerInFornt<see cref="Customer"/>.</param>
        /// <returns>The <see cref="Queue{Customer}"/>.</returns>
        private static Queue<Customer> FindCustomersLine(Customer customerInFornt)
        {
            foreach (var line in Registers)
            {
                if (line.Count != 0)
                    if (line.First() == customerInFornt)
                        return line;
            }

            return null;
        }
    }
}
