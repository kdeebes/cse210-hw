using System;
using System.Collections.Generic;
using System.Linq;

class Verse
{
    public string Text { get; private set; }
    public List<string> Words { get; private set; }

    public Verse(string text)
    {
        Text = text.Trim();
        Words = text.Split(' ').ToList();
    }

    public override string ToString() => Text;

    public List<string> GetHiddenWords()
    {
        List<string> hiddenWords = new List<string>();
        foreach (string word in Words)
        {
            if (!hiddenWords.Contains(word) && new Random().Next(2) == 0)
            {
                hiddenWords.Add(word);
            }
        }
        return hiddenWords;
    }
}

class ScriptureReference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int EndVerse { get; private set; }

    public ScriptureReference(string book, int chapter, int startVerse = 0, int endVerse = 0)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse > 0 ? startVerse : chapter;
        EndVerse = endVerse > 0 ? endVerse : chapter;
    }

    public override string ToString()
    {
        return StartVerse == EndVerse
            ? $"{Book} {Chapter}:{StartVerse}"
            : $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}

class Scripture
{
    public ScriptureReference Reference { get; private set; }
    public List<Verse> Verses { get; private set; }

    public Scripture(ScriptureReference reference, List<Verse> verses)
    {
        Reference = reference;
        Verses = verses;
    }
        
    public void Display()
    {
        Console.WriteLine($"\n{Reference}");
        Verses.ForEach(verse => Console.WriteLine(verse));
        Console.Write("Press enter to continue or type 'quit' to finish: ");
    }
    
    public void HideWords()
    {
        Verses.ForEach(verse =>
        {
            List<string> hiddenWords = verse.GetHiddenWords();
            Console.WriteLine(string.Join(" ", verse.Words.Select(w => hiddenWords.Contains(w) ? "_" : w)));
        });
    }
}

class Program
{
    static void Main(string[] args)
    {
        ScriptureReference reference = new ScriptureReference("Galatians",6, 9);
        List<Verse> verses = new List<Verse>
        {
            new Verse("Let us not become weary in doing good, for at the proper time we will reap a harvest if we do not give up.")
            
        };
        
        Scripture scripture = new Scripture(reference, verses);

        while (true)
        {
            scripture.Display();
            string userInput = Console.ReadLine().ToLower();
            if (userInput == "quit")
            {
                break;
            }
            else
            {
                scripture.HideWords();
            }
        }
    }
}