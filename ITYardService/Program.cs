using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITYardService
{
    class Program
    {
        static void Main(string[] args)
        {

            var usr1 = new User("user1", "gdh^0fi"); //create the first user
    
            var usr2 = new User("user2", "pa444ss2"); //create the second user

            var repo = new UserRepository(); // create user repository
            repo.Insert(usr1); // add the first user data to repository
            repo.Insert(usr2); //add the second user data to repository

            //repo.Delete(usr1._id); // will delete usr1

            var users = repo.All(); // take all users from repository
            foreach (var user in users) // loop through the users
            {
              
                string result = "";  //declare variable where will be encrypted password
                int keyForEven = 2; // this key we add for even symbols 
                int keyForOdd = 4;  // this key we add for odd symbols 

                foreach (char c in user._password) // loop through the symbols in the password string
                {
                    result = result + User.Encode(c, ((int)c % 2 == 0) ? keyForEven : keyForOdd); // every time we loop through the symbols we add a new encrypted symbols to variable result
                }

                string decodedStr = ""; //declare variable where will be decrypted password

                foreach (char c in result)  // loop through the symbols in the encrypted password string
                {
                    decodedStr = decodedStr + User.Decode(c, ((int)c % 2 == 0) ? (keyForEven) : (keyForOdd)); // every time we loop through the symbols we add a new decrypted symbols to variable decodedStr
                }


                //Console.WriteLine(result);
                //Console.WriteLine(decodedStr);
                user._password = result;
                //user._password = decodedStr;
            
                user.DisplayUserInfo();
            }

            //check the GetByID method -- start

            //var getById = repo.GetById(usr2._id); 
            //Console.WriteLine(getById);
            //Console.WriteLine(getById._password);
            //Console.WriteLine(getById._username);

            //repo.Update(usr2._id, "namenew", "passnew");
            //Console.WriteLine(getById);
            //Console.WriteLine(getById._password);
            //Console.WriteLine(getById._username);

            //check the GetByID method  -- end
            Console.ReadKey();
        }      
    }
}
