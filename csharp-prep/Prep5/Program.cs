//Name: Kerryann Deebes
//Class: CSE 210
//Date: 1/16/2024


using System;

class Program
{
    static void Main(string[] args)
    {
        // Call DisplayWelcome function
        DisplayWelcome();

        // Call PromptUserName function and save the returned value
        string userName = PromptUserName();

        // Call PromptUserNumber function and save the returned value
        int userNumber = PromptUserNumber();

        // Call SquareNumber function with the user's number and save the squared result
        int squaredNumber = SquareNumber(userNumber);

        // Call DisplayResult function with the user's name and squared number
        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        // Use int.TryParse to handle invalid input
        int number;
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Invalid input. Please enter a valid number: ");
        }
        return number;
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your favorite number is: {squaredNumber}");
    }
}