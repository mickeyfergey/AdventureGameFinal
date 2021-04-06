using System;
using System.Collections.Generic;
using static System.Console;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class Game
    {

        //A Player property that holds a reference to the current player
        public Player CurrentPlayer { get; set; }

        //List of rooms in the game
        public List<Room> Rooms { get; set; }

        public int totalNumberOfItems;

        public string gameTitle = @"
              _                 _                     _____                      _ 
     /\      | |               | |                   / ____|                    | |
    /  \   __| |_   _____ _ __ | |_ _   _ _ __ ___  | |  __  __ _ _ __ ___   ___| |
   / /\ \ / _` \ \ / / _ \ '_ \| __| | | | '__/ _ \ | | |_ |/ _` | '_ ` _ \ / _ \ |
  / ____ \ (_| |\ V /  __/ | | | |_| |_| | | |  __/ | |__| | (_| | | | | | |  __/_|
 /_/    \_\__,_| \_/ \___|_| |_|\__|\__,_|_|  \___|  \_____|\__,_|_| |_| |_|\___(_)
                                                                                   
                                                                                   ";

        //Sets up all the items, rooms and the current player game.
        public void Setup()
        {

            Title = "Adventure Game!";

            //Create an empty list to hold the rooms for the game
            Rooms = new List<Room>();

            //Creating items
            Item pbSandwich = new Item("PB Sandwich");
            Item cheese = new Item("Cheese");
            //Creating rooms
            Item woodenspoon = new Item("Wooden Spoon");
            Item apron = new Item("Apron");
            NPC mom = new NPC()
            {
                Name = "MA",
                Greeting = "What are you doing in the kitchen?",
                Wares = new List<Item>() {woodenspoon, apron}
            };
            Room kitchen = new Room()
            {
                Name = "Kitchen",
                RoomLoot = new List<Item>() { pbSandwich, cheese },
                RequiredItems = null,
                Guaurdian = mom
            };
            //Adding kitchen room the Room list
            Rooms.Add(kitchen);

            Item baseball = new Item("Baseball");
            Item glove = new Item("Glove");
            NPC Brother = new NPC()
            {
                Name = "Big Bro",
                Greeting = "Hey lil' man.",
                Wares = new List<Item>() {baseball, glove }
            };
            Item goldRing = new Item("Gold Ring");
            Room kidsBedroom = new Room()
            {
                Name = "Kid's Bedroom",
                RoomLoot = new List<Item>() { goldRing },
                RequiredItems = new List<Item>() { pbSandwich },
                Guaurdian = Brother
                
            };
            Rooms.Add(kidsBedroom);

            Item carKey = new Item("Car Key");
            Item wallet = new Item("Wallet", false);
            NPC dad = new NPC()
            {
                Name = "Dad",
                Greeting = "Hello, child.",
                Wares = new List<Item>() { carKey, wallet }
            };
            Item garageDoorOpener = new Item("Garage Door Opener");
            Room masterBedroom = new Room()
            {
                Name = "Master Bedroom",
                RoomLoot = new List<Item>() { garageDoorOpener },
                RequiredItems = new List<Item>() { goldRing },
                Guaurdian = dad
            };
            Rooms.Add(masterBedroom);

            Item car = new Item("Car Key");
            Item lipstick = new Item("Lipstick", false);
            Item lipgloss = new Item("Lip Gloss", false);
            NPC sister = new NPC()
            {
                Name = "Sister",
                Greeting = "Hey baby bro! Want the car?",
                Wares = new List<Item>() { lipstick, lipgloss, car }
            };
            Room garage = new Room()
            {
                Name = "Garage",
                RoomLoot = new List<Item>() { car },
                RequiredItems = new List<Item>() { garageDoorOpener, carKey },
                Guaurdian = sister
            };
            Rooms.Add(garage);


            Item freedom = new Item("Freedom!");
            Item xbox = new Item("Xbox");
            NPC bestie = new NPC()
            {
                Name = "Bob",
                Greeting = "Hey bro! You made it! You're free!!! Let's game!",
                Wares = new List<Item>() { xbox }
            };
            Room outside = new Room()
            {
                Name = "Outside",
                RoomLoot = new List<Item>() { freedom },
                RequiredItems = new List<Item>() { garageDoorOpener, carKey },
                Guaurdian = bestie
            };
            Rooms.Add(outside);


            //Creates a player
            CurrentPlayer = new Player()
            {
                Name = "",
                Inventory = new List<Item>()
            };

            //Calls the greeting
            Greeting();
        }


        public void StorePlayer(string playerName)
        {
            string path = @"/Users/michaelfergus/Desktop/Academics/CCC/•PROG 101/AdventureGameFinal/PlayerHistory.txt";
            File.AppendAllText(path, "\n" + playerName);
        }

        //Show the greeting for the game & show the menu
        public void Greeting()
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine(gameTitle);
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("Welcome to the Adventure Game! Your goal is to escape, and play Xbox with your bestie, Bob.");
            WriteLine("Your final score is calculated by the number of items you collect throughout the game");
            WriteLine("Let's start off simple. What's your name?");
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("");
            //Get the user name from the user
            Write("My name is ");
            string userInput = ReadLine();
            CurrentPlayer.Name = userInput;

            StorePlayer(userInput);
            ResetColor();
            ShowMenu();
        }

        //Showing initial game menu options
        public void ShowMenu()
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine($"Nice to meet you {CurrentPlayer.Name}. Let's do this!");
            WriteLine("Press any key to continue...");
            ReadKey();
            Clear();
            ShowRooms();
        }

        public void ShowRooms()
        {
            //Console.Clear();
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("Viewing Rooms");
            ResetColor();
          
            //Defining a starting number that will increment with the room list
            int index = 1;
            foreach (Room room in Rooms)
            {
                //Show the room name with the index number
                ForegroundColor = ConsoleColor.Blue;
                WriteLine($"{index}) {room.Name}");
                ResetColor();
                //Increment the index by 1 for the next room
                index++;
            }

            //Adding a manual option for user to select for exiting out this menu
            ForegroundColor = ConsoleColor.DarkBlue;
            WriteLine($"{index}) Exit");
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine($"Where do you want to go? {CurrentPlayer.Name}");
            
            //Get the user input as a number using a utility function
            int userInputAsNumber = Utility.GetANumberFromUser(index);

            //Check the user made the selection of the last option we manually added to the list
            if (userInputAsNumber == index)
            {
                Exit();
            }

            //Find the room user wants to go to using the number user entered. It needs to be decreased by 1 to accomadate 0 based index of the list. 
            Room selectedRoom = Rooms[userInputAsNumber - 1];

            //Calling a method to check and see user has the required items in their inventory.
            bool canUserMoveToThisRoom = MoveToARoom(selectedRoom);

            //If they user has the item, move that room
            if (canUserMoveToThisRoom)
            {
                ShowRoomDetails(selectedRoom);
            }
            else
            {
                //Shows rooms again
                Clear();
                ForegroundColor = ConsoleColor.Red;
                WriteLine("You cannot go there yet!");
                ResetColor();
                ShowRooms();
            }
        }

        

        public void Exit()
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"Goodbye, {CurrentPlayer.Name}! Hope you enjoyed playing!");
            WriteLine("");
            //Show user's inventory before exit
            CurrentPlayer.ShowInventory();
            WriteLine("");
            WriteLine($"That means you finished with {CurrentPlayer.Inventory.Count} points!");

            string path = @"/Users/michaelfergus/Desktop/Academics/CCC/•PROG 101/ToEarlyICantThinkV2/PlayerHistory.txt";
            File.AppendAllText(path, ", " + CurrentPlayer.Inventory.Count);



            ForegroundColor = ConsoleColor.DarkGray;
            WriteLine("");
            WriteLine("By: Mickey Fergus");
            WriteLine("With much assistance from ITP SP2021 S02");
            WriteLine("With extra help from Kyle Hansen");
            Environment.Exit(0);
        }

        //A method to  check and see user has the required items in their inventory.
        public bool MoveToARoom(Room room)
        {

            Clear();
            //Create a bool value - default option is that user has everything required.
            bool userHasRequiredItems = true;

            //Checks if the room has required items or not
            if (room.RequiredItems != null)
            {
                //Going over the list of required items for that room
                foreach (Item item in room.RequiredItems)
                {
                    //If the players inventor does not contain a required item, mark the local variable false.
                    if (!CurrentPlayer.Inventory.Contains(item))
                    {
                        userHasRequiredItems = false;
                        //Show user that they are missing this item
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine($"You are missing:{item.Name}");
                        ResetColor();
                    }
                }
            }
            //Return the result
            return userHasRequiredItems;
        }

        //Shows room details (inventory)
        public void ShowRoomDetails(Room room)
        {

            
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine($"Welcome to: {room.Name}, here are the item(s) in this room");
            ResetColor();

            //Defining a starting number that will increment with the room inventory list
            int index = 1;
            foreach (Item item in room.RoomLoot)
            {
                //Show the item name with the index number
                WriteLine($"{index}) {item.Name}");
                index++;
            }

            WriteLine($"{index}) Talk to {room.Guaurdian.Name}");
            index++;
            //Adding a manual option for user to select for exiting out this menu
            WriteLine($"{index}) Exit");
            WriteLine($"What do you want to pick? {CurrentPlayer.Name}");
            int userInputAsNumber = Utility.GetANumberFromUser(index);

            //Check the user made the selection of the last option we manually added to the list
            if (userInputAsNumber == index)
            {
                //User wants to go back to the rooms.
                ShowRooms();
            }
            if (userInputAsNumber == room.RoomLoot.Count +1)
            {
                Clear();
                room.Guaurdian.Trade(room, CurrentPlayer);

                ShowRoomDetails(room);

            }
            else
            {
                //Find the selected item from rooms item list
                Item selectedItem = room.RoomLoot[userInputAsNumber - 1];

                //Call the player method to add the item to the inventory
                CurrentPlayer.PickUpItem(selectedItem);

                //Show room details again so user can pick up other items
                
                ShowRoomDetails(room);
            }


        }
    }
}
