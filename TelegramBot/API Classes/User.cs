using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.API_Classes
{
    class User
    {
        //Unique identifier for this user or bot
        public int Id { get; set; }
        //	User‘s or bot’s first name
        public string FirstName { get; set; }
        //Optional. User‘s or bot’s last name
        public string LastName { get; set; }
        //Optional. User‘s or bot’s username
        public string Username { get; set; }

        public User() { }

        public User(int _id, string _firstName)
        {
            Id = _id;
            FirstName = _firstName;
        }

        public User(int _id, string _firstName, string _lastName,string _username)
        {
            Id = _id;
            FirstName = _firstName;
            LastName = _lastName;
            Username = _username;
        }
    }
}
