using System;
using System.IO;
namespace ums_model
{
    /// <summary>
    /// Method responsible for displaying the user interface
    /// </summary>
    public class UserUI
    {

        // Instanciating the users queue class
        UserQueueClass<string> userList = new UserQueueClass<string>();

        string fname;
        string lname;
        string email;
        string favfood;
        public void UI()
        {
            bool AppRunning = true;
            while (AppRunning)
            {
                // int code;
                System.Console.ForegroundColor = ConsoleColor.DarkBlue;
                System.Console.WriteLine();

                System.Console.WriteLine("Welcome to Ruqayat's User Management System Model");
                System.Console.WriteLine("---------------------------------------------------");
                System.Console.WriteLine("Press 1 to enter your details");
                System.Console.WriteLine("Press 2 to see all entries");
                System.Console.WriteLine("Press 3 to save changes");
                System.Console.WriteLine("Press 4 to dequeue first user");
                System.Console.WriteLine("Press 5 to see number of users on queue");
                System.Console.WriteLine("Press 0 to exit the application");
                System.Console.WriteLine("-----------------------------------------------------------------");
                System.Console.WriteLine();

                var userInput = System.Console.ReadLine();
                System.Console.Clear();
                switch (userInput)
                {
                    case "1":
                        System.Console.WriteLine();
                        System.Console.WriteLine("Enter your first name:");
                        fname = System.Console.ReadLine();
                        while (string.IsNullOrEmpty(fname))
                        {
                            System.Console.WriteLine("First Name can't be empty! Please Input your first name:");
                            fname = System.Console.ReadLine();
                        }

                        System.Console.WriteLine();
                        System.Console.WriteLine("Enter your last name:");
                        lname = System.Console.ReadLine();
                        while (string.IsNullOrEmpty(lname))
                        {
                            System.Console.WriteLine("Last Name can't be empty! Please Input your last name:");
                            lname = System.Console.ReadLine();
                        }

                        System.Console.WriteLine();
                        System.Console.WriteLine("Enter your email address:");
                        email = System.Console.ReadLine();
                        if (string.IsNullOrEmpty(email))
                        {
                            System.Console.WriteLine("Email can't be empty! Please Input your email address:");
                            email = System.Console.ReadLine();
                        }

                        System.Console.WriteLine();
                        System.Console.WriteLine("Enter your favourite food:");
                        favfood = System.Console.ReadLine();
                        if (string.IsNullOrEmpty(favfood))
                        {
                            System.Console.WriteLine("Favourite food can't be empty! Please Input your favourite food:");
                            favfood = System.Console.ReadLine();
                        }

                        // Enqueueing a new user into the queue class
                        userList.Enqueue(fname, lname, email, favfood);
                        System.Console.WriteLine();
                        System.Console.WriteLine("press any key to continue...");
                        System.Console.ReadLine();
                        break;

                    case "2":
                        userList.SeeUserList();
                        System.Console.WriteLine("press any key to continue...");
                        System.Console.ReadLine();
                        break;

                    case "3":
                        WriteFileAtEndAsync();
                        System.Console.WriteLine("User saved successfully!");
                        System.Console.WriteLine();
                        System.Console.WriteLine("press any key to continue...");
                        System.Console.ReadLine();
                        break;

                    case "4":
                        System.Console.WriteLine("User " + userList.Dequeue() + " removed");
                        break;

                    case "5":
                        System.Console.WriteLine("There are " + userList.Count + "users on the queue now.");
                        System.Console.WriteLine();
                        break;

                    case "0":
                        WriteFileAtEndAsync();
                        System.Console.WriteLine("Goodbye!");
                        AppRunning = false;
                        break;


                    default:
                        Console.Clear();
                        break;
                }

            }
        }
        string FilePath = @"../ums_model/UserList.txt";

        public async void WriteFileAtEndAsync()
        {
             StreamWriter sw = File.CreateText(FilePath);
             await sw.DisposeAsync();

            using (StreamWriter streamWriter = File.AppendText(FilePath))
            {
                var Temp = userList.Head;
                while (Temp != null)
                {
                    await streamWriter.WriteLineAsync(Temp.FirstName + "," + Temp.LastName + "," + Temp.Email + "," + Temp.FavFood);
                
                // userList.Dequeue();
                Temp = Temp.Next;
                }
                

            }
        }

        public async void ReadFileAtStartAsync()
        {
            if (!File.Exists(FilePath))
            {
                using StreamWriter sw = File.CreateText(FilePath);

                return;
            }
            else
            {
                using (StreamReader strmrd = File.OpenText(FilePath))
                {

                    var read = await strmrd.ReadToEndAsync();
                    read = read.TrimEnd();
                    if (string.IsNullOrEmpty(read))
                    {
                        System.Console.WriteLine("No user registered");
                        return;
                    }

                    var users = read.Split(Environment.NewLine);

                    foreach (var item in users)
                    {
                        var user = item.Split(',');
                        var fname = user[0];
                        var lname = user[1];
                        var email = user[2];
                        var favfood = user[3];

                        userList.Enqueue(fname, lname, email, favfood);
                    }
                }
            }
        }
    }
}