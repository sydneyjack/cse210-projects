using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>();

        Reference reference1 = new Reference("John", 3, 16);
        Scripture scripture1 = new Scripture(reference1,
            "For God so loved the world that he gave his only begotten Son");

        Reference reference2 = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture2 = new Scripture(reference2,
            "Trust in the Lord with all thine heart and lean not unto thine own understanding");

        Reference reference3 = new Reference("Psalm", 23, 1);
        Scripture scripture3 = new Scripture(reference3,
            "The Lord is my shepherd I shall not want");

        scriptures.Add(scripture1);
        scriptures.Add(scripture2);
        scriptures.Add(scripture3);

        Random random = new Random();
        Scripture selectedScripture = scriptures[random.Next(scriptures.Count)];

        while (!selectedScripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(selectedScripture.GetDisplayText());

            Console.WriteLine();
            Console.Write("Press Enter to continue or type quit: ");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            selectedScripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(selectedScripture.GetDisplayText());

        Console.WriteLine();
        Console.WriteLine("Program ended.");
    }
}