
//Name: Kerryann Deebes
//Class: CSE210
//Date: 2/18/2024

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creating 3-4 videos
        List<Video> videos = new List<Video>
        {
            new Video("Title 1", "Author 1", 120),
            new Video("Title 2", "Author 2", 180),
            new Video("Title 3", "Author 3", 150),
            new Video("Title 4", "Author 4", 200)
        };

        // Adding comments to each video
        videos[0].AddComment("Commenter 1", "This is a great video!");
        videos[0].AddComment("Commenter 2", "Awesome content.");

        videos[1].AddComment("Commenter 3", "Interesting video!");
        videos[1].AddComment("Commenter 4", "Could be better.");

        videos[2].AddComment("Commenter 5", "Very informative.");
        videos[2].AddComment("Commenter 6", "I learned a lot.");

        videos[3].AddComment("Commenter 7", "Awesome work!");
        videos[3].AddComment("Commenter 8", "Keep it up.");

        // Displaying information for each video
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Commenter}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(string commenter, string text)
    {
        Comments.Add(new Comment(commenter, text));
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string Commenter { get; set; }
    public string Text { get; set; }

    public Comment(string commenter, string text)
    {
        Commenter = commenter;
        Text = text;
    }
}