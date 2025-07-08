using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace assignment1
{
    
    public class LoginPage
    {
        Menu menu = null;

        public static string[] ID = new string[1];
        public static string[] list = new string[5];
        public static string[] name = new string[5];
        //intializes role, username and password (and allows other classes to access them and what the user has input)
        public static string role;
        public static string username = null;
        public static string password = null;

        public void loginPage()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("|  DOTNET Hospital Management System |");
            Console.WriteLine("|------------------------------------|");
            Console.WriteLine("|               Login                |");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.WriteLine("ID: ");           
            Console.WriteLine("Password: ");
            loginFunc();
        }
    



        public void loginFunc()
        {    
            
            try
            {   
                bool valid = false;
                //loops until the username and password are valid
                while (valid == false)
                {
                    Console.SetCursorPosition(33, 5);                   
                    Console.SetCursorPosition(4, 5);
                    username = Console.ReadLine();
                    Console.SetCursorPosition(10, 6);
                    password = passwordMask();
                    if (System.IO.File.ReadAllText(LoginPage.username + ".txt").Contains("admin")) //Admin Login; also checks the user's text file (if available) as to whether it contains "admin" or not. If so, it lets them into the "admin" login.
                    {
                        List<user> users = getAdmins();                      
                        foreach (user user in users)
                        {                      
                            if (user.isValid(username, password) && username.All(char.IsDigit)) //Checks if user input matches the file AND if all characters are digits
                            {
                                Console.WriteLine("\nValid Credentials. Welcome " + username + ". " + "\nPress any key to continue.");
                                
                                valid = true;
                                Console.ReadKey();
                                menu = new Menu(user);
                                Menu.Admin();
                            }
                        }
                    }
                    else if (System.IO.File.ReadAllText(LoginPage.username + ".txt").Contains("patient")) //Patient Login; also checks the user's text file (if available) as to whether it contains "patient" or not. If so, it lets them into the "patient" login.
                    {
                        List<user> users = getPatients();
                        foreach (user user in users)
                        {
                            if (user.isValid(username, password) && username.All(char.IsDigit)) //Checks if user input matches the file AND if all characters are digits
                            {
                                Console.WriteLine("\nValid Credentials. Welcome " + username + ". " + "\nPress any key to continue.");             
                                valid = true;
                                Console.ReadKey();
                                menu = new Menu(user);
                                Menu.Patient();
                                }
                            }
                        }

                    else if (System.IO.File.ReadAllText(LoginPage.username + ".txt").Contains("doctor")) //Doctor Loginl; also checks the user's text file (if available) as to whether it contains "doctor" or not. If so, it lets them into the "dcotor" login.
                    {
                        List<user> users = getDoctors();
                        foreach (user user in users)
                        {
                            if (user.isValid(username, password) && username.All(char.IsDigit)) //Checks if user input matches the file AND if all characters are digits
                            {
                                Console.WriteLine("\nValid Credentials. Welcome " + username + ". " + "\nPress any key to continue.");
                                valid = true;
                                Console.ReadKey();
                                menu = new Menu(user);
                                Menu.Doctor();
                            }
                        }
                    }

                    else if (System.IO.File.ReadAllText(LoginPage.username + ".txt").Contains("receptionist"))//Receptionist Login
                    {
                        List<user> users = getReceptionist();
                        foreach (user user in users)
                        {
                            if (user.isValid(username, password) && username.All(char.IsDigit)) //Checks if user input matches the file AND if all characters are digits
                            {
                                Console.WriteLine("\nValid Credentials. Welcome " + username + "." +  "\nPress any key to continue.");
                                valid = true;
                                Console.ReadKey();
                                menu = new Menu(user);
                                Menu.Receptionist();
                            }
                        }
                    }
                    
                    if (menu == null || !username.All(char.IsDigit)) //Invalid input; either nothing has been input or the ID does not contain digits.
                    {
                        Console.WriteLine("\nInvalid credentials. \nPlease try again.");
                        Console.ReadKey();
                        Console.Clear();
                        loginPage();
                    }
                }
            }               
            
            catch (Exception e)//Should the user input invalid credentials (incorrect username, invalid characters, etc), this error will show up.
            {
                Console.WriteLine("\nInvalid credentials. \nPlease try again.");
                Console.ReadKey();
                loginPage();
            }
        }

        public string passwordMask()
        {
            string password = null;
            
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)//Deletes user input as well as *'s
                {
                    Console.Write("\b \b");
                    password = password.Substring(0,password.Length - 1); 
                }
                else if (key.Key != ConsoleKey.Backspace) //Adds *'s in place of the user's input, thus "masking" it.
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }
            return password;
        }

        public List<user> getAdmins()
        {
            String[] userInfo = System.IO.File.ReadAllLines("adminLoginDB.txt");
            List<user> users = new List<user>();
            //loops through all lines in the "adminLoginDB.txt" file to check if they are a valid user
            try
            {

                foreach (string i in userInfo)
                {
                    string[] temp = i.Split(',');
                    for (int g = 0; g < temp.Length; g = g + 2)
                    {
                        user user = new user(temp[g], temp[g + 1]); //Checks the adminLoginDB.txt file for valid inputs and whether or not the user input matches whatever's in the file
                        users.Add(user);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            return users;
        }

        public List<user> getPatients()
        {
            String[] userInfo = System.IO.File.ReadAllLines("patientLoginDB.txt");
            List<user> users = new List<user>();
            //loops through all lines in the "patientLoginDB.txt" file to check if they are a valid user
            try
            {

                foreach (string i in userInfo)
                {
                    string[] temp = i.Split(',');
                    for (int g = 0; g < temp.Length; g = g + 2)
                    {
                        user user = new user(temp[g], temp[g + 1]); //Checks the patientLoginDB.txt file for valid inputs and whether or not the user input matches whatever's in the file
                        users.Add(user);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            return users;
        }

        public List<user> getDoctors()
        {
            String[] userInfo = System.IO.File.ReadAllLines("doctorLoginDB.txt");
            List<user> users = new List<user>();
            //loops through all lines in the "doctorLoginDB.txt" file to check if they are a valid user
            try
            {

                foreach (string i in userInfo)
                {
                    string[] temp = i.Split(',');
                    for (int g = 0; g < temp.Length; g = g + 2)
                    {
                        user user = new user(temp[g], temp[g + 1]); //Checks the doctorLoginDB.txt file for valid inputs and whether or not the user input matches whatever's in the file
                        users.Add(user);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            return users;
        }

        public List<user> getReceptionist()
        {
            String[] userInfo = System.IO.File.ReadAllLines("receptionistLoginDB.txt");
            List<user> users = new List<user>();
            //loops through all lines in the "receptionistLoginDB.txt" file to check if they are a valid user
            try
            {

                foreach (string i in userInfo)
                {
                    string[] temp = i.Split(',');
                    for (int g = 0; g < temp.Length; g = g + 2)
                    {
                        user user = new user(temp[g], temp[g + 1]); //Checks the doctorLoginDB.txt file for valid inputs and whether or not the user input matches whatever's in the file
                        users.Add(user);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            return users;
        }


    }
}
