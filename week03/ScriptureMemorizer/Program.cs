// Creativity / Exceeding Requirements:
//
// 1. The program randomly selects one of four different scriptures.
//
// 2. HideRandomWords() only hides words that are still visible,
//    preventing unnecessary repeated selections.

using System;

class Program
{
    static void Main(string[] args)
    {
        // First Test
        // Reference r1 = new Reference("John", 3, 16);
        // Console.WriteLine(r1.GetDisplayText());

        // Reference r2 = new Reference("Proverbs", 3, 5, 6);
        // Console.WriteLine(r2.GetDisplayText());

        // Second Test
        // Word word = new Word("faith");

        // Console.WriteLine(word.GetDisplayText());

        // word.Hide();

        // Console.WriteLine(word.GetDisplayText());

        // word.Show();

        // Console.WriteLine(word.GetDisplayText());

        // Third Test
        // Reference reference = new Reference("John", 3, 16);

        // Scripture scripture = new Scripture(
            // reference,
            // "For God so loved the world that he gave his only begotten Son"
        // );

        // Console.WriteLine(scripture.GetDisplayText());

        // scripture.HideRandomWords(3);

        // Console.WriteLine();

        // Console.WriteLine(scripture.GetDisplayText());

        Random random = new Random();

        int choice = random.Next(4);

        Reference reference;
        Scripture scripture;

        switch (choice)
        {
            case 0:
                reference = new Reference("John", 3, 16);
                scripture = new Scripture(reference,
                    "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life.");
                break;

            case 1:
                reference = new Reference("Proverbs", 3, 5, 6);
                scripture = new Scripture(reference,
                    "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him and he shall direct thy paths.");
                break;

            case 2:
                reference = new Reference("Mosiah", 2, 17);
                scripture = new Scripture(reference,
                    "When ye are in the service of your fellow beings ye are only in the service of your God.");
                break;

            default:
                reference = new Reference("Alma", 32, 21);
                scripture = new Scripture(reference,
                    "Faith is not to have a perfect knowledge of things therefore if ye have faith ye hope for things which are not seen which are true.");
                break;
        }

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            Console.Write("Press Enter to continue or type 'quit': ");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(2);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        Console.WriteLine();
        Console.WriteLine("Program finished.");
    }
}