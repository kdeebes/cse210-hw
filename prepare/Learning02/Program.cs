using System;

class Program
{
    static void Main(string[] args)
    {
        // Creates a new job instance named job1
        Job job1 = new Job();

        // Set member variables using dot notation
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        // Creates a second job instance
        Job job2 = new Job();

        // Set member variables for job2
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Resume myResume = new Resume();
        myResume._name = "Kerryann Deebes";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}