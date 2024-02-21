//Name: Kerryann Deebes
//CSE210
//2/20/2024

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

public class Program
{
    private static List<Goal> Goals = new List<Goal>();
    private static double Points = 0;
    private static int Level = 1;
    private static string FileName = "";

    public static void Main(string[] args)
    {
        while (true)
        {
            Level = LevelUp(Level, Points);
            PrintMenu();
            int choice = GetChoice();
            ProcessChoice(choice);
            Console.WriteLine($"\nYou have {Points} points.\n");
        }
    }

    private static void PrintMenu()
    {
        Console.WriteLine("Menu Items:\n" +
                          "1. Create New Goal\n" +
                          "2. List Goals\n" +
                          "3. Save Goals\n" +
                          "4. Load Goals\n" +
                          "5. Record Event\n" +
                          "6. Quit");
        Console.Write("Choose an option from the menu: ");
    }

    private static int GetChoice()
    {
        return int.Parse(Console.ReadLine());
    }

    private static void ProcessChoice(int choice)
    {
        switch (choice)
        {
            case 1:
                CreateGoal();
                break;
            case 2:
                ListGoals();
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
            case 6:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    private static void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:\n" +
                          "1. Simple Goal\n" +
                          "2. Eternal Goal\n" +
                          "3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        int type = GetChoice();
        switch (type)
        {
            case 1:
                Goals.Add(new SimpleGoal());
                break;
            case 2:
                Goals.Add(new EternalGoal());
                break;
            case 3:
                Goals.Add(new ChecklistGoal());
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    private static void ListGoals()
    {
        Console.WriteLine("The goals are: ");
        for (int i = 0; i < Goals.Count; i++)
        {
            Console.Write($"{i + 1}.");
            Goals[i].ListGoal();
        }
    }

    private static void SaveGoals()
    {
        Console.Write("What would you like to name the file? ");
        FileName = Console.ReadLine() + ".txt";
        using (StreamWriter file = new StreamWriter(FileName))
        {
            file.WriteLine(Points + ":" + Level);
            foreach (Goal goal in Goals)
            {
                file.WriteLine(goal.SerializeSelf());
            }
        }
    }

    private static void LoadGoals()
    {
        if (FileName == "")
        {
            Console.WriteLine("Please enter the filename (leave out the extension, e.g., .txt): ");
            FileName = Console.ReadLine() + ".txt";
        }
        string[] lines = File.ReadAllLines(FileName);
        Points = double.Parse(lines[0].Split(":")[0]);
        Level = int.Parse(lines[0].Split(":")[1]);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(":");
            switch (values[0])
            {
                case "simple":
                    Goals.Add(new SimpleGoal(values[1], values[2], double.Parse(values[3]), int.Parse(values[4])));
                    break;
                case "eternal":
                    Goals.Add(new EternalGoal(values[1], values[2], double.Parse(values[3]), int.Parse(values[4])));
                    break;
                case "checklist":
                    Goals.Add(new ChecklistGoal(values[1], values[2], double.Parse(values[3]), int.Parse(values[4]), int.Parse(values[5]), int.Parse(values[6])));
                    break;
            }
        }
    }

    private static void RecordEvent()
    {
        ListGoals();
        Console.Write("\nWhich goal did you accomplish? ");
        int input = int.Parse(Console.ReadLine());
        Points += Goals[input - 1].RecordEvent();
    }

    private static int LevelUp(int level, double points)
    {
        int newLevel = level;
        switch (level)
        {
            case 1:
                if (points >= 200) newLevel = 2;
                break;
            case 2:
                if (points >= 400) newLevel = 3;
                break;
            case 3:
                if (points >= 600) newLevel = 4;
                break;
            case 4:
                if (points >= 1000) newLevel = 5;
                break;
            case 5:
                if (points >= 1500) newLevel = 6;
                break;
            case 6:
                if (points >= 2250) newLevel = 7;
                break;
            case 7:
                if (points >= 3000) newLevel = 8;
                break;
            case 8:
                if (points >= 4000) newLevel = 9;
                break;
            case 9:
                if (points >= 5000) newLevel = 10;
                break;
        }
        if (level != newLevel)
        {
            WriteString($"Congratulations! You are Level {newLevel}!\n", true);
        }
        return newLevel;
    }

    private static void WriteString(string value, bool newLine = false, int speed = 10)
    {
        foreach (char character in value)
        {
            Console.Write(character);
            Thread.Sleep(speed);
        }
        if (newLine) Console.WriteLine();
    }
}

public abstract class Goal
{
    protected string Name { get; set; }
    protected string Description { get; set; }
    protected double Points { get; set; }
    protected double TimesCompleted { get; set; }

    public virtual void ListGoal()
    {
        Console.Write($" [{(IsComplete() ? 'X' : ' ')}] {Name} ({Description})");
    }

    public virtual string SerializeSelf()
    {
        return $"{GetType().Name.ToLower()}:{Name}:{Description}:{Points}:{TimesCompleted}";
    }

    public abstract bool IsComplete();

    public abstract double RecordEvent();
}

public class SimpleGoal : Goal
{
    public SimpleGoal() : this("", "", 0, 0) { }

    public SimpleGoal(string name, string description, double points, int timesFinished)
    {
        Name = name == "" ? SetName() : name;
        Description = description == "" ? SetDescription() : description;
        Points = points == 0 ? SetPoints() : points;
        TimesCompleted = timesFinished;
    }

    private string SetName()
    {
        Console.Write("What is the name of your goal? ");
        return Console.ReadLine();
    }

    private string SetDescription()
    {
        Console.Write("What is a short description of it? ");
        return Console.ReadLine();
    }

    private double SetPoints()
    {
        Console.Write("What is the amount of points associated with this goal? ");
        return double.Parse(Console.ReadLine());
    }

    public override bool IsComplete()
    {
        return TimesCompleted >= 1;
    }

    public override double RecordEvent()
    {
        TimesCompleted += 1;
        Console.WriteLine($"Congratulations! You have earned {Points} points!\n");
        return Points;
    }
}

public class EternalGoal : Goal
{
    public EternalGoal() : this("", "", 0, 0) { }

    public EternalGoal(string name, string description, double points, int timesFinished)
    {
        Name = name == "" ? SetName() : name;
        Description = description == "" ? SetDescription() : description;
        Points = points == 0 ? SetPoints() : points;
        TimesCompleted = timesFinished;
    }

    private string SetName()
    {
        Console.Write("What is the name of your goal? ");
        return Console.ReadLine();
    }

    private string SetDescription()
    {
        Console.Write("What is a short description of it? ");
        return Console.ReadLine();
    }

    private double SetPoints()
    {
        Console.Write("What is the amount of points associated with this goal? ");
        return double.Parse(Console.ReadLine());
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override double RecordEvent()
    {
        TimesCompleted += 1;
        Console.WriteLine($"Congratulations! You have earned {Points} points!\n");
        return Points;
    }
}

public class ChecklistGoal : Goal
{
    private int ReachBonus { get; set; }
    private int BonusPoints { get; set; }

    public ChecklistGoal() : this("", "", 0, 0, 0, 0) { }

    public ChecklistGoal(string name, string description, double points, int timesFinished, int reach, int bonus)
    {
        Name = name == "" ? SetName() : name;
        Description = description == "" ? SetDescription() : description;
        Points = points == 0 ? SetPoints() : points;
        TimesCompleted = timesFinished;
        ReachBonus = reach == 0 ? SetReachBonus() : reach;
        BonusPoints = bonus == 0 ? SetBonusPoints() : bonus;
    }

    private string SetName()
    {
        Console.Write("What is the name of your goal? ");
        return Console.ReadLine();
    }

    private string SetDescription()
    {
        Console.Write("What is a short description of it? ");
        return Console.ReadLine();
    }

    private double SetPoints()
    {
        Console.Write("What is the amount of points associated with this goal? ");
        return double.Parse(Console.ReadLine());
    }

    private int SetReachBonus()
    {
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        return int.Parse(Console.ReadLine());
    }

    private int SetBonusPoints()
    {
        Console.Write("What is the bonus for accomplishing it that many times?");
        return int.Parse(Console.ReadLine());
    }

    public override bool IsComplete()
    {
        return TimesCompleted >= ReachBonus;
    }

    public override double RecordEvent()
    {
        TimesCompleted += 1;
        double totalPoints = Points;
        if (IsComplete())
        {
            totalPoints += BonusPoints;
        }
        Console.WriteLine($"Congratulations! You have earned {totalPoints} points!\n");
        return totalPoints;
    }
}
