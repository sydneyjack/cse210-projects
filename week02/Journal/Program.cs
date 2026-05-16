using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator prompts = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("Choose: ");

            string input = Console.ReadLine();

            if (input == "1")
            {
                string prompt = prompts.GetRandomPrompt();
                Console.WriteLine(prompt);

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = Console.ReadLine();

                journal.AddEntry(entry);
            }

            else if (input == "2")
            {
                journal.DisplayAll();
            }

            else if (input == "3")
            {
                Console.Write("Filename: ");
                journal.SaveToFile(Console.ReadLine());
            }

            else if (input == "4")
            {
                Console.Write("Filename: ");
                journal.LoadFromFile(Console.ReadLine());
            }

            else if (input == "5")
            {
                break;
            }
        }
    }
}