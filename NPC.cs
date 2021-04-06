using System;
using System.Collections.Generic;
using static System.Console;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class NPC
    {
        public string Name { get; set; }
        public List<Item> Wares { get; set; }
        public string Greeting { get; set; }


        public void Trade(Room room, Player player)
        {
            if (Wares.Count > 0)
            {
                WriteLine($"{Greeting}. Here is what I have on me.");

                //Defining a starting number that will increment with the room inventory list
                int index = 1;
                foreach (Item item in Wares)
                {
                    //Show the item name with the index number
                    WriteLine($"{index}) {item.Name}");
                    index++;
                }
                //Adding a manual option for user to select for exiting out this menu
                WriteLine($"{index}) I'll pass.");
                WriteLine($"What do you want to pick? {player.Name}");
                int userInputAsNumber = Utility.GetANumberFromUser(index);

                //Check the user made the selection of the last option we manually added to the list
                if (userInputAsNumber < index)
                {

                
                    //Find the selected item from rooms item list
                    Item selectedItem = Wares[userInputAsNumber - 1];
                    //checking if the play can pick up item
                    if(selectedItem.CanPickUp)
                    {
                        //player is adding item to inventory
                        player.PickUpItem(selectedItem);
                        //removes item from wares
                        Wares.Remove(selectedItem);

                    }
                    else
                    {
                        WriteLine("Sorry. You can't have that.");
                        Trade(room, player);
                    }
                }
            }
            else
            {
                WriteLine($"Sorry, {player.Name}. I don't have any items left.");
            }


        }

    }
}
