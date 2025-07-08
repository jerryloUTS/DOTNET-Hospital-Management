using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace assignment1
{
        public class userDetail
        {
            private string username;
            private string surname;
            private string email;
            private int phone;
            private string address;


            public userDetail()
            {
                username = null;
                surname = null;
                email = null;
                phone = 0;
                address = null;
            }

            public userDetail(string username, string surname, string email, int phone, string address)
            {
                this.username = username;
                this.surname = surname;
                this.email = email;
                this.phone = phone;
                this.address = address;
            }

            public string getUsername()
            {
                return username;
            }

            public void setUsername(string username)
            {
                this.username = username;
            }

            public string getSurname()
            {
                return surname;
            }
            public void setSurname(string surname)
            {
                this.surname = surname;
            }
            
            public string getEmail()
            {
                return email;
            }

            public void setEmail(string email)
            {
                this.email = email;
            }

            public int getPhone()
        {
            return phone;
        }
            
            public void setPhone(int phone)
            {
                this.phone = phone;
            }

            public string getAddress()
            {
                return address;
            }

            public void setAddress(string address)
        {
            this.address = address;
        }

            public void userFullDetail(string username, string surname, string email, int phone, string address)
            {
                Console.WriteLine(this.username + this.surname + this.email + this.phone + this.address);
            }

          
        }
}

