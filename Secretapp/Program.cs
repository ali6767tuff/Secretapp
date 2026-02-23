namespace SecretApp
{
    internal class Program
    {
        static string[] userNames = { "Pelle", "Stina", "Ali" };
        static string[] userPasswords = { "1234", "12345", "12346" };

        static void Main(string[] args)
        {
            // något kul
            Console.WriteLine("Hej");
            Menu();
            bool runRrogram = true;
            while (runRrogram)
            {
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 1)
                    {
                        LoggIn();
                    }
                    else if (choice == 2)
                    {
                        AddUser();
                    }
                    else if (choice == 3)
                    {
                        DeleteUser();
                    }
                    else if (choice == 4)
                    {
                        ChangePassword();
                    }
                    else if (choice == 5)
                    {
                        ShowUsers();
                    }
                    else if (choice == 9)
                    {
                        Menu();
                    }
                    else if (choice == 0)
                    {
                        runRrogram = false;
                    }
                }

                else
                {
                    Console.WriteLine("Välj i menyn");
                }
            }
            Console.WriteLine("Hej då.");
            Thread.Sleep(3000);
        }

        //TODO Fixa att lägga till en användare
        static void AddUser()
        {
            Console.WriteLine("Hello from AddUser()");
        }

        //TODO Fixa att ta bort en användare
        static void DeleteUser()
        {
            Console.WriteLine("Hello from DeleteUser()");
        }

        static void ShowUsers()
        {
            int i = 0;
            while (i < userNames.Length)
            {
                Console.WriteLine(userNames[i].ToUpper());
                i++;
            }
        }

        //TODO Fixa att man ska kunna logga in
        static void LoggIn()
        {
            Console.WriteLine("Hello from LogIn");
        }

        //TODO Fixa att en användare ska kunna ändra lösenord
        static void ChangePassword()
        {
            Console.WriteLine("Hello from ChangePassword()");
        }

        static void Menu()
        {
            Console.WriteLine("" +
                "1. Logga in\r\n" +
                "2. Lägg till användare\r\n" +
                "3. Ta bort användare\r\n" +
                "4. Ändra lösenord\r\n" +
                "5. Visa användarlista\r\n" +
                "9. visa mennyn\r\n" +
                "0. Avsluta\r\n");
        } 
    } 
}