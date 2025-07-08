using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace assignment1
{
    public class user
    {
        private string username;
        private string password;
        
        public user() { 
            username = null;
            password = null;
        }
        public user(string username, string password)
        {          
            this.username = username;           
            this.password = password;                    
        }

        public string getUsername()
        {
            return username;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        public string getPassword()
        {
            return password;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }


        public bool isValid(string username, string password) //Checks if user input matches the file
        {
            return this.username.Equals(username) && this.password.Equals(password);
        }

        public string printUser(string username, string password)
        {
            return this.username + "," + this.password;
        }
    }
}
