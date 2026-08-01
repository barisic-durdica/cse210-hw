using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();
    private List<string> _unusedPrompts = new List<string>();

    public ListingActivity()
        : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        _unusedPrompts = new List<string>(_prompts);

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.WriteLine();

        List<string> items = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items!");

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_prompts);
        }

        int index = _random.Next(_unusedPrompts.Count);

        string prompt = _unusedPrompts[index];

        _unusedPrompts.RemoveAt(index);

        return prompt;
    }
}