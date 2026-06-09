using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly."
        )
    {
    }

    public void Run()
    {
        StartActivity();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in...");
            ShowCountdown(4);

            Console.Write("\nBreathe out...");
            ShowCountdown(4);

            Console.WriteLine();
        }

        EndActivity();
    }
}