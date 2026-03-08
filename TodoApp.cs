using System; // Ger tillgång till funktioner som Console
using System.Collections.Generic; // Ger tillgång till List<T>

class Program
{
    static void Main()
    {
        //Skapar en lista som ska innehålla alla uppgifter
        List<string> tasks = new List<string>();

        // Om true så fortsätter den köra programmet
        bool running = true;

        // Vi använder running för att bestämma om programmet ska fortsätta köras eller inte
        // Och ger användaren några val som den kan göra.
        while (running)
        {
            ShowMenu();

            // Användarens inmatning för att välja ett alternativ
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask(tasks);
                    break;
                case "2":
                    ShowTasks(tasks);
                    break;
                case "3":
                    RemoveTask(tasks);
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Programmet avslutas.");
                    break;

                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
    }


    // Metod för att visa alla uppgifter i listan
    static void ShowMenu()
    {
        Console.WriteLine(Environment.NewLine + "--- TODO APP ---");
        Console.WriteLine("1. Lägg till en uppgift");
        Console.WriteLine("2. Visa alla uppgifter");
        Console.WriteLine("3. Ta bort en uppgift");
        Console.WriteLine("4. Avsluta programmet");
        Console.Write("Välj ett alternativ: ");
    }

    // Metoden för att lägga till uppgifter i listan
    static void AddTask(List<string> tasks)
    {
        // Ställer användaren en fråga
        Console.Write("Skriv en uppgift du vill lägga till: ");
        // Låter användaren mata in en uppgift och sparar det i 'task' variabeln
        string task = Console.ReadLine();
        
        if (!string.IsNullOrWhiteSpace(task))
        {
            // lägger till uppgiften i listan
            tasks.Add(task);
            Console.WriteLine("Uppgiften har lagts till.");
        }
        else
        {
            Console.WriteLine("Uppgiften kan inte vara tom, försök igen.");
        }
    }

    static void ShowTasks(List<string> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Inga uppgifter");
        }
        else
        {
            // i är noll
            // Vi kontrollerar så att i är mindren antal saker i listan
            // efter varje kontroll plussar vi med i och loopen fortsätter tills i är mer än taks alltså listan
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
    }


    static void RemoveTask(List<string> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Inga uppgifter att ta bort.");
            return;
        }
        Console.Write("Skriv numret på uppgiften du vill ta bort: ");

        // Låter användaren mata in numret på uppgiften som de vill ha bort och sparar i 'input' variabeln
        string input = Console.ReadLine();

        // Försöker konvertera användarens inmatning till ett heltal och sparar det i 'index' variabeln
        // Och om det inte går att konvertera så kommer det inte att gå in i if-satsen och därmed inte försöka ta bort en uppgift
        if (int.TryParse(input, out int index))
        {
            index = index - 1;

            if (index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
                Console.WriteLine("Uppgiften har tagits bort.");
            }
            else
            {
                Console.WriteLine("Ogiltigt nummer, försök igen.");
            }
        }

    }

}