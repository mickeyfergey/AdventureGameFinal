using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class Item
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool CanPickUp { get; set; } 


        //This method has an optional argument called canpickup, if you don't pass in the arguament, it is going to be true by default. Optional arguments needs to defined as the last part of the argument list
        public Item( string name, bool canPickup = true)
        {
            Name = name;
            CanPickUp = canPickup;
        }
    }
}
