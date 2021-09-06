using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSytem
{
    class BookingService : IService<Booking>
    {
        private List<Booking> Bookings = new List<Booking>() 
        { 
            new Booking(1, "AZE123456", 101, DateTime.Now , DateTime.Now.AddDays(2))
        
        
        };
        public Booking Create(Booking model)
        {
            Bookings.Add(model);
            return model;
        }

        public bool Delete(Booking model)
        {
            
            Bookings.Remove(model);
            
            return true;
        }

        public Booking Get(int id)
        {
            return Bookings.Find(b => b.Id == id);
        }

        public List<Booking> GetAll()
        {
            return Bookings;
        }

        public Booking Update(Booking oldModel, Booking model)
        {
            Bookings.Remove(oldModel);
            Bookings.Add(model);
            return model;
            

        }
    }
}
