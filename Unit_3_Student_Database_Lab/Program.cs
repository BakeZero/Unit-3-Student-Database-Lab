using System;
using System.ComponentModel.Design;
using System.Text.Json;

class Program
{
    static void Main()
    {
        string[] name = new string[9] { "Harry", "Bill", "Mike", "Steve", "Payton", "Chris", "Emma", "Ashley", "Matt" };
        string[] hometown = new string[9] { "Dearborn Heights", "Grand Rapids", "Detroit", "Lansing", "Flint", "Chicago", "Ann Arbor", "Taylor", "Rochester" };
        string[] favoriteFood = new string[9] { "Pho", "Pizza", "Cheeseburgers", "Italian Sub", "Spaghetti", "Steak", "Tacos", "Wings", "Fajitas" };
        string continuePrompt = "y";

        Console.WriteLine("Welcome to the Student Database!");
        Console.Write("Would you like to display student list? (y/n): ");
        string prompt = Console.ReadLine();
        if (prompt == "y")
            DisplayStudents(name);

        do
        {
            Console.WriteLine("Which student would you like to learn more about? Enter a number 1-9 or name: ");
            int index;
            string input = Console.ReadLine();
            if (!int.TryParse(input, out index)) // If a name is inputted, return its index
                index = RetrieveIndex(input, name);
            else
                index--; // Adjusting to 0-based indexing if a number is inputted
            if (index < 0 || index > name.Length-1)
                Console.WriteLine("Invalid input. Please try again");
            else
            {
                Console.Write($"Student {index + 1} is {name[index]}. WHat would you like to know? Enter \"hometown\" or \"favorite food\": ");
                while (true)
                {
                    prompt = Console.ReadLine();
                    if (prompt.ToLower() == "hometown")
                    {
                        Console.WriteLine($"{name[index]} is from {hometown[index]}.");
                        break;
                    }
                    else if (prompt.ToLower() == "favorite food" || prompt.ToLower() == "food")
                    {
                        Console.WriteLine($"{name[index]}'s favorite food is {favoriteFood[index]}");
                        break;
                    }
                    else
                    {
                        Console.Write("That category does not exist. Please try again. Enter \"hometown\" or \"favorite food\": ");
                        continue;
                    }
                }
            }

            Console.Write("Would you like to learn about another student? (y/n): ");
            continuePrompt = Console.ReadLine();
        } while (continuePrompt == "y");
        Console.WriteLine("\nBye!");
    }

    static int RetrieveIndex(string input, string[] name)
    {
        for (int i  = 0; i < name.Length; i++)
        {
            if (name[i].ToLower() == input.ToLower())
                return i;
        }
        return -1;
    }

    static void DisplayStudents(string[] name)
    {
        Console.Write("List of students: (");
        for (int i = 0; i < name.Length; i++)
        {
            Console.Write(name[i]);
            if (i < name.Length - 1)
                Console.Write(", ");
        }
        Console.Write(")\n\n");
    }
}