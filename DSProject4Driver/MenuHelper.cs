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
    using MenuClassDemo;
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

        private static int NumberOfWindows;
        private static int ServiceTime;
        private static int HoursOfOperation;
        private static int NumberOfRegistrants;

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

                        var parsed = Int32.TryParse(numbOfReg, out NumberOfRegistrants);

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

                        var parsedIntWin = Int32.TryParse(numbOfWindows, out NumberOfWindows);

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
            if (NumberOfWindows == 0 || NumberOfRegistrants == 0 || ServiceTime == 0 || HoursOfOperation == 0)
                return false;
            return true;
        }


    }
}
