//Name: Kerryann Deebes
//Class: CSE 210
//Date: 2/22/2024

using System;

// Addresses class to encapsulate address details
class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string zipCode;

    public Address(string streetAddress, string city, string state, string zipCode)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.zipCode = zipCode;
    }

    public override string ToString()
    {
        return $"{streetAddress}, {city}, {state}, {zipCode}";
    }
}

// Base Event class
class Event
{
    private string title;
    private string description;
    private DateTime dateTime;
    private Address address;

    public Event(string title, string description, DateTime dateTime, Address address)
    {
        this.title = title;
        this.description = description;
        this.dateTime = dateTime;
        this.address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {dateTime.ToShortDateString()}\nTime: {dateTime.ToShortTimeString()}\nAddress: {address}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Type: {GetType().Name}\nTitle: {title}\nDate: {dateTime.ToShortDateString()}";
    }
}

// Lecture class
class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime dateTime, Address address, string speaker, int capacity)
        : base(title, description, dateTime, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

// Reception class
class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime dateTime, Address address, string rsvpEmail)
        : base(title, description, dateTime, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nRSVP Email: {rsvpEmail}";
    }
}

// OutdoorGathering class
class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime dateTime, Address address, string weatherForecast)
        : base(title, description, dateTime, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nWeather Forecast: {weatherForecast}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating instances of each event type
        Lecture lecture = new Lecture("Gardening 101", "Learn about gardening techniques", new DateTime(2024, 3, 15, 10, 0, 0),
            new Address("6300 KANSAS RD", "MC DAVID FL", "State", "32771"), "Kerryann Deebes", 50);

        Reception reception = new Reception("Networking Mixer", "Networking event for professionals", new DateTime(2024, 4, 20, 18, 0, 0),
            new Address("109 E CHURCH ST", "ORLANDO FL", "State", "32801"), "rsvp@rsvp.com");

        OutdoorGathering gathering = new OutdoorGathering("Picnic in the Park", "Enjoy food and games in the park", new DateTime(2024, 5, 25, 12, 0, 0),
            new Address("72691 WAYMAN RD", "MOORE HAVEN FL", "State", "33471"), "Michael");

        // Generating and displaying marketing messages for each event
        Console.WriteLine("Lecture Marketing Messages:");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine("\nFull Details:");
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine("\nShort Description:");
        Console.WriteLine(lecture.GetShortDescription());

        Console.WriteLine("\nReception Marketing Messages:");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine("\nFull Details:");
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine("\nShort Description:");
        Console.WriteLine(reception.GetShortDescription());

        Console.WriteLine("\nOutdoor Gathering Marketing Messages:");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(gathering.GetStandardDetails());
        Console.WriteLine("\nFull Details:");
        Console.WriteLine(gathering.GetFullDetails());
        Console.WriteLine("\nShort Description:");
        Console.WriteLine(gathering.GetShortDescription());
    }
}
