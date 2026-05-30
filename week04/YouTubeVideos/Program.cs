using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video(
            "Learn C# in 20 Minutes",
            "Programming Hub",
            1200);

        video1.AddComment(
            new Comment("Sydney", "Very helpful tutorial."));
        video1.AddComment(
            new Comment("John", "I finally understand classes."));
        video1.AddComment(
            new Comment("Sarah", "Great explanation."));

        videos.Add(video1);

        Video video2 = new Video(
            "How to Build a Website",
            "Tech Academy",
            950);

        video2.AddComment(
            new Comment("Michael", "Amazing content."));
        video2.AddComment(
            new Comment("Grace", "Easy to follow."));
        video2.AddComment(
            new Comment("Daniel", "Thanks for sharing."));

        videos.Add(video2);

        Video video3 = new Video(
            "Graphic Design Tips",
            "Creative Studio",
            700);

        video3.AddComment(
            new Comment("Emily", "Very useful."));
        video3.AddComment(
            new Comment("David", "Loved the examples."));
        video3.AddComment(
            new Comment("James", "Helped me improve my designs."));

        videos.Add(video3);

        Video video4 = new Video(
            "Social Media Marketing",
            "Marketing Pro",
            800);

        video4.AddComment(
            new Comment("Sophia", "Excellent advice."));
        video4.AddComment(
            new Comment("Chris", "I learned a lot."));
        video4.AddComment(
            new Comment("Olivia", "Great strategies."));

        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("\nComment List:");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine(
                    $"{comment._commenterName}: {comment._commentText}");
            }

            Console.WriteLine();
        }
    }
}