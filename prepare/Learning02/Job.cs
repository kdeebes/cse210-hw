using System;

public class Job
{
    // Member variables
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    // Display method
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} at {_company} ({_startYear}-{_endYear})");
    }
}