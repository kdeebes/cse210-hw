//Name: Kerryann Deebes
//Class: CSE 210
//Date: 1/16/2024

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished");

        int userEntry;

        do
        {
            Console.Write("Enter number: ");
            userEntry = Convert.ToInt32(Console.ReadLine());

            if (userEntry != 0)
            {
                numbers.Add(userEntry);
            }

        } while (userEntry != 0);

        // Compute sum
        int sum = 0;

        foreach (var number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"\nThe Sum is: {sum}");

        // Compute average
        float average = numbers.Count > 0 ? (float)sum / numbers.Count : 0;
        Console.WriteLine($"The average is: {average:F2}");

        // Find maximum
        int larg = numbers.Count > 0 ? numbers[0] : 0;
        foreach (var number in numbers)
        {
            if (number > larg)
            {
                larg = number;
            }
        }
        Console.WriteLine($"The largest number is: {larg}");

        Console.ReadLine(); // Keep console window open in debug mode
    }
}