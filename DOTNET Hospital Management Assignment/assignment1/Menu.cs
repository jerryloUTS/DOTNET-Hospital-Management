using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
using System.Runtime.ExceptionServices;
using System.Diagnostics.Tracing;
using System.Xml.Linq;
using System.Security.Policy;

namespace assignment1
{
    class Menu
    {
        public user username;
        public Menu(user users)
        {
            this.username = users;
        }
        public static string files = System.IO.File.ReadAllText(LoginPage.username + ".txt");
        public static string[] split = files.Split(',');
        public static void Admin()
        {
            int choice;
            LoginPage usernamea = new LoginPage();
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("|  DOTNET Hospital Management System |");
            Console.WriteLine("|------------------------------------|");
            Console.WriteLine("|         Administrator Menu         |");
            Console.WriteLine("╚════════════════════════════════════╝");
            files = System.IO.File.ReadAllText(LoginPage.username + ".txt");
            split = files.Split(',');
            Console.WriteLine("Welcome to DOTNET Hospital Management" + ", " + Menu.split[1] + " " + Menu.split[3]);
            Console.Write("Please Choose an option: \n");
            Console.Write("1. List All Doctors \n");
            Console.Write("2. Check Doctor Details \n");
            Console.Write("3. List All Patients \n");
            Console.Write("4. List Patient Details \n");
            Console.Write("5. Add Patient \n");
            Console.Write("6. Add doctor \n");
            Console.Write("7. Add receptionist \n");
            Console.Write("8. Logout \n");
            Console.Write("9. Exit System \n");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        displayAllDoctors();
                        Admin();
                        break;
                    case 2:
                        searchDoctor();
                        Admin();
                        break;
                    case 3:
                        displayAllPatients();
                        Admin();
                        break;
                    case 4:
                        searchPatient();
                        Admin();
                        break;
                    case 5:
                        createPatientAccount();
                        break;
                    case 6:
                        createDoctorAccount();
                        break;
                    case 7:
                        createReceptionistAccount();
                        break;
                    case 8:
                        LoginPage login = new LoginPage();
                        login.loginPage();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Admin();
                        break;
                }
            }
            catch (Exception e) //Returns menu in the event that the user inputs an invalid input.
            {
                Admin();
            }
        }
        public static int makeAccID()
        {
            for (int i = 10000; i < 9999999; i++) //generates code beginning from 10000
            {
                if (System.IO.File.Exists(i + ".txt")) //checks if a code with value 'i' exists in the name of a .txt file. for e.g., it checks if 10000.txt exists. if so, it does nothing. if not, it generates a code.
                {
                    //do nothing
                }
                else
                {
                    return i;
                }
            }
            return 0;
        }

        public static void Patient()
        {
            int choice;
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("|  DOTNET Hospital Management System |");
            Console.WriteLine("|------------------------------------|");
            Console.WriteLine("|           Patient Menu             |");
            Console.WriteLine("╚════════════════════════════════════╝");
            string[] accInfo = File.ReadAllLines(LoginPage.username + ".txt");
            for (int i = 0; i < 6; i++)
            {
                accInfo[i] = accInfo[i].Substring(accInfo[i].IndexOf(@",") + 1); //Gathers the information on the right of the comma on each line.
            }
            files = System.IO.File.ReadAllText(LoginPage.username + ".txt");
            split = files.Split(',');
            Console.WriteLine("Welcome to DOTNET Hospital Management" + ", " + accInfo[0] + " " + accInfo[1]);
            Console.Write("Please Choose an option: \n");
            Console.Write("1. List my Details \n");
            Console.Write("2. List my Doctor Details \n");
            Console.Write("3. List all appointments \n");
            Console.Write("4. Book Appointment \n");
            Console.Write("5. Logout \n");
            Console.Write("6. Exit System \n");

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        myDetails();
                        Patient();
                        break;
                    case 2:
                        Console.Clear();
                        myDoctorDetails();
                        Patient();
                        break;
                    case 3:
                        Console.Clear();
                        displayAllAppointments();
                        Patient();
                        break;
                    case 4:
                        Console.Clear();
                        bookAppointment();
                        Patient();
                        break;
                    case 5:
                        Console.Clear();
                        LoginPage login = new LoginPage();
                        login.loginPage(); //returns to login screen
                        break;
                    case 6:
                        Environment.Exit(0); //exits the program
                        break;
                    default:
                        Patient();
                        break;
                }
            }
            catch (Exception e)
            {
                Patient(); //in the event that the user input is not applicable, it returns them back to the menu.
            }
        }

        static public void Doctor()
        {
            int choice;
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("|  DOTNET Hospital Management System |");
            Console.WriteLine("|------------------------------------|");
            Console.WriteLine("|            Doctor Menu             |");
            Console.WriteLine("╚════════════════════════════════════╝");
            string[] accInfo = File.ReadAllLines(LoginPage.username + ".txt");
            for (int i = 0; i < 6; i++)
            {
                accInfo[i] = accInfo[i].Substring(accInfo[i].IndexOf(@",") + 1); //Gathers the information on the right of the comma on each line.
            }
            files = System.IO.File.ReadAllText(LoginPage.username + ".txt");
            split = files.Split(',');
            Console.WriteLine("Welcome to DOTNET Hospital Management" + ", " + accInfo[0] + " " + accInfo[1]);
            Console.Write("Please Choose an option: \n");
            Console.Write("1. List My Details \n");
            Console.Write("2. List My Patients \n");
            Console.Write("3. List Appointments \n");
            Console.Write("4. Check Individual Patient \n");
            Console.Write("5. List Patient Appointment(s) \n");
            Console.Write("6. Logout \n");
            Console.Write("7. Exit System \n");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        myDetails();
                        Doctor();
                        break;
                    case 2:
                        Console.Clear();
                        displayPatients();
                        Doctor();
                        break;
                    case 3:
                        Console.Clear();
                        displayMyAppointments();
                        Doctor();
                        break;
                    case 4:
                        searchPatient();
                        Doctor();
                        break;
                    case 5:
                        searchPatientAppointment();
                        Doctor();
                        break;
                    case 6:
                        LoginPage login = new LoginPage();
                        login.loginPage();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Doctor();
                        break;
                }
            }
            catch (Exception e)
            {
                Doctor(); //in the event that the user input is not applicable, it returns them back to the menu.
            }

        }

        public static void Receptionist()
        {
            int choice;
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("|  DOTNET Hospital Management System |");
            Console.WriteLine("|------------------------------------|");
            Console.WriteLine("|           Receptionist Menu        |");
            Console.WriteLine("╚════════════════════════════════════╝");
            string[] accInfo = File.ReadAllLines(LoginPage.username + ".txt");
            for (int i = 0; i < 6; i++)
            {
                accInfo[i] = accInfo[i].Substring(accInfo[i].IndexOf(@",") + 1); //Gathers the information on the right of the comma on each line.
            }
            files = System.IO.File.ReadAllText(LoginPage.username + ".txt");
            split = files.Split(',');
            Console.WriteLine("Welcome to DOTNET Hospital Management" + ", " + accInfo[0] + " " + accInfo[1]);
            Console.Write("Please Choose an option: \n");
            Console.Write("1. List all doctors \n");
            Console.Write("2. Search for doctor \n");
            Console.Write("3. List all patients \n");
            Console.Write("4. Search for patient \n");
            Console.Write("5. View All Appoinments \n");
            Console.Write("6. View Patient's Appoinments \n");
            Console.Write("7. Logout \n");
            Console.Write("8. Exit System \n");

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        displayAllDoctors();
                        Receptionist();
                        break;
                    case 2:
                        searchDoctor();
                        Receptionist();
                        break;
                    case 3:
                        displayAllPatients();
                        Receptionist();
                        break;
                    case 4:
                        searchPatient();
                        Receptionist();
                        break;
                    case 5:
                        displayAppointments();
                        Receptionist();
                        break;
                    case 6:
                        searchPatientAppointment();
                        Receptionist();
                        break;
                    case 7:
                        Console.Clear();
                        LoginPage login = new LoginPage();
                        login.loginPage(); //returns to login screen
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                    default:
                        Receptionist();
                        break;
                }
            }
            catch (Exception e)
            {
                Receptionist();
            }
        }

        public static void createPatientAccount()
        {
            Console.Clear();
            Console.WriteLine("Add Patient");
            Console.WriteLine("\nFirst Name:");
            string patientFname = Console.ReadLine();


            Console.WriteLine("\nSurname:");
            string patientSurname = Console.ReadLine();

            Console.WriteLine("\nPassword:");
            string patientPassword = Console.ReadLine();

            Console.WriteLine("\nE-Mail:");
            string patientEmail = inputEmail(); //rfers to inputEmail for valid input.

            Console.WriteLine("\nPhone:");
            string patientPhoneNum = Console.ReadLine();
            string patientPhone = patientPhoneNum;
            while (!patientPhone.All(char.IsDigit) || (!(patientPhone.Length == 10))) //Checks if the user input is both all digits and 10 characters long; if not, this while loop occurs.
            {
                Console.WriteLine("Invalid input. Please try again.");
                patientPhoneNum = Console.ReadLine();
                patientPhone = patientPhoneNum;
            }

            Console.WriteLine("\nStreet Number:");
            string patientAddressNum = Console.ReadLine();
            while (!patientAddressNum.All(char.IsDigit))
            {
                Console.WriteLine("Invalid input. Please try again.");
                patientAddressNum = Console.ReadLine();
            }
            Console.WriteLine("\nStreet:");
            string patientAddressStreet = Console.ReadLine();

            Console.WriteLine("\nCity:");
            string patientAddressCity = Console.ReadLine();

            Console.WriteLine("\nState:");
            string patientAddressState = Console.ReadLine();

            int accID = makeAccID();
            string[] accInfo = { "First Name," + patientFname + "\n" + "Surname," + patientSurname + "\n" + "Email," + patientEmail + "\n" + "Phone," + patientPhone + "\n" + "Address," + patientAddressNum + " " + patientAddressStreet + " " + patientAddressCity + " " + patientAddressState + "\n" + "patient" };
            System.IO.File.WriteAllLines(accID + ".txt", accInfo);
            string patientDetails = patientFname + "," + patientSurname + "," + patientEmail + "," + patientPhone + "," + patientAddressNum + " " + patientAddressStreet + " " + patientAddressCity + " " + patientAddressState;
            string patientLogin = accID + "," + patientPassword;
            File.AppendAllText("patientIdDB.txt", patientDetails + "\n"); //appends text into patientIdDB.txt
            File.AppendAllText("patientLoginDB.txt", patientLogin + "\n"); //appends text into patientLoginDB
            File.WriteAllText(accID + " appointment.txt", patientFname + " " + patientSurname + "," + "," + "," + ","); //appends text into their own appointment.txt file
            Console.WriteLine("\n" + patientFname + " " + patientSurname + " has been added to the system.");
            Console.WriteLine("The patient's new ID is: " + accID);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Admin();
        }

        public static void createDoctorAccount()
        {
            Console.Clear();
            Console.WriteLine("Add Doctor");
            Console.WriteLine("\nFirst Name:");
            string doctorFname = Console.ReadLine();

            Console.WriteLine("\nSurname:");
            string doctorSurname = Console.ReadLine();

            Console.WriteLine("\nPassword:");
            string doctorPassword = Console.ReadLine();

            Console.WriteLine("\nE-Mail:"); //rfers to inputEmail for valid input.
            string doctorEmail = inputEmail();

            Console.WriteLine("\nPhone:");
            string doctorPhoneNum = Console.ReadLine();
            string doctorPhone = doctorPhoneNum;
            while (!doctorPhone.All(char.IsDigit) || (!(doctorPhone.Length == 10))) //Checks if the user input is both all digits and 10 characters long; if not, this while loop occurs.
            {
                Console.WriteLine("Invalid input. Please try again.");
                doctorPhoneNum = Console.ReadLine();
                doctorPhone = doctorPhoneNum;
            }

            Console.WriteLine("\nStreet Number:");
            string doctorAddressNum = Console.ReadLine();
            while (!doctorAddressNum.All(char.IsDigit))
            {
                Console.WriteLine("\nInvalid input. Please try again.");
                doctorAddressNum = Console.ReadLine();
            }
            Console.WriteLine("\nStreet:");
            string doctorAddressStreet = Console.ReadLine();

            Console.WriteLine("\nCity:");
            string doctorAddressCity = Console.ReadLine();

            Console.WriteLine("\nState:");
            string doctorAddressState = Console.ReadLine();

            File.AppendAllText("doctorIdDB.txt", "");
            int accID = makeAccID();
            int count = File.ReadLines("doctorIdDB.txt").Count(); //Counts the number of lines in the file, and is used to add a counter of sorts to the beginning of the line with a +1 to mark the start of a new line
            string[] accInfo = { "First Name" + "," + doctorFname + "\n" + "Surname" + "," + doctorSurname + "\n" + "Email" + "," + doctorEmail + "\n" + "Phone" + "," + doctorPhone + "\n" + "Address" + "," + doctorAddressNum + " " + doctorAddressStreet + " " + doctorAddressCity + " " + doctorAddressState + "\n" + "doctor" + "\n" + accID };
            string doctorDetails = (count + 1) + "," + doctorFname + "," + doctorSurname + "," + doctorEmail + "," + doctorPhone + "," + doctorAddressNum + " " + doctorAddressStreet + " " + doctorAddressCity + " " + doctorAddressState + "," + accID;
            string doctorLogin = (accID + "," + doctorPassword);
            System.IO.File.WriteAllLines(accID + ".txt", accInfo);
            File.AppendAllText("doctorIdDB.txt", doctorDetails + "\n"); //appends text into doctorIdDB.txt
            File.AppendAllText("doctorLoginDB.txt", doctorLogin + "\n"); //appends text into doctorLoginDB
            File.WriteAllText(accID + " appointments.txt", ""); //appends text into doctorLoginDB
            File.WriteAllText(accID + " patients.txt", " "); //appends text into their own appointment.txt file
            Console.WriteLine("\n" + doctorFname + " " + doctorSurname + " has been added to the system.");
            Console.WriteLine("The doctors new ID is: " + accID);
            Console.WriteLine("Press key to continue");
            Console.ReadKey();
            Admin();
        }

        public static void createReceptionistAccount()
        {
            Console.Clear();
            Console.WriteLine("Add Receptionist");
            Console.WriteLine("First Name:");
            string recFname = Console.ReadLine();

            Console.WriteLine("\nSurname:");
            string recSurname = Console.ReadLine();

            Console.WriteLine("\nPassword:");
            string recPassword = Console.ReadLine();

            Console.WriteLine("\nE-Mail:"); //rfers to inputEmail for valid input.
            string recEmail = inputEmail();

            Console.WriteLine("\nPhone:");
            string recPhoneNum = Console.ReadLine();
            string recPhone = recPhoneNum;
            while (!recPhone.All(char.IsDigit) || (!(recPhone.Length == 10))) //Checks if the user input is both all digits and 10 characters long; if not, this while loop occurs.
            {
                Console.WriteLine("Invalid input. Please try again.");
                recPhoneNum = Console.ReadLine();
                recPhone = recPhoneNum;
            }

            Console.WriteLine("\nStreet Number:");
            string recAddressNum = Console.ReadLine();
            int recAddressNumber = Convert.ToInt32(recAddressNum);

            Console.WriteLine("\nStreet:");
            string recAddressStreet = Console.ReadLine();

            Console.WriteLine("\nCity:");
            string recAddressCity = Console.ReadLine();

            Console.WriteLine("\nState:");
            string recAddressState = Console.ReadLine();

            File.AppendAllText("receptionistIdDB.txt", "");
            Console.ReadLine();
            int accID = makeAccID();
            int count = File.ReadLines("receptionistIdDB.txt").Count(); //Counts the number of lines in the file, and is used to add a counter of sorts to the beginning of the line with a +1 to mark the start of a new line
            string[] accInfo = { "First Name" + "," + recFname + "\n" + "Surname" + "," + recSurname + "\n" + "Email" + "," + recEmail + "\n" + "Phone" + "," + recPhone + "\n" + "Address" + "," + recAddressNumber + " " + recAddressStreet + " " + recAddressCity + " " + recAddressState + "\n" + "receptionist" };
            System.IO.File.WriteAllLines(accID + ".txt", accInfo);
            string recDetails = recFname + "," + recSurname + "," + recEmail + "," + recPhone + "," + recAddressNumber + " " + recAddressStreet + " " + recAddressCity + " " + recAddressState + "," + accID;
            string recLogin = (accID + "," + recPassword);
            File.AppendAllText("receptionistIdDB.txt", recDetails + "\n"); //appends text into receptionistIdDB.txt
            File.AppendAllText("receptionistLoginDB.txt", recLogin + "\n"); //appends text into receptionistLoginDB
            Console.WriteLine("\n" + recFname + " " + recSurname + " has been added to the system.");
            Console.WriteLine("The receptionists new ID is: " + accID);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Admin();
        }

        public static void searchPatient()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("|     DOTNET Hospital Management System  |");
            Console.WriteLine("|----------------------------------------|");
            Console.WriteLine("|             Patient Search             |");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("Input patient ID:");
            string accID = Console.ReadLine();
            if (accID.All(char.IsDigit) && accID.Length > 0)
            {
                if (System.IO.File.Exists(accID + ".txt") && System.IO.File.ReadAllText(accID + ".txt").Contains("patient")) //Displays the patient should the folder/s contain the user input and said file contains "patient" which prevents the user from opening OTHER files, such as a doctors individual file or a receptionists individual file
                {
                    Console.WriteLine("\n\nPatient found.");
                    displayPatient(accID);
                }
                else
                {
                    Console.WriteLine("\n\nPatient not found. Would you like to try again? (Y/N)");
                    string input = Console.ReadLine();
                    if (input.Equals("y") || input.Equals("Y"))
                    {
                        searchPatient();
                    }
                    if (input.Equals("n") || input.Equals("N"))
                    {
                        //Exit to menu

                    }

                }
            }
            else
            {
                Console.WriteLine("\nInvalid input. All characters must be digits.");
                Console.WriteLine("Press any key to try again.");
                Console.ReadKey();
                searchPatient();
            }
        }


        public static void displayPatient(string accID) //Displays a specific patient according to the user input
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("|     DOTNET Hospital Management System  |");
            Console.WriteLine("|----------------------------------------|");
            Console.WriteLine("|             Patient Search             |");
            Console.WriteLine("╚════════════════════════════════════════╝");
            //takes information from the right of the "," character in the accInfo txt file
            string[] accInfo = File.ReadAllLines(accID + ".txt");
            string docInfo = File.ReadAllText(accID + " appointment.txt");
            string input1 = null;
            string[] docInfoSplit = docInfo.Split(',');
            for (int i = 0; i < 6; i++)
            {
                accInfo[i] = accInfo[i].Substring(accInfo[i].IndexOf(@",") + 1);
            }
            if (!string.IsNullOrEmpty(docInfoSplit[1]))
            {
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Patient Name: " + accInfo[0] + " " + accInfo[1]);
                Console.SetCursorPosition(0, 6);
                Console.WriteLine("Doctor: " + docInfoSplit[2] + " " + docInfoSplit[3]);
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("Email: " + accInfo[2]);
                Console.SetCursorPosition(0, 8);
                Console.WriteLine("Phone: " + accInfo[3]);
                Console.SetCursorPosition(0, 9);
                Console.WriteLine("Address: " + accInfo[4]);
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }

            if (string.IsNullOrEmpty(docInfoSplit[1]))
            {
                Console.WriteLine("Error found; user is not registered to a doctor. Would you like to try again? (Y/N)");
                input1 = Console.ReadLine();
                if (input1.Equals("y") || input1.Equals("Y"))
                {
                    searchPatient();
                }
                if (input1.Equals("n") || input1.Equals("N"))
                {
                    //Exit to menu
                }
            }
        }

        public static void searchPatientAppointment()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("|     DOTNET Hospital Management System  |");
            Console.WriteLine("|----------------------------------------|");
            Console.WriteLine("|           Appointment Search           |");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("Enter patient ID:");
            string accID = Console.ReadLine();
            if (accID.All(char.IsDigit) && accID.Length > 0) //ensures that the input are all digits (in the case of searching for patient IDs) as well as preventing empty inputs
            {
                if (System.IO.File.Exists(accID + " appointment.txt"))
                {
                    Console.WriteLine("\n\nPatient found.");
                    displayAppointment(accID);
                }
                if (!System.IO.File.Exists(accID + " appointment.txt"))
                {
                    Console.WriteLine("\nPatient not found. Would you like to try again? (Y/N)");
                    string input = Console.ReadLine();
                    if (input.Equals("y") || input.Equals("Y"))
                    {
                        searchPatientAppointment();
                    }
                    if (input.Equals("n") || input.Equals("N"))
                    {
                        //Exit to menu
                    }

                }
            }
            else
            {
                Console.WriteLine("\nInvalid input. All characters must be digits.");
                Console.WriteLine("Press any key to try again.");
                Console.ReadKey();
                searchPatientAppointment();
            }
        }

        public static void displayAppointment(string accID) //Displays a specific patient according to the user input
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("|     DOTNET Hospital Management System  |");
            Console.WriteLine("|----------------------------------------|");
            Console.WriteLine("|           Appointment Search           |");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("Patient" + "\t\t| " + "Doctor" + "\t\t| " + "Prescription");
            Console.WriteLine("---------------------------------------------------------");
            //takes information from the right of the "," character in the accInfo txt file
            List<string> docInfo = new List<string>();
            docInfo = File.ReadAllLines(accID + " appointment.txt").ToList();
            string doc = File.ReadAllText(accID + " appointment.txt");
            string[] docSplit = doc.Split(',');
            foreach (var line in docInfo)
            {
                string[] docInfoSplit = line.Split(',');
                Console.WriteLine(docInfoSplit[0] + " " + docInfoSplit[1] + "\t| " + docInfoSplit[2] + " " + docInfoSplit[3] + "\t\t| " + docInfoSplit[4]);
            }
            if (System.IO.File.ReadAllText(LoginPage.username + ".txt").Contains("doctor")) //Returns to the doctor menu should a doctor access this function.
            {
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
                Doctor();
            }
            if (System.IO.File.ReadAllText(LoginPage.username + ".txt").Contains("receptionist")) //Returns to the receptionist menu should a doctor access this function.
            {
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
                Receptionist();
            }
            if ((docSplit[2]).Contains("")) //Checks if the string in question is empty. If so, gives the error and returns to home screen.
            {
                Console.WriteLine("\nAppointments not found! Returning to home screen...");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }

        }

        public static void searchDoctor()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("|     DOTNET Hospital Management System  |");
            Console.WriteLine("|----------------------------------------|");
            Console.WriteLine("|             Doctor Details             |");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("doctorID:");
            string accID = Console.ReadLine();
            if (accID.All(char.IsDigit) && accID.Length > 0)
            {
                if (System.IO.File.Exists(accID + ".txt") && System.IO.File.ReadAllText(accID + ".txt").Contains("doctor"))
                {
                    Console.WriteLine("\n\nDoctor found.");
                    displayDoctor(accID);
                }
                else
                {
                    Console.WriteLine("\n\nDoctor not found. Would you like to try again? (Y/N)");
                    string input = Console.ReadLine();
                    if (input.Equals("y") || input.Equals("Y"))
                    {
                        searchDoctor();
                    }
                    if (input.Equals("n") || input.Equals("N"))
                    {
                        //Exit to menu
                    }

                }
            }
            else
            {
                Console.WriteLine("\nInvalid input. All characters must be digits.");
                Console.WriteLine("Press any key to try again.");
                Console.ReadKey();
                searchDoctor();
            }
        }

        public static void displayDoctor(string accID) //Displays a specific patient according to the user input.
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("|     DOTNET Hospital Management System  |");
            Console.WriteLine("|----------------------------------------|");
            Console.WriteLine("|             Doctor Details             |");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("Name: ");
            Console.WriteLine("Email: ");
            Console.WriteLine("Phone: ");
            Console.WriteLine("Address: ");
            //takes information from the right of the "," character in the accInfo txt file.
            string[] accInfo = File.ReadAllLines(accID + ".txt");
            for (int i = 0; i < 6; i++)
            {
                accInfo[i] = accInfo[i].Substring(accInfo[i].IndexOf(@",") + 1);
            }
            Console.SetCursorPosition(15, 5);
            Console.WriteLine(accInfo[0] + " " + accInfo[1]);
            Console.SetCursorPosition(15, 6);
            Console.WriteLine(accInfo[2]);
            Console.SetCursorPosition(15, 7);
            ; Console.WriteLine(accInfo[3]);
            Console.SetCursorPosition(15, 8);
            Console.WriteLine(accInfo[4]);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();

        }

        public static void displayAllPatients()
        {

            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("|     DOTNET Hospital Management System  |");
            Console.WriteLine("|----------------------------------------|");
            Console.WriteLine("|              All Patients              |");
            Console.WriteLine("╚════════════════════════════════════════╝");

            Console.WriteLine("Full Name" + "\t\t| " + "E-Mail" + "\t\t\t| " + "Phone Number" + "\t\t| " + "Address");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            try
            {
                var count = File.ReadAllLines("patientIdDB.txt").Count();
                //string[] file = fileA.Split(',');
                //string[] count1 = fileA.Split(' ');
                //string[] userInfo = File.ReadAllLines("patientIdDB.txt");
                List<string> userInfo = new List<string>();
                userInfo = File.ReadAllLines("patientIdDB.txt").ToList();

                foreach (var line in userInfo)
                {
                    string[] lineSplit = line.Split(',');
                    Console.WriteLine(lineSplit[0] + " " + lineSplit[1] + "\t\t| " + lineSplit[2] + "\t\t| " + lineSplit[3] + "\t\t| " + lineSplit[4]);
                    count++;
                }
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("\nPatients not found. Returning to home screen...");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }





            //String[] userInfo = System.IO.File.ReadAllLines("patientIdDB.txt")
            //for (int i = 0; i < count + 1; i++)
            //{
            //    var userInfo = System.IO.File.ReadLines("patientIdDB.txt" + i);
            //    Console.Write(i + 1 + ". " + "First Name: " + file[0] + " Surname: " + file[1] + " Email: " + file[2] + " Phone: " + file[3] + " Address: " + file[4] + "\n");
            //    Console.ReadKey();
            //}

            //int i = 0;
            //for (int j = 0; i < fileA.Length; j+=5)
            //{
            //    Console.Write(i + 1 + ". " + "First Name: " + file[j] + " Surname: " + file[j + 1] + " Email: " + file[j + 2] + " Phone: " + file[j + 3] + " Address: " + file[j + 4] + "\n");
            //    Console.ReadKey();
            //    i++;
            //}
        }

        public static void displayPatients()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("|     DOTNET Hospital Management System  |");
            Console.WriteLine("|----------------------------------------|");
            Console.WriteLine("|              My Patients               |");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("Full Name" + "\t\t| " + "Doctor" + "\t\t| " + "E-Mail" + "\t\t| " + "Phone Number" + "\t| " + "Address");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            if (!(new FileInfo(LoginPage.username + " appointments.txt").Length == 0))
            {
                string count = File.ReadAllText(LoginPage.username + ".txt");
                string[] countSplit = count.Split(',');
                List<string> userInfo = new List<string>();
                userInfo = File.ReadAllLines(LoginPage.username + " patients.txt").ToList();

                foreach (var line in userInfo)
                {
                    string[] lineSplit = line.Split(',');
                    Console.WriteLine(lineSplit[0] + " " + lineSplit[1] + "\t\t| " + lineSplit[2] + " " + lineSplit[3] + "\t\t| " + lineSplit[4] + "\t| " + lineSplit[5] + "\t| " + lineSplit[6]);

                }
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
            if ((new FileInfo(LoginPage.username + " appointments.txt").Length == 0))
            {
                Console.WriteLine("\nPatients not found. Returning to home screen...");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }

        }

        public static void displayAllDoctors()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("|     DOTNET Hospital Management System  |");
            Console.WriteLine("|----------------------------------------|");
            Console.WriteLine("|              All Doctors               |");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("Full Name" + "\t\t| " + "E-Mail" + "\t\t\t| " + "Phone Number" + "\t\t| " + "Address");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            try
            {
                string count = File.ReadAllText(LoginPage.username + ".txt");
                string[] countSplit = count.Split(',');
                List<string> userInfo = new List<string>();
                userInfo = File.ReadAllLines("doctorIdDB.txt").ToList();

                foreach (var line in userInfo)
                {
                    string[] lineSplit = line.Split(',');
                    Console.WriteLine(lineSplit[1] + " " + lineSplit[2] + "\t\t| " + lineSplit[3] + "\t\t| " + lineSplit[4] + "\t\t| " + lineSplit[5]);

                }
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("\nDoctors not found. Returning to home screen...");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }



            //String[] userInfo = System.IO.File.ReadAllLines("patientIdDB.txt")
            //for (int i = 0; i < count + 1; i++)
            //{
            //    var userInfo = System.IO.File.ReadLines("patientIdDB.txt" + i);
            //    Console.Write(i + 1 + ". " + "First Name: " + file[0] + " Surname: " + file[1] + " Email: " + file[2] + " Phone: " + file[3] + " Address: " + file[4] + "\n");
            //    Console.ReadKey();
            //}

            //int i = 0;
            //for (int j = 0; i < fileA.Length; j+=5)
            //{
            //    Console.Write(i + 1 + ". " + "First Name: " + file[j] + " Surname: " + file[j + 1] + " Email: " + file[j + 2] + " Phone: " + file[j + 3] + " Address: " + file[j + 4] + "\n");
            //    Console.ReadKey();
            //    i++;
            //}
        }

        public static void displayAllAppointments()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("|     DOTNET Hospital Management System  |");
            Console.WriteLine("|----------------------------------------|");
            Console.WriteLine("|              Appointments              |");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("Full Name               | Doctor                        | Prescription");
            string[] userInfo = null;
            userInfo = File.ReadAllLines(LoginPage.username + " appointment.txt");
            string user = File.ReadAllText(LoginPage.username + " appointment.txt");
            string[] userSplit = user.Split(',');
            if (string.IsNullOrEmpty(userSplit[3])) //Checks if the file is empty (via checking the length.) If so, gives the error and returns to home screen.
            {
                Console.WriteLine("\nAppointments not found. Returning to home screen...");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
            if (!(string.IsNullOrEmpty(userSplit[2])))
            {
                foreach (var line in userInfo)
                {
                    string[] lineSplit = line.Split(',');
                    Console.WriteLine(lineSplit[0] + " " + lineSplit[1] + "\t\t| " + lineSplit[2] + " " + lineSplit[3] + "\t\t\t| " + lineSplit[4]);
                }
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }



        }

        public static void displayAppointments()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("|     DOTNET Hospital Management System  |");
            Console.WriteLine("|----------------------------------------|");
            Console.WriteLine("|              Appointments              |");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("Full Name" + "\t\t| " + "Doctor" + "\t\t| " + "Prescription");
            Console.WriteLine("---------------------------------------------------------------");
            //string[] file = fileA.Split(',');
            //string[] count1 = fileA.Split(' ');

            //string[] userInfo = File.ReadAllLines("patientIdDB.txt");
            string[] userInfo = null;
            userInfo = File.ReadAllLines("appointments.txt");
            foreach (var line in userInfo)
            {
                string[] lineSplit = line.Split(',');
                Console.WriteLine(lineSplit[0] + " " + lineSplit[1] + "\t\t| " + lineSplit[2] + " " + lineSplit[3] + "\t\t| " + lineSplit[4]);
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Receptionist();
            if (new FileInfo(LoginPage.username + " appointment.txt").Length == 0) //Checks if the file is empty (via checking the length.) If so, gives the error and returns to home screen.
            {
                Console.WriteLine("\nAppointments not found. Returning to home screen...");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }

        }

        public static void bookAppointment()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("|     DOTNET Hospital Management System  |");
            Console.WriteLine("|----------------------------------------|");
            Console.WriteLine("|           Appointment Booking          |");
            Console.WriteLine("╚════════════════════════════════════════╝");
            var doctors = System.IO.File.ReadLines("doctorIdDB.txt");
            var doctorID = System.IO.File.ReadLines("doctorLoginDB.txt");
            string checkDoctor = File.ReadAllText(LoginPage.username + " appointment.txt");
            string doctorIDSplit = File.ReadAllText("doctorIdDB.txt");
            string doctorSplit = File.ReadAllText("doctorIdDB.txt");
            string doctor;
            string[] dSplit = doctorSplit.Split(',');
            string[] dIDSplit = doctorIDSplit.Split(',');
            string[] checkSplit = checkDoctor.Split(',');
            string[] accInfo = File.ReadAllLines(LoginPage.username + ".txt");
            int doctorChoice;

            for (int i = 0; i < 6; i++)
            {
                accInfo[i] = accInfo[i].Substring(accInfo[i].IndexOf(@",") + 1);
            }

            var count = File.ReadAllLines("doctorIdDB.txt").Count();
            //string[] file = fileA.Split(',');
            //string[] count1 = fileA.Split(' ');

            //string[] userInfo = File.ReadAllLines("patientIdDB.txt");

            List<string> userInfo = new List<string>();
            userInfo = File.ReadAllLines("doctorIdDB.txt").ToList();

            foreach (var line in userInfo)
            {
                string[] lineSplit = line.Split(',');
                string[] lineSplits = line.Split(' ');
                Console.WriteLine(lineSplit[0] + "\t" + lineSplit[1] + "\t" + lineSplit[2] + "\t" + lineSplit[3] + "\t" + lineSplit[4] + "\t" + lineSplit[5]);
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            if (string.IsNullOrEmpty(checkSplit[2]))
            {
                Console.WriteLine("\nWhich doctor would you like to select for your appointment? Type in the corresponding number in front.");
                doctor = Console.ReadLine();
                doctorChoice = Convert.ToInt32(doctor);
                string line = File.ReadLines("doctorIdDB.txt").ElementAt(doctorChoice - 1); //Selects the specific element via the user's choice, and takes 1 from said choice. e.g. if the user picks 1, it deducts 1 and chooses element 0.
                string[] doctorLineSplit = line.Split(',');
                Console.WriteLine("You have selected: " + doctorLineSplit[1] + " " + doctorLineSplit[2]);
                int accID = makeAccID();
                Console.WriteLine("Enter your reason for this appointment: ");
                string reason = Console.ReadLine();
                string[] appInfo = { accInfo[0] + "," + accInfo[1] + "," + doctorLineSplit[1] + "," + doctorLineSplit[2] + "," + reason + "," + doctorLineSplit[6] + "," };
                string[] name = { accInfo[0] + "," + accInfo[1] + "," + doctorLineSplit[1] + "," + doctorLineSplit[2] + "," + accInfo[2] + "," + accInfo[3] + "," + accInfo[4] + "," };
                System.IO.File.AppendAllLines("appointments.txt", appInfo);
                System.IO.File.WriteAllLines(LoginPage.username + " appointment.txt", appInfo);
                System.IO.File.AppendAllLines(doctorLineSplit[6] + " appointments.txt", appInfo);
                System.IO.File.AppendAllLines(doctorLineSplit[6] + " patients.txt", name);
                Console.WriteLine("The appointment has been booked successfully");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }

            if (!string.IsNullOrEmpty(checkSplit[1]))  //for when the patient already has a doctor selected, it takes them straight to the booking system without requiring them to pick a new doctor
            {
                string line = File.ReadAllText(LoginPage.username + " appointment.txt");
                string[] doctorLineSplit = line.Split(',');
                Console.WriteLine("Your currently registered doctor is: " + doctorLineSplit[2] + " " + doctorLineSplit[3]);
                int accID = makeAccID();
                Console.WriteLine("Enter your reason for this appointment: ");
                string reason = Console.ReadLine();
                string[] appInfo = { accInfo[0] + "," + accInfo[1] + "," + doctorLineSplit[2] + "," + doctorLineSplit[3] + "," + reason + "," + doctorLineSplit[5] + "," };
                System.IO.File.AppendAllLines("appointments.txt", appInfo);
                System.IO.File.AppendAllLines(LoginPage.username + " appointment.txt", appInfo);
                System.IO.File.AppendAllLines(doctorLineSplit[5] + " appointments.txt", appInfo);
                Console.WriteLine("The appointment has been booked successfully");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }

            /*if (System.IO.File.ReadAllText("doctorIdDB.txt").Contains(doctor))
            {
                string line = File.ReadLines("doctorIdDB.txt").ElementAt(doctorChoice - 1);
                string[] doctorLineSplit = line.Split(',');
                Console.WriteLine(line);
                int accID = makeAccID();
                Console.WriteLine("Enter your reason for this appointment: ");
                string reason = Console.ReadLine();
                string[] appInfo = { accInfo[0] + " " + accInfo[1] + "," + doctorLineSplit[1] + "," + doctorLineSplit[2] + "," + reason };
                System.IO.File.AppendAllLines("appointments.txt", appInfo);
                System.IO.File.AppendAllLines(LoginPage.username + " appointment.txt", appInfo);
                Console.WriteLine("The appointment has been booked successfully");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            if (!System.IO.File.ReadAllText("doctorIdDB.txt").Contains(doctor))
            {
                Console.WriteLine("Doctor not found. Please try again.");
                Patient();
            }*/

        }

        public static void displayMyAppointments()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("|     DOTNET Hospital Management System  |");
            Console.WriteLine("|----------------------------------------|");
            Console.WriteLine("|            My Appointments             |");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("Name \t\t\t| Doctor \t\t| Prescription \t\t");
            Console.WriteLine("-----------------------------------------------------------");
            //string[] file = fileA.Split(',');
            //string[] count1 = fileA.Split(' ');

            //string[] userInfo = File.ReadAllLines("patientIdDB.txt");
            List<string> userInfo = new List<string>();
            userInfo = File.ReadAllLines(LoginPage.username + " appointments.txt").ToList();
            if (!(new FileInfo(LoginPage.username + " appointments.txt").Length == 0))
            {
                foreach (var line in userInfo)
                {
                    string[] lineSplit = line.Split(',');
                    Console.WriteLine(lineSplit[0] + " " + lineSplit[1] + " \t\t| " + lineSplit[2] + " " + lineSplit[3] + " \t\t| " + lineSplit[4]);
                }
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
            if ((new FileInfo(LoginPage.username + " appointments.txt").Length == 0))
            {
                Console.WriteLine("\nAppointments not found. Returning to home screen...");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }





        //String[] userInfo = System.IO.File.ReadAllLines("patientIdDB.txt")
        //for (int i = 0; i < count + 1; i++)
        //{
        //    var userInfo = System.IO.File.ReadLines("patientIdDB.txt" + i);
        //    Console.Write(i + 1 + ". " + "First Name: " + file[0] + " Surname: " + file[1] + " Email: " + file[2] + " Phone: " + file[3] + " Address: " + file[4] + "\n");
        //    Console.ReadKey();
        //}

        //int i = 0;
        //for (int j = 0; i < fileA.Length; j+=5)
        //{
        //    Console.Write(i + 1 + ". " + "First Name: " + file[j] + " Surname: " + file[j + 1] + " Email: " + file[j + 2] + " Phone: " + file[j + 3] + " Address: " + file[j + 4] + "\n");
        //    Console.ReadKey();
        //    i++;
        //}



        public static string inputEmail()
        {
            bool valid = false;
            string email = null;
            while (valid == false)
            {
                email = Console.ReadLine();
                if ((email.Contains("@hotmail.com") || (email.Contains("@gmail.com") || email.Contains("@outlook.com") || email.Contains("@uts.edu.au"))))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please put a valid email.");

                    for (int i = 0; i < email.Length; i++) //Removes the characters that were previously written.
                    {
                        Console.Write("\b \b");
                    }
                }
            }
            return email;
        }
        public static string myDetails()
        {
            string myDetails = null;
            myDetails = System.IO.File.ReadAllText(LoginPage.username + ".txt"); //Reads all text from the text file with the logged in user's ID.     
            split = myDetails.Split(','); //Splits said file wherever there is a comma.
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("|     DOTNET Hospital Management System  |");
            Console.WriteLine("|----------------------------------------|");
            Console.WriteLine("|              My Details                |");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("------------------------------------------");
            string[] accInfo = File.ReadAllLines(LoginPage.username + ".txt");
            try
            {
                {
                    for (int i = 0; i < 6; i++)
                    {
                        accInfo[i] = accInfo[i].Substring(accInfo[i].IndexOf(@",") + 1);
                    }
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("Full name: " + accInfo[0] + " " + accInfo[1]);
                    Console.SetCursorPosition(0, 7);
                    Console.WriteLine("Email: " + accInfo[2]);
                    Console.SetCursorPosition(0, 8);
                    Console.WriteLine("Phone Number: " + accInfo[3]);
                    Console.SetCursorPosition(0, 9);
                    Console.WriteLine("Address: " + accInfo[4]);
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Unable to load your details. Returning to home.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            return myDetails;
        }
        public static string myDoctorDetails()
        {
            string myDoctorDetails = null;
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("|     DOTNET Hospital Management System  |");
            Console.WriteLine("|----------------------------------------|");
            Console.WriteLine("|            My Doctor Details           |");
            Console.WriteLine("╚════════════════════════════════════════╝");
            try
            {
                myDoctorDetails = System.IO.File.ReadAllText(LoginPage.username + " appointment.txt");
                string[] myDocDetailsSplit = myDoctorDetails.Split(',');
                string[] myDoc = System.IO.File.ReadAllLines(myDocDetailsSplit[5] + ".txt");
                for (int i = 0; i < 6; i++)
                {
                    myDoc[i] = myDoc[i].Substring(myDoc[i].IndexOf(@",") + 1);
                }

                Console.WriteLine("Name: " + myDoc[0] + " " + myDoc[1]);
                Console.WriteLine("Email: " + myDoc[2]);
                Console.WriteLine("Phone Number: " + myDoc[3]);
                Console.WriteLine("Address: " + myDoc[4]);
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error; no doctor found. Returning to home. \n\nPress any key to continue.");
                Console.ReadKey();
            }
            return myDoctorDetails;
        }
    }
}

