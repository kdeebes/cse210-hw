//Name: Kerryann Deebes
//Class: CSE 210
//Date: 2/22/2024

using System;
using System.Collections.Generic;

namespace ExerciseTrackingApp
{
    // Base Activity class
    public class Activity
    {
        private DateTime date;
       protected int lengthMinutes;


        public Activity(DateTime date, int lengthMinutes)
        {
            this.date = date;
            this.lengthMinutes = lengthMinutes;
        }

       
        public virtual double GetDistance()
        {
            return 0; 
        }

        public virtual double GetSpeed()
        {
            return 0; 
        }

        public virtual double GetPace()
        {
            return 0; 
        }

        // GetSummary method to produce a summary string
        public virtual string GetSummary()
        {
            return $"{date.ToString("dd MMM yyyy")} - {GetType().Name} ({lengthMinutes} min)";
        }
    }

    // Derived class for Running
    public class Running : Activity
    {
        private double distance; // in miles

        public Running(DateTime date, int lengthMinutes, double distance) : base(date, lengthMinutes)
        {
            this.distance = distance;
        }

        public override double GetDistance()
        {
            return distance;
        }

        public override double GetSpeed()
        {
            return distance / (base.lengthMinutes / 60.0); // mph
        }

        public override double GetPace()
        {
            return base.lengthMinutes / distance; // minutes per mile
        }

        public override string GetSummary()
        {
            return base.GetSummary() + $" - Distance: {distance} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F2} min/mile";
        }
    }

    // Derives class for Cycling
    public class Cycling : Activity
    {
        private double speed; // in kph

        public Cycling(DateTime date, int lengthMinutes, double speed) : base(date, lengthMinutes)
        {
            this.speed = speed;
        }

        public override double GetSpeed()
        {
            return speed; // kph
        }

        public override double GetDistance()
        {
            return speed * (base.lengthMinutes / 60.0); // kilometers
        }

        public override double GetPace()
        {
            return 60 / speed; // minutes per kilometer
        }

        public override string GetSummary()
        {
            return base.GetSummary() + $" - Distance: {GetDistance():F1} km, Speed: {speed:F1} kph, Pace: {GetPace():F2} min/km";
        }
    }

    // Derives class for Swimming
    public class Swimming : Activity
    {
        private int laps;

        public Swimming(DateTime date, int lengthMinutes, int laps) : base(date, lengthMinutes)
        {
            this.laps = laps;
        }

        public override double GetDistance()
        {
            return laps * 50 / 1000.0; // kilometers
        }

        public override double GetSpeed()
        {
            return GetDistance() / (base.lengthMinutes / 60.0); // kph
        }

        public override double GetPace()
        {
            return 60 / GetSpeed(); // minutes per kilometer
        }

        public override string GetSummary()
        {
            return base.GetSummary() + $" - Distance: {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2} min/km";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creates activities
            List<Activity> activities = new List<Activity>
            {
                new Running(new DateTime(2022, 11, 3), 30, 3.0),
                new Running(new DateTime(2022, 11, 3), 30, 4.8),
                new Cycling(new DateTime(2022, 11, 3), 45, 20),
                new Swimming(new DateTime(2022, 11, 3), 60, 40)
            };

            // Displays summaries
            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
