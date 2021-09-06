using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSytem
{
    class Booking
    {
        public int Id { get; set; }
        public string GuestId { get; set; }
        public int RoomNumber { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public Booking(int id, string GuestID, int RoomNUMBER, DateTime checkin , DateTime checkout)
        {
            this.Id = id;
            this.GuestId = GuestID;
            this.RoomNumber = RoomNUMBER;
            BookingDate = DateTime.Now;
            this.CheckInDate = checkin;
            this.CheckOutDate = checkout;
        }
        
    }
}
