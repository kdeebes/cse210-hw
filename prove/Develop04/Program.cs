//Name: Kerryann Deebes

using System;
using System.Threading;

abstract class MindfulnessActivity
{
    protected int durationInSeconds;

    public MindfulnessActivity(int durationInSeconds)
    {
        this.durationInSeconds = durationInSeconds;
    }

    public abstract void Start();
    public abstract void End();
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int durationInSeconds) : base(durationInSeconds) { }

    public override void Start()
    {
        Console.WriteLine("Welcome to the Breathing Activity");
        Console.WriteLine("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Thread.Sleep(3000); // Pause for 3 seconds

        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(2000); // Pause for 2 seconds

        for (int i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

        Console.WriteLine(); // Move to the next line after the countdown

        for (int i = 0; i < durationInSeconds; i += 2)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(1000); // Pause for 1 second
            Console.WriteLine("Now  breathe out...");
            Thread.Sleep(1000); // Pause for 1 second
        }
    }

    public override void End()
    {
        Console.WriteLine("Good job! You have completed the Breathing Activity.");
        Console.WriteLine($"You've spent {durationInSeconds} seconds on this activity.");
        Thread.Sleep(3000); // Pause for 3 seconds
    }
}
    

class ReflectionActivity : MindfulnessActivity
{
    public ReflectionActivity(int durationInSeconds) : base(durationInSeconds) { }

    public override void Start()
    {
        Console.WriteLine("Welcome to the reflection Activity");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Thread.Sleep(3000); // Pause for 3 seconds

        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(2000); // Pause for 2 seconds

        string[] prompts = {
            "--- Think of a time when you stood up for someone else. ---",
            "--- Think of a time when you did something really difficult ---.",
            "--- Think of a time when you helped someone in need. ---",
            "--- Think of a time when you did something truly selfless. ---"
        };

        Random rand = new Random();
        int index = rand.Next(prompts.Length);
        Console.WriteLine(prompts[index]);
        Thread.Sleep(3000); // Pause for 3 seconds

        string[] questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        foreach (var question in questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(5000); // Pause for 5 seconds
        }
    }

    public override void End()
    {
        Console.WriteLine("Good job! You have completed the Reflection Activity.");
        Console.WriteLine($"You've spent {durationInSeconds} seconds on this activity.");
        Thread.Sleep(3000); // Pause for 3 seconds
    }
}

class ListingActivity : MindfulnessActivity
{
    public ListingActivity(int durationInSeconds) : base(durationInSeconds) { }

    public override void Start()
    {
        Console.WriteLine("Welocme to the listing Activity");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Thread.Sleep(3000); // Pause for 3 seconds

        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(2000); // Pause for 2 seconds

        string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        Random rand = new Random();
        int index = rand.Next(prompts.Length);
        Console.WriteLine(prompts[index]);
        Thread.Sleep(3000); // Pause for 3 seconds

        Console.WriteLine("Start listing items...");

        for (int i = 0; i < durationInSeconds; i++)
        {
            
            Thread.Sleep(1000);
        }
    }

    public override void End()
    {
        Console.WriteLine("Good job! You have completed the Listing Activity.");
        Console.WriteLine($"You've spent {durationInSeconds} seconds on this activity.");
        Thread.Sleep(3000); // Pause for 3 seconds
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness App!");

        while (true)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Start breathing Activity");
            Console.WriteLine("2. Start reflection Activity");
            Console.WriteLine("3. Start listing Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine("Select a choice from the menu: ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }

            if (choice == 4)
            {
                Console.WriteLine("Exiting...");
                break;
            }

            Console.WriteLine("Enter duration in seconds:");
            int duration;
            while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }

            MindfulnessActivity activity;
            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity(duration);
                    break;
                case 2:
                    activity = new ReflectionActivity(duration);
                    break;
                case 3:
                    activity = new ListingActivity(duration);
                    break;
                default:
                    throw new InvalidOperationException("Invalid choice.");
            }

            activity.Start();
            activity.End();
        }
    }
}


