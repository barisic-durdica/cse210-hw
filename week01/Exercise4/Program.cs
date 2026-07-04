using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int number = -1;

        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        int sum = 0;

        foreach (int item in numbers)
        {
            sum += item;
        }

        Console.WriteLine($"The sum is: {sum}");

        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int largest = numbers[0];

        foreach (int item in numbers)
        {
            if (item > largest)
            {
                largest = item;
            }
        }

        Console.WriteLine($"The largest number is: {largest}");

        int smallestPositive = int.MaxValue;

        foreach (int item in numbers)
        {
            if (item > 0 && item < smallestPositive)
            {
                smallestPositive = item;
            }
        }

        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        numbers.Sort();

        Console.WriteLine("The sorted list is:");

        foreach (int item in numbers)
        {
            Console.WriteLine(item);
        }
    }
}