using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSytem
{
    class RoomService : IService<Room>
    {
        private List<Room> Rooms = new List<Room>()
        {
            new Room(101,"Econom", 2, 200) {Number = 101, Type = "Econom", BedCount=2, Price= 200, },
            new Room(201, "Comfort", 1, 200) {Number=201, Type="Comfort", BedCount=1, Price=500, },
            new Room(541, "VIP", 1, 1000) {Number=541, Type="VIP", BedCount=1, Price=1000, },
            new Room(763, "King suite", 1, 1500) {Number=763, Type="King suite", BedCount=1, Price=1500}
            
           
        };

       


        
        public Room Create(Room model)
        {
            Rooms.Add(model);
            return model;
        }

        public bool Delete(Room model)
        {
            
            Rooms.Remove(model);
            return true;

        }

        public Room Get(int number)
        {
            Room result = Rooms.Find(r => r.Number == number);
            if(result!=null)
            {
                return result;
            }
            return null;
        }

        

        public List<Room> GetAll()
        {            
            return Rooms;
        }

        public Room Update(byte number, Room model)
        {
            Room room = Rooms.Find(r => r.Number == number);
            room = model;
            return model;
        }

        public Room Update(Room oldModel, Room model)
        {
            Rooms.Remove(oldModel);
            Rooms.Add(model);
            return model;
        }
    }
}
