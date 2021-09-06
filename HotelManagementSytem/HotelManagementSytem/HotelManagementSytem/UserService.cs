using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSytem
{
    class UserService : IService<User>
    {
        private List<User> Users = new List<User>();
        public UserService()
        {
            Users.Add(new User(1, "rachel", "ross123", "Rachel", "Green") );
            Users.Add(new User(2,"monica","bing123","Monica", "Geller") );
        }
        public User Create(User model)
        {
            Users.Add(model);
            return model;
        }

        public bool Delete(User model)
        {
           
            Users.Remove(model);
            return true;
        }

        public User Get(int id)
        {
            return Users.Find(u => u.Id == id);
        }

        public List<User> GetAll()
        {
            return Users;
        }

        public User Update(User oldModel, User model)
        {
           
                Users.Remove(oldModel);
                Users.Add(model);
                return model;
            
           
            
        }
    }
}
