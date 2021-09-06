using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSytem
{
    class GuestService : IService<Guest>
    {
        private List<Guest> Guests = new List<Guest>();
        public GuestService()
        {
            Guests.Add(new Guest() { Id = 1, Identification = "AZE123456", Name = "Christopher", Surname = "Nolan", Email = "christopher@gmail.com", Phone = "123456", CreatedDate = DateTime.Now });
            Guests.Add(new Guest() { Id = 2, Identification = "AZE456456", Name = "Dan", Surname = "Brown", Email = "dan@gmail.com", Phone = "1245526", CreatedDate = DateTime.Now }); 
        }
        public Guest Create(Guest model)
        {
            Guests.Add(model);
            return model;
        }

        public bool Delete(Guest model)
        {
            
            Guests.Remove(model);
            return true;
        }

        public Guest Get(int id)
        {
            return Guests.Find(g => g.Id == id);

        }

        public List<Guest> GetAll()
        {
            return Guests;
        }

        public List<Guest> SearchbyName(string name)
        {
            return Guests.FindAll(g => g.Name == name);
        }

        public Guest SearchById(string identification)
        {
            return Guests.Find(c => c.Identification == identification);
        }

        public Guest Update(Guest oldModel, Guest model)
        {
            Guests.Remove(oldModel);
            Guests.Add(model);
            return model;
        }
    }
}
