using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
        Console.WriteLine($"Level: {GetLevel()}");
        Console.WriteLine($"Title: {GetTitle()}");
    }

    private int GetLevel()
    {
        return (_score / 1000) + 1;
    }

    private string GetTitle()
    {
        int level = GetLevel();

        if (level >= 15)
        {
            return "Celestial Champion";
        }
        else if (level >= 10)
        {
            return "Faith Warrior";
        }
        else if (level >= 5)
        {
            return "Disciple";
        }

        return "Seeker";
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nGoals:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Select type: ");
        string choice = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;

            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;

            case "3":
                Console.Write("Target count: ");
                int targetCount = int.Parse(Console.ReadLine());

                Console.Write("Bonus points: ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(
                    new ChecklistGoal(
                        name,
                        description,
                        points,
                        bonus,
                        targetCount));
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }

        Console.WriteLine("Goal created successfully!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        Console.WriteLine("\nWhich goal did you accomplish?");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        Console.Write("Select goal: ");
        int goalNumber = int.Parse(Console.ReadLine());

        int earnedPoints = _goals[goalNumber - 1].RecordEvent();

        _score += earnedPoints;

        Console.WriteLine($"\nCongratulations!");
        Console.WriteLine($"You earned {earnedPoints} points.");
        Console.WriteLine($"Your total score is now {_score}.");
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();

        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            if (parts[0] == "SimpleGoal")
            {
                _goals.Add(
                    new SimpleGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        bool.Parse(parts[4])));
            }
            else if (parts[0] == "EternalGoal")
            {
                _goals.Add(
                    new EternalGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3])));
            }
            else if (parts[0] == "ChecklistGoal")
            {
                _goals.Add(
                    new ChecklistGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        int.Parse(parts[5]),
                        int.Parse(parts[6])));
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}