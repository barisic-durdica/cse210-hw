// Exceeded Requirements:
//
// 1. Added an Activity Statistics feature that tracks how many
//    times each activity is completed during the session.
//
// 2. Reflection Activity prevents prompts and questions from
//    repeating until all have been used.
//
// 3. Listing Activity prevents prompts from repeating until
//    all have been used.

using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        int breathingCount = 0;
        int reflectionCount = 0;
        int listingCount = 0;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Statistics");
            Console.WriteLine("5. Quit");
            Console.WriteLine();

            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    breathingCount++;
                    break;

                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    reflectionCount++;
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    listingCount++;
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("Activity Statistics");
                    Console.WriteLine();
                    Console.WriteLine($"Breathing completed: {breathingCount}");
                    Console.WriteLine($"Reflection completed: {reflectionCount}");
                    Console.WriteLine($"Listing completed: {listingCount}");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;

                case "5":
                    running = false;
                    break;
            }
        }
    }
}