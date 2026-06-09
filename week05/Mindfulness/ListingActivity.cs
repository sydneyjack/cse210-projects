using System;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base(
            "Listing",
            "This activity helps you reflect on good things in your life."
        )
    {
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();

        return _prompts[random.Next(_prompts.Count)];
    }

    public void Run()
    {
        StartActivity();

        Console.WriteLine("\nList as many responses as you can:");

        Console.WriteLine($"\n--- {GetRandomPrompt()} ---");

        Console.Write("\nYou may begin in: ");
        ShowCountdown(5);

        List<string> items = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"\nYou listed {items.Count} items.");

        EndActivity();
    }
}