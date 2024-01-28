using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a scripture with both reference and text
            Scripture scripture = new Scripture("2 Corinthians 12:9", "And he said unto me, My grace is sufficient for thee: for my strength is made perfect in weakness. Most gladly therefore will I rather glory in my infirmities, that the power of Christ may rest upon me.");

            // Display the initial scripture
            Console.Clear();
            
            DisplayScripture(scripture);

            // Prompt the user until all words are hidden or they quit
            while (true)
            {
                Console.Write("Press Enter to continue or type quit: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    break;
                }

                if (scripture.HideRandomWords())
                {
                    Console.Clear();
                    DisplayScripture(scripture);
                }
                else
                {
                    Console.WriteLine("All words have been hidden!");
                    break;
                }
            }
        }

        static void DisplayScripture(Scripture scripture)
        {
            Console.WriteLine(scripture.Reference);
            Console.WriteLine(scripture.Text);
            Console.WriteLine();
        }
    }

    class Scripture
    {
        public string Reference { get; }
        public string Text { get; private set; }
        public List<string> HiddenWords { get; } = new List<string>();

        public Scripture(string reference, string text)
        {
            Reference = reference;
            Text = text;
        }

        public bool HideRandomWords()
        {
            string[] words = Text.Split(' ');
            Random random = new Random();

            int wordsToHide = 2; // Adjust as needed
            for (int i = 0; i < wordsToHide; i++)
            {
                int wordIndex = random.Next(0, words.Length);
                string wordToHide = words[wordIndex];

                // Only hide words that haven't been hidden yet (stretch challenge)
                if (!HiddenWords.Contains(wordToHide))
                {
                    HiddenWords.Add(wordToHide);
                    words[wordIndex] = "__________"; // Replace with hidden word marker
                }
            }

            Text = string.Join(" ", words);

            return HiddenWords.Count < words.Length; // Return true if there are still words to hide
        }
    }
}