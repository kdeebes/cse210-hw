using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace EternalQuest
{
    // Base class for all types of goals
    [Serializable]
    abstract class Goal
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public abstract void Complete();
        public abstract string Progress();
    }

    // Simple Goal class
    [Serializable]
    class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public override void Complete()
        {
            Console.WriteLine($"Goal '{Name}' completed! You gained {Value} points.");
        }

        public override string Progress()
        {
            return "[X]"; // Simple goal is always considered completed once created
        }
    }

    // Eternal Goal class
    [Serializable]
    class EternalGoal : Goal
    {
        public EternalGoal(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public override void Complete()
        {
            Console.WriteLine($"You recorded '{Name}'. You gained {Value} points.");
        }

        public override string Progress()
        {
            return "[ ]"; // Eternal goal is never completed
        }
    }

    // Checklist Goal class
    [Serializable]
    class ChecklistGoal : Goal
    {
        public int TargetCount { get; set; }
        private int _currentCount;

        public ChecklistGoal(string name, int value, int targetCount)
        {
            Name = name;
            Value = value;
            TargetCount = targetCount;
            _currentCount = 0;
        }

        public override void Complete()
        {
            _currentCount++;
            Console.WriteLine($"You recorded '{Name}'. You gained {Value} points.");
            if (_currentCount == TargetCount)
            {
                Console.WriteLine($"Congratulations! You've completed '{Name}' {TargetCount} times and received a bonus of {Value * 5} points!");
            }
        }

        public override string Progress()
        {
            return $"Completed {_currentCount}/{TargetCount} times";
        }
    }

    // Main program
    class Program
    {
        static List<Goal> goals = new List<Goal>();
        static int score = 0;

        static void Main(string[] args)
        {
            LoadData();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Menu options:");
                Console.WriteLine("1. Create new goal");
                Console.WriteLine("2. Record event");
                Console.WriteLine("3. Show goals");
                Console.WriteLine("4. Show score");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        RecordEvent();
                        break;
                    case "3":
                        ShowGoals();
                        break;
                    case "4":
                        ShowScore();
                        break;
                    case "5":
                        SaveData();
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void CreateGoal()
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string typeChoice = Console.ReadLine();

            Console.Write("Enter the name of the goal: ");
            string name = Console.ReadLine();

            Console.Write("Enter the value/points for completing the goal: ");
            int value = int.Parse(Console.ReadLine());

            switch (typeChoice)
            {
                case "1":
                    goals.Add(new SimpleGoal(name, value));
                    break;
                case "2":
                    goals.Add(new EternalGoal(name, value));
                    break;
                case "3":
                    Console.Write("Enter the target count for this goal: ");
                    int targetCount = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(name, value, targetCount));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }

        static void RecordEvent()
        {
            Console.WriteLine("Select a goal to record event:");
            ShowGoals();
            Console.Write("Enter the number of the goal: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice >= 1 && choice <= goals.Count)
            {
                Goal selectedGoal = goals[choice - 1];
                selectedGoal.Complete();
                score += selectedGoal.Value;
            }
            else
            {
                Console.WriteLine("Invalid goal selection.");
            }
        }

        static void ShowGoals()
        {
            Console.WriteLine("Current Goals:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].Name} - {goals[i].Progress()}");
            }
        }

        static void ShowScore()
        {
            Console.WriteLine($"Your current score: {score}");
        }

        static void SaveData()
        {
            using (FileStream fs = new FileStream("goals.dat", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, goals);
            }
            Console.WriteLine("Data saved successfully.");
        }

        static void LoadData()
        {
            if (File.Exists("goals.dat"))
            {
                using (FileStream fs = new FileStream("goals.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    goals = (List<Goal>)formatter.Deserialize(fs);
                }
                Console.WriteLine("Data loaded successfully.");
            }
        }
    }
}
