using System;
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        string choice = "";

        while (choice != "6")
        {
            manager.DisplayPlayerInfo();

            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");

            Console.Write("\nSelect Choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;

                case "2":
                    manager.ListGoalDetails();
                    break;

                case "3":
                    manager.RecordEvent();
                    break;

                case "4":
                    manager.SaveGoals();
                    break;

                case "5":
                    manager.LoadGoals();
                    break;

                case "6":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
