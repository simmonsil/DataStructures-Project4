///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject1
//	File Name:         MenuHelper.cs
//	Description:       MenuHelper is a helper class to add functionality to the MenuDemo provided by Dr. Bailes. 
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Joshua Trimm, trimmj@etsu.edu
//	Created:           10/3/2021
//	Copyright:         Joshua Trimm, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace DSProject1
{
    using DSProject4Driver;
    using MenuClassDemo;
    using PriorityQueue;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using System.Windows.Forms;
    using UtilityNamespace;
    using Menu = UtilityNamespace.Menu;
    using MessageBox = System.Windows.Forms.MessageBox;

    /// <summary>
    /// <see cref="MenuHelper" /> add functionality to Dr. Bailes MenuDemo package.
    /// </summary>
    public static class MenuHelper
    {
        public static Menu Menu;
        public static PriorityQueue<Evnt> PriorityQueue = new PriorityQueue<Evnt>();
        public static DateTime OpeningTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 8, 0, 0);

        private static int NumberOfRegisters;
        private static int ServiceTime;
        private static int HoursOfOperation;
        private static int NumberOfPatrons;
        private static Random rando = new Random();
        private static TimeSpan shortest;
        private static TimeSpan longest;
        private static TimeSpan totalTime;


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
            menu = menu + "Set the number of Registrants" + "Set the number of hours of operation" + "Set the number of windows" + "Set the expected checkout duration" + "Run the simulation" + "End the program";

            // Set the menu to a global variable. 
            Menu = menu;
        }


        /// <summary>
        /// The MenuChoice monitors the users menu selection.
        /// </summary>
        /// <param name="choice">The choice<see cref="Choices"/>.</param>
        public static void MenuChoice(int choiceNumber)
        {

            // While loop pulled from Dr. Bailes MenuDemoDriver
            while (choiceNumber != 6)
            {
                // check what option the user chose
                switch (choiceNumber)
                {
                    case 1: // Set the number of Registrants
                        Console.WriteLine("How many Registrants are expected to be served in a day?");
                        var numbOfReg = Console.ReadLine();

                        var parsed = Int32.TryParse(numbOfReg, out NumberOfPatrons);

                        if(!parsed)
                        {
                            MessageBox.Show($"{DateTime.Now}\n User Input Error", $"Please only use a numeric value", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                           
                        }


                        break;

                    case 2: // Set the number of hours of operation


                        Console.WriteLine("How many hours will registration be open?");

                        var numbOfHours = Console.ReadLine();

                        var parsedInt = Int32.TryParse(numbOfHours, out HoursOfOperation);

                        if (!parsedInt)
                        {
                            MessageBox.Show($"{DateTime.Now}\n User Input Error", $"Please only use a numeric value", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);

                        }
                        break;

                    case 3: // Set the number of windows

                        Console.WriteLine("How many registration lines are to be simulated?");

                        var numbOfWindows = Console.ReadLine();

                        var parsedIntWin = Int32.TryParse(numbOfWindows, out NumberOfRegisters);

                        if (!parsedIntWin)
                        {
                            MessageBox.Show($"{DateTime.Now}\n User Input Error", $"Please only use a numeric value", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);

                        }

                        break;

                    case 4: // Set the expected checkout duration
                        Console.WriteLine("What is the expected service time for a Registrant, in minutes?");

                        Console.ReadKey();

                        var checkoutDuration = Console.ReadLine();

                        var parsedIntService = Int32.TryParse(checkoutDuration, out ServiceTime);

                        if (!parsedIntService)
                        {
                            MessageBox.Show($"{DateTime.Now}\n User Input Error", $"Please only use a numeric value", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);

                        }

                        break;
                    case 5: // Run the simulation

                        if(!PropertiesReadyForCalculation())
                            MessageBox.Show($"{DateTime.Now}\n Please enter values for items 1-4. Value must be greater than 0 (Zero).", $"Values Not Set", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);

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

        private static bool PropertiesReadyForCalculation()
        {
            if (NumberOfRegisters == 0 || NumberOfPatrons == 0 || ServiceTime == 0 || HoursOfOperation == 0)
                return false;
            return true;
        }

        public static void Skip(int numLineBreaks)
        {
            for (int i = 0; i < numLineBreaks; i++)
            {
                Console.WriteLine();
            }    
        }

        public static void PrintDashes(int numDashes)
        {
            for (int i = 0; i < numDashes; i++)
            {
                Console.Write("-");
            }
        }

        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue... ");
            Console.ReadKey();
        }

        public static void GeneratePatronEvents()
        {
            TimeSpan start;
            TimeSpan interval;
            shortest = new TimeSpan(0, 100000, 0);  //shortest stay
            longest = new TimeSpan(0, 0, 0);        //longest stay
            totalTime = new TimeSpan(0, 0, 0);      //total of all stays used for finding avg

            for (int patron = 1; patron <= NumberOfPatrons; patron++)
            {
                //Random start time based on the number of minutes in the 10 hours we are open
                start = new TimeSpan(0, rando.Next(10 * 60), 0);
                //Random (neg. exp.) interval with a minimum of 10 minutes; expected time = 60 minutes
                interval = new TimeSpan(0, (int)(10.0 * Distributions.NegativeExponential(50)), 0);
                totalTime += interval;

                if (shortest > interval)
                    shortest = interval;
                if (longest < interval)
                    longest = interval;

                //Enqueue the arrival event for this person
                PriorityQueue.Enqueue(new Evnt(EVENTTYPE.ENTER, OpeningTime.Add(start), patron));
                //Enqueue the departure for this event
                PriorityQueue.Enqueue(new Evnt(EVENTTYPE.LEAVE, OpeningTime.Add(start + interval), patron));
            }


            int seconds = (int)(totalTime.TotalSeconds / NumberOfPatrons);   //avg for all patrons
            TimeSpan avgTime = new TimeSpan(0, 0, seconds);

            Console.WriteLine($"The average time customers spent in the museum was {avgTime}");
            Console.ReadKey();
        }

        private static void DoSimulation()
        {
            int lineCount = 0;
            maxPresent = 0;     //declared in the driver in Bailes's code?
            int current = 0;

            while (PriorityQueue.Count > 0)
            {
                Console.Write($"{(++lineCount).ToString().PadLeft(3)}.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" {PriorityQueue.Peek()}");
                Console.ForegroundColor = ConsoleColor.Blue;

                if (PriorityQueue.Peek().Type == EVENTTYPE.ENTER)  //ENTER event
                {
                    current++;
                    if (current > maxPresent)
                        maxPresent = current;
                }
                else    //LEAVE event
                    current--;

                Console.Write($"   Customers Present: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(current.ToString().PadLeft(2));
                Console.ForegroundColor = ConsoleColor.Blue;

                PriorityQueue.Dequeue();
                if ((lineCount % 30) == 0)
                    PressAnyKey();
            }
        }

    }
}
