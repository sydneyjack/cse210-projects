using System;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
        : base(
            "Reflection",
            "This activity helps you reflect on times when you have shown strength and resilience."
        )
    {
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        return _questions[random.Next(_questions.Count)];
    }

    public void Run()
    {
        StartActivity();

        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");

        Console.WriteLine("\nReflect on each question:");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine($"\n> {GetRandomQuestion()}");
            ShowSpinner(5);
        }

        EndActivity();
    }
}