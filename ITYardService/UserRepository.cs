using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITYardService
{
    public class UserRepository
    {
        private static Dictionary<Guid, User> _users = new Dictionary<Guid, User>();

        public User [] All()
        {
            return _users.Values.ToArray();
        }

        public User GetById(Guid id) //return user by id
        {
            return _users[id];
        }

        public void Insert(User user) // add user to repository
        {
            _users.Add(user._id, user);
        }

        public void Update(Guid id, string username, string password) //update data of user
        {
            User updatedUser = _users[id];
            updatedUser._username = username;
            updatedUser._password = password;
        }

        public void Delete(Guid id)
        {
            if (_users.ContainsKey(id)) //if we have in repository this id
            {
                _users.Remove(id); //then delete user with this id
            }
        }
    }
}
 