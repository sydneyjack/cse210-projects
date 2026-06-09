using System;

/*
EXCEEDS REQUIREMENTS:

1. Added spinner animation.
2. Added countdown timer.
3. Listing activity counts total items entered.
*/

class Program
{
    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "4")
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");

            Console.Write("\nSelect a choice: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing =
                        new BreathingActivity();
                    breathing.Run();
                    break;

                case "2":
                    ReflectionActivity reflection =
                        new ReflectionActivity();
                    reflection.Run();
                    break;

                case "3":
                    ListingActivity listing =
                        new ListingActivity();
                    listing.Run();
                    break;
            }

            if (choice != "4")
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}