using System;

class Program
{
    static bool CheckA(double a, double b, double c) => a < b && b < c;
    static bool CheckB(double a, double b, double c) => b > a && a > c;

    static bool IsRemainderMatch(int a, int b, int c, int d) => (a % b) == c || (a % b) == d;

    static double MaxOfFour(double a, double b, double c, double d) =>
        Math.Max(a, Math.Max(b, Math.Max(c, d)));
    static double MinOfFour(double a, double b, double c, double d) =>
        Math.Min(a, Math.Min(b, Math.Min(c, d)));

    static double HalfSumAbs(double a, double b)
    {
        double absA = a < 0 ? -a : a;
        double absB = b < 0 ? -b : b;
        return (absA + absB) / 2;
    }
    static double SqrtAbsProduct(double a, double b)
    {
        double absA = a < 0 ? -a : a;
        double absB = b < 0 ? -b : b;
        return Math.Sqrt(absA * absB);
    }

 
    static bool AreHeightsEqual(double h1, double h2, double h3) =>
        h1 == h2 && h2 == h3;


    static string GetWeightCategory(double weight)
    {
        if (weight < 60) return "легкий вес";
        else if (weight < 64) return "первый полусредний вес";
        else if (weight < 69) return "полусредний вес";
        else return "категория не определена";
    }

    static void Main()
    {
 
        Console.WriteLine("Задание 1а: " + CheckA(1, 2, 3));
        Console.WriteLine("Задание 1б: " + CheckB(3, 5, 1));

        Console.WriteLine("Задание 2: " + IsRemainderMatch(10, 3, 1, 2)); 

        Console.WriteLine("Задание 3а: " + MaxOfFour(4, 2, 9, 5)); 
        Console.WriteLine("Задание 3б: " + MinOfFour(4, 2, 9, 5)); 

        Console.WriteLine("Задание 4а: " + HalfSumAbs(-3, 4)); 
        Console.WriteLine("Задание 4б: " + SqrtAbsProduct(-4, -9)); 

        Console.WriteLine("Задание 5: " + AreHeightsEqual(180, 180, 180));

        Console.WriteLine("Задание 6: " + GetWeightCategory(63.5));
    }
}