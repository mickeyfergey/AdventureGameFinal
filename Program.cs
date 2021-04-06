using System;
using static System.Console;
using System.Collections.Generic;

/*
 * Adventure Game - By: Mickey Fergus
 * With much assistance from ITP SP2021 S02
 * Extra thanks to Kyle Hansen for assistance!
 * Hope you enjoy the game!
 */

namespace AdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game();
            game.Setup();
        }
    }
}
