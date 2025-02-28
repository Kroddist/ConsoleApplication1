using System;

class Program
{
    static void Main()
    {
        // Задача 1
        double x = 2, y = 3;
        if (x > 0 && y > 0) Console.WriteLine("Задача 1: Первая четверть");
        else if (x < 0 && y > 0) Console.WriteLine("Задача 1: Вторая четверть");
        else if (x < 0 && y < 0) Console.WriteLine("Задача 1: Третья четверть");
        else if (x > 0 && y < 0) Console.WriteLine("Задача 1: Четвертая четверть");

        // Задача 2
        int sixDigitNumber = 123321;
        string numberStr = sixDigitNumber.ToString();
        int sumFirstThree = numberStr[0] - '0' + numberStr[1] - '0' + numberStr[2] - '0';
        int sumLastThree = numberStr[3] - '0' + numberStr[4] - '0' + numberStr[5] - '0';
        Console.WriteLine($"Задача 2: Счастливое число? {sumFirstThree == sumLastThree}");

        // Задача 3a
        int k = 15;
        int dayOfWeek = k % 7; // 1 - понедельник, 2 - вторник, ..., 7 - воскресенье
        switch (dayOfWeek)
        {
            case 1: Console.WriteLine("Задача 3a: Понедельник"); break;
            case 2: Console.WriteLine("Задача 3a: Вторник"); break;
            case 3: Console.WriteLine("Задача 3a: Среда"); break;
            case 4: Console.WriteLine("Задача 3a: Четверг"); break;
            case 5: Console.WriteLine("Задача 3a: Пятница"); break;
            case 6: Console.WriteLine("Задача 3a: Суббота"); break;
            case 7: Console.WriteLine("Задача 3a: Воскресенье"); break;
        }

        // Задача 3b
        int d = 3; // если 1 января - это d-й день недели
        dayOfWeek = (k + d - 1) % 7;
        switch (dayOfWeek)
        {
            case 1: Console.WriteLine("Задача 3b: Понедельник"); break;
            case 2: Console.WriteLine("Задача 3b: Вторник"); break;
            case 3: Console.WriteLine("Задача 3b: Среда"); break;
            case 4: Console.WriteLine("Задача 3b: Четверг"); break;
            case 5: Console.WriteLine("Задача 3b: Пятница"); break;
            case 6: Console.WriteLine("Задача 3b: Суббота"); break;
            case 7: Console.WriteLine("Задача 3b: Воскресенье"); break;
        }

        // Задача 4a
        int m = 3, n = 5;
        int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        if (n > 1)
            Console.WriteLine($"Задача 4a: Дата предыдущего дня: {m}/{n-1}");
        else
            Console.WriteLine($"Задача 4a: Дата предыдущего дня: {m-1}/{daysInMonth[m-2]}");

        // Задача 4b
        if (n < daysInMonth[m-1])
            Console.WriteLine($"Задача 4b: Дата следующего дня: {m}/{n+1}");
        else
            Console.WriteLine($"Задача 4b: Дата следующего дня: {m+1}/{1}");

        // Задача 5
        double a = 3, b = 4, c = 5;
        bool isTriangle = a + b > c && a + c > b && b + c > a;
        Console.WriteLine($"Задача 5: Существует ли треугольник? {isTriangle}");

        // Задача 6
        bool isRightTriangle = isTriangle && (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2) ||
                                              Math.Pow(a, 2) + Math.Pow(c, 2) == Math.Pow(b, 2) ||
                                              Math.Pow(b, 2) + Math.Pow(c, 2) == Math.Pow(a, 2));
        Console.WriteLine($"Задача 6: Прямоугольный треугольник? {isRightTriangle}");

        // Задача 7
        Console.Write("Задача 7: Введите стоимость 1 кг сыра: ");
        double pricePerKg = double.Parse(Console.ReadLine());
        for (int i = 50; i <= 1000; i += 50)
        {
            double cost = pricePerKg * i / 1000;
            Console.WriteLine($"Цена {i} г сыра: {cost} руб.");
        }

        // Задача 8
        Console.WriteLine("Задача 8:");
        for (int i = 1; i <= 8; i++)
        {
            Console.WriteLine($"2,{i}");
        }

        // Задача 9a
        int sum = 0;
        for (int i = 100; i <= 500; i++)
        {
            sum += i;
        }
        Console.WriteLine($"Задача 9a: Сумма чисел от 100 до 500: {sum}");

        // Задача 9b
        Console.Write("Задача 9b: Введите значение a (a < 500): ");
        int aInput = int.Parse(Console.ReadLine());
        sum = 0;
        for (int i = aInput; i <= 500; i++)
        {
            sum += i;
        }
        Console.WriteLine($"Сумма чисел от {aInput} до 500: {sum}");

        // Задача 9c
        Console.Write("Задача 9c: Введите значение b (b > -10): ");
        int bInput = int.Parse(Console.ReadLine());
        sum = 0;
        for (int i = -10; i <= bInput; i++)
        {
            sum += i;
        }
        Console.WriteLine($"Сумма чисел от -10 до {bInput}: {sum}");

        // Задача 9d
        Console.Write("Задача 9d: Введите значение a: ");
        int aRange = int.Parse(Console.ReadLine());
        Console.Write("Введите значение b: ");
        int bRange = int.Parse(Console.ReadLine());
        sum = 0;
        for (int i = aRange; i <= bRange; i++)
        {
            sum += i;
        }
        Console.WriteLine($"Сумма чисел от {aRange} до {bRange}: {sum}");

        // Задача 10a
        int product = 1;
        for (int i = 8; i <= 15; i++)
        {
            product *= i;
        }
        Console.WriteLine($"Задача 10a: Произведение чисел от 8 до 15: {product}");

        // Задача 10b
        Console.Write("Задача 10b: Введите значение a (1 <= a <= 20): ");
        int aStart = int.Parse(Console.ReadLine());
        product = 1;
        for (int i = aStart; i <= 20; i++)
        {
            product *= i;
        }
        Console.WriteLine($"Произведение чисел от {aStart} до 20: {product}");

        // Задача 10c
        Console.Write("Задача 10c: Введите значение b (1 <= b <= 20): ");
        int bEnd = int.Parse(Console.ReadLine());
        product = 1;
        for (int i = 1; i <= bEnd; i++)
        {
            product *= i;
        }
        Console.WriteLine($"Произведение чисел от 1 до {bEnd}: {product}");

        // Задача 10d
        Console.Write("Задача 10d: Введите значение a: ");
        int aStart2 = int.Parse(Console.ReadLine());
        Console.Write("Введите значение b: ");
        int bEnd2 = int.Parse(Console.ReadLine());
        product = 1;
        for (int i = aStart2; i <= bEnd2; i++)
        {
            product *= i;
        }
        Console.WriteLine($"Произведение чисел от {aStart2} до {bEnd2}: {product}");
    }
}
