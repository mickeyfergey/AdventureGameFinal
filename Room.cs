using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class Room
    {
        public string Name { get; set; }

        public List<Item> RoomLoot { get; set; }

        public List<Item> RequiredItems { get; set; }

        public NPC Guaurdian { get; set; }



        //public Room(string name, List<Item> roomLoot)
        //{
        //    Name = name;
        //    RoomLoot = roomLoot;
        //}
    }
}
