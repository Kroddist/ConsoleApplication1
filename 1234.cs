using System;

class Program
{
    static void Main()
    {
        // Задача 1
        int twoDigitNumber = 47;
        int digit1 = twoDigitNumber / 10;
        int digit2 = twoDigitNumber % 10;
        Console.WriteLine($"Задача 1а: {digit1 == 4 || digit1 == 7 || digit2 == 4 || digit2 == 7}");
        Console.WriteLine($"Задача 1б: {digit1 == 3 || digit1 == 6 || digit1 == 9 || digit2 == 3 || digit2 == 6 || digit2 == 9}");

        // Задача 2
        int n = 3363;
        string nStr = n.ToString();
        bool hasThreeSameDigits = nStr.GroupBy(c => c).Any(g => g.Count() == 3);
        Console.WriteLine($"Задача 2: {hasThreeSameDigits}");

        // Задача 3
        double[] numbers = { -2.5, 4.5, -3.0, 5.6 };
        int negativeCount = numbers.Count(x => x < 0);
        Console.WriteLine($"Задача 3: Количество отрицательных чисел = {negativeCount}");

        // Задача 4
        double a = 1, b = -3, c = 2;
        double discriminant = b * b - 4 * a * c;
        if (discriminant >= 0)
        {
            double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            Console.WriteLine($"Задача 4: Корни уравнения: {root1}, {root2}");
        }
        else
        {
            Console.WriteLine("Задача 4: Вещественных корней нет");
        }

        // Задача 5
        double[] triple1 = { 3.2, 4.5, 1.7 };
        double[] triple2 = { 5.6, 2.8, 3.9 };
        double median1 = GetMedian(triple1);
        double median2 = GetMedian(triple2);
        double average = (median1 + median2) / 2;
        Console.WriteLine($"Задача 5: Среднее арифметическое средних чисел = {average}");

        // Задача 6 (switch)
        Console.Write("Задача 6: Введите номер дня недели (1-7): ");
        int dayOfWeek = int.Parse(Console.ReadLine());
        switch (dayOfWeek)
        {
            case 1: Console.WriteLine("Понедельник"); break;
            case 2: Console.WriteLine("Вторник"); break;
            case 3: Console.WriteLine("Среда"); break;
            case 4: Console.WriteLine("Четверг"); break;
            case 5: Console.WriteLine("Пятница"); break;
            case 6: Console.WriteLine("Суббота"); break;
            case 7: Console.WriteLine("Воскресенье"); break;
            default: Console.WriteLine("Некорректный номер дня недели"); break;
        }

        // Задача 7 (switch)
        Console.Write("Задача 7: Введите номер месяца (1-12): ");
        int month = int.Parse(Console.ReadLine());
        switch (month)
        {
            case 12: case 1: case 2: Console.WriteLine("Зима"); break;
            case 3: case 4: case 5: Console.WriteLine("Весна"); break;
            case 6: case 7: case 8: Console.WriteLine("Лето"); break;
            case 9: case 10: case 11: Console.WriteLine("Осень"); break;
            default: Console.WriteLine("Некорректный номер месяца"); break;
        }

        // Задача 8
        int birthYear = 1990, birthMonth = 5, birthDay = 15;
        int currentYear = 2025, currentMonth = 2, currentDay = 28;
        int age = currentYear - birthYear;
        if (currentMonth < birthMonth || (currentMonth == birthMonth && currentDay < birthDay))
        {
            age--;
        }
        Console.WriteLine($"Задача 8: Возраст: {age} лет");

        // Задача 9a
        Console.WriteLine("Задача 9a: Все целые числа от 20 до 35:");
        for (int i = 20; i <= 35; i++)
        {
            Console.WriteLine(i);
        }

        // Задача 9b
        Console.Write("Задача 9b: Введите значение b (b > 10): ");
        int bValue = int.Parse(Console.ReadLine());
        Console.WriteLine("Квадраты всех целых чисел от 10 до b:");
        for (int i = 10; i <= bValue; i++)
        {
            Console.WriteLine(i * i);
        }

        // Задача 9c
        Console.Write("Задача 9c: Введите значение a (a < 50): ");
        int aValue = int.Parse(Console.ReadLine());
        Console.WriteLine("Третьи степени всех целых чисел от a до 50:");
        for (int i = aValue; i <= 50; i++)
        {
            Console.WriteLine(Math.Pow(i, 3));
        }

        // Задача 9d
        Console.Write("Задача 9d: Введите значение a: ");
        int aRange = int.Parse(Console.ReadLine());
        Console.Write("Введите значение b: ");
        int bRange = int.Parse(Console.ReadLine());
        Console.WriteLine("Все целые числа от a до b:");
        for (int i = aRange; i >= bRange; i--)
        {
            Console.WriteLine(i);
        }

        // Задача 10
        double radius = 6370;
        Console.WriteLine("Задача 10: Расстояние до линии горизонта для высоты от 1 до 10 км:");
        for (int h = 1; h <= 10; h++)
        {
            double distance = Math.Sqrt(2 * radius * h + h * h);
            Console.WriteLine($"Для высоты {h} км: {distance} км");
        }
    }

    static double GetMedian(double[] numbers)
    {
        Array.Sort(numbers);
        return numbers[1]; // Среднее число в отсортированной тройке
    }
}
