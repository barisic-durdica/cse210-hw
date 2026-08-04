using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private string _currentRank = "Beginner";

    // Creativity Feature:
    // Returns the player's current rank based on their total score.
    private string GetRank()
    {
        if (_score >= 5000)
            return "Legend";

        if (_score >= 2500)
            return "Champion";

        if (_score >= 1000)
            return "Achiever";

        if (_score >= 500)
            return "Explorer";

        return "Beginner";
    }

    // Creativity Feature:
    // Detects when the player reaches a new rank and displays
    // a congratulatory Level Up message.
    private void CheckForRankUp()
    {
        string newRank = GetRank();

        if (newRank != _currentRank)
        {
            Console.WriteLine();
            Console.WriteLine("************************************");
            Console.WriteLine("          🎉 LEVEL UP! 🎉");
            Console.WriteLine($"You have reached the rank: {newRank}");
            Console.WriteLine("Keep up the great work!");
            Console.WriteLine("************************************");
            Console.WriteLine();

            _currentRank = newRank;
        }
    }

    public GoalManager()
    {
    }

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.Clear();

            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine($"Current Rank: {GetRank()}\n");

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("\nSelect a choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;

                case 2:
                    ListGoalDetails();
                    break;

                case 3:
                    SaveGoals();
                    break;

                case 4:
                    LoadGoals();
                    break;

                case 5:
                    RecordEvent();
                    break;
            }

            if (choice != 6)
            {
                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        ListGoalNames();
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");

        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        int type = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description? ");
        string description = Console.ReadLine();

        Console.Write("How many points is it worth? ");
        int points = int.Parse(Console.ReadLine());

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == 3)
        {
            Console.Write("How many times does it need to be completed? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus points when completed? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
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

        Console.WriteLine("Which goal did you accomplish?");

        ListGoalNames();

        Console.Write("Enter goal number: ");
        int number = int.Parse(Console.ReadLine());

        Goal goal = _goals[number - 1];

        goal.RecordEvent();

        int earned = goal.GetPoints();

        if (goal is ChecklistGoal checklist)
        {
            if (checklist.IsComplete() && checklist.GetAmountCompleted() > 0)
            {
                earned += checklist.GetBonus();
            }
        }

        _score += earned;

        Console.WriteLine($"Congratulations! You earned {earned} points!");

        CheckForRankUp();
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(filename))
        {
            output.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                output.WriteLine(goal.GetStringRepresentation());
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
            string line = lines[i];

            string[] parts = line.Split(':');

            string goalType = parts[0];

            string[] values = parts[1].Split(',');

            if (goalType == "SimpleGoal")
            {
                SimpleGoal goal =
                    new SimpleGoal(
                        values[0],
                        values[1],
                        int.Parse(values[2]));

                _goals.Add(goal);
            }

            else if (goalType == "EternalGoal")
            {
                EternalGoal goal =
                    new EternalGoal(
                        values[0],
                        values[1],
                        int.Parse(values[2]));

                _goals.Add(goal);
            }

            else if (goalType == "ChecklistGoal")
            {
                ChecklistGoal goal =
                    new ChecklistGoal(
                        values[0],
                        values[1],
                        int.Parse(values[2]),
                        int.Parse(values[4]),
                        int.Parse(values[3]));

                for (int j = 0; j < int.Parse(values[5]); j++)
                {
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }
    
}