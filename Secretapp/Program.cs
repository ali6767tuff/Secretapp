using System;
using System.Threading;

namespace SecretApp
{
    internal class Program
    {
        static string[] userNames = { "Pelle", "Stina", "Ali" };
        static string[] userPasswords = { "1234", "12345", "12346" };
        static int loggedInIndex = -1;

        static void Main(string[] args)
        {
            Console.WriteLine("Hej och välkommen till SecretApp!");
            Menu();

            bool runProgram = true;

            while (runProgram)
            {
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 1)
                        LoggIn();
                    else if (choice == 2)
                        AddUser();
                    else if (choice == 3)
                        DeleteUser();
                    else if (choice == 4)
                        ChangePassword();
                    else if (choice == 5)
                        ShowUsers();
                    else if (choice == 9)
                        Menu();
                    else if (choice == 0)
                        runProgram = false;
                }
                else
                {
                    Console.WriteLine("Välj ett nummer från menyn.");
                }
            }

            Console.WriteLine("Hej då.");
            Thread.Sleep(2000);
        }

        static void LoggIn()
        {
            Console.WriteLine("Inloggning");

            Console.Write("Namn: ");
            string name = Console.ReadLine();

            Console.Write("Lösenord: ");
            string password = Console.ReadLine();

            int hit = Array.IndexOf(userNames, name);

            if (hit == -1)
            {
                Console.WriteLine("Användaren finns inte.");
                return;
            }

            if (userPasswords[hit] == password)
            {
                Console.WriteLine("Välkommen " + name);
                loggedInIndex = hit;
            }
            else
            {
                Console.WriteLine("Fel lösenord.");
            }
        }

        static void AddUser()
        {
            string[] tempNames = new string[userNames.Length + 1];
            string[] tempPasswords = new string[userPasswords.Length + 1];

            Console.Write("Skriv namnet på den du vill lägga till: ");
            string name = Console.ReadLine();

            Console.Write("Välj ett lösenord: ");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Namn och lösenord får inte vara tomt.");
                return;
            }

            if (Array.IndexOf(userNames, name) != -1)
            {
                Console.WriteLine("Användarnamnet finns redan.");
                return;
            }

            int i = 0;
            while (i < userNames.Length)
            {
                tempNames[i] = userNames[i];
                tempPasswords[i] = userPasswords[i];
                i++;
            }

            tempNames[tempNames.Length - 1] = name;
            tempPasswords[tempPasswords.Length - 1] = password;

            userNames = tempNames;
            userPasswords = tempPasswords;

            Console.WriteLine("Användaren är tillagd.");
        }

        static void DeleteUser()
        {
            if (loggedInIndex == -1)
            {
                Console.WriteLine("Du måste logga in först.");
                return;
            }

            if (userNames.Length <= 1)
            {
                Console.WriteLine("Du kan inte radera den sista användaren.");
                return;
            }

            Console.Write("Skriv ditt lösenord för att bekräfta borttagning: ");
            string password = Console.ReadLine();

            if (userPasswords[loggedInIndex] != password)
            {
                Console.WriteLine("Fel lösenord.");
                return;
            }

            string[] tempNames = new string[userNames.Length - 1];
            string[] tempPasswords = new string[userPasswords.Length - 1];

            int i = 0;
            int j = 0;

            while (i < userNames.Length)
            {
                if (i == loggedInIndex)
                {
                    i++;
                    continue;
                }

                tempNames[j] = userNames[i];
                tempPasswords[j] = userPasswords[i];

                i++;
                j++;
            }

            userNames = tempNames;
            userPasswords = tempPasswords;

            loggedInIndex = -1;

            Console.WriteLine("Kontot är borttaget och du är utloggad.");
        }

        static void ChangePassword()
        {
            if (loggedInIndex == -1)
            {
                Console.WriteLine("Du måste logga in först.");
                return;
            }

            Console.Write("Skriv nuvarande lösenord: ");
            string current = Console.ReadLine();

            if (userPasswords[loggedInIndex] != current)
            {
                Console.WriteLine("Fel nuvarande lösenord.");
                return;
            }

            Console.Write("Skriv nytt lösenord: ");
            string newPassword = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                Console.WriteLine("Nytt lösenord får inte vara tomt.");
                return;
            }

            userPasswords[loggedInIndex] = newPassword;

            Console.WriteLine("Lösenordet är ändrat.");
        }

        static void ShowUsers()
        {
            int i = 0;

            while (i < userNames.Length)
            {
                if (i == loggedInIndex)
                    Console.WriteLine(userNames[i].ToUpper() + " (INLOGGAD)");
                else
                    Console.WriteLine(userNames[i].ToUpper());

                i++;
            }
        }

        static void Menu()
        {
            Console.WriteLine(
                "\n1. Logga in\n" +
                "2. Lägg till användare\n" +
                "3. Ta bort användare\n" +
                "4. Ändra lösenord\n" +
                "5. Visa användarlista\n" +
                "9. Visa menyn\n" +
                "0. Avsluta\n");
        }
    }
}
