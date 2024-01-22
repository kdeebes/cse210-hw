using System;
using System.Collections.Generic;
using System.IO;

class Entry {
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response, string date) {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString() {
        return $"{Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

class Journal {
    private List<Entry> entries;

    public Journal() {
        entries = new List<Entry>();
    }

    public void AddEntry(Entry entry) {
        entries.Add(entry);
    }

    public void DisplayEntries() {
        foreach (var entry in entries) {
            Console.WriteLine(entry.ToString());
        }
    }

    public void SaveToFile(string fileName) {
    string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
    using (StreamWriter sw = new StreamWriter(fullPath)) {
        foreach (var entry in entries) {
            sw.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    Console.WriteLine($"Journal saved to {fullPath}");
    }

    public void LoadFromFile(string fileName) {
        entries.Clear();
        try {
            using (StreamReader sr = new StreamReader(fileName)) {
                string line;
                while ((line = sr.ReadLine()) != null) {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3) {
                        Entry entry = new Entry(parts[1], parts[2], parts[0]);
                        entries.Add(entry);
                    }
                }
            }
            Console.WriteLine($"Journal loaded from {fileName}");
        } catch (FileNotFoundException) {
            Console.WriteLine($"File not found: {fileName}");
        }
    }
}

class Program {
    static void Main(string[] args) {
        Journal journal = new Journal();

        Console.WriteLine("Welcome to the Journal Program!");

        while (true) {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.Write("What would you like to do? ");
            int choice = int.Parse(Console.ReadLine());

    switch (choice)
{
    case 1:
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "Reflect on three things I am grateful for today. They can be big or small. How did they make me feel?",
            "How did I see the hand of the Lord in my life today?",
           "Reflect on a moment in my day when I felt most like myself and provide an explanation for that feeling.",
            "If I had one thing I could do over today, what would it be?"
        };

        // Display random prompt
        int randomPromptIndex = new Random().Next(0, prompts.Length);
        string randomPrompt = prompts[randomPromptIndex];
        Console.WriteLine($"{randomPrompt}");

        Console.Write("> ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString();
        Entry newEntry = new Entry(randomPrompt, response, date);
        journal.AddEntry(newEntry);
        break;

    case 2:
        journal.DisplayEntries();
        break;

    case 3:
        Console.WriteLine("What is the file name you'd like to load?:");
        string loadFileName = Console.ReadLine();
        journal.LoadFromFile(loadFileName);
        break;


    case 4:
        Console.WriteLine($"Current Directory: {Directory.GetCurrentDirectory()}");
        Console.WriteLine("Enter file name to save. Add .txt as the extension:");
        string saveFileName = Console.ReadLine();
        journal.SaveToFile(saveFileName);
        break;

    case 5:
        Environment.Exit(0);
        break;

    default:
        Console.WriteLine("Invalid choice. Please try again.");
        break;
}       
        

}

}


}