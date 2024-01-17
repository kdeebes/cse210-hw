//Name: Kerryann Deebes
//Class: CSE 210
//Date: 1/16/2024


using System;

class Program
{
    static void Main(string[] args)


    {   

        Console.WriteLine("Let's play  Guess the Number!");



        // Generates a random magic number between 1 and 100
        Random random = new Random();
        int magicNumber = random.Next(1, 100);

        // Initialize the user guess variable
        int userGuess;


        do
        {
            // Ask the user for a guess
            Console.Write("What is your guess? ");
            userGuess = int.Parse(Console.ReadLine());

            // Check if the guess is correct or provide a hint
            if (userGuess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (userGuess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

        } while (userGuess != magicNumber); // Continue looping until the guess is correct
    }
}