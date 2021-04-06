using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    static class Utility
    {
        /// <summary>
        /// Returns a number greater than 0 and less than numberOfItems
        /// </summary>
        /// <param name="numberOfItems"></param>
        /// <returns></returns>
        public static int GetANumberFromUser(int numberOfItems)
        {
            //Ask the user to enter a number betwee 1 and whatever number of items you want check against
            WriteLine($"Enter a number between 1 and {numberOfItems}");
           
            //Get the user input from console
            string userInput = ReadLine();

            //Start with negative number to make sure it can't be part of the list
            int userInputAsNumber = -1;

            //Int.Tryparse will try catch converting user input to an integer
            //We need to make sure number is greater than 0
            //And less than the highest number on the list

            if (int.TryParse(userInput, out userInputAsNumber) && userInputAsNumber > 0 && userInputAsNumber <= numberOfItems)
            {
                return userInputAsNumber;
            }
            else
            {
                //If validation fails, re run this utility until user enters a valid value.
                WriteLine("Try again");
                return GetANumberFromUser(numberOfItems);
            }
        }
    }
}
