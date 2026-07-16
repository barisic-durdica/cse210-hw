using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(5);
        Fraction fraction3 = new Fraction(3, 4);
        Fraction fraction4 = new Fraction(1, 3);

        DisplayFraction(fraction1);
        DisplayFraction(fraction2);
        DisplayFraction(fraction3);
        DisplayFraction(fraction4);

        // Test setters
        //fraction1.SetTop(6);
        //fraction1.SetBottom(7);

        // Test getters
        //Console.WriteLine(fraction1.GetTop());
        //Console.WriteLine(fraction1.GetBottom());

        // Test the other methods
        //Console.WriteLine(fraction1.GetFractionString());
        //Console.WriteLine(fraction1.GetDecimalValue());
    }

    static void DisplayFraction(Fraction fraction)
    {
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
    }
}