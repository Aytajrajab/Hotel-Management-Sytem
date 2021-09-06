using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSytem
{
    class Room
    {
        public Room(int number, string type, int bedCount, int price)
        {
            Number = number;
            Type = type;
            BedCount = bedCount;
            Price = price;
        }

        public int Number { get; set; }
        public string Type { get; set; }
        public int BedCount { get; set; }
        public int Price { get; set; }
       


        
    }
}
