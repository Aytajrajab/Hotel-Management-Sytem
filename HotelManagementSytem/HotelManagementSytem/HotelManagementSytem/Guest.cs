using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSytem
{
    class Guest
    {
        public int Id { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
