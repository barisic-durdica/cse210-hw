using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Learn C# Basics", "John Smith", 600);
        video1.AddComment(new Comment("Alex", "Very helpful!"));
        video1.AddComment(new Comment("Sarah", "Excellent explanation."));
        video1.AddComment(new Comment("Tom", "Thanks!"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Cooking Pasta", "Chef Maria", 480);
        video2.AddComment(new Comment("James", "Looks delicious."));
        video2.AddComment(new Comment("Emma", "I'll try this tonight."));
        video2.AddComment(new Comment("Lucas", "Amazing recipe!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Top 10 Football Goals", "Sports TV", 900);
        video3.AddComment(new Comment("Michael", "Goal number 3 was incredible."));
        video3.AddComment(new Comment("Daniel", "Best compilation ever."));
        video3.AddComment(new Comment("Chris", "Loved it."));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Travel in Japan", "World Explorer", 720);
        video4.AddComment(new Comment("Anna", "Japan is beautiful."));
        video4.AddComment(new Comment("David", "Adding this to my bucket list."));
        video4.AddComment(new Comment("Sophia", "Great video!"));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine();

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}:");
                Console.WriteLine(comment.GetText());
                Console.WriteLine();
            }
        }
    }
}