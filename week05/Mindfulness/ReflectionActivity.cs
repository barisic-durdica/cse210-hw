using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();
    private List<string> _unusedQuestions = new List<string>();
    private List<string> _unusedPrompts = new List<string>();

    public ReflectionActivity()
        : base(
            "Reflection",
            "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        _unusedQuestions = new List<string>(_questions);
        _unusedPrompts = new List<string>(_prompts);

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        Console.WriteLine($"--- {GetRandomPrompt()} ---");

        Console.WriteLine();
        Console.Write("When you have something in mind press Enter.");
        Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Now ponder each of the following questions:");
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.WriteLine(GetRandomQuestion());
            ShowSpinner(5);
            Console.WriteLine();
        }

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

    private string GetRandomQuestion()
    {
        if (_unusedQuestions.Count == 0)
        {
            _unusedQuestions = new List<string>(_questions);
        }

        int index = _random.Next(_unusedQuestions.Count);

        string question = _unusedQuestions[index];

        _unusedQuestions.RemoveAt(index);

        return question;
    }
}