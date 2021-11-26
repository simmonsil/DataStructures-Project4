using DSProject1;
using PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProject4Driver
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            
            // Setup the program
            MenuHelper.Setup();

            // Form Dr. Bailes code to setup the menu
            int choice = MenuHelper.Menu.GetChoice();

            // Display the menu and monitor the users input.
            MenuHelper.MenuChoice(choice);
        }
    }
}
