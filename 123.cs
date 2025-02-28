using System;

class Program
{
    static void Main()
    {
        // Задание 1
        int x1_1 = 1, y1_1 = 1, x1_2 = 4, y1_2 = 4;
        int x2_1 = 3, y2_1 = 2, x2_2 = 6, y2_2 = 5;
        int minX = Math.Min(x1_1, x2_1);
        int minY = Math.Min(y1_1, y2_1);
        int maxX = Math.Max(x1_2, x2_2);
        int maxY = Math.Max(y1_2, y2_2);
        Console.WriteLine($"Задание 1: ({minX}, {minY}) - ({maxX}, {maxY})");

        // Задание 2
        double squareArea = 25, circleArea = 78.5;
        double squareSide = Math.Sqrt(squareArea);
        double circleRadius = Math.Sqrt(circleArea / Math.PI);
        bool fitsCircleInSquare = circleRadius * 2 <= squareSide;
        bool fitsSquareInCircle = squareSide <= 2 * circleRadius;
        Console.WriteLine($"Задание 2: Круг уместится в квадрате? {fitsCircleInSquare}");
        Console.WriteLine($"Задание 2: Квадрат уместится в круге? {fitsSquareInCircle}");

        // Задание 3
        Console.Write("Задание 3: Введите число: ");
        double number = double.Parse(Console.ReadLine());
        Console.WriteLine($"Число в интервале (-5, 3)? {number > -5 && number < 3}");

        // Задание 4
        int number3Digits = 437;
        int firstDigit = number3Digits / 100;
        int secondDigit = (number3Digits / 10) % 10;
        int thirdDigit = number3Digits % 10;
        Console.WriteLine($"Задание 4a: {firstDigit > thirdDigit}");
        Console.WriteLine($"Задание 4b: {firstDigit > secondDigit}");
        Console.WriteLine($"Задание 4c: {secondDigit > thirdDigit}");

        // Задание 5
        double a = 3, b = 4, c = 5, x = 4, y = 6;
        bool canFit = (a <= x && b <= y) || (a <= y && b <= x) || 
                      (a <= x && c <= y) || (a <= y && c <= x) || 
                      (b <= x && c <= y) || (b <= y && c <= x);
        Console.WriteLine($"Задание 5: Кирпич пройдет через отверстие? {canFit}");
    }
}
