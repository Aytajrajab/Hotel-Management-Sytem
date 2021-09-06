using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSytem
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }

        public User(int id , string username, string password, string name ,string surname)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Surname = surname;
            CreatedDate = DateTime.Now;
        }
    }
}
