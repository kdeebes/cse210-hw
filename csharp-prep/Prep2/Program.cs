//Name: Kerryann Deebes
//Class: CSE 210
//Date: 1/16/2024



using System;

class Program
{
    static void Main(string[] args)
   {
        //prompts the user to input their grade percentage
        Console.Write("Please enter your grade percentage: ");
        double gradePercentage = Convert.ToDouble(Console.ReadLine());

        // Determines the letter grade using if-else statements
        char letter;

        if (gradePercentage >= 90)
        {
            letter = 'A';
        }
        else if (gradePercentage >= 80)
        {
            letter = 'B';
        }
        else if (gradePercentage >= 70)
        {
            letter = 'C';
        }
        else if (gradePercentage >= 60)
        {
            letter = 'D';
        }
        else
        {
            letter = 'F';
        }

        
        Console.WriteLine($"Your letter grade is: {letter}");

        // Checks if the user passed the course and provide a corresponding message
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed!");
        }
        else
        {
            Console.WriteLine("Keep at it. You'll get it next time!");
        }
    }
}
