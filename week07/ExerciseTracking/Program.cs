using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2026, 8, 5), 30, 5.0),
            new Cycling(new DateTime(2026, 8, 5), 45, 22.0),
            new Swimming(new DateTime(2026, 8, 5), 40, 40)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}