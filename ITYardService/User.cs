using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITYardService
{
    public class User
    {
        public Guid _id;
        public string _username;
        public string _password { get; set; }

        public User()
        {
            this._id = Guid.NewGuid();
        }

        public User(string username, string password): this()
        {
            this._username = username;
            this._password = password;
        }

        public static char Encode(char character, int key)
        {
            if (character == ' ')
            {
                return character;
            }

            char startChar = ' ';
            return (char)((((character + key) - startChar) % 95) + startChar);
        }

        public static char Decode(char character, int key)
        {
            if (character == ' ')
            {
                return character;
            }

            char startChar = ' ';
            return character - startChar - key < 0 ? (char)(character - key + 95) : (char)(character - key);
        }

        public void DisplayUserInfo()
        {
            Console.WriteLine($"Username - {this._username} and password {this._password}");
        }     
    }
}
